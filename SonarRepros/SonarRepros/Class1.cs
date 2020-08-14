using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonarRepros
{
    public enum ValueType
    {
        Array, 
        Integer,
        String,
        Null
    }
    public class ValueHolder
    {
        public ValueType Type { get; set; }
        public object Value { get; set; }
    }

    public class FalsePositiveSwitchNull
    {
        public bool IsEmpty(ValueHolder holder)
        {
            switch (holder?.Type)
            {
                case ValueType.Array:
                    return ((Array) holder.Value).Length == 0;
                case ValueType.Integer:
                    return ((int) holder.Value) == 0;
                case ValueType.String:
                    return string.IsNullOrWhiteSpace((string) holder.Value);
                case ValueType.Null:
                case null:
                    return true;
                default:
                    return false;
            }
        }

    }
}
