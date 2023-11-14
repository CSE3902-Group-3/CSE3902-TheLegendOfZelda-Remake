using System;

namespace LegendOfZelda
{
    public class MapElement
    {
        public string ElementType { get; set; }
        public int ElementValue { get; set; }
        public int XLocation { get; set; }
        public int YLocation { get; set; }
        public string ItemDrop { get; set; } = null;
    }
}
