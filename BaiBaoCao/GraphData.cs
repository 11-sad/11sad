using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiBaoCao
{
    [Serializable]
    class GraphData
    {
        public List<Point> NodeLocations;
        public EdgeCollection Edges;
        public int FormNode;
        public int ToNode;
        public bool IsUndirectedGraph;

        public GraphData(int fromNode, int toNode)
        {
            FormNode = fromNode;
            ToNode = toNode;
            NodeLocations = new List<Point>();

        }
        
    }
}
