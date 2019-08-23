namespace Spock_Bug_Tracker.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Spock_Bug_Tracker.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Configuration;

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
                    DisplayName = "austinpearson12",
                    AvatarUrl = "/images/avaatar.jpg"
                }, "Abc&123");
            }
            if (!context.Users.Any(u => u.Email == "ap@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "ap@mailinator.com",
                    Email = "ap@mailinator.com",
                    FirstName = "Pm",
                    LastName = "Phara",
                    DisplayName = "pmPhara12",
                    AvatarUrl = "/images/avaatar.jpg"
                }, "Abc&123");
            }
            if (!context.Users.Any(u => u.Email == "ap1@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "ap1@mailinator.com",
                    Email = "ap1@mailinator.com",
                    FirstName = "Dev",
                    LastName = "Donald",
                    DisplayName = "DevDonald2019",
                    AvatarUrl = "/images/avaatar.jpg"
                }, "Abc&123");
            }
            if (!context.Users.Any(u => u.Email == "ap2@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "ap2@mailinator.com",
                    Email = "ap2@mailinator.com",
                    FirstName = "Sub",
                    LastName = "Sarah",
                    DisplayName = "SubSarah98",
                    AvatarUrl = "/images/avaatar.jpg"
                }, "Abc&123");
            }
            //Demo Users
            if (!context.Users.Any(u => u.Email == "demoadmin@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "demoadmin@mailinator.com",
                    Email = "demoadmin@mailinator.com",
                    FirstName = "Demo",
                    LastName = "Admin",
                    DisplayName = "DemoAdmin2019",
                    AvatarUrl = "/images/avaatar.jpg"
                }, WebConfigurationManager.AppSettings["DemoUserPassword"]);
            }
            if (!context.Users.Any(u => u.Email == "demopm@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "demopm@mailinator.com",
                    Email = "demopm@mailinator.com",
                    FirstName = "Demo",
                    LastName = "Pm",
                    DisplayName = "DemoPm2019",
                    AvatarUrl = "/images/avaatar.jpg"
                }, WebConfigurationManager.AppSettings["DemoUserPassword"]);
            }
            if (!context.Users.Any(u => u.Email == "demodev@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "demodev@mailinator.com",
                    Email = "demodev@mailinator.com",
                    FirstName = "Demo",
                    LastName = "Dev",
                    DisplayName = "DemoDev2019",
                    AvatarUrl = "/images/avaatar.jpg"
                }, WebConfigurationManager.AppSettings["DemoUserPassword"]);
            }
            if (!context.Users.Any(u => u.Email == "demosub@mailinator.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "demosub@mailinator.com",
                    Email = "demosub@mailinator.com",
                    FirstName = "Demo",
                    LastName = "Sub",
                    DisplayName = "DemoSub2019",
                    AvatarUrl = "/images/avaatar.jpg"
                }, WebConfigurationManager.AppSettings["DemoUserPassword"]);
            }




            var userId = userManager.FindByEmail("austinpearson52@yahoo.com").Id;
            userManager.AddToRole(userId, "Admin");

            userId = userManager.FindByEmail("demoadmin@mailinator.com").Id;
            userManager.AddToRole(userId, "Admin");

            userId = userManager.FindByEmail("ap@mailinator.com").Id;
            userManager.AddToRole(userId, "Project Manager");

            userId = userManager.FindByEmail("demopm@mailinator.com").Id;
            userManager.AddToRole(userId, "Project Manager");

            userId = userManager.FindByEmail("ap1@mailinator.com").Id;
            userManager.AddToRole(userId, "Developer");

            userId = userManager.FindByEmail("demodev@mailinator.com").Id;
            userManager.AddToRole(userId, "Developer");

            userId = userManager.FindByEmail("ap2@mailinator.com").Id;
            userManager.AddToRole(userId, "Submitter");

            userId = userManager.FindByEmail("demosub@mailinator.com").Id;
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
                new TicketStatus { Name = "Archived", Description = "" }
                );
            context.TicketTypes.AddOrUpdate(
                t => t.Name,
                new TicketType { Name = "Bug", Description = "An error has occurred that resulted in either the application crashing or the user seeing error infromation" },
                new TicketType { Name = "Defect", Description = "An error has occured that resulted in either a miscalculation or an incorrect workflow" },
                new TicketType { Name = "New Feature Request", Description = "A client has called in asking for new functionality in an existing application" },
                new TicketType { Name = "New Document Request", Description = "A client has called in asling for new documentation to be created for the existing application" },
                new TicketType { Name = "Training Request", Description = "A client has called in asking to schedule a training session" },
                new TicketType { Name = "Complaint", Description = "A client has called in to make a general complaint about our application" }              
                );





        }
    }
}
