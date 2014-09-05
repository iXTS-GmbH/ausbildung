using NUnit.Framework;

namespace ixts.Ausbildung.NameService.Test
{

    [TestFixture]
    public class NameServerTests
    {
        private NameServer sut;

        [SetUp]
        public void SetUp()
        {
            var testSocket = new TestSocketFaktory();
            sut = new NameServer(2000,testSocket);
        }


        [TestCase]
        public void PutTest()
        {
            
        }

        [TestCase]
        public void GetTest()
        {

        }

        [TestCase]
        public void DelTest()
        {

        }

        [TestCase]
        public void StopTest()
        {

        }
    }
}
