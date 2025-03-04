using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoApp
{
    public class VideoPlatform 
    {
        public Node? Head { get; set; }
        public Node? Tail { get; set; }
        
        public VideoPlatform()
        {
            Head = null;
            Tail = null;
            
        }

        public void Upload(Video video)
        {
            Node newNode = new Node(video);
            if(Head == null) // check if the list is empty
            {
                Head = newNode;
                Tail = newNode;
                
            }
            else
            {
               Tail.Next = newNode;
               Tail = newNode;
                
            }
            Console.WriteLine($"\nVideo '{video.Title}' uploaded successfully...");
        }
        public bool Remove(String title)
        {
            if (Head == null) return false;

            if (Head.Data.Title.Equals(title))
            {
                Head = Head.Next;
                return true;
            }

            Node? current = Head;
            Node? previous = null;

            while (current != null && !current.Data.Title.Equals(title))
            {
                previous = current;
                current = current.Next;
            }

            if (current == null) return false; // Video not found

            previous.Next = current.Next;
            return true;
            
        }
        public bool Search(String title) 
        {
            if (Head != null)
            {
                Node temp = Head;
                while (temp != null)
                {
                    if (title.Equals(temp.Data.Title, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"\nVideo '{title}' is available in the collection");
                        return true;
                    }
                    temp = temp.Next;
                }
               
            }
            Console.WriteLine("\nThe video is not found in the collection!");
            return false;
        }

        public void ListVideos()
        {
            if (Head == null) // check if the list is empty
            {
                Console.WriteLine("No videos available");
            }
            else
            {
                Console.WriteLine("\nUploaded videos:");
                Node? temp = Head;
                while (temp != null)
                {
                    temp.Data.Display(); // print all the data of the video
                    temp = temp.Next;
                }
            }  

        }
    }
}
