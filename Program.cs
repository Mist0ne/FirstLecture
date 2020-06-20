using System;
using System.Collections.Generic;

namespace FirstLecture
{
    class Program
    {
        //ToDo спросить про зануление
        static void Main(string[] args)
        {
            List<Notebook> notebooks = new List<Notebook>();
            bool flag = true;
            Console.WriteLine("Введите одну из команд:");
            Help();
            while (flag)
            {
                String operation = Console.ReadLine();
                if (operation.ToLower() == "remove")
                {
                    Console.WriteLine("Enter recordId");
                    int _id = Int32.Parse(Console.ReadLine());
                    bool remove_flag = false;
                    for (int i = 0; i < notebooks.Count; i++)
                    {
                        if (notebooks[i].GetId() == _id)
                        {
                            notebooks.Remove(notebooks[i]);
                            Console.WriteLine("Done")
;                           remove_flag = true;
                        }
                    }
                    if (!remove_flag)
                    {
                        Console.WriteLine("Вы ввели неверный ID и вернулись в главное меню");
                    }
                }
                else if (operation.ToLower() == "add")
                {
                    notebooks.Add(NewNotebook());
                    Console.WriteLine("Done");
                }
                else if (operation.ToLower() == "printall")
                {
                    NotebookUI.PrintAllElements(notebooks);
                }
                else if (operation.ToLower() == "printallshort")
                {
                    NotebookUI.PrintShortInfoOfAllElements(notebooks);
                }
                else if (operation.ToLower() == "edit")
                {
                    Console.WriteLine("Введите ID записи, которую хотите изменить");
                    int _id = Int32.Parse(Console.ReadLine());
                    bool edit_flag = false;
                    for (int i = 0; i < notebooks.Count; i++)
                    {
                        if (notebooks[i].GetId() == _id)
                        {
                            edit_flag = true;
                            notebooks[i].EditNotebook();
                        }
                    }
                    if (!edit_flag)
                    {
                        Console.WriteLine("Вы ввели неверный ID и вернулись в главное меню");
                    }
                }
                else if (operation.ToLower() == "help")
                {
                    Help();
                }
                else if (operation.ToLower() == "exit")
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Я вас не понимаю( Введите одну из следующих команд еще раз:");
                    Help();
                }
            }
        }

        public static void Help()
        {
            Console.WriteLine("Add - Добавление новой записи");
            Console.WriteLine("Remove - Удаление записи");
            Console.WriteLine("PrintAll - Вывод всех записей");
            Console.WriteLine("PrintAllShort - Вывод всех записей с краткой информацией");
            Console.WriteLine("Edit - Изменение записи");
            Console.WriteLine("Help - вывод описания всех команд");
        }


        public static Notebook NewNotebook()
        {
            Notebook notebook = new Notebook();

            Console.WriteLine("Enter surname: ");
            notebook.SetSurname(Notebook.NewSurname()); // required parameter

            Console.WriteLine("Enter name: ");
            notebook.SetName(Notebook.NewName()); // required parameter

            Console.WriteLine("Enter middle name: ");
            notebook.SetMiddleName(Notebook.NewOptionalStringParam());

            Console.WriteLine("Enter phone number: ");
            notebook.SetPhoneNumber(Notebook.NewPhoneNumber()); // required parameter

            Console.WriteLine("Enter country: ");
            notebook.SetCountry(Notebook.NewCountry()); // required parameter

            Console.WriteLine("Enter born date: ");
            Console.WriteLine("Введите день, месяц и год Вашего рождения через пробел");
            notebook.SetBornDate(Notebook.NewBornDate(Console.ReadLine()));

            Console.WriteLine("Enter organisation: ");
            notebook.SetOrganisation(Notebook.NewOptionalStringParam());

            Console.WriteLine("Enter position: ");
            notebook.SetPosition(Notebook.NewOptionalStringParam());

            Console.WriteLine("Enter otherNotes: ");
            notebook.SetOtherNotes(Notebook.NewOptionalStringParam());

            return notebook;
        }
    }


    class Notebook
    {
        static int _id = 1;

