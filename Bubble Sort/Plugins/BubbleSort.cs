using System;
using System.Collections.Generic;
using System.Reflection;
using Sort;

namespace Plugins
{
    public class BubbleSort : ISort
    {        
        public List<object> Sort(List<object> objList, string sortPropertyName) {
            SortInfo sortInfo = new SortInfo(objList[0].GetType().GetProperty(sortPropertyName), sortPropertyName);
            for (int i = 0; i < objList.Count - 1; i++) {               
                for (int j = 0; j < objList.Count - i - 1; j++) {
                    if (!sortInfo.comparisonFunction(sortInfo.property.GetValue(objList[j]), sortInfo.property.GetValue(objList[j + 1]))) { 
                        object tmp = objList[j];
                        objList[j] = objList[j + 1];
                        objList[j + 1] = tmp;
                    }
                }
            }
            return objList;
        }
    }
}
