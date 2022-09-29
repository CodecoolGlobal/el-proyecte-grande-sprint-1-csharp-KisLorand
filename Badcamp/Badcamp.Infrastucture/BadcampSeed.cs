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
                    },
                    new Song
                    {
                        Title = "Donkey Autopsy",
                        AlbumTitle = "Big Boy Band",
                        Description = "A song about suffering and struggling",
                        Lyrics = @"Donkey Autopsy
                                    Have You Met John?
                                    Stand by Your Donkey
                                    Good Donkey
                                    Mammas Don't Let Your Babies Grow Up to Be Cats
                                    The Number of your Donkey
                                    Ring of Donkey
                                    Rhythm of the Donkey
                                    Nice Weather For Cats
                                    PAfrica is Your Land
                                    (I Can't Get No) Supercallifragisticexpialidocious Cats
                                    Stairway to PAfrica
                                    Born Supercallifragisticexpialidocious
                                    We Shall Suffer
                                    I Suffer
                                    They Are Night Cats! They Have Come Back From PAfrica!! Ahhhh!
                                    Donkey Deep, Cats High
                                    Takin' the Donkey Train
                                    Supercallifragisticexpialidocious Cats Forever
                                    Donkey Fields Forever
                                    Like a Supercallifragisticexpialidocious Donkey
                                    This Is A Sight We Had One Day From Supercallifragisticexpialidocious PAfrica
                                    Here Without John
                                    The Donkey Where Your Heart Should Be
                                    It Hurts To Shoot Cats From Your Donkey, But It's Necessary
                                    Don't Suffer
                                    John Eat My Supercallifragisticexpialidocious Cats in PAfrica
                                    Donkey I Have Become
                                    Supercallifragisticexpialidocious Blues
                                    Cats Sound Better With You
                                    Your Supercallifragisticexpialidocious Heart
                                    Just Another a Supercallifragisticexpialidocious Donkey
                                    When Supercallifragisticexpialidocious Cats Suffer
                                    Let's Run Away to PAfrica and Swim With Cats
                                    Amazing John
                                    Ghost in My Donkey
                                    She Thinks Donkey's Sexy
                                    John's Waiting
                                    Another Year of Cats
                                    I Suffer in Your Arms
                                    Goody Two Cats
                                    Great Balls of Cats
                                    Truly Madly Supercallifragisticexpialidocious
                                    Give Me Your Cats
                                    Straight Outta PAfrica
                                    Bed of Cats
                                    Yearning for Supercallifragisticexpialidocious Cats
                                    It's the End Of PAfrica As We Know It (And I Feel Fine)
                                    Four Supercallifragisticexpialidocious Cats
                                    Hotel PAfrica
                                    Smack My Donkey Up
                                    Suffer, Suffer, Suffer!
                                    Baby, I Need Your Cats
                                    Stand By John
                                    Stairway to Cats
                                    At Least Give Me My Cats Back, You Negligent Donkey!
                                    There's A Good Reason Cats Are Numbered, John
                                    Stand by Your Cats
                                    Independent Donkey
                                    Like a Donkey
                                    Donkey Boogie
                                    You've Lost That Supercallifragisticexpialidocious Donkey
                                    Look John, are you going to Suffer With Me or Not?
                                    My Name is John
                                    Sweet Donkey O' Mine
                                    You've Lost That Supercallifragisticexpialidocious Feeling
                                    The Homecoming Queen's Got A Donkey
                                    Suffer - It is the Most Fun a Girl Can Have
                                    The Girl From PAfrica
                                    I plead Donkey
                                    Every Donkey You Take
                                    Many Pieces Of Large Fuzzy Cats Gathered Together At PAfrica And Grooving On A Donkey
                                    Stairway to Donkey
                                    Suffer? I Jolly Well Won't Suffer
                                    Suffer Forever
                                    Behind Supercallifragisticexpialidocious Cats
                                    When Supercallifragisticexpialidocious Cats Cry
                                    Like Supercallifragisticexpialidocious Cats
                                    Supercallifragisticexpialidocious Rhapsody
                                    Free Donkey
                                    Welcome to Supercallifragisticexpialidocious PAfrica
                                    Gonna Make You Suffer
                                    Total Eclipse of the Donkey
                                    Whole Lotta Cats
                                    Supercallifragisticexpialidocious Donkey O' Mine
                                    You Don't Send Me Supercallifragisticexpialidocious Cats Anymore
                                    Bridge Over Supercallifragisticexpialidocious Cats
                                    Livin' on a Donkey
                                    House of the Supercallifragisticexpialidocious Donkey
                                    My Donkey Sounds Better With You
                                    Early Morning Suffer
                                    Smells Like Supercallifragisticexpialidocious Cats
                                    Early Morning Donkey
                                    You Think I Ain't Worth A Donkey But I Feel Like A Million Cats
                                    Another Donkey in the Wall
                                    Careful With That Donkey
                                    Hey John
                                    My Donkey Wants To Kill Your Mama
                                    Where Have All the Cats Gone?
                                    In Donkey We Trust",
                        AudioSource = "/public/music",
                        Genres = new HashSet<Genre> {
                            context.Genres.Where(x => x.Name=="Alter"),
                            context.Genres.Where(x => x.Name=="Folk"),
                            context.Genres.Where(x => x.Name=="Rock"),
                            context.Genres.Where(x => x.Name=="Techno")
                        }
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
