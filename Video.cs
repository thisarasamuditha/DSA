using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoApp
{
    public class Video
    {
        public String Title { get; set; }
        public String UploaderName { get; set; }
        public int ViewsCount { get; set; }

        public Video(string title, string uploaderName, int viewsCount)
        {
            Title = title;
            UploaderName = uploaderName;
            ViewsCount = viewsCount;
        }
        public void Display()
        {
            Console.WriteLine($"Title: {Title}, Uploader: {UploaderName}, Views: {ViewsCount}");

        }
    }
}
