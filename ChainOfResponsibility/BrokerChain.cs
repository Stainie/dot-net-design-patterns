using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    /*
     *     * Broker chain is a linked list of modifiers that can be applied to a model.
     *         * It is used when you want to apply a series of modifiers to a model.
     *             * This is for more flexible instances, when we want to keep the modifications temporary.
     *                 */
    public class Query
    {
        public string Name { get; set; }

        public enum Argument
        {
            Prop1,
            Prop2
        }

        public Argument ArgumentToQuery { get; set; }

        public int Value { get; set; }

        public Query(string name, Argument argumentToQuery, int value)
        {
            Name = name;
            ArgumentToQuery = argumentToQuery;
            Value = value;
        }
    }

    public class BrokerEventHandler
    {
        public event EventHandler<Query> Events;

        public void HandleQuery(object sender, Query query)
        {
            Events?.Invoke(sender, query);
        }
    }

    public class BrokerChainModel
    {
        private BrokerEventHandler queryHandler;
        public string Name { get; set; }

        private int prop1, prop2;

        public BrokerChainModel(BrokerEventHandler queryHandler, string name, int prop1, int prop2)
        {
            this.queryHandler = queryHandler;
            Name = name;
            this.prop1 = prop1;
            this.prop2 = prop2;
        }

        public int Prop1
        {
            get
            {
                var query = new Query(Name, Query.Argument.Prop1, 0);
                queryHandler.HandleQuery(this, query);
                return query.Value;
            }
        }

        public int Prop2
        {
            get
            {
                var query = new Query(Name, Query.Argument.Prop2, 0);
                queryHandler.HandleQuery(this, query);
                return query.Value;
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Prop1: {Prop1}, Prop2: {Prop2}";
        }
    }

    public abstract class QueryModifier : IDisposable
    {
        protected BrokerEventHandler eventHandler;
        protected BrokerChainModel model;

        public QueryModifier(BrokerEventHandler queryHandler, BrokerChainModel queryModel)
        {
            this.eventHandler = queryHandler;
            this.model = queryModel;
            queryHandler.Events += HandleQuery;
        }

        protected abstract void HandleQuery(object sender, Query query);

        public void Dispose()
        {
            eventHandler.Events -= HandleQuery;
        }
    }

    public class QueryProp1Modifier : QueryModifier
    {
        public QueryProp1Modifier(BrokerEventHandler eventHandler, BrokerChainModel model) : base(eventHandler, model)
        {
        }

        protected override void HandleQuery(object sender, Query query)
        {
            if (query.Name == model.Name && query.ArgumentToQuery == Query.Argument.Prop1)
                query.Value++;
        }
    }
}
