namespace WindowsFormsApplication2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemPopupContainerEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.userControl11 = new WindowsFormsApplication2.UserControl1();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barEditItem1});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 1;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPopupContainerEdit1});
            this.barManager1.StatusBar = this.bar3;
            this.barManager1.EditorKeyDown += new System.Windows.Forms.KeyEventHandler(this.barManager1_EditorKeyDown);
            // 
            // bar1
            // 
            this.bar1.BarAppearance.Disabled.BackColor = System.Drawing.Color.Transparent;
            this.bar1.BarAppearance.Disabled.BackColor2 = System.Drawing.Color.Transparent;
            this.bar1.BarAppearance.Disabled.Options.UseBackColor = true;
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barEditItem1)});
            this.bar1.Text = "Tools";
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemPopupContainerEdit1;
            this.barEditItem1.Id = 0;
            this.barEditItem1.ItemAppearance.Disabled.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.barEditItem1.ItemAppearance.Disabled.Options.UseBackColor = true;
            this.barEditItem1.ItemAppearance.Disabled.Options.UseBorderColor = true;
            this.barEditItem1.ItemAppearance.Disabled.Options.UseFont = true;
            this.barEditItem1.ItemAppearance.Disabled.Options.UseForeColor = true;
            this.barEditItem1.ItemAppearance.Disabled.Options.UseImage = true;
            this.barEditItem1.Name = "barEditItem1";
            this.barEditItem1.Width = 261;
            this.barEditItem1.EditValueChanged += new System.EventHandler(this.barEditItem1_EditValueChanged);
            this.barEditItem1.ShownEditor += new DevExpress.XtraBars.ItemClickEventHandler(this.barEditItem1_ShownEditor);
            this.barEditItem1.ShowingEditor += new DevExpress.XtraBars.ItemCancelEventHandler(this.barEditItem1_ShowingEditor);
            this.barEditItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barEditItem1_ItemClick);
            this.barEditItem1.ItemPress += new DevExpress.XtraBars.ItemClickEventHandler(this.barEditItem1_ItemPress);
            // 
            // repositoryItemPopupContainerEdit1
            // 
            this.repositoryItemPopupContainerEdit1.AppearanceDisabled.BackColor = System.Drawing.Color.Red;
            this.repositoryItemPopupContainerEdit1.AppearanceDisabled.Options.UseBackColor = true;
            this.repositoryItemPopupContainerEdit1.AutoHeight = false;
            this.repositoryItemPopupContainerEdit1.CloseOnOuterMouseClick = false;
            this.repositoryItemPopupContainerEdit1.ContextImage = global::WindowsFormsApplication2.Properties.Resources.relationship_16;
            this.repositoryItemPopupContainerEdit1.Name = "repositoryItemPopupContainerEdit1";
            this.repositoryItemPopupContainerEdit1.PopupControl = this.popupContainerControl1;
            this.repositoryItemPopupContainerEdit1.SuppressMouseEventOnOuterMouseClick = true;
            this.repositoryItemPopupContainerEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.repositoryItemPopupContainerEdit1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.repositoryItemPopupContainerEdit1_KeyDown);
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.userControl11);
            this.popupContainerControl1.Location = new System.Drawing.Point(73, 126);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(590, 170);
            this.popupContainerControl1.TabIndex = 5;
            this.popupContainerControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.popupContainerControl1_MouseDown);
            this.popupContainerControl1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.popupContainerControl1_PreviewKeyDown);
            // 
            // userControl11
            // 
            this.userControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl11.Location = new System.Drawing.Point(0, 0);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(590, 170);
            this.userControl11.TabIndex = 0;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(663, 51);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 239);
            this.barDockControlBottom.Size = new System.Drawing.Size(663, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 51);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 188);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(663, 51);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 188);
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.Location = new System.Drawing.Point(27, 86);
            this.popupContainerEdit1.MenuManager = this.barManager1;
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.popupContainerEdit1.Size = new System.Drawing.Size(490, 20);
            this.popupContainerEdit1.TabIndex = 4;
            this.popupContainerEdit1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.popupContainerEdit1_KeyDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 262);
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.popupContainerEdit1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupContainerEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPopupContainerEdit repositoryItemPopupContainerEdit1;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        private UserControl1 userControl11;
    }
}

