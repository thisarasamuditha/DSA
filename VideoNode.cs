using System.Text;
using System.Threading.Tasks;

namespace VideoApp
{
    // Node class for the VideoBST
    public class VideoNode
    {
        public Video Data { get; set; }
        public VideoNode Left { get; set; }
        public VideoNode Right { get; set; }

        public VideoNode(Video Data)
        {
            this.Data = Data;
        }
    }

}


