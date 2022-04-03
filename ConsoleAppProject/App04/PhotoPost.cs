using System;

namespace ConsoleAppProject.App04
{
    ///<summary>
    /// This class stores information about a post in a social network. 
    /// The main part of the post consists of a photo and a caption. 
    /// Other data, such as author and time, are also stored.
    ///</summary>
    /// <author>
    /// Michael Kölling and David J. Barnes
    /// @version 2
    /// Modified by : Jessica Leach 3/4/22
    /// </author>
    public class PhotoPost : Post
    {
        public String Filename { get; set; }
        public String Caption { get; set; }

        ///<summary>
        /// Constructor for objects of class PhotoPost.
        ///</summary>
        /// <param name="author">
        /// The username of the author of this post.
        /// </param>
        /// <param name="caption">
        /// A caption for the image.
        /// </param>
        /// <param name="filename">
        /// The filename of the image in this post.
        /// </param>
        public PhotoPost(String author, String filename, String caption) : base(author)
        {
            this.Filename = filename;
            this.Caption = caption;
        }
        /// <summary>
        /// Display the new photo post
        /// </summary>
        public override void Display()
        {
           
            Console.WriteLine("===================================================");
           
            Console.WriteLine("\t\t Photo Post Display");
            Console.WriteLine($"\t\tFilename: [{Filename}]");
            Console.WriteLine($"\t\tCaption: [{Caption}]");
            base.Display();
        }
    }
}