using System;

namespace GoodsClasses
{
    [Serializable]
    class Caramel : Sweet
    {
        private const string type = "Caramel";

        public Caramel(DateTime shelfLife, string name, int price)
            : base(shelfLife, name, price) { }

        public override string GetInfo() {
            return "Type: " + type + ";\n " + base.GetInfo();
        }
    }
}
