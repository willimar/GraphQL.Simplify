﻿using graph.simplify.consumer.enums;
using graph.simplify.consumer.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace graph.simplify.consumer.abstractions
{
    internal class ArgumentAbs : IArgument
    {
        public string Name { get; }

        public List<ICheck> Checks { get; }

        public IArgument AppendCheck(OperationType operation, Statement connector, object value)
        {
            this.Checks.Add(new CheckAbs()
            {
                Connector = connector,
                Operation = operation,
                Value = value,
                Order = Order.none
            });

            return this;
        }

        public IArgument AppendCheck(Order order)
        {
            this.Checks.Add(new CheckAbs()
            {
                Order = order
            });

            return this;
        }

        public ArgumentAbs(string name)
        {
            this.Checks = new List<ICheck>();
            this.Name = name;
        }
    }
}
