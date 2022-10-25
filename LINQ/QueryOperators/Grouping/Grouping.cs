using LINQ.Models;
using LINQ.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.QueryOperators.Grouping
{

    /*
     The grouping operators do the same thing as the GroupBy clause of SQL query.
     The grouping operators create a group of elements based on the given key.
     This group is contained in a special type of collection that implements an IGrouping<TKey,TSource> interface where TKey is a key value, on which the group has been formed and TSource is the collection of elements that
     matches with the grouping key value.
     */
    internal static class Grouping
    {

        private static readonly Common _common;
        private static readonly IEnumerable<Student> _students;
        static Grouping()
        {
            _common = Common.Instance;
            _students = _common.GetStudents();
        }

        /*
        The GroupBy operator returns a group of elements from the given collection based on some key value. 
        Each group is represented by IGrouping<TKey, TElement> object. Also, the GroupBy method has eight overload methods, so you can use appropriate extension method based on your requirement in method syntax
         
         ToLookup is the same as GroupBy; the only difference is GroupBy execution is deferred, whereas ToLookup execution is immediate. Also, ToLookup is only applicable in Method syntax. 
         ToLookup is not supported in the query syntax.
         
         */
        internal static void GroupBy()
        {
            _common.PrintInitials(MethodBase.GetCurrentMethod().Name);

            Console.WriteLine($"\n {MethodBase.GetCurrentMethod().Name} => {nameof(Student)} \n");

            _common.PrintGroupList(_students.GroupBy(x => x.Age), "Age");

            var filteredStudents = from student in _students
                                   group student by student.Age;


            _common.PrintGroupList(filteredStudents, "Age");

            _common.PrintInitials();
        }
    }
}
