using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;


namespace HttpMethods
{
    public class Boostrapper : Registry
    {
        public Boostrapper()
        {
            For<IClientHttpTriviafy>().Use<ClientHttpTriviafy>();
            For<ITriggeringMethods>().Use<TriggeringMethods>();
        }
    }
}
