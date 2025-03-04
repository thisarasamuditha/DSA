using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoApp
{
    public class VideoSorting
    {
        public VideoPlatform platform;

        public VideoSorting(VideoPlatform videoPlatform)
        {
            this.platform = videoPlatform;
        }

        public void SortVideosUsingSelection()
        {
            if(platform.Head == null)
            {
                Console.WriteLine("No videos to sort!");
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            // Using Selection sort
            Node? current = platform.Head;
            while (current != null)
            {
               Node? index = current.Next;
               Node? min = current;

               while (index != null)
               {
                  if (min.Data.ViewsCount > index.Data.ViewsCount)
                  {
                     min = index; // finding the minimum element in the list
                  }
                  index = index.Next;
               }
               // swapping the min data with current data
               int temp = current.Data.ViewsCount;
               current.Data.ViewsCount = min.Data.ViewsCount;
               min.Data.ViewsCount = temp;

               current = current.Next;

            }
 
            stopwatch.Stop();
            long elapsedNanoSeconds = (stopwatch.ElapsedTicks * 1_000_000_000) / Stopwatch.Frequency;
            Console.WriteLine($"\nSelection Sort completed in {elapsedNanoSeconds} ns");

            Show();
        }

        // Sort videos using Quick Sort
        public void SortVideosUsingQuick()
        {
            if (platform.Head == null)
            {
                Console.WriteLine("No videos to sort!");
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            platform.Head = QuickSort(platform.Head, GetTail(platform.Head));
            stopwatch.Stop();

            long elapsedNanoSeconds = (stopwatch.ElapsedTicks * 1_000_000_000) / Stopwatch.Frequency;
            Console.WriteLine($"\nQuick Sort completed in {elapsedNanoSeconds} ns");

            Show();
        }

        // Recursive QuickSort implementation
        private Node QuickSort(Node head, Node tail)
        {
            if (head == null || head == tail) return head;

            Node pivot = Partition(head, tail, out Node newHead, out Node newTail);

            // Recursively sort the list before the pivot
            if (newHead != pivot)
            {
                Node temp = newHead;
                while (temp.Next != pivot) temp = temp.Next;
                temp.Next = null;

                newHead = QuickSort(newHead, temp);

                temp = GetTail(newHead);
                temp.Next = pivot;
            }

            // Recursively sort the list after the pivot
            pivot.Next = QuickSort(pivot.Next, newTail);

            return newHead;
        }

        // Partition the list and return the pivot node
        private Node Partition(Node head, Node tail, out Node newHead, out Node newTail)
        {
            Node pivot = tail;
            Node prev = null, current = head, end = tail;

            // Initialize new head and tail
            newHead = null;
            newTail = tail;

            while (current != pivot)
            {
                if (current.Data.ViewsCount < pivot.Data.ViewsCount)
                {
                    if (newHead == null) newHead = current;

                    prev = current;
                    current = current.Next;
                }
                else
                {
                    if (prev != null) prev.Next = current.Next;

                    Node temp = current.Next;
                    current.Next = null;
                    end.Next = current;
                    end = current;

                    current = temp;
                }
            }

            if (newHead == null) newHead = pivot;

            newTail = end;

            return pivot;
        }

        // Helper to get the tail node of the list
        private Node GetTail(Node node)
        {
            while (node != null && node.Next != null) node = node.Next;
            return node;
        }

        // Sort videos using Merge Sort
        public void SortVideosUsingMerge()
        {
            if (platform.Head == null || platform.Head.Next == null)
            {
                Console.WriteLine("No videos to sort!");
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            platform.Head = MergeSort(platform.Head);
            stopwatch.Stop();

            long elapsedNanoSeconds = (stopwatch.ElapsedTicks * 1_000_000_000) / Stopwatch.Frequency;
            Console.WriteLine($"\nMerge Sort completed in {elapsedNanoSeconds} ns");

            Show();
        }

        // Merge Sort implementation for linked list
        private Node MergeSort(Node head)
        {
            if (head == null || head.Next == null) return head;

            Node middle = GetMiddle(head);
            Node nextToMiddle = middle.Next;
            middle.Next = null;

            Node left = MergeSort(head);
            Node right = MergeSort(nextToMiddle);

            return Merge(left, right);
        }

        // Merges two sorted linked lists
        private Node Merge(Node left, Node right)
        {
            if (left == null) return right;
            if (right == null) return left;

            Node result;
            if (left.Data.ViewsCount <= right.Data.ViewsCount)
            {
                result = left;
                result.Next = Merge(left.Next, right);
            }
            else
            {
                result = right;
                result.Next = Merge(left, right.Next);
            }
            return result;
        }

        // Finds the middle of the linked list
        private Node GetMiddle(Node head)
        {
            if (head == null) return head;

            Node slow = head, fast = head;
            while (fast.Next != null && fast.Next.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }

        public void Show()
        {
            if (platform.Head == null)
            {
                Console.WriteLine("No videos available");
                return;
            }

            Node? temp = platform.Head;
            while (temp != null)
            {
                temp.Data.Display(); // print the sorted videos
                temp = temp.Next;
            }
        }

    }

}
