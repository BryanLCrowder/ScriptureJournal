using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScriptureJournal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ScriptureJournalContext>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        Title = "Nephi",
                        Book = "1st Nephi",
                        Chapters = "2", 
                        Verses = "3",
                        Note = "Hello",
                        DateAdded = DateTime.Parse("2019-6-06")
                    },

                    new Scripture
                    {
                        Title = "Repentance",
                        Book = "2nd Nephi",
                        Chapters = "3",
                        Verses = "12",
                        Note = "Hello",
                        DateAdded = DateTime.Parse("2019-6-06")
                    },

                    new Scripture
                    {
                        Title = "Nephi",
                        Book = "Moroni",
                        Chapters = "10", 
                        Verses = "3-4",
                        Note = "Hello",
                        DateAdded = DateTime.Parse("2019-6-06")
                    },

                    new Scripture
                    {
                        Title = "Nephi",
                        Book = "Alma",
                        Chapters = "26",
                        Verses = "12",
                        Note = "Hello",
                        DateAdded = DateTime.Parse("2019-6-06")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}