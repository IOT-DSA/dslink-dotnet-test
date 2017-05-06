using DSLink.NET;

namespace DSLink.Test
{
    public class TestDSLink : DSLinkContainer
    {
        private static TestDSLink _link;

        public static TestDSLink Instance
        {
            get
            {
                if (_link == null)
                {
                    NETPlatform.Initialize();
                    _link = new TestDSLink();
                    _link.Connect().Wait();
                }
                return _link;
            }
        }

        public TestDSLink() : base(new Configuration(
            new [] {"--broker", "http://10.0.0.11:7080/conn"},
            "dotNET-Test",
            true, // Requester
            true // Responder
        ))
        {
        }
    }
}