        private int id;
        private String surname;
        private String name;
        private String middleName;
        private long phoneNumber;
        private String country;
        private DateTime bornDate;
        private String organisation;
        private String position;
        private String otherNotes;


        public Notebook()
        {
            this.id = Notebook._id;
            Notebook._id += 1;
        }


        internal void EditNotebook()
        {
            NotebookUI.PrintElement(this);
            Console.WriteLine("Выберите параметр, который хотите поменять");
            Console.WriteLine("Surname (1)");
            Console.WriteLine("Name (2)");
            Console.WriteLine("Middle Name (3)");
            Console.WriteLine("Phone number (4)");
            Console.WriteLine("Country (5)");
            Console.WriteLine("Born date (6)");
            Console.WriteLine("Organisation (7)");
            Console.WriteLine("Position (8)");
            Console.WriteLine("Other notes (9)");
            try
            {
                int choose = Int32.Parse(Console.ReadLine());
                if (choose == 1)
                {
                    this.SetSurname(NewSurname());
                }
                else if (choose == 2)
                {
                    this.SetName(NewName());
                }
                else if (choose == 3)
                {
                    this.SetMiddleName(NewOptionalStringParam());
                }
                else if (choose == 4)
                {
                    this.SetPhoneNumber(NewPhoneNumber());
                }
                else if (choose == 5)
                {
                    this.SetCountry(NewOptionalStringParam());
                }
                else if (choose == 6)
                {
                    this.SetBornDate(NewBornDate(Console.ReadLine()));
                }
                else if (choose == 7)
                {
                    this.SetOrganisation(NewOptionalStringParam());
                }
                else if (choose == 8)
                {
                    this.SetPosition(NewOptionalStringParam());
                }
                else if (choose == 9)
                {
                    this.SetOtherNotes(NewOptionalStringParam());
                }
                else
                {
                    Console.WriteLine("Ошибочка( Вы снова в главном меню");
                }
                Console.WriteLine("Done");
            }
            catch
            {
                Console.WriteLine("Ошибочка( Вы снова в главном меню");
            }
        }


        internal void SetSurname(String _surname)
        {
            this.surname = _surname;
        }

        internal void SetName(String _name)
        {
            this.name = _name;
        }

        internal void SetMiddleName(String _middleName)
        {
            this.middleName = _middleName;
        }

        internal void SetPhoneNumber(long _phoneNumber)
        {
            this.phoneNumber = _phoneNumber;
        }

        internal void SetCountry(String _country)
        {
            this.country = _country;
        }

        internal void SetBornDate(DateTime _bornDate)
        {
            this.bornDate = _bornDate;
        }

        internal void SetOrganisation(String _organisation)
        {
            this.organisation = _organisation;
        }

        internal void SetPosition(String _position)
        {
            this.position = _position;
        }

        internal void SetOtherNotes(String _otherNotes)
        {
            this.otherNotes = _otherNotes;
        }



        internal int GetId()
        {
            return this.id;
        }

        public String GetSurname()
        {
            return this.surname;
        }

        public String GetName()
        {
            return this.name;
        }

        public String GetMiddleName()
        {
            return this.middleName;
        }

        public long GetPhoneNumber()
        {
            return this.phoneNumber;
        }

        public String GetCountry()
        {
            return this.country;
        }

        public DateTime GetBornDate()
        {
            return this.bornDate;
        }

        public String GetOrganisation()
        {
            return this.organisation;
        }

        public String GetPosition()
        {
            return this.position;
        }

        public String GetOtherNotes()
        {
            return this.otherNotes;
        }


        public static String NewSurname()
        {
            String surname;
            while (true)
            {
                surname = Console.ReadLine();
                if (surname.Length > 2)
                {
                    return surname;
                }
                else
                {
                    Console.WriteLine("Это обязательный параметр, введите Фамилию");
                }
            }
        }

        public static String NewName()
        {
            String name;
            while (true)
            {
                name = Console.ReadLine();
                if (name.Length > 2)
                {
                    return name;
                }
                else
                {
                    Console.WriteLine("Это обязательный параметр, введите имя");
                }
            }
        }

        public static String NewOptionalStringParam()
        {
            String middleName = Console.ReadLine();
            if (middleName.Length > 2)
            {
                return middleName;
            }
            else
            {
                return "Not set";
            }
        }

