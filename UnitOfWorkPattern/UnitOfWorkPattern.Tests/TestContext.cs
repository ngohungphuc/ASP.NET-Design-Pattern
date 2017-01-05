using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitOfWorkPattern.Model;

namespace UnitOfWorkPattern.Tests
{
    public class TestContext : DbContext
    {
        public TestContext() : base("Name=TestContext")
        {
        }

        public TestContext(bool enableLazyLoading, bool enableProxyCreatiion) : base("Name=TestContext")
        {
            Configuration.ProxyCreationEnabled = enableProxyCreatiion;
            Configuration.LazyLoadingEnabled = enableLazyLoading;
        }

        public TestContext(DbConnection connection) : base(connection, true)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Suppress code first model migration check
            Database.SetInitializer<TestContext>(new AlwaysCreateInitializer());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public void Seed(TestContext context)
        {
            var listCountry = new List<Country>() {
               new Country() { Id = 1, Name = "US" },
               new Country() { Id = 2, Name = "India" },
               new Country() { Id = 3, Name = "Russia" }
            };
            context.Countries.AddRange(listCountry);
            context.SaveChanges();
        }
    }

    public class DropCreateIfChangeInitializer : DropCreateDatabaseIfModelChanges<TestContext>
    {
        protected override void Seed(TestContext context)
        {
            context.Seed(context);
            base.Seed(context);
        }
    }

    public class CreateInitializer : CreateDatabaseIfNotExists<TestContext>
    {
        protected override void Seed(TestContext context)
        {
            context.Seed(context);
            base.Seed(context);
        }
    }

    public class AlwaysCreateInitializer : DropCreateDatabaseAlways<TestContext>
    {
        protected override void Seed(TestContext context)
        {
            context.Seed(context);
            base.Seed(context);
        }
    }
}