using System;
using System.Collections.Generic;
using System.Text;
using UCM.Business.Student.Models;

namespace UCM.Business.SortingStrategy
{
    public class SelectionSort : SortStrategy
    {
        public override void Sort(List<StudentDetailsModel> list)
        {
            int n = list.Count;
            for (var index = 0; index < n - 1; index++)
            {
                int min = index;
                for (var index2 = index + 1; index2 < n; index2++)
                    if (list[index2].Score < list[min].Score)
                        min = index2;
                var aux = list[min];
                list[min] = list[index];
                list[index] = aux;
            }
        }
    }
}
