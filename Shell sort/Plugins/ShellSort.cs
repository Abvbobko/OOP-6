using System;
using System.Collections.Generic;
using System.Reflection;
using Sort;

namespace Plugins
{
    public class ShellSort : ISort
    {
        SortInfo sortInfo;
        public List<object> Sort(List<object> objList, string sortPropertyName) {
            sortInfo = new SortInfo(objList[0].GetType().GetProperty(sortPropertyName), sortPropertyName);                  
            return shellSort(objList);
        }

        List<object> shellSort(List<object> objList) {
            int i, j, inc; 
            object temp;
            inc = 3;
            while (inc > 0) {
                for (i = 0; i < objList.Count; i++) {
                    j = i;
                    temp = objList[i];
                    while ((j >= inc) && (!sortInfo.comparisonFunction(sortInfo.property.GetValue(objList[j - inc]), 
                                                                        sortInfo.property.GetValue(temp)))) {
                        objList[j] = objList[j - inc];
                        j = j - inc;
                    }
                    objList[j] = temp;
                }
                if (inc / 2 != 0)
                    inc = inc / 2;
                else if (inc == 1)
                    inc = 0;
                else
                    inc = 1;
            }
            return objList;
        }


    }
}
