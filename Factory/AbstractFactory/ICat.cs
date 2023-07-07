namespace Factory.AbstractFactory
{
    public interface ICat : IAnimal
    {
    }

    public class HomeCat : ICat
    {
        public IAnimal Eat()
        {
            Console.WriteLine("Cat eats in the home");
            return this;
        }
        public IAnimal Sleep()
        {
            Console.WriteLine("Cat sleeps in the bed");
            return this;
        }
    }

    public class WildCat : ICat
    {
        public IAnimal Eat()
        {
            Console.WriteLine("Cat eats in the wild");
            return this;
        }

        public IAnimal Sleep()
        {
            Console.WriteLine("Cat sleeps in the tree");
            return this;
        }
    }
}
