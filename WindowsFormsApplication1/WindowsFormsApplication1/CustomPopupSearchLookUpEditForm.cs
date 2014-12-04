using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Popup;

namespace WindowsFormsApplication1
{
    /// <summary>
    /// https://www.devexpress.com/Support/Center/Example/Details/E3135
    /// </summary>
    public class CustomPopupSearchLookUpEditForm : TreeListLookUpEditPopupForm
    {
        public CustomPopupSearchLookUpEditForm(TreeListLookUpEdit edit)
            : base(edit)
        {
        }

        protected override void CreateButtons()
        {
            base.CreateButtons();
        }
    }
}