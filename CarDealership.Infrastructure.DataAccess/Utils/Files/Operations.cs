using System.IO;
using System.Text.Json;

namespace CarDealership.Infrastructure.DataAccess.Utils.Files
{
    public class Operations 
    {
        public static string GetTextFile(string path)
        {
            var fileReader = File.OpenText(path);

            var file = fileReader.ReadToEnd();

            fileReader.Close();

            return file;
        }

        public static bool SaveTextFile<T>(T entity, string path)
        {
            try
            {
                var jsonEntity = JsonSerializer.Serialize(entity);

                File.WriteAllText(path, jsonEntity);

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
