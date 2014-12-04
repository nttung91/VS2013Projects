using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace WindowsFormsApplication1
{
    public class PagingLookupRepositoryItemBase : RepositoryItemTreeListLookUpEdit
    {
        #region Constants

        protected const int DefaultPageSize = 70;
        protected const string PagingGroup = "PagingGroup";
        protected const int DefaultMaxLoadedPageCount = 100;
        protected const int DefaultDelayOnFilterRow = 500;
        private const int MaxWidthColumnValue = 300;
        private const int BestFitMaxRowCountValue = 50;
        private const string SearchFieldControlName = "teFind";

        #endregion

        #region IFields

        #endregion

        #region IProperties

        protected bool IsFilterCriteriaChanged { get; set; }
        protected virtual string ValuePropertyName { get; set; }

        #endregion

        #region IConstructors

        #endregion

        #region IMethods

        /// <summary>
        /// Reset the change of custom criteria
        /// </summary>
        protected void SetFilterChangedValue(bool state)
        {
            IsFilterCriteriaChanged = state;
        }

        public override void Assign(RepositoryItem item)
        {
            BeginUpdate();
            try
            {
                base.Assign(item);
                var source = item as PagingLookupRepositoryItemBase;
                if (source == null) return;

                CustomAssign(source);

                if (source.OnSetDataSource != null)
                {
                    OnSetDataSource = source.OnSetDataSource;
                }
            }
            finally
            {
                EndUpdate();
            }
        }

        protected virtual void CustomAssign(PagingLookupRepositoryItemBase source)
        {
        }

        protected override void RaiseCustomDisplayText(CustomDisplayTextEventArgs e)
        {
            base.RaiseCustomDisplayText(e);
            //LookupEditDisplayTextHelper.SetCustomDisplayText(e, DisplayFormat, NullText);
        }

        //protected override void RaiseQueryPopUp(CancelEventArgs e)
        //{
        //    var currentCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;
        //        View.OptionsView.ShowAutoFilterRow = true;

        //        SetDataSource(this, EventArgs.Empty);

        //        base.RaiseQueryPopUp(e);

        //        if (string.IsNullOrEmpty(DisplayMember))
        //        {
        //            DisplayMember = ValuePropertyName;
        //        }
        //        if (string.IsNullOrEmpty(ValueMember))
        //        {
        //            ValueMember = ValuePropertyName;
        //        }

        //        if (IsFilterCriteriaChanged)
        //        {
        //            AssignAsyncDataSource();
        //        }
        //        InsertCurrentValueIfNotPresent();

        //        View.GridControl.ForceInitialize();

        //        View.Columns.Clear();

        //        foreach (var property in GetVisibleProperties().GetPropertiesVisible(true))
        //        {
        //            var gc = View.Columns.Add();
        //            // Not allow to filter in server mode.
        //            gc.OptionsFilter.AllowFilter = false;
        //            gc.FieldName = property.Key;
        //            gc.Caption = property.DisplayName;
        //            gc.MaxWidth = MaxWidthColumnValue;
        //            gc.Visible = property.Visible;
        //        }

        //        View.BestFitMaxRowCount = BestFitMaxRowCountValue;
        //        View.BestFitColumns();
        //    }
        //    finally
        //    {
        //        Cursor.Current = currentCursor;
        //    }
        //    View.Focus();
        //}


        #endregion

        public delegate void SetDataSourceHandler(object sender, EventArgs e);

        [Browsable(true)]
        public event SetDataSourceHandler OnSetDataSource;

        protected void SetDataSource(object sender, EventArgs e)
        {
            if (OnSetDataSource != null)
                OnSetDataSource(sender, e);
        }
    }
}