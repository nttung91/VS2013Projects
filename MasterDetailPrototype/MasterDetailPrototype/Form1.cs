using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterDetailPrototype
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Class c;

        private void Form1_Load(object sender, EventArgs e)
        {
            c.Students.Add(new Student { Bag = new Bag { Name = "Cap" }, Books = new List<Book>() { new Book() { BookName = "Toan" } } });
            bindingSource1.DataSource = new List<Class> { c };
        }
    }
}
