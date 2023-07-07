namespace Factory.AbstractFactory
{
    public interface IDog : IAnimal
    {
    }

    public class HomeDog : IDog
    {
        public IAnimal Eat()
        { 
            Console.WriteLine("Dog eats in the home");
            return this;
        }

        public IAnimal Sleep()
        {
            Console.WriteLine("Dog sleeps in the bed");
            return this;
        }
    }

    public class WildDog : IDog
    {
        public IAnimal Eat()
        {
            Console.WriteLine("Dog eats in the wild");
            return this;
        }
        public IAnimal Sleep()
        {
            Console.WriteLine("Dog sleeps in the tree");
            return this;
        }
    }
}
