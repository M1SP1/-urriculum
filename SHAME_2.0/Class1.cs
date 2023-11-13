using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHAME_2._0
{

    struct Initials // структура ФИО 
    {
        public string surname;
        public string name;
        public string patronymic;
    }

    struct Сurriculum // Структура адрес
    {
        public string faculty;
        public string speciality;
        public string cource;
        public string group;
    }
    class Data // класс Данные 
    {
        // поля класса
        private Initials init;
        private Сurriculum curriculum;

       public Data() { } // конструктор для создания пустого объекта 
        public Data(Initials init_, Сurriculum curriculum_) // конструктор с параметрами
        {
            init = init_;
            curriculum = curriculum_;
        }

        public void DataEntry(Initials init_, Сurriculum curriculum_) // ввод данных, как конструктор с параметрами, но только метод 
        {
            init = init_;
            curriculum = curriculum_;
        }

        public void Print() // вывод данных в консоль
        {
            Console.WriteLine("ФИО: " + init.surname + " " + init.name + " " + init.patronymic);
            Console.WriteLine($"Факультет: {curriculum.faculty}\n" +
                $"Специальность: {curriculum.speciality}\n" +
                $"Курс: {curriculum.cource}\n" +
                $"Группа: {curriculum.group}");
        }

        // так как поля закрыты от внешнего доступа, пригодятся методы, которые смогут выдать информацию об этих полях
        public Initials GetInitials() { return init; } // вывод из класса поля Инициалы 

        public Сurriculum GetCurriculum() { return curriculum; } // вывод из класса поля Учебный план
    }
}
