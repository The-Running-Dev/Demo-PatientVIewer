using NUnit.Framework;

using PatientViewer.Data.Extensions;

namespace PatientViewer.Tests.Repositories
{
    /// <summary>
    /// Contains tests for the Patient PatientService class
    /// </summary>
    [TestFixture]
    public class StringExtensionsTests: TestsBase
    {
        [Test]
        public void Strings_Should_Not_Be_Equal()
        {
            Assert.True(!"Ben".IsEqualTo("Dan"));
        }

        [Test]
        public void Strings_Should_Be_Equal()
        {
            Assert.True("Ben".IsEqualTo("Ben"));
        }

        [Test]
        public void String_Should_Not_Be_Equal_To_Null()
        {
            Assert.True(!"Dan".IsEqualTo(null));
        }
    }
}