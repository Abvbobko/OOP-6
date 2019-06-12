using System;

namespace GoodsClasses
{
    [Serializable]
    class Lollipop : Sweet
    {

        private const string type = "Lollipop";

        public Lollipop(DateTime shelfLife, string name, int price) 
           : base(shelfLife, name, price) {}

        public override string GetInfo() {
            return "Type: " + type + ";\n " + base.GetInfo();
        }

    }
}
