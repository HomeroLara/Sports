using System;
using System.Collections.Generic;
using System.Text;
using Sports.Core.Models.Navigation;

namespace Sports.Core.Services
{
    public interface INavigationParameters : IEnumerable<NavigationParameter>
    {
        void Add(string key, object value);
        bool ContainsKey(string key);
        int Count { get; }
        bool HasData { get; }
        IEnumerable<string> Keys { get; }
        string ToQueryStringParameters();
        T GetValue<T>(string key);
        bool TryGetValueByType<T>(out T value);
        IEnumerable<T> GetValues<T>(string key);
        bool TryGetValue<T>(string key, out T value);
        object this[string key] { get; }
    }
}
