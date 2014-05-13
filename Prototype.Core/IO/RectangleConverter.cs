using System;
using System.Text.RegularExpressions;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;

namespace Prototype.Core.IO
{
    public class RectangleConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Rectangle);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString().Replace("\"", "").Replace(' ', ','));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType != typeof(Rectangle))
                return serializer.Deserialize(reader);

            var valores = reader.Value.ToString().Split(',');
            var model = new Rectangle();

            model.X = Convert.ToInt32(Regex.Replace(valores[0], "[^0-9]", ""));
            model.Y = Convert.ToInt32(Regex.Replace(valores[1], "[^0-9]", ""));
            model.Width = Convert.ToInt32(Regex.Replace(valores[2], "[^0-9]", ""));
            model.Height = Convert.ToInt32(Regex.Replace(valores[3], "[^0-9]", ""));

            return model;
        }
    }
}