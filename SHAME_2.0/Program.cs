using System;
using System.Text.Json;
using System.Text.Unicode;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Text.Encodings.Web;

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
                Console.WriteLine("1. Добавить студента");
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
        static string InputNoSpaces(string message)
        {
            string res;
            do
            {
                Console.Write(message);
                res = Console.ReadLine();
                Regex regex = new Regex(@"\s+");
                res = regex.Replace(res, string.Empty);
                Console.Clear();

            } while (res == "");
            return res;
        }
        static void AddData(ref Data[] data)
        {

            int numOfAdded = data.Length;

            Initials init;
            Сurriculum curriculum;


            Data[] buf_data = new Data[numOfAdded + 1];
            for (int i = 0; i < data.Length; i++)
                buf_data[i] = data[i];      //копируем ссылки на объекты из исходного массива
            data = buf_data;        //и запоминаем ссылуку на расширенный массив
            data[numOfAdded] = new Data();
            init.surname = InputNoSpaces("Фамилия: ");
            init.name = InputNoSpaces("Имя: ");
            init.patronymic = InputNoSpaces("Отчество: ");
            curriculum.faculty = InputNoSpaces("Название факультета: ");
            curriculum.speciality = InputNoSpaces("Название специальности: ");
            curriculum.course = InputNoSpaces("Номер курса: ");
            curriculum.group = InputNoSpaces("Номер группы: ");
            data[numOfAdded].DataEntry(init, curriculum);

            Console.Clear();
            Console.WriteLine("Данные добавлены!");
        }

        static void DataReading(ref Data[] data)
        {
            string fileName;
            Console.Write("Введите название файла: ");
            fileName = Console.ReadLine();

            Console.Clear();

            try
            {
                StreamReader reading = new StreamReader(fileName);  //открытие лучше делать под try, банально введенного файла может не существовать
                string json = reading.ReadToEnd();                  
                data = JsonSerializer.Deserialize<Data[]>(json);    //десериализация прочитанных данных
                reading.Close();

                Console.WriteLine($"Данных: {data.Length} считано из файла: {fileName}");
            }
            catch
            {
                Console.WriteLine($"Ошибка при работе с файлом: {fileName} !");
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
            try
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                StreamWriter record = new StreamWriter(fileName, false);        //лучше создние файла тоже в try взять
                string jsonString = JsonSerializer.Serialize(data, options);
                record.Write(jsonString);
                record.Close();

                Console.WriteLine($"Данных: {data.Length} записанно в файл: {fileName}");
            }
            catch
            {
                Console.WriteLine($"Ошибка при работе с файлом: {fileName} !");
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
