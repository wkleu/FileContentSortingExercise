using System.Linq;
using FileContentSortingExercise.Service;
using NUnit.Framework;

namespace FileContentSortingExercise.Tests.Service
{
    public class ContentExtractorTests
    {
        [Test]
        public void ExtractPopulatesCorrectly()
        {
            var allLines = new[]
            {
                "FirstName,LastName,Address,PhoneNumber",
                "TestName1,LastName1,1 Address,11111111",
                "TestName2,LastName2,2 Address,22222222",
                "TestName3,LastName3,3 Address,33333333",
                "TestName4,LastName4,4 Address,4444444"
            };

            var contentExtractor = new ContentExtractor();
            var extracted = contentExtractor.Extract(allLines);
            var allContentItems = extracted.AllContentItems;

            Assert.That(allContentItems.Count, Is.EqualTo(4));
            Assert.That(allContentItems.Count(item => item.FirstName.Equals("TestName1")), Is.EqualTo(1));
            Assert.That(allContentItems.Count(item => item.LastName.Equals("LastName2")), Is.EqualTo(1));
            Assert.That(allContentItems.Count(item => item.Address.Equals("3 Address")), Is.EqualTo(1));
            Assert.That(allContentItems.Count(item => item.PhoneNumber.Equals("4444444")), Is.EqualTo(1));
        }
    }
}
