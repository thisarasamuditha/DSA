using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoApp
{
    public class Node
    {
        public Video Data { get; set; }
        public Node? Next { get; set; }

        public Node(Video data)
        {
            Data = data;
            Next = null;
        }
    }
}
