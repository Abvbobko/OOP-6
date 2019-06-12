using System;

namespace GoodsClasses
{
    abstract class Sweet : Food
    {
        private const string type = "Sweets";

        public Sweet(DateTime shelfLife, string name, int price) 
            : base(shelfLife, name, price) {
        }

        public override string GetInfo() {
            return type + "\n " + base.GetInfo();
        }

    }
}
