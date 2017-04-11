using FileContentSortingExercise.Model;
using NUnit.Framework;

namespace FileContentSortingExercise.Tests.Model
{
    public class ContentItemTests
    {
        [Test]
        public void ChangingAddress_populatesStreetName()
        {
            var contentItem = new ContentItem
            {
                Address = "111 Test Street"
            };

            // initial value
            Assert.That(contentItem.StreetName, Is.EqualTo("Test Street"));

            // changed
            contentItem.Address = "777 Changed";
            Assert.That(contentItem.StreetName, Is.EqualTo("Changed"));
        }
    }
}