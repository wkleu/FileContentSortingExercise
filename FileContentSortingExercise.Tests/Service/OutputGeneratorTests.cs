using FileContentSortingExercise.Model;
using FileContentSortingExercise.Service;
using NUnit.Framework;

namespace FileContentSortingExercise.Tests.Service
{
    public class OutputGeneratorTests
    {
        private ExtractedContent _extractedContent;

        [SetUp]
        public void SetUp()
        {
            _extractedContent = new ExtractedContent();
            _extractedContent.Add(new ContentItem()
            {
                FirstName = "John",
                LastName = "John",
                Address = "111 Street C"
            });
            _extractedContent.Add(new ContentItem()
            {
                FirstName = "John",
                LastName = "NotJohn",
                Address = "777 Street B"
            });
        }

        [Test]
        public void GetFrequencyWithAlphabeticLines()
        {
            var outputGenerator = new OutputGenerator(_extractedContent);

            var output = outputGenerator.GetFrequencyWithAlphabeticLines();

            Assert.That(output.Count, Is.EqualTo(2));
            Assert.That(output[0], Is.EqualTo("John, 3"));
            Assert.That(output[1], Is.EqualTo("NotJohn, 1"));
        }

        [Test]
        public void GetByStreetNameLines()
        {
            var outputGenerator = new OutputGenerator(_extractedContent);

            var output = outputGenerator.GetByStreetNameLines();

            Assert.That(output.Count, Is.EqualTo(2));
            Assert.That(output[0], Is.EqualTo("777 Street B"));
            Assert.That(output[1], Is.EqualTo("111 Street C"));
        }
    }
}
