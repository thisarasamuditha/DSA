using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoApp
{

	public class VideoBST
	{
        private VideoNode root;

        // Insert a new video into the BST
        public void Upload(Video video)
        {
            root = UploadHelper(root, video);
            Console.WriteLine($"\nVideo '{video.Title}' uploaded successfully...");

        }

        private VideoNode UploadHelper(VideoNode root, Video video)
        {
            if (root == null)
                return new VideoNode(video);

            if (string.Compare(video.Title, root.Data.Title, StringComparison.OrdinalIgnoreCase) < 0)
                root.Left = UploadHelper(root.Left, video);

            else if (string.Compare(video.Title, root.Data.Title, StringComparison.OrdinalIgnoreCase) > 0)
                root.Right = UploadHelper(root.Right, video);

            return root;
        }
        public bool Remove(String title)
        {
            root = RemoveHelper(root, title);
            return root != null;
        }
        private VideoNode RemoveHelper(VideoNode root, String title)
        {
            if (root == null)
            {
                return root;
            }
            int cmp = string.Compare(title, root.Data.Title, StringComparison.OrdinalIgnoreCase);

            if (cmp < 0)
            {
                root.Left = RemoveHelper(root.Left, title);
            }
            else if (cmp > 0)
            {
                root.Right = RemoveHelper(root.Right, title);
            }
            else
            { // video found
                if (root.Left == null && root.Right == null)
                {
                    root = null;
                }
                else if (root.Right != null)
                { // need to find the successor to replace this node
                    root.Data.Title = Successor(root);
                    root.Right = RemoveHelper(root.Right, root.Data.Title);
                }
                else
                { // need to find the predecessor to replace this node
                    root.Data.Title = Predecessor(root);
                    root.Left = RemoveHelper(root.Left, root.Data.Title);
                }
            }
            return root;
        }

        private string Predecessor(VideoNode root)
        {
            root = root.Left;
            while (root.Right != null)
            {
                root = root.Right;
            }
            return root.Data.Title;
        }

        private string Successor(VideoNode root)
        {
            root = root.Right;
            while (root.Left != null)
            {
                root = root.Left;
            }
            return root.Data.Title;
        }

        // Search for a video by title
        public bool Search(string title)
        {
            VideoNode? result = SearchHelper(root, title);

            if (result != null)
            {
                Console.WriteLine($"\nVideo '{title}' is available in the collection");
                return true;
            }
            else
            {
                Console.WriteLine("\nThe video is not found in the collection!");
                return false;
            }

        }

        private VideoNode SearchHelper(VideoNode root, string title)
        {
            if (root == null || root.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                return root;

            return string.Compare(title, root.Data.Title, StringComparison.OrdinalIgnoreCase) < 0
                ? SearchHelper(root.Left, title)
                : SearchHelper(root.Right, title);
        }

        // Display all videos (in-order traversal)
        public void DisplayVideos()
        {
            DisplayInOrder(root);
        }

        private void DisplayInOrder(VideoNode root)
        {
            if (root != null)
            {
                DisplayInOrder(root.Left);
                Console.WriteLine($"Title: {root.Data.Title}, Uploader: {root.Data.UploaderName}, Views: {root.Data.ViewsCount}");
                DisplayInOrder(root.Right);
            }
        }
    }

}

        