        public static long NewPhoneNumber()
        {
            long phoneNumber;
            while (true)
            {
                try
                {
                    phoneNumber = Int64.Parse(Console.ReadLine());
                    if (phoneNumber != 0)
                    {
                        return phoneNumber;
                    }
                }
                catch
                {
                    Console.WriteLine("Введите номер, используя только цифры");
                }
            }
        }

        public static String NewCountry()
        {
            String country;
            while (true)
            {
                country = Console.ReadLine();
                if (country.Length > 2)
                {
                    return country;
                }
                else
                {
                    Console.WriteLine("Это обязательный параметр, введите Страну");
                }
            }
        }

        public static DateTime NewBornDate(String date)
        {
            try
            {
                List<int> _date = new List<int>(Array.ConvertAll(date.Split(' '), int.Parse));
                return new DateTime(_date[2], _date[1], _date[0]);
            }
            catch
            {
                Console.WriteLine("Не хотите заполнять поле? Введите + и пропустим этот шаг или попробуйте еще раз");
                String answer = Console.ReadLine();
                if (answer == "+")
                {
                    return new DateTime();
                }
                else
                {
                    return NewBornDate(answer);
                }
            }
        }

    }


    class NotebookUI
    {
        public static void PrintElement(Notebook record)
        {
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("|      ID      | " + record.GetId());
            Console.WriteLine("|   Surname    | " + record.GetSurname());
            Console.WriteLine("|     Name     | " + record.GetName());
            Console.WriteLine("|  MiddleName  | " + record.GetMiddleName());
            Console.WriteLine("| PhoneNumber  | " + record.GetPhoneNumber());
            Console.WriteLine("|   Country    | " + record.GetCountry());
            if (record.GetBornDate().Year == 1)
            {
                Console.WriteLine("|   BornDate   | " + "Not set");
            }
            else
            {
                Console.WriteLine("|   BornDate   | " + $"{record.GetBornDate().Day}/{record.GetBornDate().Month}/{record.GetBornDate().Year}");
            }
            Console.WriteLine("| Organisation | " + record.GetOrganisation());
            Console.WriteLine("|  Postition   | " + record.GetPosition());
            Console.WriteLine("|  OtherNotes  | " + record.GetOtherNotes());

            Console.WriteLine("----------------------------------------");
        }

        public static void PrintAllElements(List<Notebook> record)
        {
            for (int i = 0; i < record.Count; i++)
            {
                Console.WriteLine("----------------------------------------");

                Console.WriteLine("|      ID      | " + record[i].GetId());
                Console.WriteLine("|   Surname    | " + record[i].GetSurname());
                Console.WriteLine("|     Name     | " + record[i].GetName());
                Console.WriteLine("|  MiddleName  | " + record[i].GetMiddleName());
                Console.WriteLine("| PhoneNumber  | " + record[i].GetPhoneNumber());
                Console.WriteLine("|   Country    | " + record[i].GetCountry());
                if (record[i].GetBornDate().Year == 1)
                {
                    Console.WriteLine("|   BornDate   | " + "Not set");
                }
                else
                {
                    Console.WriteLine("|   BornDate   | " + $"{record[i].GetBornDate().Day}/{record[i].GetBornDate().Month}/{record[i].GetBornDate().Year}");
                }
                Console.WriteLine("| Organisation | " + record[i].GetOrganisation());
                Console.WriteLine("|  Postition   | " + record[i].GetPosition());
                Console.WriteLine("|  OtherNotes  | " + record[i].GetOtherNotes());

                Console.WriteLine("----------------------------------------\n\n");
            }
        }

        public static void PrintShortInfoOfAllElements(List<Notebook> record)
        {
            for (int i = 0; i < record.Count; i++)
            {
                Console.WriteLine("----------------------------------------");
                
                Console.WriteLine("|   Surname    | " + record[i].GetSurname());
                Console.WriteLine("|     Name     | " + record[i].GetName());
                Console.WriteLine("| PhoneNumber  | " + record[i].GetPhoneNumber());

                Console.WriteLine("----------------------------------------\n\n");
            }
        }
    }
}