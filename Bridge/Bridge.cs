namespace Bridge
{
    // Bridge pattern lets you split a large class or a set of closely related classes into two separate hierarchies—abstraction and implementation
    // which can be developed independently of each other.
    public interface IRenderer
    {
        string WhatToRenderAs { get; }
    }

    public class VectorRenderer : IRenderer
    {
        public string WhatToRenderAs => "lines";
    }

    public class RasterRenderer : IRenderer
    {
        public string WhatToRenderAs => "pixels";
    }

    public abstract class Shape
    {
        public string Name { get; set; }
    }

    public class Triangle : Shape
    {
        public IRenderer Renderer;

        public Triangle(IRenderer renderer)
        {
            Renderer = renderer;
            Name = "Triangle";
        }
        public override string ToString() => $"Drawing {Name} as lines";

    }

    public class Square : Shape
    {
        public IRenderer Renderer;

        public Square(IRenderer renderer)
        {
            Renderer = renderer;
            Name = "Square";
        }
        public override string ToString() => $"Drawing {Name} as lines";

    }

    public class VectorSquare : Square
    {
        public override string ToString() => $"Drawing {Name} as lines";

        public VectorSquare(VectorRenderer renderer) : base(renderer)
        {
            Renderer = renderer;
            Name = "Square";
        }
    }

    public class RasterSquare : Square
    {
        public override string ToString() => $"Drawing {Name} as pixels";

        public RasterSquare(RasterRenderer renderer) : base(renderer)
        {
            Renderer = renderer;
            Name = "Square";
        }
    }

    // imagine VectorTriangle and RasterTriangle are here too
}