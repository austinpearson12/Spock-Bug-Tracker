namespace Spock_Bug_Tracker.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Spock_Bug_Tracker.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Spock_Bug_Tracker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Spock_Bug_Tracker.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var roleManager = new RoleManager<IdentityRole>(
               new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            if (!context.Roles.Any(r => r.Name == "Project Manager"))
            {
                roleManager.Create(new IdentityRole { Name = "Project Manager" });
            }
            if (!context.Roles.Any(r => r.Name == "Developer"))
            {
                roleManager.Create(new IdentityRole { Name = "Developer" });
            }
            if (!context.Roles.Any(r => r.Name == "Submitter"))
            {
                roleManager.Create(new IdentityRole { Name = "Submitter" });
            }



            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "austinpearson52@yahoo.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "austinpearson52@yahoo.com",
                    Email = "austinpearson52@yahoo.com",
                    FirstName = "Austin",
                    LastName = "Pearson",
                    DisplayName = "austinpearson12"
                }, "Abc&123");
            }
            if (!context.Users.Any(u => u.Email == "ap@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "ap@mailinator.com",
                    Email = "ap@mailinator.com",
                    FirstName = "Austin",
                    LastName = "Pearson",
                    DisplayName = "austinpearson12"
                }, "Abc&123");
            }
            if (!context.Users.Any(u => u.Email == "ap1@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "ap1@mailinator.com",
                    Email = "ap1@mailinator.com",
                    FirstName = "Austin",
                    LastName = "Pearson",
                    DisplayName = "austinpearson12"
                }, "Abc&123");
            }
            if (!context.Users.Any(u => u.Email == "ap2@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "ap2@mailinator.com",
                    Email = "ap2@mailinator.com",
                    FirstName = "Austin",
                    LastName = "Pearson",
                    DisplayName = "austinpearson12"
                }, "Abc&123");
            }

            var userId = userManager.FindByEmail("austinpearson52@yahoo.com").Id;
            userManager.AddToRole(userId, "Admin");

            userId = userManager.FindByEmail("ap@mailinator.com").Id;
            userManager.AddToRole(userId, "Project Manager");

            userId = userManager.FindByEmail("ap1@mailinator.com").Id;
            userManager.AddToRole(userId, "Developer");

            userId = userManager.FindByEmail("ap2@mailinator.com").Id;
            userManager.AddToRole(userId, "Submitter");

            context.TicketPriorities.AddOrUpdate(
                t => t.Name,
                new TicketPriority { Name ="Immediate", Description = "Highest priority level requiring immediate action"},
                new TicketPriority { Name = "High", Description = "A high priority level requiring quick action" },
                new TicketPriority { Name = "Medium", Description = "" },
                new TicketPriority { Name = "Low", Description = "" },
                new TicketPriority { Name = "None", Description = "" }
                );

            context.TicketStatuses.AddOrUpdate(
                t => t.Name,
                new TicketStatus { Name = "New / UnAssigned", Description = "" },
                new TicketStatus { Name = "UnAssigned", Description = "" },
                new TicketStatus { Name = "New / Assigned", Description = "" },
                new TicketStatus { Name = "Assigned", Description = "" },
                new TicketStatus { Name = "In Progress", Description = "" },
                new TicketStatus { Name = "Completed", Description = "" },
                new TicketStatus { Name = "Archived", Description = "" },
               
                new TicketStatus { Name = "Completed", Description = "" },
                new TicketStatus { Name = "Archived", Description = "" }
                );
            context.TicketTypes.AddOrUpdate(
                t => t.Name,
                new TicketType { Name = "Bug / Defect", Description = "" },
                new TicketType { Name = "New Functionality Request", Description = "" },
                new TicketType { Name = "New Document Request", Description = "" },
                new TicketType { Name = "Training Request", Description = "" },
                new TicketType { Name = "Complaint", Description = "" }              
                );
        }
    }
}
