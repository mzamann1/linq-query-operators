using LINQ.Models;
using LINQ.Shared;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace LINQ.QueryOperators.Sorting
{
    /*
    OrderBy and ThenBy sorts collections in ascending order by default.
    ThenBy or ThenByDescending is used for second level sorting in method syntax.
    ThenByDescending method sorts the collection in decending order on another field.
    ThenBy or ThenByDescending is NOT applicable in Query syntax.
    Apply secondary sorting in query syntax by separating fields using comma. 
     */


    internal static class Sorting
    {
        private static readonly Common _common;
        private static readonly IEnumerable<Student> _students;
        static Sorting()
        {
            _common = Common.Instance;
            _students = _common.GetStudents();
        }
        //OrderBy sorts the values of a collection in ascending or descending order.It sorts the collection in ascending order by default because ascending keyword is optional here. Use descending keyword to sort collection in descending order.
        internal static void OrderBy()
        {
            _common.PrintInitials(MethodBase.GetCurrentMethod().Name);

            Console.WriteLine($"\n {MethodBase.GetCurrentMethod().Name} => {nameof(Student)} \n");

            _common.PrintList(_students.OrderBy(x => x.Age));

            var filteredStudents = from student in _students
                                   orderby student.Age
                                   select student;

            _common.PrintList(filteredStudents);

            _common.PrintInitials();
        }


        //The OfType operator filters the collection based on the ability to cast an element in a collection to a specified type
        internal static void OrderByDescending()
        {
            _common.PrintInitials(MethodBase.GetCurrentMethod().Name);


            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name} => {nameof(Student)}");

            _common.PrintList(_students.OrderByDescending(x => x.Age));

            var filteredStudents = from student in _students
                                   orderby student.Age descending
                                   select student;

            _common.PrintList(filteredStudents);

            _common.PrintInitials();

        }

        /*
         The ThenBy and ThenByDescending extension methods are used for sorting on multiple fields.

         The OrderBy() method sorts the collection in ascending order based on specified field. Use ThenBy() method after OrderBy to sort the collection on another field in ascending order. Linq will first sort the
         collection based on primary field which is specified by OrderBy method and then sort the resulted collection in ascending order again based on secondary field specified by ThenBy method.
         
        The same way, use ThenByDescending method to apply secondary sorting in descending order.
         */

        internal static void ThenBy()
        {
            _common.PrintInitials(MethodBase.GetCurrentMethod().Name);

            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name} => {nameof(Student)}");

            _common.PrintList(_students.OrderByDescending(x => x.Age).ThenBy(s => s.StudentName));

            var filteredStudents = from student in _students
                                   orderby student.Age, student.StudentName
                                   select student;

            _common.PrintList(filteredStudents);

            _common.PrintInitials();

        }

    }
}
