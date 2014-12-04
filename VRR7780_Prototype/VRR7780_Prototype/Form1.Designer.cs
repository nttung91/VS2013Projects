namespace VRR7780_Prototype
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
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colKatDescr = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSumJan = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSumFeb = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSumMar = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSumApr = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSumMay = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSumJun = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSumJul = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSumAug = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSumSep = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSumOct = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSumNov = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSumDec = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.DisplayFormat.FormatString = "N00";
            this.repositoryItemSpinEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.colKatDescr,
            this.colSumJan,
            this.colSumFeb,
            this.colSumMar,
            this.colSumApr,
            this.colSumMay,
            this.colSumJun,
            this.colSumJul,
            this.colSumAug,
            this.colSumSep,
            this.colSumOct,
            this.colSumNov,
            this.colSumDec});
            this.treeList1.DataSource = this.bindingSource1;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.KeyFieldName = "Id";
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.ParentFieldName = "ParentId";
            this.treeList1.Size = new System.Drawing.Size(711, 365);
            this.treeList1.TabIndex = 0;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "WKL";
            this.treeListColumn1.FieldName = "Kategorie";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // colKatDescr
            // 
            this.colKatDescr.Caption = "Beschreibung";
            this.colKatDescr.FieldName = "KatDescr";
            this.colKatDescr.Name = "colKatDescr";
            this.colKatDescr.Visible = true;
            this.colKatDescr.VisibleIndex = 1;
            this.colKatDescr.Width = 53;
            // 
            // colSumJan
            // 
            this.colSumJan.Caption = "Januar";
            this.colSumJan.FieldName = "SumJan";
            this.colSumJan.Format.FormatString = "0.00";
            this.colSumJan.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSumJan.Name = "colSumJan";
            this.colSumJan.Visible = true;
            this.colSumJan.VisibleIndex = 2;
            this.colSumJan.Width = 53;
            // 
            // colSumFeb
            // 
            this.colSumFeb.Caption = "Februar";
            this.colSumFeb.FieldName = "SumFeb";
            this.colSumFeb.Format.FormatString = "0.00";
            this.colSumFeb.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSumFeb.Name = "colSumFeb";
            this.colSumFeb.Visible = true;
            this.colSumFeb.VisibleIndex = 3;
            this.colSumFeb.Width = 53;
            // 
            // colSumMar
            // 
            this.colSumMar.Caption = "März";
            this.colSumMar.FieldName = "SumMar";
            this.colSumMar.Format.FormatString = "0.00";
            this.colSumMar.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSumMar.Name = "colSumMar";
            this.colSumMar.Visible = true;
            this.colSumMar.VisibleIndex = 4;
            this.colSumMar.Width = 53;
            // 
            // colSumApr
            // 
            this.colSumApr.Caption = "April";
            this.colSumApr.FieldName = "SumApr";
            this.colSumApr.Format.FormatString = "0.00";
            this.colSumApr.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSumApr.Name = "colSumApr";
            this.colSumApr.Visible = true;
            this.colSumApr.VisibleIndex = 5;
            this.colSumApr.Width = 53;
            // 
            // colSumMay
            // 
            this.colSumMay.Caption = "Mai";
            this.colSumMay.FieldName = "SumMay";
            this.colSumMay.Format.FormatString = "0.00";
            this.colSumMay.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSumMay.Name = "colSumMay";
            this.colSumMay.Visible = true;
            this.colSumMay.VisibleIndex = 6;
            this.colSumMay.Width = 53;
            // 
            // colSumJun
            // 
            this.colSumJun.Caption = "Juni";
            this.colSumJun.FieldName = "SumJun";
            this.colSumJun.Format.FormatString = "0.00";
            this.colSumJun.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSumJun.Name = "colSumJun";
            this.colSumJun.Visible = true;
            this.colSumJun.VisibleIndex = 7;
            this.colSumJun.Width = 53;
            // 
            // colSumJul
            // 
            this.colSumJul.Caption = "Juli";
            this.colSumJul.FieldName = "SumJul";
            this.colSumJul.Format.FormatString = "0.00";
            this.colSumJul.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSumJul.Name = "colSumJul";
            this.colSumJul.Visible = true;
            this.colSumJul.VisibleIndex = 8;
            this.colSumJul.Width = 53;
            // 
            // colSumAug
            // 
            this.colSumAug.Caption = "August";
            this.colSumAug.FieldName = "SumAug";
            this.colSumAug.Format.FormatString = "0.00";
            this.colSumAug.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSumAug.Name = "colSumAug";
            this.colSumAug.Visible = true;
            this.colSumAug.VisibleIndex = 9;
            this.colSumAug.Width = 54;
            // 
            // colSumSep
            // 
            this.colSumSep.Caption = "September";
            this.colSumSep.FieldName = "SumSep";
            this.colSumSep.Format.FormatString = "0.00";
            this.colSumSep.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSumSep.Name = "colSumSep";
            this.colSumSep.Visible = true;
            this.colSumSep.VisibleIndex = 10;
            this.colSumSep.Width = 54;
            // 
            // colSumOct
            // 
            this.colSumOct.Caption = "Oktober";
            this.colSumOct.FieldName = "SumOct";
            this.colSumOct.Format.FormatString = "0.00";
            this.colSumOct.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSumOct.Name = "colSumOct";
            this.colSumOct.Visible = true;
            this.colSumOct.VisibleIndex = 11;
            this.colSumOct.Width = 54;
            // 
            // colSumNov
            // 
            this.colSumNov.Caption = "November";
            this.colSumNov.FieldName = "SumNov";
            this.colSumNov.Format.FormatString = "0.00";
            this.colSumNov.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSumNov.Name = "colSumNov";
            this.colSumNov.Visible = true;
            this.colSumNov.VisibleIndex = 12;
            this.colSumNov.Width = 54;
            // 
            // colSumDec
            // 
            this.colSumDec.Caption = "Dezember";
            this.colSumDec.FieldName = "SumDec";
            this.colSumDec.Format.FormatString = "0.00";
            this.colSumDec.Format.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colSumDec.Name = "colSumDec";
            this.colSumDec.Visible = true;
            this.colSumDec.VisibleIndex = 13;
            this.colSumDec.Width = 53;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(VRR7780_Prototype.Item);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 365);
            this.Controls.Add(this.treeList1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colKatDescr;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSumJan;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSumFeb;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSumMar;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSumApr;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSumMay;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSumJun;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSumJul;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSumAug;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSumSep;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSumOct;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSumNov;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSumDec;
        private System.Windows.Forms.BindingSource bindingSource1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;

    }
}

