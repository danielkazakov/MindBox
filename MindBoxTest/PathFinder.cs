using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBoxTest
{
    class PathFinder
    {
        public static IEnumerable<Tuple<string, string>> FindPath(IEnumerable<Tuple<string,string>> route)
        {
            if (route == null)
                throw new ArgumentNullException("Null route");

            var list = new List<Tuple<string, string>>();

            if (route.Count() == 0)
                return list;

            var forward = new Dictionary<string, string>();
            var backward = new Dictionary<string, string>();

            //O(N)
            foreach(var item in route)
            {
                forward[item.Item1] = item.Item2;
                backward[item.Item2] = item.Item1;
            }

            if (forward.Count != backward.Count)
                throw new ArgumentException("Invalid route");

            //O(N/2)
            var start = backward.First().Value;
            var temp = "";

            //O(N)
            while(backward.TryGetValue(start, out temp))
            {
                start = temp;
            }

            var finish = forward[start];

            list.Add(new Tuple<string, string>(start, finish));

            //O(N)
            while (forward.TryGetValue(finish, out temp))
            {
                list.Add(new Tuple<string, string>(finish, temp));
                finish = temp;
            }

            if (forward.Count != list.Count)
                throw new ArgumentException("Invalid route");

            return list;
        }
    }
}
