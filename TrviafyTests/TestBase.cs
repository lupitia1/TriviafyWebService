using StructureMap;

namespace TriviafyTests
{
    public class TestBase
    {
        public Container container = new Container(
           c => { c.AddRegistry<HttpMethods.Boostrapper>(); });
    }
}