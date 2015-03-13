using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.VisualStyles;
using DevExpress.XtraPrinting;

namespace MasterDetailPrototype
{
    public class Student
    {
        public Bag Bag { get; set; }
        public IList<Book> Books { get; set; }
    }
}
