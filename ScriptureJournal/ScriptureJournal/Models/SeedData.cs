using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScriptureJournal.Data;
using System;
using System.Linq;


namespace ScriptureJournal.Models
{
    public static class SeedData
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
                        Book = "James",
                        Chapter = 1,
                        Verse = 5,
                        Note = "Joseph Smith's inspiration to pray",
                        Date = new DateTime(1820, 3, 26, 11, 00, 00)
                    },

                    new Scripture
                    {
                        Book = "1 Nephi",
                        Chapter = 3,
                        Verse = 7,
                        Note = "Classic 'Go and Do'",
                        Date = DateTime.Now
                    },

                    new Scripture
                    {
                        Book = "D&C",
                        Chapter = 6,
                        Verse = 34,
                        Note = "My mission scripture",
                        Date = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
        }
    }
}