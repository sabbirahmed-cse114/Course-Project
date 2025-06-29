using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Text.Json;


namespace iTransition.Forms.Infrastructure.Extensions
{
    public static class TempDataExtensions
    {
        public static void Put<T>(this ITempDataDictionary tempData, string key, T value) where T : class
        {
            tempData[key] = JsonSerializer.Serialize(value);
        }
    }
}
