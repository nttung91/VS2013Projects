using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace VRR7780_Prototype
{
    public partial class Form1 : Form
    {
        private List<Item> Items = new List<Item>();

        public Form1()
        {
            InitializeComponent();
            ReadData();
        }

        private void ReadData()
        {
            using (var sr = new StreamReader("data.txt"))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    var strs = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    var item = new Item();
                    item.Wargr = strs[0];
                    item.WargrDescr = strs[1];
                    item.Rayon = strs[2];
                    item.RayonDescr = strs[3];
                    item.Kategorie = strs[4];
                    for (int i = 5; i < strs.Length - 12; i++)
                    {
                        item.KatDescr = i == strs.Length - 11 || i == 5 ? strs[i] : strs[i] + ",";
                    }
                    item.SumJan = strs[strs.Length - 12] != "null" ? Convert.ToDouble(strs[strs.Length - 12]) : (double?)null;
                    item.SumFeb = strs[strs.Length - 11] != "null" ? Convert.ToDouble(strs[strs.Length - 11]) : (double?)null;
                    item.SumMar = strs[strs.Length - 10] != "null" ? Convert.ToDouble(strs[strs.Length - 10]) : (double?)null;
                    item.SumApr = strs[strs.Length - 9] != "null" ? Convert.ToDouble(strs[strs.Length - 9]) : (double?)null;
                    item.SumMay = strs[strs.Length - 8] != "null" ? Convert.ToDouble(strs[strs.Length - 8]) : (double?)null;
                    item.SumJun = strs[strs.Length - 7] != "null" ? Convert.ToDouble(strs[strs.Length - 7]) : (double?)null;
                    item.SumJul = strs[strs.Length - 6] != "null" ? Convert.ToDouble(strs[strs.Length - 6]) : (double?)null;
                    item.SumAug = strs[strs.Length - 5] != "null" ? Convert.ToDouble(strs[strs.Length - 5]) : (double?)null;
                    item.SumSep = strs[strs.Length - 4] != "null" ? Convert.ToDouble(strs[strs.Length - 4]) : (double?)null;
                    item.SumOct = strs[strs.Length - 3] != "null" ? Convert.ToDouble(strs[strs.Length - 3]) : (double?)null;
                    item.SumNov = strs[strs.Length - 2] != "null" ? Convert.ToDouble(strs[strs.Length - 2]) : (double?)null;
                    item.SumDec = strs[strs.Length - 1] != "null" ? Convert.ToDouble(strs[strs.Length - 1]) : (double?)null;
                    Items.Add(item);
                }
            }
            //MessageBox.Show(Items.Count.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Items = PreProcessData(Items);
            bindingSource1.DataSource = Items;
        }

        private List<Item> PreProcessData(List<Item> items)
        {
            var wargs = items.GroupBy(x => x.Wargr).Select(g => new Item()
            {
                Kategorie = g.Key,
                KatDescr = g.First().WargrDescr,
                ParentId = Convert.ToInt32(g.First().Rayon),
                SumJan = g.Any(x => x.SumJan.HasValue) ? g.Sum(x => x.SumJan) : null,
                SumFeb = g.Any(x => x.SumFeb.HasValue) ? g.Sum(x => x.SumFeb) : null,
                SumMar = g.Any(x => x.SumMar.HasValue) ? g.Sum(x => x.SumMar) : null,
                SumApr = g.Any(x => x.SumApr.HasValue) ? g.Sum(x => x.SumApr) : null,
                SumMay = g.Any(x => x.SumMay.HasValue) ? g.Sum(x => x.SumMay) : null,
                SumJun = g.Any(x => x.SumJun.HasValue) ? g.Sum(x => x.SumJun) : null,
                SumJul = g.Any(x => x.SumJul.HasValue) ? g.Sum(x => x.SumJul) : null,
                SumAug = g.Any(x => x.SumAug.HasValue) ? g.Sum(x => x.SumAug) : null,
                SumSep = g.Any(x => x.SumSep.HasValue) ? g.Sum(x => x.SumSep) : null,
                SumOct = g.Any(x => x.SumOct.HasValue) ? g.Sum(x => x.SumOct) : null,
                SumNov = g.Any(x => x.SumNov.HasValue) ? g.Sum(x => x.SumNov) : null,
                SumDec = g.Any(x => x.SumDec.HasValue) ? g.Sum(x => x.SumDec) : null
            }).ToList();

            var rayons = items.GroupBy(x => x.Rayon).Select(g => new Item()
            {
                Kategorie = g.Key,
                KatDescr = g.First().RayonDescr,
                SumJan = g.Any(x => x.SumJan.HasValue) ? g.Sum(x => x.SumJan) : null,
                SumFeb = g.Any(x => x.SumFeb.HasValue) ? g.Sum(x => x.SumFeb) : null,
                SumMar = g.Any(x => x.SumMar.HasValue) ? g.Sum(x => x.SumMar) : null,
                SumApr = g.Any(x => x.SumApr.HasValue) ? g.Sum(x => x.SumApr) : null,
                SumMay = g.Any(x => x.SumMay.HasValue) ? g.Sum(x => x.SumMay) : null,
                SumJun = g.Any(x => x.SumJun.HasValue) ? g.Sum(x => x.SumJun) : null,
                SumJul = g.Any(x => x.SumJul.HasValue) ? g.Sum(x => x.SumJul) : null,
                SumAug = g.Any(x => x.SumAug.HasValue) ? g.Sum(x => x.SumAug) : null,
                SumSep = g.Any(x => x.SumSep.HasValue) ? g.Sum(x => x.SumSep) : null,
                SumOct = g.Any(x => x.SumOct.HasValue) ? g.Sum(x => x.SumOct) : null,
                SumNov = g.Any(x => x.SumNov.HasValue) ? g.Sum(x => x.SumNov) : null,
                SumDec = g.Any(x => x.SumDec.HasValue) ? g.Sum(x => x.SumDec) : null
            }).ToList();

            foreach (var item in items)
            {
                item.ParentId = Convert.ToInt32(item.Wargr);
            }

            items.AddRange(wargs);
            items.AddRange(rayons);

            var nulld = wargs.Where(x => x.Kategorie == "110").ToList();
            return items;
        }
    }
}