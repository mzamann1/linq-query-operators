using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LINQ.Models;
using LINQ.Shared;
using System.Reflection;

namespace LINQ.QueryOperators.Filtering
{
    internal static class Filtering
    {
        private static readonly Common _common;
        private static readonly IEnumerable<Student> _students;
        static Filtering()
        {
            _common = Common.Instance;
            _students = _common.GetStudents();
        }

        //The Where operator (Linq extension method) filters the collection based on a given criteria expression and returns a new collection.The criteria can be specified as lambda expression or Func delegate type.
        internal static void Where()
        {

            _common.PrintInitials(MethodBase.GetCurrentMethod().Name);

            Console.WriteLine($"\n{MethodBase.GetCurrentMethod().Name} => {nameof(Student)} \n");

            _common.PrintList(_students.Where(x => x.Age > 12 && x.Age < 20));

            var filteredStudents = from student in _students
                                   where student.Age > 12 && student.Age < 20
                                   select student;

            _common.PrintList(filteredStudents);

            _common.PrintInitials();
        }


        //The OfType operator filters the collection based on the ability to cast an element in a collection to a specified type
        internal static void OfType()
        {
            _common.PrintInitials(MethodBase.GetCurrentMethod().Name);


            Console.WriteLine($"{MethodBase.GetCurrentMethod().Name} => {nameof(Student)}");

            _common.PrintList(_students.OfType<Student>());

            var filteredStudents = from student in _students.OfType<Student>()
                                   select student;

            _common.PrintList(filteredStudents);

            _common.PrintInitials();

        }
    }
}
