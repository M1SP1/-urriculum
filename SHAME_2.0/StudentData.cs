using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDatabase
{

    struct Initials
    {
        public string surname;
        public string name;
        public string patronymic;
    }

    struct Сurriculum
    {
        public string faculty;
        public string speciality;
        public string course;
        public string group;
    }
    class Data
    {
        
        private Initials init;
        private Сurriculum curriculum;

        public Data() { }
        public Data(Initials init, Сurriculum curriculum)
        {
            this.init = init;
            this.curriculum = curriculum;
        }

        public void DataEntry(Initials init, Сurriculum curriculum)
        {
            this.init = init;
            this.curriculum = curriculum;
        }

        public void Print()
        {
            Console.WriteLine($"ФИО: {init.surname} {init.name} {init.patronymic}");
            Console.WriteLine("Факультет: " + curriculum.faculty);
            Console.WriteLine("Специальность: " + curriculum.speciality);
            Console.WriteLine("Курс: " + curriculum.course);
            Console.WriteLine("Группа: " + curriculum.group);
        }

        public Initials GetInitials() { return init; }

        public Сurriculum GetCurriculum() { return curriculum; }
    }
}
