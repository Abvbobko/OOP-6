using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop.Tools
{
    class Memento
    {
        public List<object> State { get; private set; }
        public Memento(List<object> state) {
            this.State = state;
        }
    }

    class Caretaker
    {
        public Memento Memento { get; set; }
    }

    class OriginatorList : ListBox
    {        
        public void SetMemento(Memento memento) {            
            Items.Clear();            
            foreach (object state in memento.State) {
                Items.Add(state);
            }
        }
        public Memento CreateMemento() {        
            List<object> tmp = new List<object>();            
            foreach (object item in Items) {
                tmp.Add(item);
            }
            return new Memento(tmp);
        }
    }
}
