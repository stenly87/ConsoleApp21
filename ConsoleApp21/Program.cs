using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    class Program
    {
        public object Name { get; internal set; }

        static void Main(string[] args)
        {
            Human human1 = new Human {  Talant = "Болтать"};
            human1.SayHello();
            Human human2 = new Human { Talant = "ПисАть"};
            human2.SayHello();

            Human human3 = human2 + human2 + human1 + human1 + human2;
            Console.WriteLine(human3.Talant);

            human3 = human2 + human1;
            Console.WriteLine(human3.Talant);
        }
    }

    // операторы: +-/* &|!^ (type)obj
    // 
    class Human
    {
        public string Talant { get; set; }

        public virtual void SayHello()
        {
            Console.WriteLine("hello");
        }

        // оператор преобразования типа
        // public static explicit|implicit operator Целевой_тип(Тип obj)
        // explicit указывается для явного преобразования human = (Human)kiborg;
        // implicit - для неявного преобразования human = kiborg;
        public static explicit operator Program(Human h1)
        {
            return new Program();
        }

        // перегрузка стандартных операторов
        // public static Тип operator Оператор(аргументы)
        public static Human operator +(Human h1, Human h2)
        {
            if (h1.Talant =="ПисАть" && 
                h2.Talant == "Болтать" ||
                h2.Talant == "ПисАть" &&
                h1.Talant == "Болтать")
                return new Human { Talant = "Журналист" };
            return new Human { Talant = "Оболтус" };
        }
    }

    class Kiborg : Human
    {
        public override void SayHello()
        {
            Console.WriteLine("zzzz");
        }
    }
}
