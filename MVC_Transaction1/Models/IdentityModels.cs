﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;

namespace MVC_Transaction1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class MyUser : IdentityUser<long, MyLogin, MyUserRole, MyClaim>
    {

    }

    public class MyUserRole : IdentityUserRole<long>
    {

    }
    public class MyRole : IdentityRole<long, MyUserRole>
    {

    }

    public class MyClaim : IdentityUserClaim<long> { }

    public class MyLogin : IdentityUserLogin<long> { }

    public class ApplicationDbContext : IdentityDbContext<MyUser, MyRole, long, MyLogin, MyUserRole, MyClaim>
    {
        public ApplicationDbContext()
            : base("MagicEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Map Entities to their tables.
            modelBuilder.Entity<MyUser>().ToTable("User");
            modelBuilder.Entity<MyUserRole>().ToTable("UserRole");
            modelBuilder.Entity<MyRole>().ToTable("Role");
            modelBuilder.Entity<MyClaim>().ToTable("UserClaim");
            modelBuilder.Entity<MyLogin>().ToTable("UserLogin");

            // Set AutoIncrement-Properties
            modelBuilder.Entity<MyUser>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<MyRole>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<MyClaim>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);




        }
    }

    public class MyPasswordHasher : PasswordHasher
    {
        public override PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            return hashedPassword.Equals(HashPassword(providedPassword)) ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
        public override string HashPassword(string password)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var textToHash = Encoding.Default.GetBytes(password);
            var result = sha1.ComputeHash(textToHash);
            var resultText = Convert.ToBase64String(result);
            resultText = resultText.Replace("+", "-");
            return resultText;
        }
    }

    #region Manage Roles
    //public class IdentityManager
    //{
    //    public bool RoleExists(string name)
    //    {
    //        var rm = new RoleManager<IdentityRole>(
    //            new RoleStore<IdentityRole>(new ApplicationDbContext()));
    //        return rm.RoleExists(name);
    //    }


    //    public bool CreateRole(string name)
    //    {
    //        var rm = new RoleManager<IdentityRole>(
    //            new RoleStore<IdentityRole>(new ApplicationDbContext()));
    //        var idResult = rm.Create(new IdentityRole(name));
    //        return idResult.Succeeded;
    //    }


    //    public bool CreateUser(ApplicationUser user, string password)
    //    {
    //        var um = new UserManager<ApplicationUser>(
    //            new UserStore<ApplicationUser>(new ApplicationDbContext()));
    //        var idResult = um.Create(user, password);
    //        return idResult.Succeeded;
    //    }


    //    public bool AddUserToRole(string userId, string roleName)
    //    {
    //        var um = new UserManager<ApplicationUser>(
    //            new UserStore<ApplicationUser>(new ApplicationDbContext()));
    //        var idResult = um.AddToRole(userId, roleName);
    //        return idResult.Succeeded;
    //    }


    //    public void ClearUserRoles(string userId)
    //    {
    //        var um = new UserManager<ApplicationUser>(
    //            new UserStore<ApplicationUser>(new ApplicationDbContext()));
    //        var user = um.FindById(userId);
    //        var currentRoles = new List<IdentityUserRole>();
    //        currentRoles.AddRange(user.Roles);
    //        foreach (var role in currentRoles)
    //        {
    //            um.RemoveFromRole(userId, role.Role.Name);
    //        }
    //    }
    //    }

    #endregion


}