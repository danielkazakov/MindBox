using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBoxTest
{
    class PathFactory
    {
        public Tuple<string, string>[] I = new Tuple<string, string>[]
        {
            new Tuple<string, string>("Мельбурн", "Кельн"),
            new Tuple<string, string>("Кельн", "Москва"),
            new Tuple<string, string>("Москва", "Париж"),
            new Tuple<string, string>("Париж", "Брюсель"),
            new Tuple<string, string>("Брюсель", "Лондон")
        };

        public Tuple<string, string>[] E = new Tuple<string, string>[]
        {
            new Tuple<string, string>("Лужники", "Москва"),
            new Tuple<string, string>("Москва", "Космос"),
            new Tuple<string, string>("Волга", "Арена"),
        };

        public bool CheckPath(int length, IEnumerable<Tuple<string, string>> path)
        {
            var i = 0;
            foreach(var item in path)
            {
                if (!item.Equals(I[i]))
                    return false;
                i++;
            }
            if (i != length)
                return false;

            return true;
        }

        public IEnumerable<Tuple<string, string>> MakeRoute(params int[] list)
        {
            var route = new List<Tuple<string, string>>();

            foreach(var i in list)
            {
                route.Add(I[i]);
            }

            return route;
        }

        public IEnumerable<Tuple<string, string>> MakePositionRoute(params Tuple<string, string>[] list)
        {
            var route = new List<Tuple<string, string>>();

            foreach (var item in list)
            {
                route.Add(item);
            }

            return route;
        }

    }
}
