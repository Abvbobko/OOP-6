using System;

namespace GoodsClasses
{
    abstract class Goods {
        protected int price;
        protected string name;

        public int Price {
            get {
                return price;
            }            
        }

        public string Name {
            get {
                return name;
            }
        }

        static private int CntOfGoods = 0;

        static public int DecCntOfGoods() {
            return --CntOfGoods;
        }

        static public int GetCntOfGoods() {
            return CntOfGoods;
        }

        public Goods(string name, int price) {  
            this.name = name;
            this.price = price;
            CntOfGoods++;
        }

        public virtual string GetInfo() {
            return "Name: " + name + ";\n Price: " + price;
        }
        
    }
}
