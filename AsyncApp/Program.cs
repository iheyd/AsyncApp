namespace AsyncApp
{
    class Program
    {
        private static async Task Main()
        {
            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "TextFiles");
            var fileProcessor = new FileProcessor();

            // Вариант а
            Console.WriteLine("Вариант а:");
            var startTimeA = DateTime.Now;
            await fileProcessor.ProcessFilesAsync(directoryPath, FileProcessor.ReadFileAndCountSpaces);
            var endTimeA = DateTime.Now;
            Console.WriteLine($"Время выполнения: {endTimeA - startTimeA}");

            // Вариант б
            Console.WriteLine("\nВариант б:");
            var startTimeB = DateTime.Now;
            await fileProcessor.ProcessAllFilesAsync(directoryPath);
            DateTime endTimeB = DateTime.Now;
            Console.WriteLine($"Время выполнения: {endTimeB - startTimeB}");

            // Вариант в
            Console.WriteLine("\nВариант в:");
            var startTimeC = DateTime.Now;
            await fileProcessor.ProcessFilesAsync(directoryPath, FileProcessor.ReadFileLineByLineAndCountSpaces);
            var endTimeC = DateTime.Now;
            Console.WriteLine($"Время выполнения: {endTimeC - startTimeC}");
        }
    }
}