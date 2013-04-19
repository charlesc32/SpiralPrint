using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SpiralPrintTests
{
    [TestClass]
    public class SpiralPrintTest
    {
        [TestMethod]
        public void TestParseInputLine()
        {
            PrivateType program = new PrivateType(typeof(Program));
            var line = "3;3;1 2 3 4 5 6 7 8 9";
            var expected = new List<List<string>>() { new List<string>() { "1", "2", "3" }, new List<string>() { "4", "5", "6" }, new List<string>() { "7", "8", "9" } };
            var actual = (List<List<string>>)program.InvokeStatic("ParseInputLine", line);

            Assert.IsTrue(expected.Count == actual.Count, "Counts don't match");

            for (int i = 0; i < expected.Count; i++)
            {
                CollectionAssert.Equals(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestPrintSpiralExample()
        {
            PrivateType program = new PrivateType(typeof(Program));
            var line = "3;3;1 2 3 4 5 6 7 8 9";
            var input = (List<List<string>>)program.InvokeStatic("ParseInputLine", line);
            var expected = "1 2 3 6 9 8 7 4 5";
            var actual = program.InvokeStatic("PrintSpiral", input).ToString();
            Assert.AreEqual(expected, actual);

            line = "3;4;1 2 3 4 5 6 7 8 9 10 11 12";
            input = (List<List<string>>)program.InvokeStatic("ParseInputLine", line);
            expected = "1 2 3 4 8 12 11 10 9 5 6 7";
            actual = program.InvokeStatic("PrintSpiral", input).ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
