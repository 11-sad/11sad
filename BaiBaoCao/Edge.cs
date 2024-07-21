using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiBaoCao
{

    [Serializable]
    class EdgeCollection : IEnumerable<Edge>
    {
        List<Edge> _list;

        public EdgeCollection()
        {
            _list = new List<Edge>();
        }
        public bool Add(Edge edge)
        {
            if (!_list.Contains(edge))
            {
                Edge newEdge = new Edge(edge.End, edge.Start);
                if (_list.Contains(newEdge))
                {
                    edge = _list[_list.IndexOf(newEdge)];
                    edge.IsUndirected = true;
                }
                else
                {
                    _list.Add(edge);
                }
                return true;
            }
            return false;
        }
        public void Clear()
        {
            _list.Clear();
        }
        public bool Contains(Edge edge)
        {
            return _list.Contains(edge);
        }
        public Edge this[int index]
        {
            get { return _list[index]; }
        }
        public bool Contains(Edge edge, bool checkInverted)
        {
            if (_list.Contains(edge))
                return true;
            if (checkInverted)
                return _list.Contains(new Edge(edge.End, edge.Start));
            return false;
        }
        public void RemoveAt(int index)
        {
            System.Threading.Thread.Sleep(100);
            _list.RemoveAt(index);
        }
        public int Count
        {
            get { return _list.Count; }
        }
        public IEnumerator<Edge> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
    [Serializable]
    class Edge
    {
        public int Start;
        public int End;
        public bool IsUndirected;
        public bool IsRemoving;

        public Edge(int start, int end)
        {
            this.Start = start;
            this.End = end;
            this.IsUndirected = false;
        }


        public override bool Equals(Object obj)
        {
            if (!(obj is Edge))
                return false;
            Edge con = (Edge)obj;
            if (this.Start == con.Start && this.End == con.End)
                return true;
            if (this.IsUndirected && this.Start == con.End && this.End == con.Start)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return Start ^ End;
        }
    }
}
