namespace WindowsFormsApplication1
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
            this.treeListLookUpEdit1 = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.treeListLookUpEdit2 = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpEdit2TreeList = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit2TreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListLookUpEdit1
            // 
            this.treeListLookUpEdit1.Location = new System.Drawing.Point(96, 138);
            this.treeListLookUpEdit1.Name = "treeListLookUpEdit1";
            this.treeListLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.treeListLookUpEdit1.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.treeListLookUpEdit1.Size = new System.Drawing.Size(376, 20);
            this.treeListLookUpEdit1.TabIndex = 0;
            // 
            // treeListLookUpEdit1TreeList
            // 
            this.treeListLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            this.treeListLookUpEdit1TreeList.OptionsBehavior.EnableFiltering = true;
            this.treeListLookUpEdit1TreeList.OptionsSelection.MultiSelect = true;
            this.treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit1TreeList.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowAlways;
            this.treeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit1TreeList.TabIndex = 0;
            // 
            // treeListLookUpEdit2
            // 
            this.treeListLookUpEdit2.Location = new System.Drawing.Point(144, 220);
            this.treeListLookUpEdit2.Name = "treeListLookUpEdit2";
            this.treeListLookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.treeListLookUpEdit2.Properties.TreeList = this.treeListLookUpEdit2TreeList;
            this.treeListLookUpEdit2.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.treeListLookUpEdit2_Properties_ButtonClick);
            this.treeListLookUpEdit2.Size = new System.Drawing.Size(474, 20);
            this.treeListLookUpEdit2.TabIndex = 1;
            // 
            // treeListLookUpEdit2TreeList
            // 
            this.treeListLookUpEdit2TreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpEdit2TreeList.Name = "treeListLookUpEdit2TreeList";
            this.treeListLookUpEdit2TreeList.OptionsBehavior.EnableFiltering = true;
            this.treeListLookUpEdit2TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit2TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit2TreeList.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 411);
            this.Controls.Add(this.treeListLookUpEdit2);
            this.Controls.Add(this.treeListLookUpEdit1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit2TreeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TreeListLookUpEdit treeListLookUpEdit1;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private DevExpress.XtraEditors.TreeListLookUpEdit treeListLookUpEdit2;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit2TreeList;
    }
}

