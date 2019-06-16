using System;

using NUnit.Framework;

using PatientViewer.Data.Extensions;

namespace PatientViewer.Tests.Repositories
{
    /// <summary>
    /// Tests for the RepositoryCache class
    /// </summary>
    [TestFixture]
    public class RepositoryCacheTests : TestsBase
    {
        [Test]
        public void Should_Add_Data_to_the_Cache()
        {
            var key = Guid.NewGuid().ToString();

            RepositoryCache.Add(key, "Data");

            var data = RepositoryCache.Get(key, () => "New Data");

            // Cleanup
            RepositoryCache.Remove(key);

            Assert.True(data.IsEqualTo("Data"), $"Looking for \"Data\" But Found \"{data}\"");
        }

        [Test]
        public void Should_Get_Data_from_the_Cache()
        {
            var key = Guid.NewGuid().ToString();
            var data = RepositoryCache.Get(key, () => "Data");

            // Cleanup
            RepositoryCache.Remove(key);

            Assert.True(data.IsEqualTo("Data"));
        }

        [Test]
        public void Should_Get_No_Data_from_the_Cache()
        {
            var key = Guid.NewGuid().ToString();
            var data = RepositoryCache.Get(key, () => "");

            // Cleanup
            RepositoryCache.Remove(key);

            Assert.True(!data.IsEqualTo("Data"), $"Looking for \"Data\" But Found \"{data}\"");
        }
    }
}