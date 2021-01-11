using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NerdStore.Catalogo.Domain;
using NerdStore.Core.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());

        public IConfiguration Configuration { get; }

        public CatalogoContext(DbContextOptions<CatalogoContext> options, IConfiguration configuration) 
            : base(options) 
        {
            Configuration = configuration;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseLoggerFactory(_logger)
        //        .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
        //        p => p.EnableRetryOnFailure(
        //        maxRetryCount: Convert.ToInt32(Configuration["ConfigureSQLServer:MaxRetryCount"]),
        //        maxRetryDelay: TimeSpan.FromSeconds(Convert.ToDouble(Configuration["ConfigureSQLServer:MaxRetryDelay"])),
        //        errorNumbersToAdd: null)
        //    .MigrationsHistoryTable("Migration", "EF"));
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}
