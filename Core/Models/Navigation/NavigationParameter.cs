using System;

namespace Sports.Core.Models.Navigation
{
    public class NavigationParameter
    {
        public string Key { get; set; }
        public object Value { get; set; }
        public Type Type { get; }

        public NavigationParameter(string key, object value, Type type)
        {
            Key = key;
            Value = value;
            Type = type;
        }
    }
}
