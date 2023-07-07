namespace Factory.AbstractFactory
{
    internal interface IAnimalFactory
    {
        ICat CreateCat();
        IDog CreateDog();
    }

    public class HomeAnimalFactory : IAnimalFactory
    {
        public ICat CreateCat()
        {
            return new HomeCat();
        }

        public IDog CreateDog()
        {
            return new HomeDog();
        }
    }

    public class WildAnimalFactory : IAnimalFactory
    {
        public ICat CreateCat()
        {
            return new WildCat();
        }

        public IDog CreateDog()
        {
            return new WildDog();
        }
    }
}
