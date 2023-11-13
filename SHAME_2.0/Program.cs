using System;
using System.IO;
using System.Text;

namespace SHAME_2._0
{
    internal class Program
    {
        static int _stateMenu;
        static void Menu() // Меню 
        {
            try
            {
                Console.Write("Выберите действие: \n" +
            "_________________________\n" +
            "1. Добавить студента (ну или студентку)\n" +
            "2. Посмотреть информацию\n" +
            "-------------------------\n" +
            "3. Сохранить файл\n" +
            "4. Удалить студента\n" +
            "5. Изменить\n" +
            "-------------------------\n" +
            "Ваш Выбор: ");
                _stateMenu = Convert.ToInt32(Console.ReadLine());
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
            int _action;
            Data[] _data = new Data[0]; // массив объектов класса данные  

            while (_stateMenu != 0)
            {
                try 
                {

                    switch (_stateMenu)
                    {
                        case 0: // закрыть программу
                            
                            Array.Clear(_data, 0, _data.Length);
                            break;
                             
                        case 1: // добавить данные
                        {
                            Console.Clear(); 

                            Console.Write("1. Добавить\n" +
                            "2. Открыть файл\n" +
                            "Ваш выбор: ");
                            _action = Convert.ToInt32(Console.ReadLine());
                            
                            Console.Clear();

                            if (_action == 1)
                            {
                                AddData(ref _data); // Добавление данных, где ref - ссылка на параметр
                            }
                            else if (_action == 2)
                            {
                                DataReading(ref _data); //  чтение данных из файла, где ref - ссылка на параметр
                            }
                            else

                            Console.WriteLine("Пункт меню выбран не верно!");
                            Console.ReadLine();
                            Console.Clear();

                            break;
                        }
                        
                        case 2: // вывести данные в консоль
                            Console.Clear();

                            if (_data.Length > 0)
                            {
                                 
                                Print(_data);
                            }
                            else
                                Console.Write("Данные пусты!");

                            Console.ReadLine();  
                            Console.Clear(); 
                            break;


                        case 3: // сохранить данные (новый или уже открытый)
                            Console.Clear();
                            if (_data.Length > 0)
                            {
                                SavingData(_data);
                            }
                            else
                                Console.Write("Данные пусты!");

                            Console.ReadLine(); 
                            Console.Clear(); 
                                             
                            break;

                        case 4: //удалить данные
                            Console.Clear();
                            if (_data.Length > 0)
                            {
                                DeleteData(ref _data);
                            }
                            else
                                Console.Write("Данные пусты!");

                            Console.ReadLine();
                            Console.Clear();

                            break;

                        case 5: // изменить данные
                            Console.Clear();
                            if (_data.Length > 0)
                            {
                                DataChange(_data);
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

                    Menu(); // вывод меню
                }
                catch
                {
                    Console.WriteLine("Ай-ай-ай, не надо так!");
                    Console.ReadLine();
                    Console.Clear();
                    Menu();
                }
            }
        }

        // добавление данных
        static void AddData(ref Data[] _data)
        {
            //ref - ссылка

            int num_of_added = _data.Length;

            //временные перемиенные 
            Initials init;
            Сurriculum curriculum;

            if (num_of_added == 0)
            {
                // если данных нет, выделяем новую память 
                _data = new Data[num_of_added + 1];
                for (int i = 0; i < _data.Length; i++)
                    _data[i] = new Data();

                // вводим нужные данные 
                Console.Write("Введите фамилию: ");
                init.surname = Console.ReadLine();
                Console.Write("Введите имя: ");
                init.name = Console.ReadLine();
                Console.Write("Отчетсво: ");
                init.patronymic = Console.ReadLine();

                Console.Write("Введите название факультета: ");
                curriculum.faculty = Console.ReadLine();
                Console.Write("Введите название специальности: ");
                curriculum.speciality = Console.ReadLine();
                Console.Write("Введите номер курса: ");
                curriculum.cource = Console.ReadLine();
                Console.Write("Введите номер группы: ");
                curriculum.group = Console.ReadLine();

                _data[0].DataEntry(init, curriculum);
            }
            else
            {
                // копируем массив данных с помощью метода Close()
                // иначе, можно создать новый массив к каждому элементу нового присвоить значение старого массива в цикле 
                // for(......) buf_data [i] = data[i];
                Data[] buf_data = (Data[])_data.Clone();

                // выделяем новую память под текущий массив данных
                _data = new Data[num_of_added + 1]; // после этого, все данные тут потеряются
                for (int i = 0; i < _data.Length; i++)
                    _data[i] = new Data();

                // копируем данные из временного массива в текущий обратно 
                for (int i = 0; i < buf_data.Length; i++)
                    _data[i] = buf_data[i];

                // вводим данные, которые добавляем 
                Console.Write("Введите фамилию: ");
                init.surname = Console.ReadLine();
                Console.Write("Введите имя: ");
                init.name = Console.ReadLine();
                Console.Write("Отчетсво: ");
                init.patronymic = Console.ReadLine();

                Console.Write("Введите название факультета: ");
                curriculum.faculty = Console.ReadLine();
                Console.Write("Введите название специальности: ");
                curriculum.speciality = Console.ReadLine();
                Console.Write("Введите номер курса: ");
                curriculum.cource = Console.ReadLine();
                Console.Write("Введите номер группы: ");
                curriculum.group = Console.ReadLine();

                // добавляем данные в массив данных
                _data[num_of_added].DataEntry(init, curriculum);

                //удаляем временный масив 
                Array.Clear(buf_data, 0, buf_data.Length);
            }
            Console.Clear();
            Console.WriteLine("Данные добавлены!");
            
        }

        // чтение данных из файла
        static void DataReading(ref Data[] _data)
        {
            string fileName;
            Console.Write("Введите название файла: ");
            fileName = Console.ReadLine();

            Console.Clear();

            // для чтания данных из потока используется класс StreamReader
            StreamReader reading = new StreamReader(fileName);
            try
            {
                // некоторый код, котоырй выполнится, если файл удалось открыть без ошибок 

                int num_of_data = Convert.ToInt32(reading.ReadLine());
                int i = 0, // индекс элемента массива данных
                num_of_lines = 0; //номер строки, чтобы понять какую строку данных считываем

                // выделяем память 
                _data = new Data[num_of_data];
                for (; i < _data.Length; i++)
                    _data[i] = new Data();
                i = 0;

                // временные переменные 
                Initials init;
                Сurriculum curriculum;

                init.name = ""; init.surname = ""; init.patronymic = "";


                // считываем пока есть, что считать
                while (!reading.EndOfStream)
                {
                    if (num_of_lines == 0)
                    {
                        // считываем и запоминаем строку
                        init.surname = reading.ReadLine();
                        num_of_lines++; // номер строки 
                    }
                    else if (num_of_lines == 1)
                    {
                        // считываем и запоминаем строку
                        init.name = reading.ReadLine();
                        num_of_lines++;
                    }
                    else if (num_of_lines == 2)
                    {
                        // считываем и запоминаем строку 
                        init.patronymic = reading.ReadLine();
                        num_of_lines++;
                    }

                    else if (num_of_lines == 3)
                    {
                        //  считываем строку и находим местро розрыва ' ' в строке и запоминаем данные 
                        string line = reading.ReadLine();
                        string[] splitline = line.Split(' ');

                        curriculum.faculty = splitline[0];
                        curriculum.speciality = splitline[1];
                        curriculum.cource = splitline[2];
                        curriculum.group = splitline[3];

                        // добавляем данные 
                        _data[i].DataEntry(init, curriculum);

                        i++; // увеличивыем индекс элемента 
                        num_of_lines = 0; // обнуляем номер строки
                    }
                }
                Console.WriteLine($"Данных: {_data.Length} считано из файла: {fileName}");
            }
            catch
            {
                // код, который нужно выполнить если случилась ошибка в блоке try 

                Console.WriteLine($"Ошибка при работе с файлом: {fileName} !");
            }
            finally
            {
                // код, который должен выполниться независимо от того, случилась ли ошибка
                reading.Close(); // закрываем файл
            }
        }
        //вывод в консоль 
        static void Print(Data[] _data)
        {
            int i = 1;
            foreach (Data d in _data)
            {
                Console.WriteLine("Данные №" + i++);
                d.Print();
                Console.WriteLine("________________________");
            }
        }

        // запись в файл 
        static void SavingData(Data[] _data)
        {
            // название нужного файла 
            string fileName;

            Console.Write("Введите название файла: ");
            fileName = Console.ReadLine();

            Console.Clear();

            // для записи данных в поток используется класс StreamWriter
            StreamWriter record = new StreamWriter(fileName, false);
            try
            {
                // фрагмент кода, который будет работать в случае успешного открытия 

                // записываем данные в файл
                record.WriteLine(_data.Length);

                foreach (Data d in _data)
                {
                    record.WriteLine(d.GetInitials().surname);
                    record.WriteLine(d.GetInitials().name);
                    record.WriteLine(d.GetInitials().patronymic);

                    record.WriteLine(d.GetCurriculum().faculty + " " + d.GetCurriculum().speciality + " " + d.GetCurriculum().cource + " " + d.GetCurriculum().group);
                }

                Console.WriteLine($"Данных: {_data.Length} записанно в файл: {fileName}");
            }
            catch
            {
                Console.WriteLine($"Ошибка при работе с файлом:{fileName} !");
            }
            finally
            {
                record.Close();
            }
        }

        // извлечение данных
        static void DataChange(Data[] _data)
        {
            Console.WriteLine($"Введите необходимый элемент (от 1 до {_data.Length}): ");
            int _n = Convert.ToInt32(Console.ReadLine());
            _n--; // так как вводим от 1

            Console.Clear();

            //проверяем правильность ввода
            if (_n >= 0 && _n < _data.Length)
            {
                // временные переменные
                Initials init;
                Сurriculum curriculum;

                //вводим нужные данные 
                Console.Write("Введите фамилию: ");
                init.surname = Console.ReadLine();
                Console.Write("Введите имя: ");
                init.name = Console.ReadLine();
                Console.Write("Отчетсво: ");
                init.patronymic = Console.ReadLine();

                Console.Write("Введите название факультета: ");
                curriculum.faculty = Console.ReadLine();
                Console.Write("Введите название специальности: ");
                curriculum.speciality = Console.ReadLine();
                Console.Write("Введите номер курса: ");
                curriculum.cource = Console.ReadLine();
                Console.Write("Введите номер группы: ");
                curriculum.group = Console.ReadLine();

                // добавляем ланные в масив данных
                _data[_n].DataEntry(init, curriculum);

                Console.Clear();
                Console.WriteLine($"Данные элемента: {_n + 1} изменены!");
            }
            else
                Console.WriteLine("Номер введен не верно!");
        }

        // удаление данных
        static void DeleteData(ref Data[] _data)
        {
            Console.WriteLine($"Введите необхъодимый элемент (от 1 до {_data.Length}): ");
            int _n = Convert.ToInt32(Console.ReadLine());
            _n--; // так как водим от 1 

            Console.Clear();

            // проверяем правильность ввоа 
            if (_n >= 0 && _n < _data.Length)
            {
                // копируем массив данных с помощью метода Close()
                // иначе можно создать новый массив и каждому элементу нового присвоить значение старого массива в цикле
                // for(....) buf_data[i] = _data[i];
                Data[] buf_data = (Data[])_data.Clone();

                // выделяем новую память для текущего массива 
                int new_size = _data.Length - 1;
                _data = new Data[new_size]; // после этого, данные в массиве сотрутся 

                // считываем данные из временного массива в основной кроме удаяемого 
                int d = 0;
                for (int i = 0; i < buf_data.Length; i++)
                {
                    if (i != _n)
                    {
                        _data[d] = buf_data[i];
                        d++;
                    }
                }

                Console.Clear();
                Console.WriteLine($"Данные №{_n + 1} удалены!");

                // удаляем временный массив
                Array.Clear(buf_data, 0, buf_data.Length);
            }
            else
                Console.WriteLine("Номер введен не верно!");
        }


    }
}
