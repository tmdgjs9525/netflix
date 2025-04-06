using System.Collections.Generic;

namespace netflix.Parameter
{
    public class Parameters : Dictionary<string, object>
    {
        public T GetValue<T>(string key)
        {
            if (TryGetValue(key, out var value) && value is T typedValue)
            {
                return typedValue;
            }

            throw new KeyNotFoundException($"The key '{key}' was not found.");
        }
    }
}
