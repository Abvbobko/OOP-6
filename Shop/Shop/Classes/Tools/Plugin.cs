using CipherInterface;
using Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Tools
{
    class Plugin
    {
        public static Type DownloadEnDePlugin(Assembly asm) {
            Type[] allTypes = asm.GetTypes();
            for (int i = 0; i < allTypes.Length; i++) {
                foreach (Type type in allTypes[i].GetInterfaces()) {
                    if (type.FullName == typeof(ICipher).FullName) {
                        return allTypes[i];
                    }
                
                }
            }
            return null;
        }

        public static Type DownloadSortPlugin(Assembly asm) {
            Type[] allTypes = asm.GetTypes();
            for (int i = 0; i < allTypes.Length; i++) {
                foreach (Type type in allTypes[i].GetInterfaces()) {
                    if (type.FullName == typeof(ISort).FullName) {
                        return allTypes[i];
                    }
                }
            }
            return null;
        }
    }
}
