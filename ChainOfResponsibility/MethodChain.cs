using System.Reflection.Metadata;
using System.Text;

namespace ChainOfResponsibility
{
    /*
     * Method chain is a linked list of modifiers that can be applied to a model.
     * It is used when you want to apply a series of modifiers to a model.
     * This is for less flexible instances, when we want to keep the modifications permanent.
     */
    public class MethodChainModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public MethodChainModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}";
        }
    }

    public class ChainModifier
    {
        protected MethodChainModel model;
        protected ChainModifier next;   // linked list structure

        public ChainModifier(MethodChainModel model) => this.model = model;

        public ChainModifier Add(ChainModifier modifier)
        {
            if (next == null)
                next = modifier;
            else
                next.Add(modifier);
            return modifier;
        }

        public virtual void Handle() => next?.Handle();
    }

    public class ModelModifier : ChainModifier
    {
        public ModelModifier(MethodChainModel model) : base(model)
        {
        }

        public override void Handle()
        {
            model.Name = model.Name.ToUpper();
            base.Handle();
        }
    }
}