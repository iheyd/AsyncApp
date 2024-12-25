namespace AsyncApp
{
    public static class SpaceCounter
    {
        public static int CountSpaces(string content)
        {
            return content.Count(c => c == ' ');
        }
    }
}