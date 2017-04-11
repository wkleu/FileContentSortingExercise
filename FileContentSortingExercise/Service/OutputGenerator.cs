using System.Collections.Generic;
using System.Linq;
using FileContentSortingExercise.Model;

namespace FileContentSortingExercise.Service
{
    public class OutputGenerator
    {
        private readonly ExtractedContent _extractedContent;

        public OutputGenerator(ExtractedContent extractedContent)
        {
            _extractedContent = extractedContent;
        }

        public IList<string> GetFrequencyWithAlphabeticLines()
        {
            var orderedByFrequencyAndAlphabetic = _extractedContent.GetOrderedNamesWithFrequency();
            return orderedByFrequencyAndAlphabetic.Select(item => item.Name + ", " + item.Frequency).ToList();
        }

        public IList<string> GetByStreetNameLines()
        {
            var orderedByStreetName = _extractedContent.GetContentItemsOrderedByStreetName();
            return orderedByStreetName.Select(item => item.Address).ToList();
        }
    }
}
