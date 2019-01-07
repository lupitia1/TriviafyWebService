using Entities;
using HttpMethods;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviafyTests
{
    class TriggeringTests
    {
        [Test]
        public void CanGetFourSongs()
        {

            TriggeringMethods trigger = new TriggeringMethods();
            var result = trigger.Trigger();

            Assert.AreEqual(4, result.Count);

        }
    }
}
