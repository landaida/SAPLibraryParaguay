﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SAPLibraryParaguay
{
    public class ToStringBuilder<T>
    {
        private readonly T target;
        private readonly string typeName;
        private const string DELIMITER = "=";
        private IList<string> values = new List<string>();

        public ToStringBuilder(T target)
        {
            this.target = target;
            typeName = target.GetType().Name;
        }

        public ToStringBuilder<T> Append<TProperty>(Expression<Func<T, TProperty>> propertyOrField)
        {
            var expression = propertyOrField.Body as MemberExpression;
            if (expression == null)
            {
                throw new ArgumentException("Expecting Property or Field Expression");
            }
            var name = expression.Member.Name;
            var func = propertyOrField.Compile();
            var returnValue = func(target);
            string value = (returnValue == null) ? "null" : returnValue.ToString();
            values.Add(name + DELIMITER + value);
            return this;
        }

        public override string ToString()
        {
            return typeName + ":{" + string.Join(",", values) + "}";
        }
    }
}
