using System.Collections.Generic;

namespace Sort
{
    public interface ISort
    {
        List<object> Sort(List<object> objList, string sortPropertyName);
    }
}
