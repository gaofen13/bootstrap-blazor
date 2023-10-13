using System.Collections;

namespace BootstrapBlazor
{
    public class ComponentParameters : IEnumerable<KeyValuePair<string, object>>
    {
        internal readonly Dictionary<string, object?> Parameters;

        public ComponentParameters()
        {
            Parameters = [];
        }

        public ComponentParameters Add(string parameterName, object? value)
        {
            Parameters[parameterName] = value;
            return this;
        }

        public T? Get<T>(string parameterName)
        {
            if (Parameters.TryGetValue(parameterName, out var value))
            {
                if (value == null)
                {
                    return default;
                }
                return (T)value;
            }

            throw new KeyNotFoundException($"{parameterName} does not exist in parameters");
        }

        public T? TryGet<T>(string parameterName)
        {
            if (Parameters.TryGetValue(parameterName, out var value))
            {
                if (value == null)
                {
                    return default;
                }
                return (T)value;
            }

            return default;
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => Parameters.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Parameters.GetEnumerator();
    }
}
