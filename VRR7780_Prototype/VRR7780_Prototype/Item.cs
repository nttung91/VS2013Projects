using System;

namespace VRR7780_Prototype
{
    public class Item
    {
        public int? ParentId { get; set; }
        public int Id { get { return Convert.ToInt32(Kategorie); } }
        public string Wargr { get; set; }
        public string WargrDescr { get; set; }
        public string Rayon { get; set; }
        public string RayonDescr { get; set; }
        public string Kategorie { get; set; }
        public string KatDescr { get; set; }
        public double? SumJan { get; set; }
        public double? SumFeb { get; set; }
        public double? SumMar { get; set; }
        public double? SumApr { get; set; }
        public double? SumMay { get; set; }
        public double? SumJun { get; set; }
        public double? SumJul { get; set; }
        public double? SumAug { get; set; }
        public double? SumSep { get; set; }
        public double? SumOct { get; set; }
        public double? SumNov { get; set; }
        public double? SumDec { get; set; }
    }
}