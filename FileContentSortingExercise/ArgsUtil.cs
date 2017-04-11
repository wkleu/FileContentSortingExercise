namespace FileContentSortingExercise
{
    public static class ArgsUtil
    {
        /**
         * Retrieves an argument at supplied index or revert to default value
         */
        public static string GetArgument(string[] args, int indexRequired, string defaultValue)
        {
            var filePath = defaultValue;
            if (args.Length > indexRequired)
            {
                filePath = args[indexRequired];
            }
            return filePath;
        }
    }
}
