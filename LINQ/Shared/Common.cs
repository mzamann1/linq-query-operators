using LINQ.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Shared
{
    public class Common
    {
        //Lazy<T> for thread safety

        /// <summary>
        /// Provides support for lazy initialization.
        /// By default, all public and protected members of <see cref="Lazy{T}">; are thread-safe
        /// and may be used concurrently from multiple threads.
        /// </summary>

        private static readonly Lazy<Common> _lazyLogger = new Lazy<Common>(() => new Common());


        //property to be available for the clients to get instance of the class
        public static Common Instance
        {
            get
            {
                //returning the lazy value of logger
                return _lazyLogger.Value;
            }
        }

        protected Common()
        {
        }

        //simple method

        internal IEnumerable<Student> GetStudents()
        {
            return new List<Student>
            {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 },
            new Student() { StudentID = 2, StudentName = "Steve", Age = 21 },
            new Student() { StudentID = 3, StudentName = "Bill", Age = 25 },
            new Student() { StudentID = 4, StudentName = "Ram", Age = 20 },
            new Student() { StudentID = 5, StudentName = "Ron", Age = 31 },
            new Student() { StudentID = 6, StudentName = "Chris", Age = 17 },
            new Student() { StudentID = 7, StudentName = "Rob", Age = 19 },
        };

        }

        public void PrintInitials(string sectionName = null)
        {
            if (sectionName == null)
                Console.WriteLine($"\n=========================================\n");
            else
                Console.WriteLine($"\n================= {sectionName} ========================\n");
        }

        internal void PrintList(IEnumerable<Student> list)
        {
            PrintHeader(typeof(Student).GetProperties().Select(x => x.Name));

            Console.WriteLine("--------------------------------");

            foreach (var item in list)
            {
                PrintLine(item);
            }

            Console.WriteLine("\n\n");
        }

        private void PrintLine(Student student)
        {
            Console.WriteLine($"   {student.StudentID}   \t    {student.StudentName}   \t  {student.Age}");
        }

        internal void PrintGroupList(IEnumerable<IGrouping<int, Student>> list, string groupByOn)
        {
            foreach (var group in list)
            {
                Console.WriteLine($"{groupByOn} Group: {group.Key}"); //Each group has a key 

                PrintHeader(typeof(Student).GetProperties().Select(x => x.Name));

                foreach (Student s in group)
                {
                    PrintLine(s);
                }
            }
            Console.WriteLine("\n\n");
        }
        private void PrintHeader(IEnumerable<string> header)
        {
            foreach (var headerItem in header)
            {
                Console.Write($"{headerItem} | ");
            }

            Console.WriteLine();

        }
    }


}
