﻿namespace Adapter
{
    // Adapter pattern lets you wrap an otherwise incompatible object in an adapter to make it compatible with another class.
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
        public AdapteeToAdapter(Adaptee adaptee)
        {
            PropertyA = adaptee.Property;
            PropertyB = adaptee.Property;
        }

        public int PropertyA { get; }
        public int PropertyB { get; }
    }
}
