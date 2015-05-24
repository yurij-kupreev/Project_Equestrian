using System;
using System.Data.Entity;
using System.Diagnostics;

namespace ORM
{
    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EquestrianResultsModel")
        {
            Debug.WriteLine("Context creating!");            
            Database.SetInitializer<EntityModel>(new EquestrianDbInitializer());
        }

        public DbSet<Athlete> Athlets { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; } 

        public void Dispose()
        {
            base.Dispose();
            Debug.WriteLine("Context disposing!");
        }
    }

    public class EquestrianDbInitializer : CreateDatabaseIfNotExists<EntityModel>
    {
        protected override void Seed(EntityModel context)
        {
            context.Roles.Add(new Role() { Name = "admin" });
            context.Roles.Add(new Role() { Name = "user" });
            context.Users.Add(new User() { Email = "mainadmin@gmail.com", 
                Password = "AOh7hsnVI3Q79kulz13Z18Nc+PCtTvH3gzMbG8pU7eNrIrl1iHAOA+8srQEjetRIdg==", 
                RoleId = 1, AddedDate = DateTime.Today });

            base.Seed(context);
        }
    }
}
