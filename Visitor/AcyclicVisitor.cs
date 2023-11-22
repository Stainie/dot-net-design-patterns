using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public interface IAcyclicVisitor<T>
    {
        void Visit(T visitor);
    }

    public interface IAcyclicVisitor // Degenerate interface - used for type checking (without generics)
    {
    }

    public abstract class AcyclicExpression
    {
        public virtual void Accept(IAcyclicVisitor visitor)
        {
            if (visitor is IAcyclicVisitor<AcyclicExpression> typedVisitor)
            {
                typedVisitor.Visit(this);
            }
        }
    }

    public class AcyclicDoubleExpression : AcyclicExpression
    {
        public double Value { get; }

        public AcyclicDoubleExpression(double value)
        {
            Value = value;
        }

        public override void Accept(IAcyclicVisitor visitor)
        {
            if (visitor is IAcyclicVisitor<AcyclicDoubleExpression> typedVisitor)
            {
                typedVisitor.Visit(this);
            }
        }
    }

    public class AcyclicAdditionExpression : AcyclicExpression
    {
        public AcyclicExpression Left { get; }
        public AcyclicExpression Right { get; }

        public AcyclicAdditionExpression(AcyclicExpression left, AcyclicExpression right)
        {
            Left = left;
            Right = right;
        }

        public override void Accept(IAcyclicVisitor visitor)
        {
            if (visitor is IAcyclicVisitor<AcyclicAdditionExpression> typedVisitor)
            {
                typedVisitor.Visit(this);
            }
        }
    }

    public class AcyclicExpressionPrinter : IAcyclicVisitor, IAcyclicVisitor<AcyclicExpression>, IAcyclicVisitor<AcyclicDoubleExpression>, IAcyclicVisitor<AcyclicAdditionExpression>
    {
        private StringBuilder sb = new StringBuilder();

        public void Visit(AcyclicExpression obj)
        {
            sb.Append(obj);
        }

        public void Visit(AcyclicDoubleExpression obj)
        {
            sb.Append(obj.Value);
        }

        public void Visit(AcyclicAdditionExpression obj)
        {
            sb.Append("(");
            obj.Left.Accept(this);
            sb.Append("+");
            obj.Right.Accept(this);
            sb.Append(")");
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }

}
