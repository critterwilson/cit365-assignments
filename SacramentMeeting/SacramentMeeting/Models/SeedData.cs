using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SacramentMeeting.Data;
using System;
using System.Linq;

namespace SacramentMeeting.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SacramentContext(
                                        serviceProvider.GetRequiredService<
                                            DbContextOptions<SacramentContext>>()))
            {
                // Look for any students.
                if (context.Meeting.Any())
                {
                    return;   // DB has been seeded
                }

                var members = new Member[]
                {
                    new Member{FirstName="Mike",LastName="Wilson"},
                    new Member{FirstName="Melanie",LastName="Wilson"},

                    new Member{FirstName="Spencer",LastName="Wilson"},
                    new Member{FirstName="Jamyn",LastName="Wilson"},
                    new Member{FirstName="Hallie",LastName="Wilson"},
                    new Member{FirstName="Dean",LastName="Wilson"},

                    new Member{FirstName="Tyson",LastName="Allen"},
                    new Member{FirstName="Joci",LastName="Allen"},
                    new Member{FirstName="Levi",LastName="Allen"},
                    new Member{FirstName="Annie",LastName="Allen"},
                    new Member{FirstName="Ellie",LastName="Allen"},
                    new Member{FirstName="Caleb",LastName="Allen"},

                    new Member{FirstName="Tanner",LastName="Wilson"},
                    new Member{FirstName="Elle",LastName="Wilson"},

                    new Member{FirstName="Christopher",LastName="Wilson"},
                    new Member{FirstName="Kelcy",LastName="Wilson"},
                    new Member{FirstName="Jude",LastName="Wilson"}
                };
                foreach (Member m in members)
                {
                    context.Member.Add(m);
                }
                context.SaveChanges();

                var hymns = new Hymn[]
                {
                    new Hymn{ID=2, Title="The Spirit of God"},
                    new Hymn{ID=26, Title="Joseph Smith's First Prayer"},
                    new Hymn{ID=27, Title="Praise to the Man"},
                    new Hymn{ID=29, Title="A Poor Wayfaring Man of Grief"},
                    new Hymn{ID=86, Title="How Great Thou Art"},
                    new Hymn{ID=172, Title="In Humility, Our Savior"},
                    new Hymn{ID=185, Title="Reverently and Meekly Now"},
                    new Hymn{ID=188, Title="Thy Will, O Lord, Be Done"},
                    new Hymn{ID=196, Title="Jesus, Once of Humble Birth"},
                    new Hymn{ID=201, Title="Joy to the World"},
                    new Hymn{ID=220, Title="Lord, I Would Follow Thee"},
                    new Hymn{ID=249, Title="Called to Serve"}
                };
                foreach (Hymn h in hymns)
                {
                    context.Hymn.Add(h);
                }
                context.SaveChanges();

                //var meetings = new Meeting[]
                //{
                //new Meeting{MeetingDate=DateTime.Parse("2020-3-22"),
                //            PresidingID=1, ConductingID=1, FastMeeting=false},
                //new Meeting{MeetingDate=DateTime.Parse("2020-3-29"),
                //            PresidingID=1, ConductingID=1, FastMeeting=true},
                //new Meeting{MeetingDate=DateTime.Parse("2020-4-12"),
                //            PresidingID=1, ConductingID=3, FastMeeting=false}
                //};
                //foreach (Meeting m in meetings)
                //{
                //    context.Meeting.Add(m);
                //}
                //context.SaveChanges();
            }
        }
    }
}