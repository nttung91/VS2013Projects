using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraPrinting.Native;
using Elca.Tools.ManorChangeScriptRunner.Framework;
using Elca.Tools.ManorChangeScriptRunner.Properties;

namespace Elca.Tools.ManorChangeScriptRunner
{
    public partial class FrmMain : XtraForm
    {
        private DataLoader _loader;
        private ScriptHandler _handler;
        private OracleHelper _helper;

        private BindingList<ScriptItem> _source;

        private Color _memoBg;
        private Color _memoBgError = Color.Tomato;

        public FrmMain()
        {
            InitializeComponent();
            _memoBg = memoOutput.BackColor;

            InitializeHelpers();
            LoadSettings();
            LoadOracleHomes();

            LoadScriptsToExecute();
        }

        private void InitializeHelpers()
        {
            _loader = new DataLoader();
            _handler = new ScriptHandler();
            _helper = new OracleHelper();
        }

        private void LoadScriptsToExecute(string path = null)
        {
            gridTodoScripts.DataSource = null;
            if (!layoutControlSettings.ValidateChildren())
            {
                MessageBox.Show(Messages.InvalidSettings);
                return;
            }

            if (string.IsNullOrEmpty(path))
            {
                path = (string)editScriptsFromManorDir.EditValue;
            }
            var scripts = _loader.GetScriptsToExecute(path);
            scripts = scripts.OrderBy(p => p.DateTime).ThenBy(p => p.Database).ThenBy(p => p.Name);
            _source = new BindingList<ScriptItem>(scripts.ToList());

            // Mark later repeated items
            var tmpList = new List<string>();
            var now = DateTime.Now;
            var middleOfCurrentMonth = new DateTime(now.Year, now.Month, 16);

            DateTime scriptsBeforeDateAreFinished;

            if (now >= middleOfCurrentMonth)  // We are in the 2nd half of the current month, e.g. now = 19.1.14
            {
                scriptsBeforeDateAreFinished = middleOfCurrentMonth; // 16.1.14
            }
            else  // We are in the 1st half of the current month, e.g. now = 5.2.14
            {
                // Get the 1st day of the current month
                scriptsBeforeDateAreFinished = new DateTime(now.Year, now.Month, 1); // 1.2.14
            }

            // Newest scripts first
            foreach (var scriptItem in _source.Reverse().ToList())
            {
                if (tmpList.Contains(scriptItem.Name + scriptItem.Database, StringComparer.OrdinalIgnoreCase))
                {
                    // We found an old version of a script we already found (which has newer) --> skip the old
                    _source.Remove(scriptItem);
                    _handler.Execute(scriptItem, DirectoryParameters, ScriptExecutionType.Skip);
                }
                else if (scriptItem.DateTime < scriptsBeforeDateAreFinished)
                {
                    // The script is "finished", we ignore scripts which are not ready yet
                    tmpList.Add(scriptItem.Name + scriptItem.Database);
                }
            }

            gridTodoScripts.DataSource = _source;
        }

        private void gridViewMain_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (gridViewMain.IsGroupRow(e.RowHandle))
                return;

