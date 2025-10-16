﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace Tools.Serialization
{
    public class StringValueProvider : IValueProvider
    {
        private readonly string _value;

        public StringValueProvider(string value)
        {
            _value = value;
        }

        public object GetValue(object target)
        {
            return _value;
        }

        public void SetValue(object target, object? value)
        {
            throw new NotImplementedException();
        }
    }
}
