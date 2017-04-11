using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FileContentSortingExercise.Tests
{
    public class ArgsUtilTests
    {
        [Test]
        public void ReturnsDefaultValue_WithEmptyArgs()
        {
            var arg = ArgsUtil.GetArgument(new string[0], 0, "default");

            Assert.That(arg, Is.EqualTo("default"));
        }

        [Test]
        public void ReturnsDefaultValue_WhenRequiredIndexMissing()
        {
            var arg = ArgsUtil.GetArgument(new [] {"first"}, 1, "default");

            Assert.That(arg, Is.EqualTo("default"));
        }

        [Test]
        public void ReturnsIndexValue_WhenFound()
        {
            var arg = ArgsUtil.GetArgument(new[] { "first", "second" }, 1, "default");

            Assert.That(arg, Is.EqualTo("second"));
        }
    }
}
