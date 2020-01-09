using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UCM.Business.Student.Models;

namespace UCM.Business.SortingStrategy
{
    public class SortedList
    {
        public List<StudentDetailsModel> list;
        private SortStrategy _sortstrategy;

        public SortedList(IEnumerable<StudentDetailsModel> students)
        {
            list = students.ToList();
        }
        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this._sortstrategy = sortstrategy;
        }

        public void Sort()
        {
            _sortstrategy.Sort(list);

            // Iterate over list and display results

            /*foreach (var student in _list)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} {student.Score}");
            }
            Console.WriteLine();*/
        }
    }
}
