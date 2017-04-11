using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FileContentSortingExercise.Model
{
    /**
     * Encapsulates all content extracted with methods to get content items in the required order
     */

    public class ExtractedContent
    {
        private readonly IDictionary<string, int> _namesWithFrequency = new Dictionary<string, int>();

        public IList<ContentItem> AllContentItems { get; } = new List<ContentItem>();

        public void Add(ContentItem contentItem)
        {
            AllContentItems.Add(contentItem);
            IncrementOrAddFrequency(contentItem.FirstName);
            IncrementOrAddFrequency(contentItem.LastName);
        }
        
        private void IncrementOrAddFrequency(string name)
        {
            if (_namesWithFrequency.ContainsKey(name))
            {
                _namesWithFrequency[name]++;
            }
            else
            {
                _namesWithFrequency[name] = 1;
            }
        }

        public IEnumerable<ContentItem> GetContentItemsOrderedByStreetName()
        {
            return AllContentItems.OrderBy(x => x.StreetName);
        }

        // ordered by frequency and name
        public IEnumerable<NameWithFrequency> GetOrderedNamesWithFrequency()
        {
            return
                _namesWithFrequency.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Select(x => new NameWithFrequency(x.Key, x.Value));
        }
    }
}