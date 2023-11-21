namespace Strategy
{
    public enum ChocolateType
    {
        Milk,
        Dark,
        White
    }

    public interface IChocolate
    {
        string GetChocolateType();
    }

    public class MilkChocolate : IChocolate
    {
        public string GetChocolateType()
        {
            return "Milk";
        }
    }

    public class DarkChocolate : IChocolate
    {
        public string GetChocolateType()
        {
            return "Dark";
        }
    }

    public class WhiteChocolate : IChocolate
    {
        public string GetChocolateType()
        {
            return "White";
        }
    }

    public class ChocolateGenerator<CT> where CT : IChocolate, new()
    {
        private IChocolate chocolate = new CT();

        public string GetChocolateType()
        {
            return chocolate.GetChocolateType();
        }
    }
}
