using Badcamp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badcamp.Infrastucture
{
	public class BadcampSeed
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
                    new Artist
                    {
                        Name = "KA-ZZ",
                        User = context.Users.Where(user => user.Username == "Kázmér").FirstOrDefault(),
                        Description = "I don't want peace. I want Problems Allways.",
                        ProfilePicture = "/kazimir_3.png",
                        Genres = new HashSet<Genre> {
                            context.Genres.Where(x => x.Name=="Alter").FirstOrDefault(),
                            context.Genres.Where(x => x.Name=="Folk").FirstOrDefault(),
                            context.Genres.Where(x => x.Name=="Rock").FirstOrDefault(),
                            context.Genres.Where(x => x.Name=="Techno").FirstOrDefault(),
                        }
                    },
                    new Artist
                    {
                        Name = "Hubba",
                        User = context.Users.Where(user => user.Username == "Huba").FirstOrDefault(),
                        Description = "",
                        ProfilePicture = "/huba_and_kazimir.png",
                        Genres = new HashSet<Genre> {
                            context.Genres.Where(x => x.Name=="Hip-Hopp").FirstOrDefault(),
                            context.Genres.Where(x => x.Name=="Pop").FirstOrDefault(),
                        }
                        /*Events =
                        Songs =*/
                    },
                    new Artist
                    {
                        Name = "Gizi",
                        User = context.Users.Where(user => user.Username == "Gisella").FirstOrDefault(),
                        Description = "",
                        ProfilePicture = "/gizella.png",
                        Genres = new HashSet<Genre> {
                            context.Genres.Where(x => x.Name=="Rock").FirstOrDefault()
                        }
                    },
                    new Artist
                    {
                        Name = "Billy Geen",
                        User = context.Users.Where(user => user.Username == "Béla").FirstOrDefault(),
                        Description = "",
                        ProfilePicture = "",
                        Genres = new HashSet<Genre> {
                            context.Genres.Where(x => x.Name=="Rock").FirstOrDefault()
                        }
                    },
                    new Artist
                    {
                        Name = "Johny Cache",
                        User = context.Users.Where(user => user.Username == "Elek").FirstOrDefault(),
                        Description = "",
                        ProfilePicture = "/gizella.png",
                        Genres = new HashSet<Genre> {
                            context.Genres.Where(x => x.Name=="Rock").FirstOrDefault()
                        }
                    }
                    );
                context.SaveChanges();
            }
            if (!context.Songs.Any())
            {
                context.Songs.AddRange(
                    new Song
                    {
                        Artist = context.Artists.Where(x => x.Name == "Hubba").FirstOrDefault(),
                        Title = "Hubbalubbadubdub",
                        AlbumTitle = "The Curtain",
                        Description = "A song about Huba. And Kázmér.",
                        Lyrics = "",
                        AudioSource = "/public/music",
                        Genres = new HashSet<Genre> {
                            context.Genres.Where(x => x.Name=="Hip-Hopp").FirstOrDefault(),
                            context.Genres.Where(x => x.Name=="Pop").FirstOrDefault(),
                        }
                    },
                    new Song
                    {
                        Artist = context.Artists.Where(x => x.Name == "Gizi").FirstOrDefault(),
                        Title = "The Dream",
                        AlbumTitle = "Derams",
                        Description = "",
                        Lyrics = "",
                        AudioSource = "/public/music",
                        Genres = new HashSet<Genre> {
                            context.Genres.Where(x => x.Name=="Rock").FirstOrDefault(),
                        }
                    },
                    new Song
                    {
                        Artist = context.Artists.Where(x => x.Name == "Billy Geen").FirstOrDefault(),
                        Title = "Castle In The Sky",
                        AlbumTitle = "High in the sky",
                        Description = "",
                        Lyrics = "",
                        AudioSource = "/public/music",
                        Genres = new HashSet<Genre> {
                            context.Genres.Where(x => x.Name=="Alter").FirstOrDefault(),
                            context.Genres.Where(x => x.Name=="Rock").FirstOrDefault(),
                            context.Genres.Where(x => x.Name=="Techno").FirstOrDefault(),
                        }
                    },
                    new Song
                    {
                        Artist = context.Artists.Where(x => x.Name == "KA-ZZ").FirstOrDefault(),
                        Title = "Supercallifragisticexpialidocious Rhapsody",
                        AlbumTitle = "Done-Keyz",
                        Description = "A warnig",
                        Lyrics = @"Supercallifragisticexpialidocious Rhapsody
                            Ghost in My Donkey
                            Donkey Boogie
                            Smack My Donkey Up
                            Amazing John
                            Where Have All the Cats Gone?
                            Like Supercallifragisticexpialidocious Cats
                            We Shall Suffer
                            Look John, this is my Donkey
                            You've Lost That Supercallifragisticexpialidocious Feeling
                            Stairway to Cats
                            Baby, I Need Your Cats
                            Great Cats of Donkey
                            When Supercallifragisticexpialidocious Cats Suffer
                            Many Pieces Of Large Fuzzy Cats Gathered Together At PAfrica And Grooving On A Donkey
                            Have You Met John?
                            The Girl From PAfrica
                            Bridge Over Supercallifragisticexpialidocious Cats
                            Your Cheatin' Donkey
                            Can't Take My Cats Off You
                            You Don't Send Me Supercallifragisticexpialidocious Cats Anymore
                            Sweet Donkey O' Mine
                            There's A Good Reason Cats Are Numbered, John
                            One Angry Donkey And 200 Supercallifragisticexpialidocious Cats
                            Your Supercallifragisticexpialidocious Heart
                            You Can't Suffer Through A Buffalo Herd
                            Whole Lotta Cats
                            The Number of your Donkey
                            PAfrica on My Mind
                            Don't Suffer
                            Early Morning Donkey
                            Careful With That Donkey
                            A Lot Of People Tell Me I Have A Fake Donkey
                            They Are Night Cats! They Have Come Back From PAfrica!! Ahhhh!
                            Great Balls of Cats
                            Stairway to Donkey
                            The Donkey Where Your Heart Should Be
                            Another Donkey in the Wall
                            Here Without John
                            You've Lost That Supercallifragisticexpialidocious Donkey
                            Stand by Your Cats
                            Supercallifragisticexpialidocious Blues
                            Four Supercallifragisticexpialidocious Cats
                            Hey John
                            I Suffer
                            Good Donkey
                            Just Another a Supercallifragisticexpialidocious Donkey
                            Suffer - It is the Most Fun a Girl Can Have
                            You Think I Ain't Worth A Donkey But I Feel Like A Million Cats
                            Whole Lotta Supercallifragisticexpialidocious Cats
                            Cats Sound Better With You
                            Don't Eat Cats Off The Sidewalk
                            Stand by Your Donkey
                            Suffer? I Jolly Well Won't Suffer
                            Give Me Your Cats
                            John Eat My Supercallifragisticexpialidocious Cats in PAfrica
                            A Song for John
                            Yearning for Supercallifragisticexpialidocious Cats
                            In Donkey We Trust
                            Every Donkey You Take
                            Suffer This Way
                            Enter John
                            Early Morning Suffer
                            Supercallifragisticexpialidocious Donkey O' Mine
                            (I Can't Get No) Supercallifragisticexpialidocious Cats
                            It's the End Of PAfrica As We Know It (And I Feel Fine)
                            PAfrica is Your Land
                            Smells Like a Supercallifragisticexpialidocious Donkey
                            She Thinks Donkey's Sexy
                            My Name is John
                            When Supercallifragisticexpialidocious Cats Cry
                            Mammas Don't Let Your Babies Grow Up to Be Cats
                            Stairway to PAfrica
                            Hotel PAfrica
                            Born Supercallifragisticexpialidocious
                            House of the Supercallifragisticexpialidocious Donkey
                            Another Year of Cats
                            Like a Supercallifragisticexpialidocious Donkey
                            Takin' the Donkey Train
                            Somewhere Over the Donkey
                            Cats in My Donkey
                            Truly Madly Supercallifragisticexpialidocious
                            Gonna Make You Suffer
                            My Donkey Wants To Kill Your Mama
                            The Homecoming Queen's Got A Donkey
                            Free Donkey
                            Smells Like Supercallifragisticexpialidocious Cats
                            John Broke My Heart At PAfrica
                            Suffer, Suffer, Suffer!
                            Rhythm of the Donkey
                            Welcome to Supercallifragisticexpialidocious PAfrica
                            Livin' on a Donkey
                            Straight Outta PAfrica
                            Ring of Donkey
                            Donkey I Have Become
                            My Donkey Sounds Better With You
                            Mad to Suffer
                            Let's Run Away to PAfrica and Swim With Cats
                            Supercallifragisticexpialidocious Cats Forever
                            Stand By John",
                        AudioSource = "/public/music",
                        Genres = new HashSet<Genre> {
                            context.Genres.Where(x => x.Name=="Alter").FirstOrDefault(),
                            context.Genres.Where(x => x.Name=="Folk").FirstOrDefault(),
                            context.Genres.Where(x => x.Name=="Rock").FirstOrDefault(),
                            context.Genres.Where(x => x.Name=="Techno").FirstOrDefault(),
                        }
                    },
                    new Song
                    {
                        Artist = context.Artists.Where(x => x.Name == "KA-ZZ").FirstOrDefault(),
                        Title = "Great Balls of Cats",
                        AlbumTitle = "Done-Keyz",
                        Description = "A warnig",
                        Lyrics = @"
                            Yearning for Supercallifragisticexpialidocious Cats
                            Every Donkey You Take
                            Suffer? I Jolly Well Won't Suffer
                            My Name is John
                            Suffer Forever
                            Late Night Donkey
                            Cats Sound Better With You
                            Stand by Your Cats
                            House of the Supercallifragisticexpialidocious Donkey
                            Supercallifragisticexpialidocious Cats Forever
                            Takin' the Donkey Train
                            I plead Donkey
                            At Least Give Me My Cats Back, You Negligent Donkey!
                            Your Supercallifragisticexpialidocious Heart
                            Donkey Boogie
                            Here Without John
                            They Are Night Cats! They Have Come Back From PAfrica!! Ahhhh!
                            I Suffer
                            Donkey Fields Forever
                            Goody Two Cats
                            Born Supercallifragisticexpialidocious
                            Suffer - It is the Most Fun a Girl Can Have
                            Mammas Don't Let Your Babies Grow Up to Be Cats
                            Many Pieces Of Large Fuzzy Cats Gathered Together At PAfrica And Grooving On A Donkey
                            Early Morning Donkey
                            Like a Supercallifragisticexpialidocious Donkey
                            Donkey Deep, Cats High
                            One Angry Donkey And 200 Supercallifragisticexpialidocious Cats
                            Good Donkey
                            Like Supercallifragisticexpialidocious Cats
                            A Song for John
                            Behind Supercallifragisticexpialidocious Cats
                            My Donkey Wants To Kill Your Mama
                            Truly Madly Supercallifragisticexpialidocious
                            Careful With That Donkey
                            Stairway to Donkey
                            Supercallifragisticexpialidocious Donkey O' Mine
                            Sweet Donkey O' Mine
                            It Hurts To Shoot Cats From Your Donkey, But It's Necessary
                            Another Donkey in the Wall
                            This Is A Sight We Had One Day From Supercallifragisticexpialidocious PAfrica
                            A Lot Of People Tell Me I Have A Fake Donkey
                            Don't Eat Cats Off The Sidewalk
                            PAfrica on My Mind
                            Just Another a Supercallifragisticexpialidocious Donkey
                            John Broke My Heart At PAfrica
                            Welcome to Supercallifragisticexpialidocious PAfrica
                            The Number of your Donkey
                            Amazing John
                            You Don't Send Me Supercallifragisticexpialidocious Cats Anymore
                            Livin' on a Donkey
                            Straight Outta PAfrica
                            Give Me Your Cats
                            Ring of Donkey
                            Stairway to PAfrica
                            Stairway to Cats
                            Ghost in My Donkey
                            Suffer, Suffer, Suffer!
                            You've Lost That Supercallifragisticexpialidocious Donkey
                            Enter John
                            Hotel PAfrica
                            Whole Lotta Supercallifragisticexpialidocious Cats
                            Look John, are you going to Suffer With Me or Not?
                            Look John, this is my Donkey
                            It's the End Of PAfrica As We Know It (And I Feel Fine)
                            There's A Good Reason Cats Are Numbered, John
                            My Donkey Sounds Better With You
                            Have You Met John?
                            Smells Like Supercallifragisticexpialidocious Cats
                            Supercallifragisticexpialidocious Rhapsody
                            John's Supercallifragisticexpialidocious Cats Club Band
                            Somewhere Over the Donkey
                            (I Can't Get No) Supercallifragisticexpialidocious Cats
                            The Homecoming Queen's Got A Donkey
                            Four Supercallifragisticexpialidocious Cats
                            Stand by Your Donkey
                            I Suffer in Your Arms
                            Bed of Cats
                            Your Cheatin' Donkey
                            When Supercallifragisticexpialidocious Cats Cry
                            Donkey I Have Become
                            Can't Take My Cats Off You
                            Whole Lotta Cats
                            Total Eclipse of the Donkey
                            Baby, I Need Your Cats
                            You've Lost That Supercallifragisticexpialidocious Feeling
                            We Shall Suffer
                            Rhythm of the Donkey
                            Great Cats of Donkey
                            Early Morning Suffer
                            Let's Run Away to PAfrica and Swim With Cats
                            In Donkey We Trust
                            Another Year of Cats
                            Suffer This Way
                            The Girl From PAfrica
                            Don't Suffer
                            You Think I Ain't Worth A Donkey But I Feel Like A Million Cats
                            Stand By John
                            Cats in My Donkey",
                        AudioSource = "/public/music",
                        Genres = new HashSet<Genre> {
                            context.Genres.Where(x => x.Name=="Alter").FirstOrDefault(),
                            context.Genres.Where(x => x.Name=="Folk").FirstOrDefault(),
                            context.Genres.Where(x => x.Name=="Rock").FirstOrDefault(),
                            context.Genres.Where(x => x.Name=="Techno").FirstOrDefault(),
                        }
                    },
                    new Song
                    {
                        Title = "Donkey Autopsy",
                        AlbumTitle = "Big Boy Band",
                        Description = "A song about suffering and struggling",
                        Lyrics = @"
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
                            context.Genres.Where(x => x.Name=="Alter").FirstOrDefault(),
                            context.Genres.Where(x => x.Name=="Folk").FirstOrDefault(),
                            context.Genres.Where(x => x.Name=="Rock").FirstOrDefault(),
                            context.Genres.Where(x => x.Name=="Techno").FirstOrDefault()
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