            var row = gridViewMain.GetRow(e.RowHandle) as ScriptItem;
            if (row != null)
            {
                if (gridViewMain.FocusedRowHandle == e.RowHandle)
                {
                    e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                }

                if (row.HasNewerLater)
                {
                    e.Appearance.BackColor = Color.LightGray;
                }

                var now = DateTime.Now;
                var middleOfCurrentMonth = new DateTime(now.Year, now.Month, 16);

                DateTime tooOldScriptDate; // Scripts < this date are overdue --> colored orange
                DateTime scriptMustBeBefore; // Scripts < this date and >= tooOldScriptDate are the ones to execute --> colored green

                if (now >= middleOfCurrentMonth) // e.g. now = 19.1.14
                {
                    tooOldScriptDate = new DateTime(now.Year, now.Month, 1); // 1.1.14
                    scriptMustBeBefore = middleOfCurrentMonth; // 16.1.14
                }
                else // e.g. now = 5.2.14
                {
                    tooOldScriptDate = new DateTime(now.Year, now.Month, 16).AddMonths(-1); // 16.1.14
                    scriptMustBeBefore = new DateTime(now.Year, now.Month, 1); // 1.2.14
                }

                if (row.DateTime < scriptMustBeBefore && row.DateTime >= tooOldScriptDate)
                {
                    e.Appearance.ForeColor = Color.Green;
                }
                else if (row.DateTime >= scriptMustBeBefore)
                {
                    e.Appearance.ForeColor = Color.Gray;
                }
                else if (row.DateTime < tooOldScriptDate)
                {
                    e.Appearance.ForeColor = Color.Orange;
                }
            }

        }

        private DirectoryParameters DirectoryParameters
        {
            get
            {
                return new DirectoryParameters((string)editOracleHome.EditValue, (string)editTnsProdu.EditValue,
                                               (string)editTnsFis.EditValue, (string)editTnsHaus.EditValue,
                                               (string)editTnsMai.EditValue,
                                               (string)editSqlPath.EditValue,
                                               (string)editExecutedPath.EditValue,
                                               (string)editCopyVNPath.EditValue);
            }
        }

        private void LoadSettings()
        {
            editOracleHome.EditValue = Settings.Default.OracleHome;
            editTnsProdu.EditValue = Settings.Default.TNSProdu;
            editTnsFis.EditValue = Settings.Default.TNSFis;
            editTnsHaus.EditValue = Settings.Default.TNSHaus;
            editTnsMai.EditValue = Settings.Default.TNSMai;
            editSqlPath.EditValue = Settings.Default.SqlPath;
            editScriptsFromManorDir.EditValue = Settings.Default.ScriptsFromManor;
            editExecutedPath.EditValue = Settings.Default.ExecutedScripts;
            editCopyVNPath.EditValue = Settings.Default.ScriptsForVN;

        }

        private void LoadOracleHomes()
        {
            try
            {
                var homes = _helper.GetOracleHomes();
                homes.ForEach(p => editOracleHome.Properties.Items.Add(p));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Messages.OracleHomes, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadOracleTns();
        }

        private void LoadOracleTns()
        {
            if (!string.IsNullOrEmpty((string)editOracleHome.EditValue))
            {
                try
                {
                    var tnsList = _helper.LoadTNSNames((string)editOracleHome.EditValue);
                    editTnsProdu.Properties.Items.Clear();
                    editTnsFis.Properties.Items.Clear();
                    editTnsHaus.Properties.Items.Clear();
                    editTnsMai.Properties.Items.Clear();
                    tnsList.ForEach(p => editTnsProdu.Properties.Items.Add(p));
                    tnsList.ForEach(p => editTnsFis.Properties.Items.Add(p));
                    tnsList.ForEach(p => editTnsHaus.Properties.Items.Add(p));
                    tnsList.ForEach(p => editTnsMai.Properties.Items.Add(p));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, Messages.OracleTns, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var buttonEdit = (ButtonEdit)sender;
            var folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                buttonEdit.EditValue = folderBrowserDialog1.SelectedPath;
            }
        }


        private bool ValidatePath(BaseEdit editor)
        {
            var path = (string)editor.EditValue;
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
            {
                return false;
            }
            return true;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            Settings.Default.OracleHome = (string)editOracleHome.EditValue;
            Settings.Default.TNSProdu = (string)editTnsProdu.EditValue;
            Settings.Default.TNSFis = (string)editTnsFis.EditValue;
            Settings.Default.TNSHaus = (string)editTnsHaus.EditValue;
            Settings.Default.TNSMai = (string)editTnsMai.EditValue;
            Settings.Default.SqlPath = (string)editSqlPath.EditValue;
            Settings.Default.ScriptsFromManor = (string)editScriptsFromManorDir.EditValue;
            Settings.Default.ExecutedScripts = (string)editExecutedPath.EditValue;
            Settings.Default.ScriptsForVN = (string)editCopyVNPath.EditValue;


            Settings.Default.Save();
        }

        private void editSettingsField_Validating(object sender, CancelEventArgs e)
        {
            if (!ValidatePath((BaseEdit)sender))
            {
                e.Cancel = true;
            }
        }
        private void editTns_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace((string)((ComboBoxEdit)sender).EditValue))
            {
                e.Cancel = true;
            }
        }

