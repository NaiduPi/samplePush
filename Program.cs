using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExamples
{
   public class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = (from std in Student.GetStudents()
                                         where std.Age>18 && std.StandardID > 0

                                         select std).ToList();
            foreach(Student st in studentList)
            {
                Console.WriteLine($"ID:{st.StudentID} Name: {st.StudentName}");
            }
            //------------------------------------------
            var teenStudentsName = from s in studentList
                                   where s.Age > 12
                                   select new { StudentName = s.StudentName };
            foreach (var st1 in teenStudentsName)
            {
                Console.WriteLine($" Name: {st1.StudentName}");
            }

            //...........................................
            var studentsGroupByStandard = from s in Student.GetStudents()
                                          group s by s.StandardID into sg
                                          orderby sg.Key
                                          select new { sg.Key, sg };


            foreach (var group in studentsGroupByStandard)
            {
                Console.WriteLine("StandardID {0}:", group.Key);

                foreach(var g in group.sg)
                    
                {
                    Console.WriteLine(g.StudentName);
                }

                //group.sg.ToList().ForEach(st => Console.WriteLine(st.StudentName));
            }
            //----------------------------------------------
            var studentsGroup = from stad in Standard.GetStandards()
                                join s in Student.GetStudents()
                                on stad.StandardID equals s.StandardID
                                    into sg
                                select new
                                {
                                    StandardName = stad.StandardName,
                                    Students = sg
                                };

            foreach (var group in studentsGroup)
            {
                Console.WriteLine(group.StandardName);

                foreach (var g in group.Students)

                {
                    Console.WriteLine(g.StudentName);
                }
                //group.Students.ToList().ForEach(st => Console.WriteLine(st.StudentName));
            }
            //-------------------------------------
            List<int> IntegerList = new List<int>()
            {
                1,2,3,4,5,6,76,2,3,4,5,87,22,2,1
            };

            var qs = (from i in IntegerList
                      select i).Distinct();
            foreach(var i in qs)
            {
                Console.WriteLine("Distnict values{0}",i);
                    }
            //--------------------------------------------
            string[] nameArray = {"Naidu","naidu","ABC","abc" };
            var dv = nameArray.Distinct(StringComparer.OrdinalIgnoreCase);
            foreach(var d in dv)
            {
                Console.WriteLine(d);
            }
            Console.ReadLine();
        }
    }
}
    