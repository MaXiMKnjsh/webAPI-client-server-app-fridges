using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiFridges.Data;

namespace WebApiFridges.TESTS.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        public readonly DataContext Context;
        public TestCommandBase()
        {
            Context = ContextFactory.Create();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(Context);
        }
    }
}
