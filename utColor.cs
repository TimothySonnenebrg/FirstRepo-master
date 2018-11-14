using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TJS.VehicleTracker.BL;
using System.Linq;

namespace TJS.VehicleTracker.BL.Test
{
    [TestClass]
    public class utColor
    {
        [TestMethod]
        public void LoadColorTest()
        {
            ColorList colors = new ColorList();
            colors.Load();
            Assert.AreEqual(3, colors.Count);
            colors = null;

        }
    }
}
