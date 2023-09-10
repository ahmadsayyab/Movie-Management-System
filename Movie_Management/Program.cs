using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Management
{
    public class Program
    {


        public static void Menu()
        {

            Console.WriteLine("===== Movie Management System =====");
            Console.WriteLine("\nWhich operation do you want to perform?\nChoose by id from the following menu. ");
            bool loopBreaker = true;

            while(loopBreaker)
            {
                
                Console.WriteLine("\n\n1. Add Movie\n2. Delete Movie\n3. Rate Movie\n4. Find Movie\n" +
                    "5. Show All Movies\n6. Exit \n\nEnter your choice (1-6):");

                string option = Console.ReadLine();
                int choose_option;
                while (string.IsNullOrEmpty(option) || !int.TryParse(option, out choose_option))
                {
                    if (string.IsNullOrEmpty(option))
                    {
                        Console.WriteLine("Please select one of the choices to proceed with the program!: ");
                        option = Console.ReadLine();
                    }
                    else if (!int.TryParse(option, out choose_option))
                    {
                        Console.WriteLine("Your input should be a digit between 1 - 6");
                        option = Console.ReadLine();
                    }
                    
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }


                switch (choose_option)
                {
                    case 1:
                        AddMovie();
                        break;
                    case 2:
                        DeleteMovie();
                        break;
                    case 3:
                        UpdateMovieRating();
                        break;
                    case 4:
                        FindMovie();
                        break;
                    case 5:
                        ShowAllMovies();
                        break;
                    case 6:
                        loopBreaker = false;
                        break;
                    default:
                        Console.WriteLine("\n===Wrong option===");
                        Console.WriteLine("Choose option only from the menu");
                        break;
                }
            }



        }

        //Hashtable stores movies data.
        public static Hashtable moviesData = new Hashtable();    
           


        //Function to add Movie into the Hashtable.
        public static void AddMovie()
        {

            

            bool confirm = true;

            while(confirm)
            {
                Console.WriteLine("Enter the movie title:");
                string title = Console.ReadLine();

                while (string.IsNullOrEmpty(title))
                {
                    Console.WriteLine("You missed out entering Movie Title, Please enter it!: ");
                    title = Console.ReadLine();
                }

                Console.WriteLine("Enter the movie rating (out of 10):");
                string rating = Console.ReadLine();
                int movie_rating;
                while (string.IsNullOrEmpty(rating) || !int.TryParse(rating, out movie_rating) || movie_rating > 10)
                {
                    if (string.IsNullOrEmpty(rating))
                    {
                        Console.WriteLine("You missed out entering Movie Rating, Please enter it!: ");
                        rating = Console.ReadLine();
                    }
                    else if (!int.TryParse(rating, out movie_rating))
                    {
                        Console.WriteLine("Your input should be a digit in range: 1 - 10");
                        rating = Console.ReadLine();
                    }
                    else if (movie_rating > 10)
                    {
                        Console.WriteLine("Keep your rating under 10:");
                        rating = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }


                moviesData.Add(title, rating);

                Console.WriteLine("####################################################");
                Console.WriteLine($"Movie Title: {title} & Rating: {rating} has been added Successfully!!!");
                Console.WriteLine("#####################################################");
                Console.WriteLine("\nDo you want to add another Movie? type yes, OR any other Char to stop entering");
                string choice = Console.ReadLine().ToLower();

                
                if(choice == "yes")
                {
                    confirm = true;
                }
                else
                {
                    confirm = false;
                }
                
                
            }


            //Console.WriteLine("\n===Movies List===");
            //Console.WriteLine("====Before deletion=====");
            //foreach (var key in moviesData.Keys)
            //{
            //    Console.WriteLine($"Movie Name: {key} \t Movie_Rating:  {moviesData[key]}");
            //}

        }



        //Function to let user delete any specific movie
        public static void DeleteMovie()
        {

            //Console.WriteLine("\n===Movies List===");
            //Console.WriteLine("====Before deletion=====");
            //foreach (var key in moviesData.Keys)
            //{
            //    Console.WriteLine($"Movie Name: {key} \t Movie_Rating:  {moviesData[key]}");
            //}

            bool confirm = true;

            while (confirm)
            {

                if (moviesData.Count != 0)
                {
                    Console.WriteLine("Enter the movie title to delete:");
                    string title = Console.ReadLine();

                    while (string.IsNullOrEmpty(title) || !moviesData.ContainsKey(title))
                    {
                        if (string.IsNullOrEmpty(title))
                        {
                            Console.WriteLine("You missed out entering Movie Title, Please enter it!: ");
                            title = Console.ReadLine();
                        }
                        else if (!moviesData.ContainsKey(title))
                        {
                            Console.WriteLine("The title you provided does not exist in the collection, " +
                                "enter the correct title!!!");
                            title = Console.ReadLine();


                        }

                        else
                        {
                            Console.WriteLine("Something went wrong!!!");
                        }

                    }

                    if (moviesData.ContainsKey(title))
                    {
                        Console.WriteLine("#######################################################");
                        Console.WriteLine($"Movie_Name: {title} has been deleted Successfully!!!");
                        Console.WriteLine("#####################################################\n");
                        moviesData.Remove(title);
                    }


                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }


                    Console.WriteLine("Do you want to delete another Movie? " +
                        "type yes, OR any other Char to stop entering");
                    string choice = Console.ReadLine().ToLower();


                    if (choice == "yes")
                    {
                        confirm = true;
                    }
                    else
                    {
                        confirm = false;
                    }

                }
                else
                {
                    Console.WriteLine("#########################");
                    Console.WriteLine("The collection is empty!!!");
                    Console.WriteLine("#########################");
                    break;
                }


                //Console.WriteLine("\n===Movies List===");
                //Console.WriteLine("====After deletion=====");
                //foreach (var key in moviesData.Keys)
                //{
                //    Console.WriteLine($"Movie Name: {key} \t Movie_Rating:  {moviesData[key]}");
                //}



            }

        }


       //Function to allow a user to Update a movie Rating
       public static void UpdateMovieRating()
       {

            //Console.WriteLine("\n===Movies List===");
            //Console.WriteLine("====Before Updating=====");
            //foreach (var key in moviesData.Keys)
            //{
            //    Console.WriteLine($"Movie Name: {key} \t Movie_Rating:  {moviesData[key]}");
            //}
            bool confirm = true;

            while (confirm)
            {

                if (moviesData.Count != 0)
                {
                    Console.WriteLine("Enter the movie title:");
                    string title = Console.ReadLine();

                    while (string.IsNullOrEmpty(title) || !moviesData.ContainsKey(title))
                    {
                        if (string.IsNullOrEmpty(title))
                        {
                            Console.WriteLine("You missed out entering Movie Title, Please enter it!: ");
                            title = Console.ReadLine();
                        }


                        else if (!moviesData.ContainsKey(title))
                        {
                            Console.WriteLine("The title you provided does not exist in the collection, " +
                                "enter the correct title!!!");
                            title = Console.ReadLine();

                        }

                        else
                        {
                            Console.WriteLine("Try again");
                        }

                    }

                    Console.WriteLine("Enter the new rating (out of 10):");
                    string rating = Console.ReadLine();
                    int movie_rating;
                    while (string.IsNullOrEmpty(rating) || !int.TryParse(rating, out movie_rating) || movie_rating > 10)
                    {
                        if (string.IsNullOrEmpty(rating))
                        {
                            Console.WriteLine("You missed out entering Movie Rating, Please enter it!: ");
                            rating = Console.ReadLine();
                        }
                        else if (!int.TryParse(rating, out movie_rating))
                        {
                            Console.WriteLine("Your input should be a digit in range: 1 - 10");
                            rating = Console.ReadLine();
                        }
                        else if (movie_rating > 10)
                        {
                            Console.WriteLine("Keep your rating under 10:");
                            rating = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input");
                        }
                    }




                    if (moviesData.ContainsKey(title))
                    {
                        moviesData[title] = rating;
                    }
                    else
                    {
                        Console.WriteLine("Something wrong happend");
                    }



                    Console.WriteLine("###############################################");
                    Console.WriteLine("Movie Rating has been updated Successfully!!!");
                    Console.WriteLine("###############################################");

                    Console.WriteLine($"\nNew Rating for the Movie {title} is:  {moviesData[title]}\n");

                    Console.WriteLine("Do you want to update rating for another Movie? type yes, " +
                        "OR any other Char to stop entering");
                    string choice = Console.ReadLine().ToLower();


                    if (choice == "yes")
                    {
                        confirm = true;
                    }
                    else
                    {
                        confirm = false;
                    }

                }

                else
                {
                    Console.WriteLine("#########################");
                    Console.WriteLine("The collection is empty");
                    Console.WriteLine("#########################");
                    break;
                }

            }


           
            //Console.WriteLine("\n===Movies List===");
            //Console.WriteLine("====After Updating=====");
            //foreach (var key in moviesData.Keys)
            //{


            //    Console.WriteLine($"Movie Name: {key} \t Movie_Rating:  {moviesData[key]}");
            //}



        }


        //Function to allow the user to search for a specific movie
        public static void FindMovie()
        {
            
            bool confirm = true;

            while (confirm)
            {

                if (moviesData.Count != 0)
                {
                    Console.WriteLine("Enter the movie title to find if it exist:");
                    string title = Console.ReadLine();

                    while (string.IsNullOrEmpty(title) || !moviesData.ContainsKey(title))
                    {
                        if (string.IsNullOrEmpty(title))
                        {
                            Console.WriteLine("You missed out entering Movie Title, Please enter it!: ");
                            title = Console.ReadLine();
                        }

                        else if (!moviesData.ContainsKey(title))
                        {
                            Console.WriteLine("The title you provided does not exist in the collection" +
                                "enter the correct title!!!");
                            title = Console.ReadLine();
                        }
                    }

                    if (moviesData.ContainsKey(title))
                    {
                        Console.WriteLine("##########################");
                        Console.WriteLine("Movie found Successfully!!!");
                        Console.WriteLine("##########################");
                        Console.WriteLine($"\nMovie_Name: {title} \t Movie_Rating: {moviesData[title]}\n");
                    }

                    else
                    {
                        Console.WriteLine("Something went wrog");
                    }


                    Console.WriteLine("Do you want to search for another Movie? " +
                        "type yes, OR any other Char to stop entering");
                    string choice = Console.ReadLine().ToLower();


                    if (choice == "yes")
                    {
                        confirm = true;
                    }
                    else
                    {
                        confirm = false;
                    }
                }

                else
                {
                    Console.WriteLine("#########################");
                    Console.WriteLine("The collection is empty!!!");
                    Console.WriteLine("#########################");
                    break;
                }


                //Console.WriteLine("\n===Movies List===");
                //Console.WriteLine("====After deletion=====");
                //foreach (var key in moviesData.Keys)
                //{
                //    Console.WriteLine($"Movie Name: {key} \t Movie_Rating:  {moviesData[key]}");
                //}



            }
        }

        //function to allow the user to see all the movies in the collection

        public static void ShowAllMovies()
        {
            if(moviesData.Count != 0)
            {
                foreach (var key in moviesData.Keys)
                {

                    Console.WriteLine("\n\t==== ALL Movies ====\n");
                    Console.WriteLine($"Movie Name: {key} \t Movie_Rating:  {moviesData[key]}");
                }
                
               
            }
            else
            {
                Console.WriteLine("#########################");
                Console.WriteLine("The Collection is empty!!!");
                Console.WriteLine("#########################");
                
            }
           
            
           
        }
        static void Main(string[] args)
        {
            Program.Menu();
        }
    }
}
