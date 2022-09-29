using Badcamp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Infrastucture
{
	internal class BadcampSeed
	{
        private readonly BadcampContext context;

        public BadcampSeed(BadcampContext context)
        {
            this.context = context;
        }
        public void Seed()
        {
            context.Database.Migrate();
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        Username = "Kázmér",
                        Password = "asdfg",
                        DateOfBirth = new DateTime(1820, 3, 1, 7, 0, 0),
                        FullName = "Kazimir Baradlay"
                    },
                    new User
                    {
                        Username = "Huba",
                        Password = "hubalubadubdub",
                        DateOfBirth = new DateTime(2001, 3, 1, 7, 0, 0),
                        FullName = "Huba"
                    },
                    new User
                    {
                        Username = "Elek",
                        Password = "Telek",
                        DateOfBirth = new DateTime(2003, 4, 20, 4, 20, 0),
                        FullName = "Elek Telek"
                    },
                    new User
                    {
                        Username = "Gisella",
                        Password = "asdfg",
                        DateOfBirth = new DateTime(1985, 8, 20, 7, 0, 0),
                        FullName = "Huba"
                    },
                    new User
                    {
                        Username = "Béla",
                        Password = "asdfg",
                        DateOfBirth = new DateTime(1985, 8, 20, 7, 0, 0),
                        FullName = "Bela Lugosy"
                    },
                    new User
                    {
                        Username = "IMI",
                        Password = "imi",
                        DateOfBirth = new DateTime(1990, 8, 20, 7, 0, 0),
                        FullName = "Imre"
                    }
                    );
                context.SaveChanges();
            }
            if (!context.Genres.Any())
            {
                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Hip-Hopp"
                    },
                    new Genre
                    {
                        Name = "Hipp-Hopp"
                    },
                    new Genre
                    {
                        Name = "Pop"
                    },
                    new Genre
                    {
                        Name = "Rock"
                    },
                    new Genre
                    {
                        Name = "Techno"
                    },
                    new Genre
                    {
                        Name = "Alter"
                    },
                    new Genre
                    {
                        Name = "Folk"
                    }
                    );
                context.SaveChanges();
            }
            if (!context.Artists.Any())
            {
                context.Artists.AddRange(
                    new ArtistModel
                    {
                        Name = "KA-ZZ",
                        User = context.Users.Where(user => user.Username == "Kázmér").FirstOrDefault(),
                        Description = "I don't want peace. I want Problems Allways.",
                        ProfilePicture = "/kazimir_3.png",
                    },
                    new ArtistModel
                    {
                        Name = "Hubba",
                        User = context.Users.Where(user => user.Username == "Huba").FirstOrDefault(),
                        Description = "",
                        ProfilePicture = "/huba_and_kazimir.png",
                        ArtistGenre =
                        Events =
                        Songs =
                    },
                    new ArtistModel
                    {
                        Name = "Gizi",
                        User = context.Users.Where(user => user.Username == "Gisella").FirstOrDefault(),
                        Description = "",
                        ProfilePicture = "/gizella.png",
                    },
                    new ArtistModel
                    {
                        Name = "Billy Geen",
                        User = context.Users.Where(user => user.Username == "Béla").FirstOrDefault(),
                        Description = "",
                        ProfilePicture = "",
                    },
                    new ArtistModel
                    {
                        Name = "Johny Cache",
                        User = context.Users.Where(user => user.Username == "Elek").FirstOrDefault(),
                        Description = "",
                        ProfilePicture = "/gizella.png",
                    }
                    );
                context.SaveChanges();
            }
            if (!context.Songs.Any()
                && !context.Artists.Any())
            {
                context.Songs.AddRange(
                    new Song
                    {
                        Title = "Hubbalubbadubdub",
                        AlbumTitle = "The Curtain",
                        Description = "A song about Huba. And Kázmér.",
                        Lyrics = "",
                        AudioSource = "/public/music",
                        Genres = new HashSet<Genre> {
                            context.Genres.Where(x => x.Name=="Hip-Hopp"),
                            context.Genres.Where(x => x.Name=="Pop"),
                        }
                    },
                    new Song
                    {
                        Title = "The Dream",
                        AlbumTitle = "Derams",
                        Description = "",
                        Lyrics = "",
                        AudioSource = "/public/music",
                        Genres = new HashSet<Genre> {
                            context.Genres.Where(x => x.Name=="Rock"),
                        }
                    },
                    new Song
                    {
                        Title = "Castle In The Sky",
                        AlbumTitle = "High in the sky",
                        Description = "",
                        Lyrics = "",
                        AudioSource = "/public/music",
                        Genres = new HashSet<Genre> {
                            context.Genres.Where(x => x.Name=="Alter"),
                            context.Genres.Where(x => x.Name=="Rock"),
                            context.Genres.Where(x => x.Name=="Techno")
                        }
                    );
                context.SaveChanges();
            }
            if (!context.Events.Any())
            {
                context.Events.AddRange(
                    new Event
                    {
                        Artist = context.Artists.Where(x => x.Name == "Hubba").FirstOrDefault(),
                        Title = "Meet up",
                        Description = "Meet me in person at 31/09/2022",
                        Upvote = 42
                    },
                    new Event
                    {
                        Artist = context.Artists.Where(x => x.Name == "Hubba").FirstOrDefault(),
                        Title = "Handshakes",
                        Description = "Shake it!!",
                        Upvote = 200
                    },
                    new Event
                    {
                        Artist = context.Artists.Where(x => x.Name == "KA-ZZ").FirstOrDefault(),
                        Title = "Free Huggs",
                        Description = "Offering hugs for the low, low cost of free",
                        Upvote = 4
                    }
                    );
                context.SaveChanges();
            }
        }

    }
}
