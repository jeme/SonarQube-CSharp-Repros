using Newtonsoft.Json.Linq;
using System;

namespace SonarRepros
{

    public class FalsePositiveSwitchNull
    {
        public bool IsEmpty(JToken token)
        {
            switch (token?.Type)
            {
                case JTokenType.Array:
                    return !token.HasValues;
                case JTokenType.Integer:
                case JTokenType.Float:
                    return 0 == (int)token;
                case JTokenType.String:
                    return bool.FalseString.Equals((string)token, StringComparison.OrdinalIgnoreCase);
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
}
