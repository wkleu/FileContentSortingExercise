using FileContentSortingExercise.Model;
using NUnit.Framework;

namespace FileContentSortingExercise.Tests.Model
{
    public class ContentIndexValuesTests
    {
        [Test]
        public void IndexIsPopulated()
        {
            var contentIndexValues = new ContentIndexValues(new[] {"PhoneNumber", "Address", "LastName", "FirstName"});

            Assert.That(contentIndexValues.PhoneNumberIndex, Is.EqualTo(0));
            Assert.That(contentIndexValues.AddressIndex, Is.EqualTo(1));
            Assert.That(contentIndexValues.LastNameIndex, Is.EqualTo(2));
            Assert.That(contentIndexValues.FirstNameIndex, Is.EqualTo(3));
        }
    }
}