using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssignmentTest
{
    /// <summary>
    /// Represents the test suite for the Assignment project.
    /// </summary>
    [TestClass]
    public class AssignmentTests
    {
        /// <summary>
        /// Tests the properties of the Robot class.
        /// </summary>
        [TestMethod]
        public void PropertiesTest()
        {
            Robot robot1 = new();
            Assert.AreEqual(6, robot1.NumCommands);

            const int ExpectedCommands = 10;
            Robot robot2 = new(ExpectedCommands);
            Assert.AreEqual(ExpectedCommands, robot2.NumCommands);

            Assert.IsFalse(robot1.IsPowered);
            robot1.IsPowered = true;
            Assert.IsTrue(robot1.IsPowered);

            Assert.AreEqual(0, robot1.X);
            robot1.X = -5;
            Assert.AreEqual(-5, robot1.X);

            Assert.AreEqual(0, robot1.Y);
            robot1.Y = -5;
            Assert.AreEqual(-5, robot1.Y);
        }

        /// <summary>
        /// Tests the execution of a custom command on the Robot.
        /// </summary>
        [TestMethod]
        public void CustomCommandTest()
        {
            Robot robot = new();

            // Load commands
            robot.LoadCommand(new OnCommand());
            robot.LoadCommand(new EastCommand());
            robot.LoadCommand(new CustomCommand());

            // Run commands
            robot.Run();

            // Check final state
            Assert.AreEqual(1, robot.X);
            Assert.AreEqual(0, robot.Y);
            Assert.IsTrue(robot.IsPowered);
        }
    }
}
