using System;
using System.Collections.Generic;
namespace Asean
{
    class Student
    {
     

        public string StudentNumber {get;set;}
        public string Surname {get;set;}
        public string FirstName {get;set;}
        public string Occupation {get;set;}
        public string Gender {get;set;}
        public string CountryCode {get;set;}
        public string AreaCode{get;set;}
        public string Number{get;set;}

        public Student(string StudentNumber, string Surname, string FirstName, string Occupation, string Gender, string CountryCode, string AreaCode, string Number)
        {
            this.StudentNumber = StudentNumber;
            this.Surname = Surname;
            this.FirstName = FirstName;
            this.Occupation = Occupation;
            this.Gender = Gender;
            this.CountryCode = CountryCode;
            this.AreaCode = AreaCode;
            this.Number = Number;
        }

        public string GetFullPhoneNumber()
        {
            return CountryCode + "-" + AreaCode + "-" + Number ;
        }

        public string GetDescription()
        {
            string Pronoun;

            if (Gender.ToUpper() == "M")
            {
                Pronoun = "His";
            }
            else
            {
                Pronoun = "Her";
            }
            return FirstName + " " + Surname + " is a " + Occupation + ". " + Pronoun + " number is " + GetFullPhoneNumber();

        }

        public string GetSearchLine()
        {
            string Pronoun;

            if (Gender.ToUpper() == "M")
            {
                Pronoun = "His";
            }
            else
            {
                Pronoun = "Her";
            }


            return Surname + ", " + FirstName + ", with student number " + StudentNumber + ", is a " + Occupation + ". " + Pronoun + " phone number is " + GetFullPhoneNumber();
        }

    }

    class Country
    {
        public string Name{get;set;}
        public string Code{get;set;}


        public Country (string Name, string Code)
        {
            this.Name = Name;
            this.Code = Code;
        }
    }
    class PhoneBook
        {
            private List <Student> students = new List<Student>();
            public List<Student> GetStudentsByCodes(List<string> codes, bool showAll)
            {
            
                List<Student> matches = new List<Student>();

            foreach (Student s in students)
            {
                    
                    if (showAll == true)
                {
                    matches.Add(s);
                } else if(codes.Contains(s.CountryCode)) {
                    matches.Add(s);
                }
                    
            }
            for (int i = 0; i < matches.Count - 1; i++)
             {
                for (int j = i + 1; j < matches.Count; j++)
                    {
        
                        if (string.Compare(matches[i].Surname, matches[j].Surname) > 0)
                            {
                                Student temp = matches[i];
                                matches[i] = matches[j];
                                matches[j] = temp;
                            }
       
                    }
              }
            

            return matches;
            }

            public void AddStudent(Student s)
            {
                students.Add(s);
            }



