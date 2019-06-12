using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Tools
{
    class ObjEnumerator {
        private object[] objects = new object[0];

        public void Add(object obj){
            Array.Resize(ref objects, objects.Length + 1);
            objects[objects.Length - 1] = obj;
        }

        public object[] Get {
            get {
                return objects;
            }
        }

        public int Length {
            get {
                return objects.Length;
            }
        }

        public IEnumerator GetEnumerator() {
            for (int i = 0; i < objects.Length; i++) {
                yield return objects[i];
            }
        }
    }
}
