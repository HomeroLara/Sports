using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sports.Core.Models.Navigation;

namespace Sports.Core.Services
{
    public class NavigationParameters : INavigationParameters
    {
        #region PRIVATE MEMBERS
        private readonly List<NavigationParameter> _entries = new List<NavigationParameter>();
        #endregion

        #region CONSTRUCTORS
        public NavigationParameters()
        {
        }

        protected NavigationParameters(string query)
        {
            if (!string.IsNullOrWhiteSpace(query))
            {
                int num = query.Length;
                for (int i = ((query.Length > 0) && (query[0] == '?')) ? 1 : 0; i < num; i++)
                {
                    int startIndex = i;
                    int num4 = -1;
                    while (i < num)
                    {
                        char ch = query[i];
                        if (ch == '=')
                        {
                            if (num4 < 0)
                            {
                                num4 = i;
                            }
                        }
                        else if (ch == '&')
                        {
                            break;
                        }
                        i++;
                    }
                    string key = null;
                    string value = null;
                    if (num4 >= 0)
                    {
                        key = query.Substring(startIndex, num4 - startIndex);
                        value = query.Substring(num4 + 1, (i - num4) - 1);
                    }
                    else
                    {
                        value = query.Substring(startIndex, i - startIndex);
                    }

                    if (key != null)
                        Add(Uri.UnescapeDataString(key), Uri.UnescapeDataString(value));
                }
            }
        }
        #endregion

        #region IMPLEMENTATION
        public object this[string key]
        {
            get
            {
                return _entries.FirstOrDefault(x => string.Equals(x.Key == key, StringComparison.OrdinalIgnoreCase));
            }
        }

        public int Count => _entries.Count;
        public bool HasData => _entries.Any();

        public IEnumerable<string> Keys => _entries.Select(x => x.Key);

        public void Add(string key, object value) => _entries.Add(new NavigationParameter(key, value, value.GetType()));

        public void Add(List<NavigationParameter> parameters) => _entries.AddRange(parameters);

        public bool ContainsKey(string key) => _entries.Exists(x => x.Key.Equals(key, StringComparison.OrdinalIgnoreCase));

        public IEnumerator<NavigationParameter> GetEnumerator() => _entries.GetEnumerator();

        public T GetValue<T>(string key)
        {
            var type = typeof(T);

            foreach (var kvp in _entries)
            {
                if (string.Equals(kvp.Key, key, StringComparison.OrdinalIgnoreCase) && type == kvp.Type)
                {
                    return (T)kvp.Value;
                }
            }

            return default(T);
        }

        private static bool TryGetValueInternal(NavigationParameter navigationParameter, Type type, out object value)
        {
            var success = false;
            value = GetDefault(type);


            if (navigationParameter.Value == null)
            {
                success = true;
            }
            else if (navigationParameter.Type == type)
            {
                success = true;
                value = navigationParameter.Value;
            }
            else if (type.IsAssignableFrom(navigationParameter.Type))
            {
                success = true;
                value = navigationParameter.Value;
            }
            else if (type.IsEnum)
            {
                var valueAsString = navigationParameter.Value.ToString();
                if (Enum.IsDefined(type, valueAsString))
                {
                    success = true;
                    value = Enum.Parse(type, valueAsString);
                }
                else if (int.TryParse(valueAsString, out var numericValue))
                {
                    success = true;
                    value = Enum.ToObject(type, numericValue);
                }
            }

            if (!success && type.GetInterface("System.IConvertible") != null)
            {
                success = true;
                value = Convert.ChangeType(navigationParameter.Value, type);
            }

            return success;
        }

        public object GetValue(string key, Type type)
        {

            foreach (var kvp in _entries)
            {
                if (string.Equals(kvp.Key, key, StringComparison.OrdinalIgnoreCase) && kvp.Value.GetType() == type)
                {
                    if (TryGetValueInternal(kvp, type, out var value))
                        return value;

                    throw new InvalidCastException($"Unable to convert the value of Type '{kvp.Value.GetType().FullName}' to '{type.FullName}' for the key '{key}' ");
                }
            }

            return GetDefault(type);
        }

        public IEnumerable<T> GetValues<T>(string key)
        {
            List<T> values = new List<T>();
            var type = typeof(T);

            foreach (var kvp in _entries)
            {
                if (string.Equals(kvp.Key, key, StringComparison.OrdinalIgnoreCase) && kvp.Value.GetType() == type)
                {
                    TryGetValueInternal(kvp, type, out var value);
                    values.Add((T)value);
                }
            }

            return values.AsEnumerable();
        }

        public bool TryGetValue<T>(string key, out T value)
        {
            var type = typeof(T);

            foreach (var kvp in _entries)
            {
                if (string.Equals(kvp.Key, key, StringComparison.OrdinalIgnoreCase) && kvp.Value.GetType() == type)
                {
                    var success = TryGetValueInternal(kvp, typeof(T), out object valueAsObject);
                    value = (T)valueAsObject;
                    return success;
                }
            }

            value = default(T);
            return false;
        }

        public bool TryGetValueByType<T>(out T value)
        {
            var type = typeof(T);
            foreach (var kvp in _entries)
            {
                if (kvp.Type == type)
                {
                    value = (T)kvp.Value;
                    return true;
                }
            }

            value = default(T);
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public string ToQueryStringParameters()
        {
            var queryBuilder = new StringBuilder();

            if (_entries.Count > 0)
            {
                queryBuilder.Append('?');
                var first = true;

                foreach (var kvp in _entries)
                {
                    if (!first)
                    {
                        queryBuilder.Append('&');
                    }
                    else
                    {
                        first = false;
                    }

                    queryBuilder.Append(Uri.EscapeDataString(kvp.Key));
                    queryBuilder.Append('=');
                    queryBuilder.Append(Uri.EscapeDataString(kvp.Value != null ? kvp.Value.ToString() : ""));
                }
            }

            return queryBuilder.ToString();
        }

        private static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }
        #endregion
    }
}
