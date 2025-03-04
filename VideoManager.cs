using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoApp
{
    public class VideoManager
    {
        public VideoPlatform platform;
        public VideoBST videoBST;
        public VideoSorting sorting;

        public VideoManager()
        {
            platform = new VideoPlatform();
            videoBST = new VideoBST();
            sorting = new VideoSorting(platform);
        }

        public void RemoveVideo(string title)
        {
            bool removedFromList = platform.Remove(title);
            bool removedFromBST = videoBST.Remove(title);

            if (removedFromBST || removedFromList)
            {
                Console.WriteLine($"\nVideo '{title}' removed successfully...");
            }
            else
            {
                Console.WriteLine("\nThe video is not found in the collection!");
            }
        }
        public void DisplayVideos()
        {
            platform.ListVideos();
            videoBST.DisplayVideos();
        }
    }
}
