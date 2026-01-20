using System;

namespace HW10
{
    enum Color
    {
        BLACK, WHITE, GREY, BROWN, DARK_BROWN, BLACK_STRIPES, WHITE_STRIPES
    }

    enum Size
    {
        SMALL, MEDIUM, LARGE, HUGE
    }

    abstract class Animal
    {
        protected Color color;
        protected Size size;

        protected Animal(Color color, Size size)
        {
            this.color = color;
            this.size = size;
        }

        public abstract void Sound();
        public abstract void Eat();
    }

    class Mammalia : Animal
    {
        protected int numberBabies;

        public Mammalia(Color color, Size size, int numberBabies)
            : base(color, size)
        {
            this.numberBabies = numberBabies;
        }

        public override void Eat()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Console.WriteLine("Mammalia is running");
        }

        public override void Sound()
        {
            throw new NotImplementedException();
        }
    }

    abstract class Dog : Mammalia
    {
        protected bool fierce;

        internal Dog(Color color, Size size, int numberBabies, bool fierce)
            : base(color, size, numberBabies)
        {
            this.fierce = fierce;
        }

        public void Bark()
        {
            Console.WriteLine("Dog bark");
        }

        public void Bite()
        {
            Console.WriteLine("Dog bite");
        }

        public override void Sound()
        {
            Console.WriteLine("Dog sound");
        }

        public override void Eat()
        {
            Console.WriteLine("Dog eating");
        }
    }

    class ThaiRidgeBack : Dog
    {
        private string origin;

        public ThaiRidgeBack(Color color, Size size, int numberBabies, bool fierce, string origin)
            : base(color, size, numberBabies, fierce)
        {
            this.origin = origin;
        }

        public string Origin => origin;
    }

    class Aves : Animal
    {
        public Aves(Color color, Size size) : base(color, size) { }

        public void Fly()
        {
            Console.WriteLine("Bird is flying");
        }

        public override void Sound()
        {
            Console.WriteLine("Aves sound");
        }

        public override void Eat()
        {
            Console.WriteLine("Aves eating");
        }
    }

    class Bird : Aves
    {
        protected string egg;

        public Bird(Color color, Size size, string egg)
            : base(color, size)
        {
            this.egg = egg;
        }

        public override void Sound()
        {
            Console.WriteLine("Bird sound");
        }

        public override void Eat()
        {
            Console.WriteLine("Bird eating");
        }
    }

    sealed class HummingBird : Bird
    {
        public HummingBird(Color color, Size size, string egg)
            : base(color, size, egg)
        {
        }
    }

    class Osteicthyes : Animal
    {
        public Osteicthyes(Color color, Size size) : base(color, size) { }

        public void Swimming()
        {
            Console.WriteLine("Fish is swimming");
        }

        public override void Sound()
        {
            Console.WriteLine("Fish sound");
        }

        public override void Eat()
        {
            Console.WriteLine("Fish eating");
        }
    }

    class Fish : Osteicthyes
    {
        protected string waterGroup;

        public Fish(Color color, Size size, string waterGroup)
            : base(color, size)
        {
            this.waterGroup = waterGroup;
        }
    }

    class AngelFish : Fish
    {
        private string location;

        public AngelFish(Color color, Size size, string waterGroup, string location)
            : base(color, size, waterGroup)
        {
            this.location = location;
        }

        public string Location => location;
    }
    class Program
    {
        static void Main(string[] args)
        {
            ThaiRidgeBack dog = new ThaiRidgeBack(
                Color.DARK_BROWN,
                Size.MEDIUM,
                3,
                true,
                "Thailand"
            );

            dog.Sound();
            dog.Eat();
            dog.Run();
            dog.Bark();
            dog.Bite();
            Console.WriteLine("Origin: " + dog.Origin);

            HummingBird bird = new HummingBird(Color.WHITE,Size.SMALL,"Small egg");

            bird.Sound();
            bird.Eat();
            bird.Fly();

            AngelFish fish = new AngelFish(Color.WHITE_STRIPES,Size.SMALL,"Fresh Water","Amazon River");

            fish.Sound();
            fish.Eat();
            fish.Swimming();
            Console.WriteLine("Location: " + fish.Location);
        }
    }
}
