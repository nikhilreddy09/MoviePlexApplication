using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviePlex
{
    class Program 
    {


        static string[] MovieRatingsArray;
        static string[] MovieNamesArray;
        static  IList<string> MovieNames = new List<string>();
        static IList<string> MovieRatings = new List<string>();
        static  string option;
        static int numberOfMovies;
        static string movieselected;
        static string ratingselected;
        static int agelimit;
        static string f;
        static string satisfaction;
        static string noMovies;
        static string limitOrRating;
        static int ageinput;
        static void Main(string[] args)
        {
             void home()
            {
                Console.WriteLine("\t\t\t\tWelcome to MoviePlex Ticket Booking System \n \t\t\t\t******************************************");

                do
                {
                    Console.WriteLine("Please select from the following options: \n 1.Administrator\n 2.Guests");

                    option = Console.ReadLine().Trim();
                
                    if (option == "1")
                    {
                        ///execute administrator
                        ///
                       // Console.WriteLine("admin");
                        Administrator();
                        break;
                    }
                    if (option == "2")
                    {
                        //exec guests
                       
                        guests();
                        // Console.WriteLine("guests");
                        break;
                    }
                    if(option != "1" || option != "2")
                    {
                        Console.WriteLine("incorrect option selected. returning back to home screen");
                    }
                } while (option != "1" || option != "2");
            }
             home();
             void Administrator()
            {
                var i = 0;
                var s = 5;
                string inputPassword;
                string password = "nikhil";

                do {
                    Console.WriteLine("Please enter the password");

                    inputPassword = Console.ReadLine();

                    if (inputPassword == password)
                    {
                        InsertMovies();
                        break;
                    }
                    else if (inputPassword == "B" || inputPassword == "b")
                    {
                        Console.WriteLine("home");
                        home();
                        break;
                    }
                    else if (inputPassword != password)
                    {
                        i++;
                        s--;
                        Console.WriteLine("You have entered an invalid password");
                        Console.WriteLine("you have {0} attempts to enter the correct password or press B to go back to previous screen",s);
                        
                       }

                    if(i==5)
                    {
                        Console.WriteLine("no more attempts. back to the home screen \n back to homescreen button disabled.");
                        home();
                        break;
                    }
                } while (i <= 5 || inputPassword != "B");

            } 

             void InsertMovies()
            {

                string MovieInput;
                string RatingInput;
                Console.Write("Hello Admin. \t\t How many movies are playing today?:");
                var n = Console.ReadLine();
                if (int.TryParse(n, out numberOfMovies))
                {
                    if (numberOfMovies > 0)
                    {
                        for (var i = 1; i <= numberOfMovies; i++)
                        {
                            Console.Write("enter the name of {0} movie:", i);
                            MovieInput = Console.ReadLine();
                            MovieNames.Add(MovieInput);
                           
                            
                                start: Console.WriteLine("enter the rating of the {0} Movie", i);
                                    RatingInput = Console.ReadLine().ToUpper().Trim();
                                    if (RatingInput == "G" || RatingInput == "PG" || RatingInput == "R" || RatingInput == "PG-13" || RatingInput == "NC-17")
                                    {
                                        MovieRatings.Add(RatingInput);
                                    }
                                    else
                                    {
                                        Console.WriteLine("these are the available ratings : \n 1. G \n 2. PG \n 3. R \n 4. PG-13 \n 5. NC-17");
                                        goto start;
                                    }
                                    
                               

                       
                        }

                        MovieNamesArray = MovieNames.ToArray();

                        MovieRatingsArray = MovieRatings.ToArray();

                        Console.WriteLine("These are the movies playing:");
                        for (int i = 0; i < numberOfMovies; i++)
                        {
                            Console.WriteLine(i + 1 + "." + MovieNamesArray[i] + "{" + MovieRatingsArray[i] + "}");
                        }





                        do
                        {
                            Console.WriteLine("Your movies playing today are listed Above. Are you satisfied? (Y/N)");

                            satisfaction = Console.ReadLine().ToUpper();
                            if (satisfaction == "Y")
                            {
                                home();
                            }
                            else if (satisfaction == "N")
                            {///insert for deletion
                                MovieNames.Clear();
                                MovieRatings.Clear();
                                InsertMovies();
                            }
                        } while (satisfaction != "Y" || satisfaction != "N");
                    }
                    else
                    {
                        Console.WriteLine("number of movies playing cannot be zero or negative");
                        InsertMovies();
                    }
                }
                else
                {
                    InsertMovies();
                }

               
            }

             void guests()
            {
                if (numberOfMovies == 0)
                {
                    Console.WriteLine("there are no movies playing today.");
                    do
                    {
                        Console.WriteLine("press H to go back to home screen");
                        noMovies = Console.ReadLine().Trim().ToUpper();
                        if(noMovies == "H")
                        {
                            home();
                        }
                    } while (noMovies != "H");

                }
                else { 
                Console.WriteLine("These are the movies playing:");
                for (int i = 0; i < numberOfMovies; i++)
                {
                    Console.WriteLine(i + 1 +"." + MovieNamesArray[i] + "{" + MovieRatingsArray[i] + "}");
                }

                Console.WriteLine("please select a movie to continue booking");

                var a = Console.ReadLine();
                //  MovieSelection = Convert.ToInt32(Console.ReadLine());

                if (int.TryParse(a, out int MovieSelection))
                {
                    //Console.WriteLine("sucess");
                    if (MovieSelection > numberOfMovies || MovieSelection <= 0)
                    {
                        Console.WriteLine("please select from the options above");
                        guests();
                    }
                    else
                    {
                        movieselected = MovieNamesArray[MovieSelection - 1];
                        ratingselected = MovieRatingsArray[MovieSelection - 1];
                        // rating = ratingselected.ToUpper();

                        if (ratingselected == "G")
                        {
                            agelimit = 0;
                        }
                        else if (ratingselected == "PG")
                        {
                            agelimit = 10;
                        }
                        else if (ratingselected == "PG-13")
                        {
                            agelimit = 13;
                        }
                        else if (ratingselected == "R")
                        {
                            agelimit = 15;
                        }
                        else if (ratingselected == "NC-17")
                        {
                            agelimit = 17;
                        }

                        Console.WriteLine("movie selected : \n {0}  {1}", movieselected, ratingselected);
                            
                          agestart:      Console.WriteLine("please enter your age for verification");
                                var b = Console.ReadLine();
                           
                        if (int.TryParse(b, out int age))
                        {
                            if (age > 110 || age <= 0)
                            {
                                    Console.WriteLine("please enter a valid age to continue");
                                    goto agestart;
                            }
                            else if (age > agelimit)
                            {
                                Console.WriteLine("enjoy the movie");
                                do
                                {
                                    Console.WriteLine("select B TO GO BACK TO GUEST SCREEN OR H TO GO BACK TO HOME SCREEN");
                                    f = Console.ReadLine().ToUpper();
                                    if (f == "B")
                                    {
                                        guests();
                                    }
                                    else if (f == "H")
                                    {
                                            MovieNames.Clear();
                                            MovieRatings.Clear();
                                            home();

                                    }

                                } while (f != "B" || f != "H");
                                //guests();
                                //Console.WriteLine("please select a seat to continue booking");
                                }
                            else if (agelimit > age)
                            {
                                Console.WriteLine("you are not allowed to watch this movie. \nThis movie requires a minimum age of {0}", agelimit);
                                guests();
                            }


                        }
                        else
                        {
                                Console.WriteLine("please enter a valid age to continue");
                                goto agestart;
                         }

                    }
                }
                else
                {
                    //failure
                    guests();

                }
            }

            }
        }
    }
}
