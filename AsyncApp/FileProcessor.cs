namespace AsyncApp
{
    public class FileProcessor
    {
        public async Task ProcessFilesAsync(string directoryPath, Func<string, Task<int>> countSpacesFunc)
        {
            var files = Directory.GetFiles(directoryPath, "*.txt");
            var tasks = files.Select(countSpacesFunc);
            var results = await Task.WhenAll(tasks);

            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"Файл: {Path.GetFileName(files[i])}, Пробелов: {results[i]}");
            }
        }

        public static async Task<int> ReadFileAndCountSpaces(string filePath)
        {
            string content = await File.ReadAllTextAsync(filePath);
            return SpaceCounter.CountSpaces(content);
        }

        public async Task ProcessAllFilesAsync(string directoryPath)
        {
            await ProcessFilesAsync(directoryPath, ReadFileAndCountSpaces);
        }

        public static async Task<int> ReadFileLineByLineAndCountSpaces(string filePath)
        {
            int spaceCount = 0;
            using (var reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    spaceCount += SpaceCounter.CountSpaces(line);
                }
            }
            return spaceCount;
        }
    }
}