using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MindBoxTest
{
    [TestClass]
    public class FindPathTest
    {
        private PathFactory F = new PathFactory();

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Null route")]
        public void NullRoute()
        {
            var result = PathFinder.FindPath(null);            
        }

        [TestMethod]
        public void EmptyRoute()
        {
            var route = F.MakeRoute();

            var result = PathFinder.FindPath(route);

            Assert.IsTrue(F.CheckPath(0, result));
        }

        [TestMethod]
        public void OneValueRoute()
        {
            var route = F.MakeRoute(0);

            var result = PathFinder.FindPath(route);

            Assert.IsTrue(F.CheckPath(1, result));
        }

        [TestMethod]
        public void SimpleRoute()
        {
            var route = F.MakeRoute(0, 1);

            var result = PathFinder.FindPath(route);

            Assert.IsTrue(F.CheckPath(2, result));
        }

        [TestMethod]
        public void ReverseRoute()
        {
            var route = F.MakeRoute(1, 0);

            var result = PathFinder.FindPath(route);

            Assert.IsTrue(F.CheckPath(2, result));
        }

        [TestMethod]
        public void ExampleRoute()
        {
            var route = F.MakeRoute(0, 2, 1);

            var result = PathFinder.FindPath(route);

            Assert.IsTrue(F.CheckPath(3, result));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid route")]
        public void RouteWithWrongInItemInFirst()
        {
            var route = F.MakePositionRoute(F.E[0], F.I[0], F.I[2], F.I[1]);

            var result = PathFinder.FindPath(route);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid route")]
        public void RouteWithWrongInItemInMiddle()
        {
            var route = F.MakePositionRoute(F.I[0], F.E[0], F.I[1]);

            var result = PathFinder.FindPath(route);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid route")]
        public void RouteWithWrongInItemInLast()
        {
            var route = F.MakePositionRoute(F.I[0], F.I[1], F.E[0]);

            var result = PathFinder.FindPath(route);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid route")]
        public void RouteWithWrongOutItemInFirst()
        {
            var route = F.MakePositionRoute(F.E[1], F.I[0], F.I[2], F.I[1]);

            var result = PathFinder.FindPath(route);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid route")]
        public void RouteWithWrongOutItemInMiddle()
        {
            var route = F.MakePositionRoute(F.I[0], F.E[1], F.I[1], F.I[2]);

            var result = PathFinder.FindPath(route);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid route")]
        public void RouteWithWrongOutItemInLast()
        {
            var route = F.MakePositionRoute(F.I[0], F.I[1], F.I[2], F.E[1]);

            var result = PathFinder.FindPath(route);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid route")]
        public void RouteWithWrongInOutItemInFirst()
        {
            var route = F.MakePositionRoute(F.E[2], F.I[0], F.I[2], F.I[1]);

            var result = PathFinder.FindPath(route);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid route")]
        public void RouteWithWrongInOutItemInMiddle()
        {
            var route = F.MakePositionRoute(F.I[0], F.E[2], F.I[1], F.I[2]);

            var result = PathFinder.FindPath(route);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid route")]
        public void RouteWithWrongInOutItemInLast()
        {
            var route = F.MakePositionRoute(F.I[0], F.I[1], F.I[2], F.E[2]);

            var result = PathFinder.FindPath(route);
        }

    }
}
