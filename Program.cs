// See https://aka.ms/new-console-template for more information
using VideoApp;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the video uploading platform");
        Console.WriteLine("---------------------------------------\n");

        VideoBST videoBST = new VideoBST();
        VideoPlatform platform = new VideoPlatform();
        VideoSorting sorting = new VideoSorting(platform);
        VideoManager videoManager = new VideoManager();


        while (true)
        {
            Console.WriteLine("1: Upload a video using LinkedList");
            Console.WriteLine("2: Upload a video using BST");
            Console.WriteLine("3: Search a video using LinkedList");
            Console.WriteLine("4: Search a video using BST");
            Console.WriteLine("5: Remove a video");
            Console.WriteLine("6: Display videos");
            Console.WriteLine("7: Sort videos by views using Selection Sort");
            Console.WriteLine("8: Sort videos by views using Merge Sort");
            Console.WriteLine("9: Sort videos by views using Quick Sort");
            Console.WriteLine("10: Exit \n");

            Console.Write("Choose an option: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Title: ");
                    String title = Console.ReadLine();
                    Console.Write("Uploader Name: ");
                    String name = Console.ReadLine();
                    Console.Write("Views: ");
                    int views = Convert.ToInt32(Console.ReadLine());

                    videoManager.platform.Upload(new Video(title, name, views));
                    break;

                case 2:
                    Console.Write("Title: ");
                    String UploadTitle = Console.ReadLine();
                    Console.Write("Uploader Name: ");
                    String UploaderName = Console.ReadLine();
                    Console.Write("Views: ");
                    int ViewsCount = Convert.ToInt32(Console.ReadLine());

                    videoManager.videoBST.Upload(new Video(UploadTitle, UploaderName, ViewsCount));
                    break;

                case 3:
                    Console.Write("Title of the video you want to search: ");
                    String SearchTitle1 = Console.ReadLine();
                    videoManager.platform.Search(SearchTitle1);
                    break;

                case 4:
                    Console.Write("Title of the video you want to search: ");
                    String SearchTitle2 = Console.ReadLine();
                    videoManager.videoBST.Search(SearchTitle2);
                    break;

                case 5:
                    Console.Write("Title of the video you want to remove: ");
                    String topic = Console.ReadLine();

                    videoManager.RemoveVideo(topic);
                    break;

                case 6:
                    videoManager.DisplayVideos();
                    break;

                case 7:
                    videoManager.sorting.SortVideosUsingSelection();
                    break;

                case 8:
                    videoManager.sorting.SortVideosUsingMerge();
                    break;

                case 9:
                    videoManager.sorting.SortVideosUsingQuick();
                    break;

                case 10:
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again!");
                    break;
            }
            Console.WriteLine();


        }


    }
}