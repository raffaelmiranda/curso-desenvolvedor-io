using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaApiCore.Model
{
    public class ApiDbContext: DbContext
    {
        public ApiDbContext(DbContextOptions options): base(options)
        {
            
        }

        public DbSet<Fornecedor> Fornecedores { get; set; }
    }
}
