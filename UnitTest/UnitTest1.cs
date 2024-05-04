using NUnit.Framework;
using System.IO;
using Newtonsoft.Json;
using System;

namespace Statistics.Tests
{
    [TestFixture]
    public class StatisticsTests
    {
        private static int[] testData = JsonConvert.DeserializeObject<int[]>(File.ReadAllText("data.json"));

        [Test]
        public void TestMaximum()
        {
            int expected = testData.Max();
            int actual = Statistics.Maximum();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestMinimum()
        {
            int expected = testData.Min();
            int actual = Statistics.Minimum();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestMean()
        {
            double expected = Array.ConvertAll(testData, x => (double)x).Average();
            double actual = Statistics.Mean();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestMedian()
        {
            Array.Sort(testData);
            int expected = testData[testData.Length / 2];
            int actual = (int)Statistics.Median();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestRange()
        {
            int expected = testData.Max() - testData.Min();
            int actual = Statistics.Range();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestStandardDeviation()
        {
            double mean = Array.ConvertAll(testData, x => (double)x).Average();
            double expected = Math.Sqrt(Array.ConvertAll(testData, x => Math.Pow((x - mean), 2)).Average());
            double actual = Statistics.StandardDeviation();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestMode()
        {
            int[] testData = new int[] { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 };
            int[] expectedModes = new int[] { 4 }; // here 4 is mode

            int[] actualModes = Statistics.Mode();

            CollectionAssert.AreEqual(expectedModes, actualModes);
        }
    }
}