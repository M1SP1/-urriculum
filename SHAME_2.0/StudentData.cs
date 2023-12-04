using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace StudentDatabase
{

    struct Initials
    {
        [JsonInclude]
        public string surname;
        [JsonInclude]
        public string name;
        [JsonInclude]
        public string patronymic;
    }

    struct Сurriculum
    {
        [JsonInclude]
        public string faculty;
        [JsonInclude]
        public string speciality;
        [JsonInclude]
        public string course;
        [JsonInclude]
        public string group;
    }
    class Data
    {
        [JsonInclude]
        private Initials init;
        [JsonInclude]
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
