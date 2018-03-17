using CST356_lab3.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST356_lab3.Data
{
    public interface IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Classes> Classes { get; set; }
    }
}
