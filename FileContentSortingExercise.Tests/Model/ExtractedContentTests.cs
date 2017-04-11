using System.Collections;
using System.Linq;
using FileContentSortingExercise.Model;
using NUnit.Framework;

namespace FileContentSortingExercise.Tests.Model
{
    public class ExtractedContentTests
    {
        [Test]
        [TestCaseSource(typeof(TestCases), nameof(TestCases.OrderedByStreetNameTestCases))]
        public string[] GetContentItemsOrderedByStreetName(AddressTestCase addressTestCase)
        {
            var extractedContent = new ExtractedContent();
            foreach (var address in addressTestCase.Addresses)
            {
                extractedContent.Add(new ContentItem
                {
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    Address = address
                });
            }
            return extractedContent.GetContentItemsOrderedByStreetName().Select(x => x.Address).ToArray();
        }

        [Test]
        [TestCaseSource(typeof(TestCases), nameof(TestCases.OrderedNamesWithFrequencyTestCases))]
        public NameWithFrequency[] GetOrderedNamesWithFrequency(NamesWithFrequencyTestCase testCase)
        {
            var extractedContent = new ExtractedContent();
            foreach (var name in testCase.Names)
            {
                extractedContent.Add(new ContentItem
                {
                    FirstName = name.FirstName,
                    LastName = name.LastName
                });
            }

            return extractedContent.GetOrderedNamesWithFrequency().ToArray();
        }
    }

    public class TestCases
    {
        public static IEnumerable OrderedByStreetNameTestCases
        {
            get
            {
                yield return new TestCaseData(new AddressTestCase
                {
                    Addresses = new[] {"111 Aaa", "999 Zzzz", "1 Beep", "1 Bop"}
                }).Returns(new[]{ "111 Aaa","1 Beep", "1 Bop", "999 Zzzz"});
                yield return new TestCaseData(new AddressTestCase
                {
                    Addresses = new[] { "1 D", "1 C", "1 B", "1 A" }
                }).Returns(new[] { "1 A", "1 B", "1 C", "1 D" });
                yield return new TestCaseData(new AddressTestCase
                {
                    Addresses = new[] { "111 Ac", "999 Ab", "1 Aa", "777 Ad" }
                }).Returns(new[] { "1 Aa", "999 Ab", "111 Ac", "777 Ad" });
                yield return new TestCaseData(new AddressTestCase
                {
                    Addresses = new[] { "1 Name D Street", "2 Name C Street", "3 Name B Street", "4 Name A Street" }
                }).Returns(new[] { "4 Name A Street", "3 Name B Street", "2 Name C Street", "1 Name D Street" });
            }
        }

        public static IEnumerable OrderedNamesWithFrequencyTestCases
        {
            get
            {
                yield return new TestCaseData(new NamesWithFrequencyTestCase
                {
                    Names = new[] { new FullName("Aaa", "A"), new FullName("Aaa", "Aaa"), new FullName("Aaaa", "Aaa"), new FullName("A", "Aaaa") },
                }).Returns(new [] { new NameWithFrequency("Aaa", 4), new NameWithFrequency("A", 2), new NameWithFrequency("Aaaa", 2) });

                yield return new TestCaseData(new NamesWithFrequencyTestCase
                {
                    Names = new[] { new FullName("John", "John"), new FullName("John", "John"), new FullName("John", "Johnn") },
                }).Returns(new[] { new NameWithFrequency("John", 5), new NameWithFrequency("Johnn", 1) });

                yield return new TestCaseData(new NamesWithFrequencyTestCase
                {
                    Names = new[] { new FullName("A", "B"), new FullName("C", "D"), new FullName("E", "F")},
                }).Returns(new[] { new NameWithFrequency("A", 1), new NameWithFrequency("B", 1), new NameWithFrequency("C", 1), new NameWithFrequency("D", 1), new NameWithFrequency("E", 1), new NameWithFrequency("F", 1) });

                yield return new TestCaseData(new NamesWithFrequencyTestCase
                {
                    Names = new[] { new FullName("Same", "Name"), new FullName("Same", "Name"), new FullName("Same", "Name") },
                }).Returns(new[] { new NameWithFrequency("Name", 3), new NameWithFrequency("Same", 3) });

                yield return new TestCaseData(new NamesWithFrequencyTestCase
                {
                    Names = new[] { new FullName("Matt", "Brown"), new FullName("Heinrich", "Jones"), new FullName("Johnson", "Smith"), new FullName("Tim", "Johnson") },
                }).Returns(new[] { new NameWithFrequency("Johnson", 2), new NameWithFrequency("Brown", 1), new NameWithFrequency("Heinrich", 1), new NameWithFrequency("Jones", 1), new NameWithFrequency("Matt", 1), new NameWithFrequency("Smith", 1), new NameWithFrequency("Tim", 1) });
            }
        }
    }

    public class AddressTestCase
    {
        public string[] Addresses { get; set; }
    }

    public class NamesWithFrequencyTestCase
    {
        public FullName[] Names { get; set; }
    }

    public class FullName
    {
        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}