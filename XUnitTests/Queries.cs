using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTests
{
    public class Queries
    {
        [Fact]
        public void CountAllCompanies()
        {
            var repository = new TestRepository();
            var count = repository.FindAllCompanies().Count;
            Assert.True(count == 7);
        }
    }
}
