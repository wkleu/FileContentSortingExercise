using System.Linq;
using FileContentSortingExercise.Model;

namespace FileContentSortingExercise.Service
{
    public class ContentExtractor
    {
        public const char Comma = ',';

        public ExtractedContent Extract(string[] allLines)
        {
            var header = allLines[0];
            var contentLines = allLines.Skip(1);
            var headerValues = header.Split(Comma);
            var indexValues = new ContentIndexValues(headerValues);

            var extractedContent = new ExtractedContent();

            foreach (var line in contentLines)
            {
                var splittedLine = line.Split(Comma);
                var contentItem = new ContentItem()
                {
                    FirstName = splittedLine[indexValues.FirstNameIndex],
                    LastName = splittedLine[indexValues.LastNameIndex],
                    Address = splittedLine[indexValues.AddressIndex],
                    PhoneNumber = splittedLine[indexValues.PhoneNumberIndex]

                };

                extractedContent.Add(contentItem);
            }

            return extractedContent;
        }
    }
}
