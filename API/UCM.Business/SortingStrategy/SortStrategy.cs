using System;
using System.Collections.Generic;
using System.Text;
using UCM.Business.Student.Models;

namespace UCM.Business.SortingStrategy
{
    public abstract class SortStrategy
    {
        public abstract void Sort(List<StudentDetailsModel> list);
    }
}
