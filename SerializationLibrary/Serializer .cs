using System;
using System.IO;
using System.Text.Json;

namespace SerializationLibrary
{
    public class Serializer
    {
        public static void Serialize<T>(T data, string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var jsonData = JsonSerializer.Serialize(data, options);
                File.WriteAllText(filePath, jsonData);
            }
            catch (Exception ex)
            {
                throw new SerializationException("Ошибка при сериализации данных", ex);
            }
        }

        public static T Deserialize<T>(string filePath)
        {
            try
            {
                string jsonData;
                using (var fileStream = File.OpenRead(filePath))
                using (var streamReader = new StreamReader(fileStream))
                {
                    jsonData = streamReader.ReadToEnd();
                }
                return JsonSerializer.Deserialize<T>(jsonData);
            }
            catch (Exception ex)
            {
                throw new SerializationException("Ошибка при десериализации данных", ex);
            }
        }
    }

    public class SerializationException : Exception
    {
        public SerializationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
