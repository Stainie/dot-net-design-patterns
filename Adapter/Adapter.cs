namespace Adapter
{
    public class Adaptee
    {
        public int Property;
    }

    public interface IAdapter
    {
        int PropertyA { get; }
        int PropertyB { get; }
    }

    public static class ExtensionMethods
    {
        public static int PropSum(this IAdapter ia)
        {
            return ia.PropertyA + ia.PropertyB;
        }
    }

    public class AdapteeToAdapter : IAdapter
    {
        public AdapteeToAdapter(Adaptee square)
        {
            PropertyA = square.Property;
            PropertyB = square.Property;
        }

        public int PropertyA { get; }
        public int PropertyB { get; }
    }
}