        private void editTnsMai_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace((string)editTnsMai.EditValue))
            {
                e.Cancel = true;
            }
        }

        private void editOracleHome_Validated(object sender, EventArgs e)
        {
            LoadOracleTns();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            LoadScriptsToExecute();
            Cursor.Current = Cursors.Default;
        }

        private ScriptItem CurrentScriptItem
        {
            get
            {
                if (gridViewMain.IsDataRow(gridViewMain.FocusedRowHandle))
                {
                    return gridViewMain.GetRow(gridViewMain.FocusedRowHandle) as ScriptItem;
                }
                return null;
            }
        }

        private void btnExecuteSelectedScript_Click(object sender, EventArgs e)
        {
            if (chkOnlyExecute.Checked)
            {
                ProcessCurrentScript(ScriptExecutionType.ExecuteOnly);
            }
            else
            {
                ProcessCurrentScript(ScriptExecutionType.ExecuteAndMove);
            }
        }

        private void btnMoveSelectedScript_Click(object sender, EventArgs e)
        {
            ProcessCurrentScript(ScriptExecutionType.Move);
        }

        private void ProcessCurrentScript(ScriptExecutionType type)
        {
            if (CurrentScriptItem != null)
            {
                tabbedControlGroupOutputPreview.SelectedTabPage = layoutControlGroupOutput;

                var item = CurrentScriptItem;
                var result = _handler.Execute(item, DirectoryParameters, type);

                memoOutput.EditValue = result.Output;
                memoActions.Text += string.Format("{0}: {1}", item.FullPath, result.Log) + Environment.NewLine;

                if (result.Log == ScriptResult.Error)
                {
                    memoOutput.BackColor = _memoBgError;
                }
                else if (type != ScriptExecutionType.ExecuteOnly)
                {
                    memoOutput.BackColor = _memoBg;
                    _source.Remove(item);
                    // gridViewMain.RefreshData();
                }
                LoadNewlySelectedRow();
            }
        }

        private void btnSkipSelectedScript_Click(object sender, EventArgs e)
        {
            ProcessCurrentScript(ScriptExecutionType.Skip);
        }

        private void memoOutput_TextChanged(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(() => SetSelection((MemoEdit)sender)));
        }

        private void memoActions_TextChanged(object sender, EventArgs e)
        {
            BeginInvoke(new MethodInvoker(() => SetSelection((MemoEdit)sender)));
        }
        private void SetSelection(MemoEdit control)
        {
            control.SelectionStart = control.Text.Length;
            control.ScrollToCaret();
        }

        private void gridViewMain_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadNewlySelectedRow();
        }

        private void LoadNewlySelectedRow()
        {
            if (CurrentScriptItem == null)
            {
                layoutControlGroupPreview.Text = Messages.PreviewSql;
                memoPreview.Text = string.Empty;
            }
            else
            {
                layoutControlGroupPreview.Visibility = LayoutVisibility.Always;
                layoutControlGroupPreview.Text = Messages.PreviewSqlFile + CurrentScriptItem.Name;
                var text = File.ReadAllText(CurrentScriptItem.FullPath, Encoding.Default);
                if (!text.Contains(Environment.NewLine))
                {
                    text = text.Replace("\n", Environment.NewLine);
                }
                memoPreview.Text = text;
            }
        }


    }
}