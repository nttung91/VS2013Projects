using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            repositoryItemPopupContainerEdit1.EditValueChanged += repositoryItemPopupContainerEdit1_EditValueChanged;
        }

        void repositoryItemPopupContainerEdit1_EditValueChanged(object sender, EventArgs e)
        {
            (barManager1.ActiveEditor as PopupContainerEdit).ShowPopup();
            popupContainerControl1.Focus();
        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void barEditItem1_ShowingEditor(object sender, DevExpress.XtraBars.ItemCancelEventArgs e)
        {

        }

        private void PceOnKeyUp1(object sender, KeyPressEventArgs e)
        {
            // if (e.KeyChar == 'd')
            {
                MessageBox.Show("fasdfadsfadfafd");
            }
        }

        private void PceOnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            //if (keyEventArgs.KeyCode == Keys.Down)
            {
                MessageBox.Show("fasdfadsfadfafd");
            }
        }

        private void PceOnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            //if (keyEventArgs.KeyCode == Keys.Down)
            {
                MessageBox.Show("fdasf");
            }
        }

        private void barEditItem1_ItemPress(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {  //MessageBox.Show("ntg");
        }

        private void repositoryItemPopupContainerEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down)
            {
                MessageBox.Show("ntg");
            }
        }

        private void barEditItem1_ShownEditor(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barEditItem1.Edit.KeyDown += Edit_KeyDown;
            var pce = barManager1.ActiveEditor as PopupContainerEdit;
            if (pce == null) return;
            pce.KeyDown += PceOnKeyDown;
            pce.KeyUp += PceOnKeyUp;
            pce.KeyPress += PceOnKeyUp1;

        }

        void Edit_KeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            var pce = barManager1.ActiveEditor as PopupContainerEdit;
            if (pce == null) return;
            if (e.KeyCode == Keys.Down)
            {
                MessageBox.Show("work");
            }
        }

        private void barManager1_EditorKeyDown(object sender, KeyEventArgs e)
        {
            var pce = barManager1.ActiveEditor as PopupContainerEdit;
            if (pce == null) return;
            if (e.KeyCode == Keys.Down)
            {
                MessageBox.Show("work");
            }
        }

        private void popupContainerControl1_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("work");
        }

        private void popupContainerControl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            MessageBox.Show("work");
        }

        private void popupContainerEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show("work");
        }

        private void barEditItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           barEditItem1.Edit.QueryProcessKey += Edit_QueryProcessKey;
            barEditItem1.AppearanceDisabled.BackColor = barEditItem1.Appearance.BackColor;
            barEditItem1.AppearanceDisabled.BackColor2 = barEditItem1.Appearance.BackColor2;
        }

        void Edit_QueryProcessKey(object sender, DevExpress.XtraEditors.Controls.QueryProcessKeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                (barManager1.ActiveEditor as PopupContainerEdit).ShowPopup();
            }
        }
    }
}
