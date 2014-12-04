using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            treeListLookUpEdit2.Properties.DataSource = typeof(string);
            treeListLookUpEdit2.EditValue = "NTG";
        }

        private LambdaExpression CreateExpression<TBo>(Expression<Func<TBo, object>> boLambdaExpression)
        {
            return boLambdaExpression;
        }

        private static List<string> GetManyToOnePropertyNames(LambdaExpression dbLambdaExpression, Type dbEntityType)
        {
            var manyToOnePropertyNames = new List<string>();
            MemberExpression memberExpression = GetMemberExpression(dbLambdaExpression);
            while (memberExpression != null && memberExpression.Expression.Type != dbEntityType)
            {
                if (memberExpression.Expression.NodeType == ExpressionType.Call)
                {
                    var methodCallExpression = memberExpression.Expression as MethodCallExpression;
                    if (methodCallExpression == null) break;
                    memberExpression = methodCallExpression.Object as MemberExpression;
                }
                else
                {
                    memberExpression = memberExpression.Expression as MemberExpression;
                }

                if (memberExpression == null)
                {
                    break;
                }
                string manyToOnePropertyName = memberExpression.Member.Name;
                manyToOnePropertyNames.Add(manyToOnePropertyName);
            }
            manyToOnePropertyNames.Reverse();
            return manyToOnePropertyNames;
        }

        // From CSLA:
        private static MemberExpression GetMemberExpression(LambdaExpression memberLambdaExpression)
        {
            if (memberLambdaExpression == null) throw new ArgumentNullException("memberLambdaExpression");

            MemberExpression memberExpr = null;

            // The Func<TTarget, object> we use returns an object, so first statement can be either 
            // a cast (if the field/property does not return an object) or the direct member access.
            if (memberLambdaExpression.Body.NodeType == ExpressionType.Convert)
            {
                // The cast is an unary expression, where the operand is the 
                // actual member access expression.
                memberExpr = ((UnaryExpression)memberLambdaExpression.Body).Operand as MemberExpression;
            }
            else if (memberLambdaExpression.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = memberLambdaExpression.Body as MemberExpression;
            }

            if (memberExpr == null) throw new ArgumentException(string.Format("Not a member access"), "memberLambdaExpression");
            return memberExpr;
        }

        private void treeListLookUpEdit2_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button == treeListLookUpEdit2.Properties.Buttons[1])
            {
                treeListLookUpEdit2.EditValue = null;
            }
        }
    }
}
