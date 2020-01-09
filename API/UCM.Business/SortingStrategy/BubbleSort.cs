using System;
using System.Collections.Generic;
using System.Text;
using UCM.Business.Student.Models;

namespace UCM.Business.SortingStrategy
{
    public class BubbleSort : SortStrategy
    {
        public override void Sort(List<StudentDetailsModel> list)
        {
            for(var index=0; index<list.Count; index++)
            {
                for (var index2 = 0; index2 < list.Count - 1; index2++)
                {
                    if (list[index2].Score > list[index2 + 1].Score)
                    {
                        var aux = list[index2];
                        list[index2] = list[index2 + 1];
                        list[index2 + 1] = aux;
                    }
                }
            }
        }
    }
}
