#if NETCOREAPP
using System.Text.Json;

namespace SilkierQuartz.Helpers
{
    public class JsonPascalCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName( string name )
        {
            return name;
        }
    }
}
#endif