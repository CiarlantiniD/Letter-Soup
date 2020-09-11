using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class FillGridServiceShould
    {
        private FillGridService fillGridService;

        [SetUp]
        public void SetUp()
        {
            fillGridService = new FillGridService();
        }

        [Test]
        public void FillGridServiceShouldSimplePasses()
        {
            // Given
            DataGrid dataGrid = new DataGrid(new char[3,3]);

            // When
            var result = fillGridService.FillGrid(dataGrid);

            // Then
            Assert.IsTrue(CheckEmptySpaces.Check(result));
        }
    }
}
