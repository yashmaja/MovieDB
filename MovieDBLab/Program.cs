using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieDBLab
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MovieDBContext context = new MovieDBContext())
            {
                //CreateDB(context); -- added list of 25 movies

                DisplayDB(context);

                Console.Write("\nWould you like to search by genre or title? y/n: ");
                string doSearch = Validator.Validator.GetString("y/n").ToLower().Trim();

                if (doSearch == "y")
                {
                    bool repeat = true;
                    while (repeat)
                    {
                        Console.Write("Enter 1 for genre and 2 for title: ");
                        int searchChoice = Validator.Validator.GetInt(1, 2);

                        if (searchChoice == 1)
                        {
                            string genre = GetGenre();
                            PrintMovieList(SearchByGenre(context, genre));
                        }
                        else
                        {
                            while (true)
                            {
                                Console.Write("Please enter the name of a title: ");
                                string title = Validator.Validator.GetString("move title");

                                if (context.Movies.Any(m => title == m.Title))
                                {
                                    PrintMovieList(SearchByTitle(context, title));
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("That does not exist in this database.");
                                }
                            }
                        }

                        repeat = Validator.Validator.Repeat("\nWould you like to conduct another search?");
                    }
                }

                else if (doSearch == "n")
                {
                    Console.WriteLine("\nGoodbye!");
                }
                else
                {
                    Console.WriteLine("\nThat is not a valid input. Try again.\n");
                }
            }
        }

        static void CreateDB(MovieDBContext context)
        {
            Movie m1 = new Movie()
            {
                Title = "Modern Times",
                Genre = "Comedy",
                Runtime = 87
            };
            Movie m2 = new Movie()
            {
                Title = "White Chicks",
                Genre = "Comedy",
                Runtime = 109
            };
            Movie m3 = new Movie()
            {
                Title = "The Princess Bride",
                Genre = "Comedy",
                Runtime = 98
            };
            Movie m4 = new Movie()
            {
                Title = "2001: A Space Odyssey",
                Genre = "SciFi",
                Runtime = 139
            };
            Movie m5 = new Movie()
            {
                Title = "The Godfather",
                Genre = "Classic",
                Runtime = 175
            };
            Movie m6 = new Movie()
            {
                Title = "Citizen Kane",
                Genre = "Classic",
                Runtime = 119
            };
            Movie m7 = new Movie()
            {
                Title = "Star Wars",
                Genre = "SciFi",
                Runtime = 121
            };
            Movie m8 = new Movie()
            {
                Title = "Spirited Away",
                Genre = "Animated",
                Runtime = 125
            };
            Movie m9 = new Movie()
            {
                Title = "Howl's Moving Castle",
                Genre = "Animated",
                Runtime = 119
            };
            Movie m10 = new Movie()
            {
                Title = "My Neighbor Totoro",
                Genre = "Animated",
                Runtime = 86
            };
            Movie m11 = new Movie()
            {
                Title = "The Shining",
                Genre = "Horror",
                Runtime = 146
            };
            Movie m12 = new Movie()
            {
                Title = "Sound of Music",
                Genre = "Musical",
                Runtime = 174
            };
            Movie m13 = new Movie()
            {
                Title = "Phantom of the Opera",
                Genre = "Musical",
                Runtime = 143
            };
            Movie m14 = new Movie()
            {
                Title = "Fiddler on the Roof",
                Genre = "Musical",
                Runtime = 181
            };
            Movie m15 = new Movie()
            {
                Title = "The King and I",
                Genre = "Musical",
                Runtime = 133
            };
            Movie m16 = new Movie()
            {
                Title = "West Side Story",
                Genre = "Musical",
                Runtime = 153
            };
            Movie m17 = new Movie()
            {
                Title = "Streetcar Named Desire",
                Genre = "Classic",
                Runtime = 122
            };
            Movie m18 = new Movie()
            {
                Title = "Interstellar",
                Genre = "SciFi",
                Runtime = 169
            };
            Movie m19 = new Movie()
            {
                Title = "Alien",
                Genre = "SciFi",
                Runtime = 117
            };
            Movie m20 = new Movie()
            {
                Title = "Parasite",
                Genre = "Drama",
                Runtime = 132
            };
            Movie m21 = new Movie()
            {
                Title = "Titanic",
                Genre = "Drama",
                Runtime = 194
            };
            Movie m22 = new Movie()
            {
                Title = "Rocky",
                Genre = "Drama",
                Runtime = 119
            };
            Movie m23 = new Movie()
            {
                Title = "Dead Poets Society",
                Genre = "Drama",
                Runtime = 128
            };
            Movie m24 = new Movie()
            {
                Title = "Back to the Future",
                Genre = "SciFi",
                Runtime = 116
            };
            Movie m25 = new Movie()
            {
                Title = "The Breakfast Club",
                Genre = "Classic",
                Runtime = 97
            };

            context.Movies.Add(m1);
            context.Movies.Add(m2);
            context.Movies.Add(m3);
            context.Movies.Add(m4);
            context.Movies.Add(m5);
            context.Movies.Add(m6);
            context.Movies.Add(m7);
            context.Movies.Add(m8);
            context.Movies.Add(m9);
            context.Movies.Add(m10);
            context.Movies.Add(m11);
            context.Movies.Add(m12);
            context.Movies.Add(m13);
            context.Movies.Add(m14);
            context.Movies.Add(m15);
            context.Movies.Add(m16);
            context.Movies.Add(m17);
            context.Movies.Add(m18);
            context.Movies.Add(m19);
            context.Movies.Add(m20);
            context.Movies.Add(m21);
            context.Movies.Add(m22);
            context.Movies.Add(m23);
            context.Movies.Add(m24);
            context.Movies.Add(m25);

            context.SaveChanges();
        }

        static void DisplayDB(MovieDBContext context)
        {
            foreach (Movie m in context.Movies)
            {
                Console.WriteLine($"{$"{m.Id}.\tTitle: {m.Title}",-40}{$"Genre: {m.Genre}",-25}{$"Runtime: {m.Runtime} mins",10}");
            }
        }

        static void PrintMovieList(List<Movie> movies)
        {
            Console.WriteLine("\nThe movie(s) that match your search criteria:");
            Console.WriteLine("------------------------------------------------------------------------------------------");
            foreach (Movie m in movies)
            {
                Console.WriteLine($"{$"Title: {m.Title}",-40}{$"Genre: {m.Genre}",-25}{$"Runtime: {m.Runtime} mins",10}");
            }
        }

        static string GetGenre()
        {
            List<string> genres = new List<string>()
            {
                "Comedy",
                "Drama",
                "SciFi",
                "Classic",
                "Animated"
            };

            Console.WriteLine($"\nWhich category are you interested in?");
            for (int i = 1; i <= genres.Count; i++)
            {
                Console.WriteLine($"{i}. {genres[i - 1]}");
            }

            Console.Write("Enter a number 1-5: ");

            int choice = Validator.Validator.GetInt(1, 5);
            return genres[choice - 1];
        }

        static List<Movie> SearchByGenre(MovieDBContext context, string genre)
        {
            List<Movie> matchedMovies = context.Movies.Where(m => m.Genre == genre).ToList();
            return matchedMovies;
        }

        static List<Movie> SearchByTitle(MovieDBContext context, string title)
        {
            List<Movie> matchedMovies = context.Movies.Where(m => m.Title == title).ToList();
            return matchedMovies;
        }
    }
}