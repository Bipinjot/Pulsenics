using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pulsenics.Data;
using System;
using System.Linq;

namespace Pulsenics.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new FilesContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<FilesContext>>()))
        {
            // Look for any movies.
            if (context.FileSystem.Any())
            {
                return;   // DB has been seeded
            }
            context.FileSystem.AddRange(
                new FileSystem
                {
                    Name = "Resume",
                    Extension = ".docx",
                    CreatedDate = DateTime.Parse("1989-2-12"),
                    LastModifiedDate = DateTime.Parse(DateTime.Now.ToString())
    
                },
                new FileSystem
                {
                    Name = "Tutorial",
                    Extension = ".excel",
                    CreatedDate = DateTime.Parse("1989-2-12"),
                    LastModifiedDate = DateTime.Parse(DateTime.Now.ToString())
                },
                new FileSystem
                {
                    Name = "Cover Letters",
                    Extension = ".docx",
                    CreatedDate = DateTime.Parse("1989-2-12"),
                    LastModifiedDate = DateTime.Parse(DateTime.Now.ToString())
                },
                new FileSystem
                {
                    Name = "Transcripts",
                    Extension = ".pdf",
                    CreatedDate = DateTime.Parse("1989-2-12"),
                    LastModifiedDate = DateTime.Parse(DateTime.Now.ToString())
                }
            );
            context.SaveChanges();
        };

         using (var context = new UserContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<UserContext>>()))
        {
            // Look for any movies.
            if (context.User.Any())
            {
                return;   // DB has been seeded
            }
            context.User.AddRange(
                new User
                {
                    Name = "Resume",
                    Email = "test@test.com",
                    Phone = "6932713962"
                }
            );
            context.SaveChanges();
        }
    }
}