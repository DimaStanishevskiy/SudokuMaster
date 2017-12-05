using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuMaster.Models
{
    /// <summary>
    /// Cell on the Sudoku field
    /// </summary>
    internal class Cell
    {
        private int? cellValue;

        /// <summary>
        /// The value of the cell (from 1 to 9 inclusive)
        /// </summary>
        public int? Value
        {
            set
            {
                if (value < 1 || value > 9)
                    throw new Exception();
                this.cellValue = value;
            }
            get
            {
                return this.cellValue;
            }
        }

        /// <summary>
        /// Indicates whether the field value is filled
        /// </summary>
        public bool IsFilled
        {
            get
            {
                return Value != null;
            }
        }
        /// <summary>
        /// A List with possible values
        /// </summary>
        public List<int> PotentialValues { set; get; }

        /// <summary>
        /// Create empty cell
        /// </summary>
        public Cell()
        {
            this.Value = null;
            PotentialValues = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9
            };
        }

        /// <summary>
        /// Create cell with specified value
        /// </summary>
        /// <param name="value">Cell value</param>
        public Cell(int value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Perform a check on the uniqueness of a possible cell value
        /// </summary>
        /// <returns>true - if the possible value is unique, false - if the possible value is not unique or the cell has a value</returns>
        public bool CheckForUnambiguity ()
        {
            if(!this.IsFilled)
                if(this.PotentialValues.Count == 1)
                {
                    this.Value = this.PotentialValues.First();
                    return true;
                }
            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != Type.GetType("SudokuMaster.Models.Cell"))
                return false;

            Cell objCell = obj as Cell;
            if (objCell.Value != this.Value || objCell.IsFilled != this.IsFilled || !objCell.PotentialValues.SequenceEqual(this.PotentialValues))
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(Convert.ToString(this.Value.GetHashCode()) + Convert.ToString(this.PotentialValues.GetHashCode()));
        }
    }
}