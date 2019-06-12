using System;

namespace GoodsClasses
{
    abstract class Food : Goods
    {
        protected DateTime shelfLife;

        public DateTime ShelfLife {
            get {
                return shelfLife;
            }
        }

        public Food(DateTime shelfLife, string name, int price)
          : base(name, price) {            
            this.shelfLife = shelfLife;            
        }

        public override string GetInfo() {            
            return base.GetInfo() + ";\n Shelf Life: " + shelfLife.ToString("MM/dd/yyyy");
        }
    }
}
