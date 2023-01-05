using IndvDtaDbPrjctTest.Data;
using IndvDtaDbPrjctTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace IndvDtaDbPrjctTest.UI
{
    public class Menu
    {
        public static async void LoginMenu()
        {
            string theEnd, menuInput, userName, passWord;
            uint correctInput;
            bool checkPassword;

            do
            {
                string[] menu = new string[2] { "1: Log in using user Credentials ", "2: Quit " };

                do
                {
                    for (int i = 0; i < menu.Length; i++)
                    {
                        Console.WriteLine(menu[i]);
                    }
                    menuInput = Console.ReadLine();

                } while (!uint.TryParse(menuInput, out correctInput));

                if (correctInput == 1)
                {
                    do
                    {
                        Console.Clear();
                        Console.Write("Username: ");
                        userName = Console.ReadLine();

                        Console.Write("Password: ");
                        passWord = Console.ReadLine();

                        //CheckAny(userName,passWord);

                        if (CheckAny(userName, passWord) == true && userName == "admin")
                        {
                            Console.Clear();
                            AdminMenu();
                        }
                        else if (CheckAny(userName, passWord) == true && userName != "admin")
                        {
                            Console.Clear();
                            UserMenu();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Wrong input or invalid password!");
                        }

                        Console.WriteLine("Press Enter to continue or 'q' to quit");
                        theEnd = Console.ReadLine();
                        Console.Clear();

                    } while (theEnd.ToLower() != "q");
                }
                else if (correctInput == 2)
                {

                }
                else
                {
                    Console.WriteLine("Input can only be between [1-2]");
                }

                Console.WriteLine("Press Enter to continue or 'q' to quit");
                theEnd = Console.ReadLine();

            } while (theEnd.ToLower() != "q");

        }
        //Shows how many in each department that are teachers
        public static void TeachersInDepartment()
        {
            using (var context = new NewSchoolContext())
            {

                var fcltyDprtmnt = from d in context.TeachersInDepartments
                                   select d;

                foreach (var item in fcltyDprtmnt)
                {
                    Console.WriteLine(new string('-', (30)));
                    Console.WriteLine($"Number of teachers in {item.DepartmentName} is {item.InDepartment}");
                }
            }
        }
        //Shows information about students
        public static void StudentInformation()
        {
            using (var context = new NewSchoolContext())
            {
                var stdntInfo = from s in context.StudentInformations
                                select s;

                foreach (var item in stdntInfo)
                {
                    Console.WriteLine(new string('-', (30)));
                    Console.WriteLine($"Student ID: {item.PkStudentId}\nName: {item.Fname} {item.Fname}\nPersonal ID number: {item.PersonNummer}\nClassname: {item.ClassName}");
                }
            }
        }
        //Shows a list of all the active class (started before todays date)
        public static void ActiveClasses()
        {
            using (var context = new NewSchoolContext())
            {
                var activClss = from a in context.ActiveClasses
                                select a;

                Console.WriteLine("Active Classes");

                foreach (var item in activClss)
                {
                    Console.WriteLine(new string('-', (30)));
                    Console.WriteLine($"Class: {item.SubjectName}\nStart Date: {item.StartDate}");
                }
            }
        }
        //Checking username and password
        public static bool CheckAny(string userInput, string passw)
        {
            using (var context = new NewSchoolContext())
            {
                var cred = context.Credentials.FirstOrDefault(user => user.UserName == userInput && user.PassWord == passw);

                if (cred != default && cred.PassWord == passw)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        //
        public static void UserMenu()
        {
            string theEnd, menuInput;
            uint approvedMenuInput;

            do
            {
                do
                {
                    string[] menuArray = new string[6]
                    {
                        "1: Get all Faculty members: ",
                        "2: Get all students: ",
                        "3: Show list of all active classes: ",
                        "4: Information about the students: ",
                        "5: Get a list of number of Teachers in each department: ",
                        "6: Quit: "
                    };

                    for (int i = 0; i < menuArray.Length; i++)
                    {
                        Console.WriteLine(menuArray[i]);
                    }

                    menuInput = Console.ReadLine();

                } while (!uint.TryParse(menuInput, out approvedMenuInput) && approvedMenuInput > 8);


                switch (approvedMenuInput)
                {
                    case 1:
                        Console.WriteLine("Get all Faculty members press: ");
                        GetFaculty();
                        break;
                    case 2:
                        Console.WriteLine("2: Get all students enrolled in NewSchool: ");
                        GetStudents();
                        break;
                    case 3:
                        Console.WriteLine("3: Show list of all active classes: ");
                        ActiveClasses();
                        break;
                    case 4:
                        Console.WriteLine("4: Information about the students ");
                        StudentInformation();
                        break;
                    case 5:
                        Console.WriteLine("5: Get a list of number of Teachers in each department: ");
                        TeachersInDepartment();
                        break;
                    case 6:
                        Console.Clear();
                        break;
                }

                Console.Write("Enter to go back to menu or 'q' to quit: ");
                theEnd = Console.ReadLine();

                Console.Clear();

            } while (theEnd.ToLower() != "q");
        }
        public static void GetFaculty()
        {
                using (var context = new NewSchoolContext())
                {
                    var myFaculty = from f in context.Faculties
                                    select f;

                    Console.Clear();

                    foreach (var faculty in myFaculty)
                    {
                        Console.WriteLine($"{faculty.Fname} {faculty.Lname}");
                        Console.WriteLine(new string('-', (30)));

                    }
            }

        }
        public static void GetStudents()
        {

            Console.WriteLine("Sort by Firstname or Lastname [1-2]: ");
            int input = int.Parse(Console.ReadLine());

            string sortByName = "";

            Console.WriteLine("Sort by 'Ascending' or 'Descending' [1-2]: ");
            int ascOrDesc = int.Parse(Console.ReadLine());

            string upOrDown = "";

            if (input == 1)
            {
                if (ascOrDesc == 1)
                {
                    using (var context = new NewSchoolContext())
                    {
                        var myStudents = from s in context.Students
                                         orderby s.Fname ascending
                                         select s;

                        Console.Clear();

                        foreach (var student in myStudents)
                        {
                            Console.WriteLine($"{student.Fname} {student.Lname} {student.PersonNummer} ");
                            Console.WriteLine(new string('-', (30)));

                        }

                    }
                }
                else if (ascOrDesc == 2)
                {
                    using (var context = new NewSchoolContext())
                    {
                        var myStudents = from s in context.Students
                                         orderby s.Fname descending
                                         select s;

                        Console.Clear();

                        foreach (var student in myStudents)
                        {
                            Console.WriteLine($"{student.Fname} {student.Lname} {student.PersonNummer}");
                            Console.WriteLine(new string('-', (30)));

                        }

                    }
                }
            }
            else if (input == 2)
            {
                if (ascOrDesc == 1)
                {
                    using (var context = new NewSchoolContext())
                    {
                        var myStudents = from s in context.Students
                                         orderby s.Lname ascending
                                         select s;

                        Console.Clear();

                        foreach (var student in myStudents)
                        {
                            Console.WriteLine($"{student.Fname} {student.Lname} {student.PersonNummer}");
                            Console.WriteLine(new string('-', (30)));

                        }

                    }
                }
                else if (ascOrDesc == 2)
                {
                    using (var context = new NewSchoolContext())
                    {
                        var myStudents = from s in context.Students
                                         orderby s.Lname descending
                                         select s;

                        Console.Clear();

                        foreach (var student in myStudents)
                        {
                            Console.WriteLine($"{student.Lname} {student.Fname} {student.PersonNummer}");
                            Console.WriteLine(new string('-', (30)));

                        }

                    }
                }
            }
        }
        public static void AdminMenu()
        {
            string theEnd, menuInput;
            uint approvedMenuInput;

            do
            {
                do
                {
                    string[] menuArray = new string[3]
                    {
                        "1: Add new Students: ",
                        "2: Add new Faculty: ",
                        "3: Quit: "
                    };

                    for (int i = 0; i < menuArray.Length; i++)
                    {
                        Console.WriteLine(menuArray[i]);
                    }

                    menuInput = Console.ReadLine();

                } while (!uint.TryParse(menuInput, out approvedMenuInput) && approvedMenuInput > 3);


                switch (approvedMenuInput)
                {
                    case 1:
                        Console.WriteLine("1: Add new students: ");
                        do
                        {
                            StudentRegistry();

                            Console.Clear();

                            Console.Write("Press Enter to add another Student or 'q' to quit: ");
                            theEnd = Console.ReadLine();

                            Console.Clear();

                        } while (theEnd.ToLower() != "q");

                        break;
                    case 2:
                        Console.WriteLine("2: Add new Faculty:");
                        do
                        {
                            FacultyRegistry();

                            Console.Clear();

                            Console.Write("Press Enter to add another Faculty member or 'q' to quit: ");
                            theEnd = Console.ReadLine();

                            Console.Clear();

                        } while (theEnd.ToLower() != "q");
                        break;
                    case 3:
                        Console.Clear();
                        break;
                }

                Console.Write("Enter to go back to menu or 'q' to logout: ");
                theEnd = Console.ReadLine();

                Console.Clear();

            } while (theEnd.ToLower() != "q");
        }
        public static void StudentRegistry()
        {
            using var context = new NewSchoolContext();
            var student = new Student();

            Console.Write("Enter firstname: ");
            student.Fname = Console.ReadLine(); ;

            Console.Clear();

            Console.Write("Enter lastname: ");
            student.Lname = Console.ReadLine();

            Console.Clear();

            Console.Write("Type in PersonId [yyyymmdd-xxxx]: ");
            student.PersonNummer = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("1: Beaver\n2: Eagle\n3: Swamprat\n4: Guinea Pig\n5: Horse\n6: Moose");
            Console.Write("Assign to class [1-6]: ");
            student.FkClassId = int.Parse(Console.ReadLine());

            Console.Clear();

            context.Students.Add(student);
            context.SaveChanges();
            Console.WriteLine("Databasen är uppdaterad");

        }
        public static void FacultyRegistry()
        {
            using var context = new NewSchoolContext();
            var faculty = new Faculty();

            Console.Write("Enter firstname: ");
            faculty.Fname = Console.ReadLine(); ;

            Console.Clear();

            Console.Write("Enter lastname: ");
            faculty.Lname = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("1: Headmaster\n2: Administrator\n3: Creepy Janitor\n4: Lunchlady\n5: Guidens Councelor\n6: Teacher");
            Console.Write("Assign type of faculty[1-6]: ");
            faculty.FkFacultyTypeId = int.Parse(Console.ReadLine());

            Console.Clear();

            context.Faculties.Add(faculty);
            context.SaveChanges();
            Console.WriteLine("Databasen är uppdaterad");

        }
    }
}