            public Student FindByStudentNumber(string Number)
            {
                foreach (Student s in students)
                {
                    if (s.StudentNumber == Number)
                    {
                        return s;
                    } 
                }

                return null;
            }
        }




    
    class Program
    {
        static void Main()
        {


            List <Country> Countries = new List<Country>( );     
            Countries.Add(new Country("Philippines", "63"));
            Countries.Add(new Country("Thailand", "66"));
            Countries.Add(new Country("Singapore", "65"));
            Countries.Add(new Country("Indonesia", "62"));
            Countries.Add(new Country("Malaysia", "60"));
        
            PhoneBook phonebook = new PhoneBook();

            bool running = true;
            while (running)
            {   
                Console.WriteLine("1 = Store to ASEAN phonebook ");
                Console.WriteLine("2 = Edit entry in ASEAN phonebook");
                Console.WriteLine("3 = Search ASEAN phonebook by country");
                Console.WriteLine("4 = Search ASEAN phonebook by Student Number");
                Console.WriteLine("5 = Exit");
        
                string choice = Console.ReadLine()!;
                switch (choice)
                {
                    case "1" :
                    string again;
                    do {
                    Console.WriteLine("Enter student Number");
                    string studentNumber = Console.ReadLine()!;

                    Console.WriteLine("Enter student Surname");
                    string studentSurname = Console.ReadLine()!;

                    Console.WriteLine("Enter student First Name");
                    string studentFirstName = Console.ReadLine()!;

                    Console.WriteLine("Enter student Occupation");
                    string Occupation = Console.ReadLine()!;
                    
                    Console.WriteLine("Enter student Gender | M for Male | F for Female");
                    string StudentGender = Console.ReadLine()!;

                    Console.WriteLine("Enter student Country Code");
                    string CountryCode = Console.ReadLine()!;

                    Console.WriteLine("Enter student Area Code");
                    string AreaCode = Console.ReadLine()!;

                    Console.WriteLine("Enter student Number");
                    string Number = Console.ReadLine()!;


                    Student s = new Student(studentNumber, studentSurname, studentFirstName, Occupation, StudentGender, CountryCode, AreaCode, Number);
                    phonebook.AddStudent(s);

                    Console.WriteLine("Do you want to try again? Y for yes | N for no");
                    
                    again = Console.ReadLine()!;
                    } while (again.ToUpper()== "Y");
                    break;

                    case "2" :
                    Console.WriteLine("Please enter student Number : ");
                    string editNumber = Console.ReadLine()!;
                    Student result = phonebook.FindByStudentNumber(editNumber);

                    if (result == null)
                        {
                            Console.WriteLine("Student Not Found");
                        }
                    else
                        {
                            Console.WriteLine("Here is the existing information about this student" + result.StudentNumber + ":");
                            Console.WriteLine(result.GetDescription());

                    bool editing = true;
                    while (editing)
                        {
                            Console.WriteLine("1 = Student Number | 2 = Surname | 3 = Gender | 4 = Occupation");
                            Console.WriteLine("5 = Country Code | 6 = Area Code | 7 = Phone Number");
                            Console.WriteLine("8 = Go Back to Main Menu");
                            Console.WriteLine("Enter Choice");
                            string editChoice = Console.ReadLine()!;

                            switch(editChoice)
                            {
                                case "1" :
                                Console.WriteLine("Enter student Number");
                                result.StudentNumber= Console.ReadLine()!;
                                break;

                                case "2":
                                Console.WriteLine("Enter student Surname");
                                result.Surname = Console.ReadLine()!;
            
                                break;

                                case "3":
                                Console.WriteLine("Enter student Gender");
                                result.Gender = Console.ReadLine()!;
                                break;

                                case "4":
                                Console.WriteLine("Enter student Occupation");
                                result.Occupation = Console.ReadLine()!;
                                break;

                                case "5":
                                Console.WriteLine("Enter Country Code");
                                result.CountryCode = Console.ReadLine()!;
                                break; 

                                case "6":
                                Console.WriteLine("Enter Area Code");
                                result.AreaCode = Console.ReadLine()!;
                                break;

                                case "7":
                                Console.WriteLine("Enter Number");
                                result.Number = Console.ReadLine()!;
                                break;

                                case "8":
                                editing = false;
                                break;
                            }

                        if (editChoice != "8")
                            {
                                Console.WriteLine(result.GetDescription());
                            }
                        }
                        }
                    break;

                    case "3" :
                    Console.WriteLine("1 = Philippines | 2 = Thailand | 3 = Singapore | 4 = Indonesia | 5 = Malaysia");
                    Console.WriteLine("6 = ALL | 0 = No more");

                    List<string> pickedCodes = new List<string> ();
                    bool showAll = false;
                    
                    bool picking = true;
                    while(picking)
                        {
                        Console.WriteLine("Enter Choice");
                        string pick = Console.ReadLine()!;
                        if (pick == "0")
                            {
                                picking = false;
                            }
                            else if (pick == "6")
                            {
                                showAll = true;
                            }
                            else if (pick == "1" || pick == "2" || pick == "3" || pick == "4" || pick == "5" )
                            {
                                int number = int.Parse(pick);
                                pickedCodes.Add(Countries[number - 1].Code);
                            }
                        }
                        
                        List<Student> found = phonebook.GetStudentsByCodes(pickedCodes, showAll);
                        
                            string names = "";
                            if (showAll)
                            {
                                names = "all countries";
                            }
                            else
                            {
                                foreach (Country c in Countries)
                                {
                                    if (pickedCodes.Contains(c.Code))
                                    {
                                        if (names != "")
                                        {
                                            names = names + " and ";
                                        }
                                            names = names + c.Name;
                                    }
                                }
                            }

                                Console.WriteLine("Here are the students from " + names + ":");

                                foreach (Student s in found)
                                {
                                    Console.WriteLine(s.GetSearchLine());
                                }
                    break;

                    case "4" :
                    Console.WriteLine("Enter student Number");
                    string searchNumber = Console.ReadLine()!;
                    Student studentMatch = phonebook.FindByStudentNumber(searchNumber);

                    if (studentMatch == null)
                    {
                        Console.WriteLine("Student Not Found");
                    }
                    else
                    {
                        Console.WriteLine(studentMatch.GetSearchLine());
                    }
                    break;
                    case "5" :
                    running = false;
                    break;
                }       
            }

            
        }
    }
}
