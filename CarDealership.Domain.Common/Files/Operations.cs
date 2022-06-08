namespace CarDealership.Domain.Common.Files
{
    public class Operations : IOperations
    {
        public string GetTextFile(string path)
        {
            var fileReader = System.IO.File.OpenText(path);

            return fileReader.ReadToEnd();
        }
    }
}
