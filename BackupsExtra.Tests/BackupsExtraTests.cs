using Backups;
using NUnit.Framework;

namespace BackupsExtra.Tests
{
    public class BackupsExtraTests
    {
        private Repository _newRepo;

        [SetUp]
        public void Setup()
        {
            _newRepo = new Repository("rep");
        }

        [Test]
        public void CreateRemoverWithNegativePointNumber_ThrowException()
        {
            Assert.Catch<BackupsExtraException>(() =>
            {
                IPointRemover remover = new ByNumberRemover(-1);
            });
        }
    }
}