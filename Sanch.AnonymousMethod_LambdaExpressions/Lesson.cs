using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanch.AnonymousMethod_LambdaExpressions
{
    class Lesson
    {
        public string Name { get; set; }
        public DateTime Begin { get; private set; }
        public event EventHandler<DateTime> Started; //делигат с аргуметами object and datatime 
        public Lesson(string name) //конструктор
        {
            //Проверка входных аргументов

            Name = name;
        }
        public void Start()//метод
        {
            Begin = DateTime.Now;
            Started?.Invoke(this, Begin); //вызов
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
