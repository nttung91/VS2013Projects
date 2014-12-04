using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;

namespace DrawHeaderCheckBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private void gridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == gridColumn1)
            {
                e.Info.InnerElements.Clear();
                Rectangle casheRect = e.Info.CaptionRect;
                Rectangle checkRect = e.Info.CaptionRect;
                checkRect.Width = 20;
                checkRect.Location = new Point(gridColumn1.Width / 2 - checkRect.Width / 2, checkRect.Location.Y);
                Rectangle rec = e.Info.CaptionRect;
                rec.Width -= 20;
                rec.X += 20;
                e.Info.CaptionRect = rec;
                e.Painter.DrawObject(e.Info);
                e.Info.CaptionRect = casheRect;
                DrawCheckEdit(e.Graphics, checkRect);
                e.Handled = true;
            }
        }


        private void DrawCheckBox(ColumnHeaderCustomDrawEventArgs e)
        {
            DrawCheckEdit(e.Graphics, e.Bounds);
        }

        private static void DrawCheckEdit(Graphics graphics, Rectangle r)
        {
            var checkEdit = new RepositoryItemCheckEdit() { Enabled = true };

            var editInfo = (CheckEditViewInfo)checkEdit.CreateViewInfo();
            var editPainter = (CheckEditPainter)checkEdit.CreatePainter();

            editInfo.Bounds = r;
            editInfo.CalcViewInfo(graphics);
            using (var cache = new GraphicsCache(graphics))
            {
                editPainter.Draw(new ControlGraphicsInfoArgs(editInfo, cache, r));
            }
        }

        private void gridView1_MouseUp(object sender, MouseEventArgs e)
        {
            var hitInfo = gridView1.CalcHitInfo(e.Location);
            if (hitInfo.InColumnPanel)
            {

            }
        }
    }
}
