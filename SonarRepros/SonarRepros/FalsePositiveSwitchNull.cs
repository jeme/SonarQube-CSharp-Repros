using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

namespace SonarRepros
{

    public class FalsePositiveSwitchNull
    {
        public static readonly FakeReadOnly<int> fakeCollectione = new FakeReadOnly<int>(true);
        public static readonly TrueReadOnly<int> trueCollection = new TrueReadOnly<int>();

        public bool IsEmpty(JToken token)
        {
            switch (token?.Type)
            {
                case JTokenType.Array:
                    return !token.HasValues;
                case JTokenType.Integer:
                case JTokenType.Float:
                    return 0 == (int) token;
                case JTokenType.String:
                    return bool.FalseString.Equals((string) token, StringComparison.OrdinalIgnoreCase);
                case JTokenType.Boolean:
                    return !(bool)token;
                case JTokenType.Null:
                case JTokenType.Undefined:
                case null:
                    return true;
                default:
                    return false;
            }
        }

        public bool NullOrEmpty(JToken token)
        {
            return token == null || token.Type == JTokenType.Null ||
                (token.Type == JTokenType.Array && !token.HasValues) ||
                (token.Type == JTokenType.Object && !token.HasValues) ||
                (token.Type == JTokenType.String && string.IsNullOrWhiteSpace((string)token));
        }

    }

    public class TrueReadOnly<T> : IReadOnlyCollection<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count { get; }
    }

    public class FakeReadOnly<T> : ICollection<T>, IReadOnlyCollection<T>
    {
        public FakeReadOnly(bool isReadOnly = true)
        {
            IsReadOnly = isReadOnly;
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        int ICollection<T>.Count => 0;

        public bool IsReadOnly { get; }

        int IReadOnlyCollection<T>.Count => 0;
    }
}
