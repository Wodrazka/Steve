using Newtonsoft.Json;

namespace Steve.Logger.Misc
{
    public class FileTimeSpanConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value! ?? "";

            return Enum.Parse(typeof(FileTimeSpan), enumString, true);
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            writer.WriteValue(Enum.GetName(typeof(FileTimeSpan), value ?? ""));
        }
    }
}
