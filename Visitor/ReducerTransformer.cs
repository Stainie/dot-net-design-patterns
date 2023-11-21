using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public interface ITransform<out R>
    {
        R Transform(DoubleReducer dr);
        R Transform(AdditionReducer ar);
    }

    public abstract class Reducer
    {
        public abstract T Reduce<T>(ITransform<T> transform);
    }

    public class DoubleReducer : Reducer
    {
        public double Value { get; }

        public DoubleReducer(double value)
        {
            Value = value;
        }
        public override T Reduce<T>(ITransform<T> transform)
        {
            return transform.Transform(this);
        }
    }

    public class AdditionReducer : Reducer
    {
        public Reducer Left { get; }
        public Reducer Right { get; }

        public AdditionReducer(Reducer left, Reducer right)
        {
            Left = left;
            Right = right;
        }

        public override T Reduce<T>(ITransform<T> transform)
        {
            return transform.Transform(this);
        }

    }

    public class PrintTransformer : ITransform<string>
    {
        public string Transform(DoubleReducer dr)
        {
            return dr.Value.ToString();
        }

        public string Transform(AdditionReducer ar)
        {
            return $"({ar.Left.Reduce(this)} + {ar.Right.Reduce(this)})";
        }
    }

    public class SquareTransformer : ITransform<Reducer>
    {
        public Reducer Transform(DoubleReducer dr)
        {
            return new DoubleReducer(dr.Value * dr.Value);
        }

        public Reducer Transform(AdditionReducer ar)
        {
            return new AdditionReducer(ar.Left.Reduce(this), ar.Right.Reduce(this));
        }

    }
}
