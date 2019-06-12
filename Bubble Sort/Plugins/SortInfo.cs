using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Plugins
{
    public class SortInfo
    {

        private bool FirstMoreOrEqInt(object arg1, object arg2) {
            if ((int)arg1 <= (int)arg2) {
                return true;
            }
            return false;
        }

        private bool FirstMoreOrEqString(object arg1, object arg2) {
            if (String.Compare(arg1.ToString(), arg2.ToString()) <= 0) {
                return true;
            }
            return false;
        }

        private bool FirstMoreOrEqDate(object arg1, object arg2) {
            if ((DateTime)arg1 <= (DateTime)arg2) {
                return true;
            }
            return false;
        }

        private bool FirstMoreOrEqDouble(object arg1, object arg2) {
            if ((double)arg1 <= (double)arg2) {
                return true;
            }
            return false;
        }

        public PropertyInfo property;
        Type propertyType;

        public delegate bool ComparisonFunction(object arg1, object arg2);
        public ComparisonFunction comparisonFunction;

        public SortInfo(PropertyInfo property, string sortPropertyName) {
            this.property = property;
            propertyType = property.PropertyType;
            switch (propertyType.Name.ToString()) {
                case "Int16":
                case "Int32":
                case "Int64":
                    comparisonFunction = FirstMoreOrEqInt;
                    break;
                case "String":
                    comparisonFunction = FirstMoreOrEqString;
                    break;
                case "DateTime":
                    comparisonFunction = FirstMoreOrEqDate;
                    break;
                case "Double":
                    comparisonFunction = FirstMoreOrEqDouble;
                    break;
                default:
                    comparisonFunction = null;
                    break;
            }

        }
    }
}
