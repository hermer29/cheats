using System;
using System.Collections.Generic;

namespace Hermer29.Cheats.DebugValues
{
    internal class CockpitReadOnlyModel
    {
        private Dictionary<string, string> _values = new Dictionary<string, string>();

        internal event Action<string, string> ValueDefined;
        internal event Action<string, string> ValueChanged;
        
        internal void SetValue(string key, object value)
        {
            if (_values.ContainsKey(key) == false)
            {
                _values.Add(key, value.ToString());
                ValueDefined.Invoke(key, value.ToString());
                return;
            }
            _values[key] = value.ToString();
            ValueChanged.Invoke(key, value.ToString());
        }
    }
}