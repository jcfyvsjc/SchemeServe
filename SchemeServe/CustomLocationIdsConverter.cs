using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SchemeServe.Controllers;

public class CustomLocationIdsConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(string[]);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JArray array = JArray.Load(reader);
        string[] locationIdsArray = array.ToObject<string[]>();
        
        return locationIdsArray;
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        string[] locationIdsArray = (string[])value;
        string locationIds = string.Join(",", locationIdsArray);
        
        writer.WriteValue(locationIds);
    } 
    
    public override bool CanWrite => true;
}