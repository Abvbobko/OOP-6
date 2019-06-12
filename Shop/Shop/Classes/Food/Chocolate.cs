using System;

namespace GoodsClasses
{
    [Serializable]
    class Chocolate : Sweet
    {
        private const string type = "Chocolate";

        public Chocolate(DateTime shelfLife, string name, int price) 
            : base(shelfLife, name, price) { }

        public override string GetInfo() {
            return "Type: " + type + ";\n " + base.GetInfo();
        }
    }
}
