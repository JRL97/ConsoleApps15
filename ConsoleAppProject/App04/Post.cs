using System;
using System.Collections.Generic;
using ConsoleAppProject.Helpers;


namespace ConsoleAppProject.App04
{
    ///<summary>
    ///  The Post class is the parent class for both MessagePost and PhotoPost
    ///</summary>
    /// <author>
    /// Michael Kölling and David J. Barnes
    /// @version 0.1
    /// Modified by : Jessica Leach 3/4/22
    /// </author>
    public class Post
    {
       
        public int PostId { get; }
        public String Username { get; set; }

        public DateTime Timestamp { get; }

        public static int instances = 0;

        private int likes;
        

        private readonly List<String> comments;

        /// <summary>
        /// This allows the programe to run and outputs the associated Title and author for 
        /// each app.
        /// </summary>
        public void Run()
        {
            bool repeat = true;
            while (repeat)
            {
                ConsoleHelper.OutputHeading("App04 Social Network", "Jessica Leach");
                repeat = ConsoleHelper.Repeat();
            }

           
        }

        /// <summary>
        /// Constructor for the Post Class
        /// </summary>
        /// <param name="author"></param>
        public Post(String author)
        {
            instances++;
            PostId = instances;

            this.Username = author;
            Timestamp = DateTime.Now;

            likes = 0;
            comments = new List<String>();
        }

        ///<summary>
        /// Add a like to a total for a post
        ///</summary>
        public void Like()
        {
            likes++;
        }

        ///<summary>
        /// Remove a like from the total on a post
        ///</summary>
        public void Unlike()
        {
            if (likes > 0)
            {
                likes--;
            }
        }

        ///<summary>
        /// Add a comment to a post
        /// </summary>
        public void AddComment(String text)
        {
            comments.Add(text);
        }

        ///<summary>
        /// Display a post and post info in the terminal
        ///</summary>
        public virtual void Display()
        {
            Console.WriteLine();
            Console.WriteLine($"\tPost ID:\t {PostId}");
            Console.WriteLine($"\tAuthor:\t\t {Username}");
            Console.WriteLine($"\tTime Elpased:\t {FormatElapsedTime(Timestamp)}");
            Console.WriteLine($"\tDate Posted:\t {Timestamp.ToLongDateString()}");
            Console.WriteLine($"\tTime Posted:\t {Timestamp.ToLongTimeString()}");
            Console.WriteLine("===================================================");
            Console.WriteLine();

            if (likes > 0)
            {
                Console.WriteLine($"    Likes: -  {likes}  people like this.");
            }
            else
            {
                Console.WriteLine();
            }
           
            if (comments.Count == 0)
            {
                Console.WriteLine("    No comments.");
              
                Console.WriteLine("===================================================");
               
            }
            else
            {
                Console.WriteLine($"    Comment(s): {comments.Count}  Click here to view.");
                foreach (string comments in comments)
                {
                    Console.WriteLine($"\tComment: {comments}\n");
                 
                    Console.WriteLine("===================================================");
              

                }
            }
        }

        /// <summary>
        /// Count the number of posts
        /// </summary>
        public static int GetNumberOfPosts()
        {
            return instances;
        }

        /// <summary>
        ///Calculate how long ago a post was made
        /// </summary>
        /// <param name="time">
        /// The time value to convert (in system milliseconds)
        /// </param> 
        /// <returns>
        /// A relative time string for the given time
        /// </returns>  
        private String FormatElapsedTime(DateTime time)
        {
            DateTime current = DateTime.Now;
            TimeSpan timePast = current - time;

            long seconds = (long)timePast.TotalSeconds;
            long minutes = seconds / 60;

            if (minutes > 0)
            {
                return minutes + " minutes ago";
            }
            else
            {
                return seconds + " seconds ago";
            }
        }
    }
}
