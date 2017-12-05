using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuMaster.Models;
using System.Runtime.CompilerServices;
using System.Linq;

[assembly: InternalsVisibleTo("Cell")]
namespace SudokuMasterTest
{
    [TestClass]

    public class CellTest
    {
        [TestMethod]
        public void CreateEmptyCell()
        {
            //arrange
            Cell cell = new Cell();

            //act
            bool testResult =
                cell.Value == null &&
                cell.IsFilled == false &&
                cell.PotentialValues.Count == 9;

            //assert
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void CreateCellWithValue()
        {
            //arrange
            Cell cell = new Cell(2);

            //act
            bool testResult =
                cell.Value == 2 &&
                cell.IsFilled == true;

            //assert
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void CreateCellWithBadValue()
        {
            try
            {
                Cell cell = new Cell(0);
                Assert.IsTrue(false);
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void ChechForUnambiguitySingleValue()
        {
            //arrange
            Cell cell = new Cell();

            //act
            cell.PotentialValues.RemoveRange(0, 8);
            int lastPotentialValue = cell.PotentialValues.First();
            bool testResult = 
                cell.CheckForUnambiguity() && 
                cell.IsFilled && 
                cell.Value == lastPotentialValue; 

            //assert
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void ChechForUnambiguityNoSingleValue()
        {
            //arrange
            Cell cell = new Cell();

            //act
            int lastPotentialValue = cell.PotentialValues.First();
            bool testResult =
                !cell.CheckForUnambiguity() &&
                !cell.IsFilled &&
                cell.Value == null;

            //assert
            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void CellEquals()
        {
            //arrange
            Cell cell1 = new Cell();
            Cell cell2 = new Cell();

            //act

            //assert
            Assert.IsTrue(cell1.Equals(cell2));
        }

        [TestMethod]
        public void CellGetHashCode()
        {
            //arrange
            Cell cell = new Cell();

            //act
            int hash = cell.GetHashCode();

            //assert
            Assert.IsNotNull(hash);
        }

    }
}
