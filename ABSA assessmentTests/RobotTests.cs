using Microsoft.VisualStudio.TestTools.UnitTesting;
using ABSA_assessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSA_assessment.Tests
{
    [TestClass()]
    public class RobotTests
    {
        [TestMethod()]
        public void TestExceptionCase()
        {
            Robot Robo = new Robot();
            int[] RoboSouthArray;
            int[] RoboNorthArray;
            int[] RoboEastArray;
            int[] RoboWestArray;
            try
            {
                RoboNorthArray = Robo.MoveNorth(2);
                RoboSouthArray = Robo.MoveSouth(1, RoboNorthArray.Last().ToString());
                RoboEastArray = Robo.MoveEast(3, RoboSouthArray.Last());
                RoboWestArray = Robo.MoveWest(4, RoboEastArray.Last(), RoboSouthArray.Last());
            }
            catch(ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "enter numeric number < 10");
            }
            Assert.Fail("No exception was thrown");
        }

        [TestMethod()]
        public void TestUniqueMovesCase()
        {
            try
            {
                Robot Robo = new Robot();
                int[] RoboNorthArray = Robo.MoveNorth(3);
                int[] RoboSouthArray = Robo.MoveSouth(2, RoboNorthArray.Last().ToString());
                int[] RoboEastArray = Robo.MoveEast(4, RoboSouthArray.Last());
                int[] RoboWestArray = Robo.MoveWest(0, RoboEastArray.Last(), RoboSouthArray.Last());
                Robo.GetMovements();
            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, "Final output test failed check");
            }
            Assert.Fail("No exception was thrown");
        }
    }
}