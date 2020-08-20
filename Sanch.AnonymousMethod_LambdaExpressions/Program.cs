using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Sanch.AnonymousMethod_LambdaExpressions
{
    class Program
    {
        public delegate int MyHandler(int i);//создаем делегат
        static void Main(string[] args)
        {

            var lesson = new Lesson("Программирование С#"); //создаем объект класса
            lesson.Started += (sender, date) => // есть событие начала урока - делаем обработчик события
            {
                Console.WriteLine(sender); // объект (Lesson) помещается в сендер 
                Console.WriteLine(date); //вызов из события
            };
            lesson.Start();

            var list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }
            var res = list.Aggregate((x, y) => x + y);
            Console.WriteLine(res);


            var result1 = Agr(list, delegate (int i)//в созданный делегат засунули анонимный метод
            {
                var r = i * i;
                Console.WriteLine(r);
                return r;
            }); // с делигатом прописанным ( анонимный метод )

            var result2 = Agr(list, Method); // с именным методом 

            var result3 = Agr(list, x => x * x * x * x); // c лямбда выражение












            /*
            MyHandler handler = delegate (int i) //тип_аргумента аргумент1, тип_аргумента аргумент2, ...
            {
            //реализация анонимного метода 
            // return i*i;
            };
            */
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                MyHandler handler = delegate (int i)//в созданный делегат засунули анонимный метод
                {
                    var r = i * i;
                    Console.WriteLine(r);
                    return r;
                };
                //если мы хотим поместить в наш делигат метод, то можно сделать 
                handler += Method;
                handler(result);
                //в один и тот же делигат поместили как анонимный метод так и неанонимный метод и вызвали их



                ////////ЛЯМБДА - ВЫРАЖЕНИЯ//////////////////////////////////////////////
                MyHandler lambdaHandler = (i) => // аргументы без типа указываем, лямбда-оператор - =>
                {
                    var r = i * i;
                    Console.WriteLine(r);
                    return r;
                };
                /*
                MyHandler lambdaHandler = (i) => i * i; можно так если одна операция(одно выражение) без скобок {}
                */
                lambdaHandler(99);//вызов лямбда - выражения


            }

            Console.ReadKey();
        }
        public static int Agr(List<int> list, MyHandler handler)
        {
            int result = 0;
            foreach (var item in list)
            {
                result += handler(item);
            }
            return result;
        }

        public static int Method(int i)
        {
            var r = i * i * i;
            Console.WriteLine(r);
            return r;
        }
    }
}
