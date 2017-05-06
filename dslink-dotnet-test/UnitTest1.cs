using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace DSLink.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsConnectedTest()
        {
            Assert.AreEqual(ConnectionState.Connected, TestDSLink.Instance.Connector.ConnectionState);
        }

        [TestMethod]
        public async Task SubscriptionTest()
        {
            var distType = "";
            await TestDSLink.Instance.Requester.Subscribe("/sys/dist", update =>
            {
                distType = update.Value.Value<string>();
            });

            await Task.Delay(2000);
            Assert.AreEqual("dart", distType);
        }
    }
}
