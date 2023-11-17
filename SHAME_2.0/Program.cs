using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace StudentDatabase
{
    internal class Program
    {
        static int stateMenu;
        static void Menu()
        {
            try
            {
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("======================================");
                Console.WriteLine("1. Добавить студента (ну или студентку");
                Console.WriteLine("2. Посмотреть информацию");
                Console.WriteLine("======================================");
                Console.WriteLine("3. Сохранить файл");
                Console.WriteLine("4. Удалить студента");
                Console.WriteLine("5. Изменить");
                Console.WriteLine("======================================");
                Console.Write("Ваш Выбор: ");
                stateMenu = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                Menu();
            }
        }

        static void Main(string[] args)
        {
            Menu();
            int action;
            Data[] data = new Data[0]; // массив объектов класса данные  

            while (stateMenu != 0)
            {
                try 
                {

                    switch (stateMenu)
                    {
                        case 0:
                            
                            Array.Clear(data, 0, data.Length);
                            break;
                             
                        case 1:
                        {
                            Console.Clear(); 

                            Console.WriteLine("1. Добавить ");
                            Console.WriteLine("2. Открыть файл");
                            Console.Write("Ваш выбор: ");

                            action = Convert.ToInt32(Console.ReadLine());
                            
                            Console.Clear();

                            if (action == 1)
                            {
                                AddData(ref data);
                            }
                            else if (action == 2)
                            {
                                DataReading(ref data);
                            }
                            else
                                Console.WriteLine("Пункт меню выбран не верно!");

                            Console.ReadLine();
                            Console.Clear();

                            break;
                        }
                        
                        case 2:
                            Console.Clear();

                            if (data.Length > 0)
                            {
                                Print(data);
                            }
                            else
                                Console.Write("Данные пусты!");

                            Console.ReadLine();  
                            Console.Clear(); 
                            break;

                        case 3:
                            Console.Clear();
                            if (data.Length > 0)
                            {
                                SavingData(data);
                            }
                            else
                                Console.Write("Данные пусты!");

                            Console.ReadLine(); 
                            Console.Clear(); 
                                             
                            break;

                        case 4:
                            Console.Clear();
                            if (data.Length > 0)
                            {
                                DeleteData(ref data);
                            }
                            else
                                Console.Write("Данные пусты!");

                            Console.ReadLine();
                            Console.Clear();

                            break;

                        case 5:
                            Console.Clear();
                            if (data.Length > 0)
                            {
                                DataChange(data);
                            }
                            else
                                Console.Write("Данные пусты!");

                            Console.ReadLine();
                            Console.Clear();

                            break;

                        default:
                            Console.WriteLine("Пункт меню выбран не верно!");
                            Console.Clear();
                            
                            break;
                    }

                    Menu(); 
                }
                catch 
                {
                    Console.WriteLine("Что-то определённо пошло не так!");
                    Console.ReadLine();
                    Console.Clear();
                    Menu();
                }
            }
        }

        static void AddData(ref Data[] data)
        {

            int numOfAdded = data.Length;
 
            Initials init;
            Сurriculum curriculum;

            if (numOfAdded == 0)
            {
               
                data = new Data[numOfAdded + 1];
                for (int i = 0; i < data.Length; i++)
                    data[i] = new Data();

                do
                {
                    Console.Write("Фамилия: ");
                    init.surname = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    init.surname = regex.Replace(init.surname, string.Empty);
                    Console.Clear();

                } while (init.surname == "");

                do
                {
                    Console.Write("Имя: ");
                    init.name = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    init.name = regex.Replace(init.name, string.Empty);
                    Console.Clear();
                   
                } while (init.name == ""); 

                do
                {
                    Console.Write("Отчетсво: ");
                    init.patronymic = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    init.patronymic = regex.Replace(init.patronymic, string.Empty);
                    Console.Clear();

                } while (init.patronymic == "");

                do
                {
                    Console.Write("Название факультета: ");
                    curriculum.faculty = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    curriculum.faculty = regex.Replace(curriculum.faculty, string.Empty);
                    Console.Clear();

                } while (curriculum.faculty == "");

                do
                {
                    Console.Write("Название специальности: ");
                    curriculum.speciality = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    curriculum.speciality = regex.Replace(curriculum.speciality, string.Empty);
                    Console.Clear();

                } while (curriculum.speciality == "");

                do
                {
                    Console.Write("Номер курса: ");
                    curriculum.course = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    curriculum.course = regex.Replace(curriculum.course, string.Empty);
                    Console.Clear();

                } while (curriculum.course == "");

                do
                {
                    Console.Write("Номер группы: ");
                    curriculum.group = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    curriculum.group = regex.Replace(curriculum.group, string.Empty);
                    Console.Clear();

                } while (curriculum.group == "");

                data[0].DataEntry(init, curriculum);
            }
            else
            {
                // копируем массив данных с помощью метода Close()
                // иначе, можно создать новый массив к каждому элементу нового присвоить значение старого массива в цикле 
                Data[] buf_data = (Data[])data.Clone();

                data = new Data[numOfAdded + 1];
                for (int i = 0; i < data.Length; i++)
                    data[i] = new Data();

                for (int i = 0; i < buf_data.Length; i++)
                    data[i] = buf_data[i];
 
                do
                {
                    Console.Write("Фамилия: ");
                    init.surname = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    init.surname = regex.Replace(init.surname, string.Empty);
                    Console.Clear();

                } while (init.surname == "");

                do
                {
                    Console.Write("Имя: ");
                    init.name = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    init.name = regex.Replace(init.name, string.Empty);
                    Console.Clear();

                } while (init.name == "");

                do
                {
                    Console.Write("Отчетсво: ");
                    init.patronymic = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    init.patronymic = regex.Replace(init.patronymic, string.Empty);
                    Console.Clear();

                } while (init.patronymic == ""); 

                do
                {
                    Console.Write("Название факультета: ");
                    curriculum.faculty = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    curriculum.faculty = regex.Replace(curriculum.faculty, string.Empty);
                    Console.Clear();

                } while (curriculum.faculty == "");

                do
                {
                    Console.Write("Название специальности: ");
                    curriculum.speciality = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    curriculum.speciality = regex.Replace(curriculum.speciality, string.Empty);
                    Console.Clear();

                } while (curriculum.speciality == "");

                do
                {
                    Console.Write("Номер курса: ");
                    curriculum.course = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    curriculum.course = regex.Replace(curriculum.course, string.Empty);
                    Console.Clear();

                } while (curriculum.course == "");

                do
                {
                    Console.Write("Номер группы: ");
                    curriculum.group = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    curriculum.group = regex.Replace(curriculum.group, string.Empty);
                    Console.Clear();

                } while (curriculum.group == "");

                data[numOfAdded].DataEntry(init, curriculum);

                Array.Clear(buf_data, 0, buf_data.Length);
            }
            Console.Clear();
            Console.WriteLine("Данные добавлены!");
            
        }

        static void DataReading(ref Data[] data)
        {
            string fileName;
            Console.Write("Введите название файла: ");
            fileName = Console.ReadLine();

            Console.Clear();

            StreamReader reading = new StreamReader(fileName);
            try
            { 
                int numOfData = Convert.ToInt32(reading.ReadLine());
                int i = 0,
                numOfLine = 0;
 
                data = new Data[numOfData];
                for (; i < data.Length; i++)
                    data[i] = new Data();
                i = 0;
 
                Initials init;
                Сurriculum curriculum;

                init.name = ""; 
                init.surname = ""; 
                init.patronymic = "";

                while (!reading.EndOfStream)
                {
                    if (numOfLine == 0)
                    {
                        init.surname = reading.ReadLine();
                        numOfLine++;
                    }
                    else if (numOfLine == 1)
                    {
                        init.name = reading.ReadLine();
                        numOfLine++;
                    }
                    else if (numOfLine == 2)
                    {
                        init.patronymic = reading.ReadLine();
                        numOfLine++;
                    }

                    else if (numOfLine == 3)
                    {

                        string line = reading.ReadLine();
                        string[] splitline = line.Split(' ');

                        curriculum.faculty = splitline[0];
                        curriculum.speciality = splitline[1];
                        curriculum.course = splitline[2];
                        curriculum.group = splitline[3];

                        data[i].DataEntry(init, curriculum);

                        i++;
                    }
                }
                Console.WriteLine($"Данных: {data.Length} считано из файла: {fileName}");
            }
            catch
            {
                Console.WriteLine($"Ошибка при работе с файлом: {fileName} !");
            }
            finally
            {
                Array.Resize(ref data, data.Length - 1);
                reading.Close();
            }
        }
 
        static void Print(Data[] data)
        {
            int i = 1;
            foreach (Data d in data)
            {
                Console.WriteLine("Данные №" + i++);
                d.Print();
                Console.WriteLine("====================================");
            }
        }

        static void SavingData(Data[] data)
        {
            string fileName;

            Console.Write("Введите название файла: ");
            fileName = Console.ReadLine();

            Console.Clear();

            StreamWriter record = new StreamWriter(fileName, false);
            try
            {
                record.WriteLine(data.Length);

                foreach (Data d in data)
                {
                    record.WriteLine(d.GetInitials().surname);
                    record.WriteLine(d.GetInitials().name);
                    record.WriteLine(d.GetInitials().patronymic);
                    record.WriteLine(d.GetCurriculum().faculty);
                    record.WriteLine(d.GetCurriculum().speciality);
                    record.WriteLine(d.GetCurriculum().course);
                    record.WriteLine(d.GetCurriculum().group);
                }
                Console.WriteLine($"Данных: {data.Length} записанно в файл: {fileName}");
            }
            catch
            {
                Console.WriteLine($"Ошибка при работе с файлом: {fileName} !");
            }
            finally
            {
                record.Close();
            }
        }

        static void DataChange(Data[] data)
        {
            Console.WriteLine($"Введите необходимый элемент (от 1 до {data.Length}): ");
            int n = Convert.ToInt32(Console.ReadLine());
            n--; 

            Console.Clear();

            if (n >= 0 && n < data.Length)
            {
                Initials init;
                Сurriculum curriculum;
 
                do
                {
                    Console.Write("Фамилия: ");
                    init.surname = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    init.surname = regex.Replace(init.surname, string.Empty);
                    Console.Clear();

                } while (init.surname == "");

                do
                {
                    Console.Write("Имя: ");
                    init.name = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    init.name = regex.Replace(init.name, string.Empty);
                    Console.Clear();

                } while (init.name == "");

                do
                {
                    Console.Write("Отчетсво: ");
                    init.patronymic = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    init.patronymic = regex.Replace(init.patronymic, string.Empty);
                    Console.Clear();

                } while (init.patronymic == "");

                do
                {
                    Console.Write("Название факультета: ");
                    curriculum.faculty = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    curriculum.faculty = regex.Replace(curriculum.faculty, string.Empty);
                    Console.Clear();

                } while (curriculum.faculty == "");

                do
                {
                    Console.Write("Название специальности: ");
                    curriculum.speciality = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    curriculum.speciality = regex.Replace(curriculum.speciality, string.Empty);
                    Console.Clear();

                } while (curriculum.speciality == "");

                do
                {
                    Console.Write("Номер курса: ");
                    curriculum.course = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    curriculum.course = regex.Replace(curriculum.course, string.Empty);
                    Console.Clear();

                } while (curriculum.course == "");

                do
                {
                    Console.Write("Номер группы: ");
                    curriculum.group = Console.ReadLine();
                    Regex regex = new Regex(@"\s+");
                    curriculum.group = regex.Replace(curriculum.group, string.Empty);
                    Console.Clear();

                } while (curriculum.group == "");

                data[n].DataEntry(init, curriculum);

                Console.Clear();
                Console.WriteLine($"Данные элемента: {n + 1} изменены!");
            }
            else
                Console.WriteLine("Номер введен не верно!");
        }

        static void DeleteData(ref Data[] data)
        {
            Console.WriteLine($"Введите необхъодимый элемент (от 1 до {data.Length}): ");
            int n = Convert.ToInt32(Console.ReadLine());
            n--;

            Console.Clear();
 
            if (n >= 0 && n < data.Length)
            {
                Data[] buf_data = (Data[])data.Clone();

                int new_size = data.Length - 1;
                data = new Data[new_size]; 
 
                int d = 0;
                for (int i = 0; i < buf_data.Length; i++)
                {
                    if (i != n)
                    {
                        data[d] = buf_data[i];
                        d++;
                    }
                }

                Console.Clear();
                Console.WriteLine($"Данные №{n + 1} удалены!");

                Array.Clear(buf_data, 0, buf_data.Length);
            }
            else
                Console.WriteLine("Номер введен не верно!");
        }
    }
}
