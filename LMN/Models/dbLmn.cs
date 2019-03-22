﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LMN.Models
{
    
    public class dbLmn
    {
        public class QAdminContext : DbContext
        {
            public DbSet<Course> Courses { get; set; }
            public DbSet<Author> Authors { get; set; }
            public DbSet<Tag> Tags { get; set; }
            public DbSet<Quiz> Quizs { get; set; }
            public DbSet<User> Users { get; set; } 
            public QAdminContext() : base("name=DefaultConnectionB")
            {

            }
        }
        public static List<User> querryTable()
        {
            using (var context = new QAdminContext())
            {

                var q2 = context.Users;
                //  var selectedUsers = q2.OrderBy(x=>x.Id).Where(user => user.permissionLevel == 1).ToList();
                return q2.ToList();

            }
        }

        public static void AddRandomQuizs()
        {
            using (var context = new QAdminContext())
            {
                for (int i = 1; i <= 100; i++)
                {
                    var quiz = new Quiz { Id = i, Name = RandomString(45), Description = RandomString(45), solvable = true };
                    context.Quizs.Add(quiz);
                }
                context.SaveChanges();
            }
        }

        public static void AddRandomUsers()
        {
            using (var context = new QAdminContext())
            {
                for (int i = 1; i <= 100; i++)
                {
                    var user = new User { Id = i, userName = RandomString(45), passWord = RandomString(45), permissionLevel = i };
                    context.Users.Add(user);
                }
                context.SaveChanges();
            }
        }

        public static void RemoveAllEntries(string tableName)
        {
            using (var context = new QAdminContext())
            {
                context.Database.ExecuteSqlCommand("TRUNCATE TABLE " + tableName);
            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        
    }
}