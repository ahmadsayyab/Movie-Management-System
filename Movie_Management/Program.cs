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
        //public static Hashtable moviesData = new Hashtable();    

        //ArrayList to store movies data
        public static ArrayList moviesData = new ArrayList();



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
                Console.WriteLine("Enter author of the movie: ");
                string author = Console.ReadLine();
                int movie_author;
                while (string.IsNullOrEmpty(author) || int.TryParse(author, out movie_author))
                {
                    if (string.IsNullOrEmpty(author))
                    {
                        Console.WriteLine("You missed out entering Author Name, Please enter it!: ");
                        author = Console.ReadLine();
                    }
                    else if (int.TryParse(author, out movie_author))
                    {
                        Console.WriteLine("Name cannot be an integer");
                        author = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }
                }
                int count = 0;
                double sum = 0;
                bool choose = true;
                while (choose)
                {
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

                     count++;
                    sum += double.Parse(rating);
                    Console.WriteLine("Do you want to add another rating?, type yes");
                    string decide = Console.ReadLine().ToLower();

                    if(decide == "yes")
                    {
                        choose = true;
                       
                    }
                    else
                    {
                        choose = false;
                    }

                }

               
                double avg_rating = sum / count;
                Console.WriteLine($"The average rating of the movie {title} after {count} times of rating is: {avg_rating}");





                //moviesData.Add(title, rating);
                moviesData.Add(title);
                //moviesData.Add(movie_rating);
                moviesData.Add(avg_rating);
                moviesData.Add(author);
                
                

                Console.WriteLine("####################################################");
                Console.WriteLine($"Movie Title: {title}, Movie Author: {author} & Rating: {avg_rating} has been added Successfully!!!");
                Console.WriteLine("#####################################################");
                Console.WriteLine("\nDo you want to add another Movie Data? type yes, OR any other Char to stop entering");
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


            Console.WriteLine("\n===Movies List===");
            int itemsPerGroup = 3;
            int itemCount = 0;
            Console.Write("Movie Name: \tRating: \tAuthor:\n");
            foreach (var item in moviesData)
            {

                Console.Write(item + "  \t\t");
                itemCount++;

                if (itemCount % itemsPerGroup == 0)
                {
                    // Start a new line after every group of three items
                    Console.WriteLine();
                }

            }

        }



        // //Function to let user delete any specific movie
        public static void DeleteMovie()
        {

            bool confirm = true;

            while (confirm)
            {

                if (moviesData.Count != 0)
                {


                    Console.WriteLine("Enter the movie title to delete:");
                    string title = Console.ReadLine();

                    while (string.IsNullOrEmpty(title) || !moviesData.Contains(title))
                    {
                        if (string.IsNullOrEmpty(title))
                        {
                            Console.WriteLine("You missed out entering Movie Title, Please enter it!: ");
                            title = Console.ReadLine();
                        }
                        else if (!moviesData.Contains(title))
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
                        Console.WriteLine("#######################################################");
                        Console.WriteLine($"Movie_Name: {title} has been deleted Successfully!!!");
                        Console.WriteLine("#####################################################\n");

                    int indexToRemove = -1; 

                    // Find the index of the movie title in the ArrayList
                    for (int i = 0; i < moviesData.Count; i += 3) 
                    {
                        string movieTitle = (string)moviesData[i];

                        if (movieTitle.Equals(title))
                        {
                            indexToRemove = i;
                            break; 
                        }
                    }

                    if (indexToRemove != -1)
                    {
                        
                        moviesData.RemoveRange(indexToRemove, 3); 
                       
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

                int itemsPerGroup = 3;
                int itemCount = 0;
                Console.Write("Movie Name: \tRating: \tAuthor:\n");
                foreach (var item in moviesData)
                {

                    Console.Write(item + "  \t\t");
                    itemCount++;

                    if (itemCount % itemsPerGroup == 0)
                    {
                        // Start a new line after every group of three items
                        Console.WriteLine();
                    }

                }



            }

        }


        ////Function to allow a user to Update a movie Rating
        public static void UpdateMovieRating()
        {

            bool confirm = true;

            while (confirm)
            {

                if (moviesData.Count != 0)
                {
                    Console.WriteLine("Enter the movie title:");
                    string title = Console.ReadLine();

                    while (string.IsNullOrEmpty(title) || !moviesData.Contains(title))
                    {
                        if (string.IsNullOrEmpty(title))
                        {
                            Console.WriteLine("You missed out entering Movie Title, Please enter it!: ");
                            title = Console.ReadLine();
                        }


                        else if (!moviesData.Contains(title))
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



                    int indexToUpdate = -1;
                    for (int i = 0; i < moviesData.Count; i += 3)
                    {
                        string movieTitle = (string)moviesData[i];

                        if (movieTitle.Equals(title))
                        {
                            indexToUpdate = i;
                            break;
                        }
                    }

                    //double new_rating = avg_rating + int.Parse(rating) / (count + 1);

                    if (indexToUpdate != -1)
                    {
                        
                        moviesData[indexToUpdate + 1] = rating;

                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }




                    Console.WriteLine("###############################################");
                    Console.WriteLine("Movie Rating has been updated Successfully!!!");
                    Console.WriteLine("###############################################");

                    Console.WriteLine($"\nNew Rating for the Movie {title} is: {rating}\n");

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



            int itemsPerGroup = 3;
            int itemCount = 0;
            Console.Write("Movie Name: \tRating: \tAuthor:\n");
            foreach (var item in moviesData)
            {

                Console.Write(item + "  \t\t");
                itemCount++;

                if (itemCount % itemsPerGroup == 0)
                {
                    
                    Console.WriteLine();
                }

            }



        }


        // //Function to allow the user to search for a specific movie
        public static void FindMovie()
        {

            bool confirm = true;

            while (confirm)
            {

                if (moviesData.Count != 0)
                {
                    Console.WriteLine("Enter the movie title to find if it exist:");
                    string title = Console.ReadLine();

                    while (string.IsNullOrEmpty(title) || !moviesData.Contains(title))
                    {
                        if (string.IsNullOrEmpty(title))
                        {
                            Console.WriteLine("You missed out entering Movie Title, Please enter it!: ");
                            title = Console.ReadLine();
                        }

                        else if (!moviesData.Contains(title))
                        {
                            Console.WriteLine("The title you provided does not exist in the collection" +
                                "enter the correct title!!!");
                            title = Console.ReadLine();
                        }
                    }

                    if (moviesData.Contains(title))
                    {
                        Console.WriteLine("##########################");
                        Console.WriteLine("Movie found Successfully!!!");
                        Console.WriteLine("##########################");
                        
                        int indexToShow = -1;
                        for (int i = 0; i < moviesData.Count; i += 3)
                        {
                            string movieTitle = (string)moviesData[i];

                            if (movieTitle.Equals(title))
                            {
                                indexToShow = i;
                                break;
                            }
                        }

                        if (indexToShow != -1)
                        {

                            
                            Console.Write($"Movie Name: {moviesData[indexToShow]}\t" );
                            Console.Write($"Movie Rating: {moviesData[indexToShow + 1]}\t");
                            Console.Write($"Movie Author: {moviesData[indexToShow + 2]}\t\n");

                        }
                        else
                        {
                            Console.WriteLine("Something went wrong");
                        }

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



            }
        }

        // //function to allow the user to see all the movies in the collection

        public static void ShowAllMovies()
        {
            if (moviesData.Count != 0)
            {
                int itemsPerGroup = 3;
                int itemCount = 0;
                Console.Write("Movie Name: \tRating: \tAuthor:\n");
                foreach (var item in moviesData)
                {

                    Console.Write(item + "  \t\t");
                    itemCount++;

                    if (itemCount % itemsPerGroup == 0)
                    {
                        
                        Console.WriteLine();
                    }

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
