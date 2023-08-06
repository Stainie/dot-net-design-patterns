using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
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

    public class EventHandler
    {
        public event EventHandler<Query> Events;

        public void HandleQuery(object sender, Query query)
        {
            Events?.Invoke(sender, query);
        }
    }

    public class BrokerChainModel
    {
        private EventHandler queryHandler;
        public string Name { get; set; }

        private int prop1, prop2;

        public BrokerChainModel(EventHandler queryHandler, string name, int prop1, int prop2)
        {
            this.queryHandler = queryHandler;
            Name = name;
            this.prop1 = prop1;
            this.prop2 = prop2;
        }

        public int GetProp(Query.Argument argument)
        {
            var query = new Query(Name, argument, 0);
            queryHandler.HandleQuery(this, query);
            return query.Value;
        }
    }

    public abstract class QueryModifier : IDisposable
    {
        protected EventHandler eventHandler;
        protected BrokerChainModel model;

        public QueryModifier(EventHandler queryHandler, BrokerChainModel queryModel)
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
        public QueryProp1Modifier(EventHandler eventHandler, BrokerChainModel model) : base(eventHandler, model)
        {
        }

        protected override void HandleQuery(object sender, Query query)
        {
            if (query.Name == model.Name && query.ArgumentToQuery == Query.Argument.Prop1)
                query.Value++;
        }
    }
}
