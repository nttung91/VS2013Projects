using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;
using DevExpress.XtraEditors.Repository;

namespace WindowsFormsApplication1
{
    [ToolboxItem(false)]
    public class PagingLookupControlBase : PopupContainerEdit
    {

        protected static void InitializeClearButton()
        {
        }

        
        public PagingLookupControlBase()
        {

        }
        protected virtual object GetEditValue(object value)
        {
            throw new NotImplementedException();
        }

    }
}