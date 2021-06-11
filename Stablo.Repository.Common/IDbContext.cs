using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stablo.Repository.Common
{
    public interface IDbContext
    {
        public DbContext GetContext();
    }
}
