using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinesweeperTools;

namespace MinesweeperAnalyser.UnitTest
{
	[TestClass]
	public class RandomMatrixCreatorTest
	{
		[TestMethod]
		public void Create_ReturnGoodAmountOfSpace()
		{
			RandomMatrixCreator creator = new RandomMatrixCreator();

			bool[,] matrix = creator.Create(nbrColumns: 3, nbrRows: 4, nbrBombs: 3);

			Assert.AreEqual(2, matrix.Rank, "An array of two dimensions should be created");
			
			int nbrColumns = matrix.GetLength(0);
			Assert.AreEqual(3, nbrColumns, "An array with 3 columns should be created");

			int nbrRows = matrix.GetLength(1);
			Assert.AreEqual(4, nbrRows, "An array with 4 rows should be created");
		}

		[TestMethod]
		public void Create_WithThreeBombs_ReturnGoodAmountOfBombs()
		{
			RandomMatrixCreator creator = new RandomMatrixCreator();

			bool[,] matrix = creator.Create(nbrColumns: 4, nbrRows: 4, nbrBombs: 3);

			int nbrBombsFound = 0;
			foreach(bool cell in matrix)
			{
				if (cell == true)
					nbrBombsFound++;
			}

			Assert.AreEqual(3, nbrBombsFound);
		}

		[TestMethod]
		[ExpectedException(typeof(MatrixCreationException))]
		public void Create_WithMoreBombsThanSpace_ThrowException()
		{
			RandomMatrixCreator creator = new RandomMatrixCreator();
			
			bool[,] matrix = creator.Create(nbrColumns: 1, nbrRows: 1, nbrBombs: 3);
		}

		[TestMethod]
		[ExpectedException(typeof(MatrixCreationException))]
		public void Create_WithoutBomb_ThrowException()
		{
			RandomMatrixCreator creator = new RandomMatrixCreator();

			bool[,] matrix = creator.Create(nbrColumns: 2, nbrRows: 2, nbrBombs: 0);
		}
		
		[TestMethod]
		public void Create_DoNotReturnTwiceTheSameMatrix()
		{
			RandomMatrixCreator creator = new RandomMatrixCreator();

			bool[,] matrix1 = creator.Create(nbrColumns: 10, nbrRows: 10, nbrBombs: 6);
			bool[,] matrix2 = creator.Create(nbrColumns: 10, nbrRows: 10, nbrBombs: 6);

			bool isSame = true;
			for (int idxColumn = 0; idxColumn < matrix1.GetLength(0); idxColumn++)
			{
				for (int idxRow = 0; idxRow < matrix1.GetLength(1); idxRow++)
				{
					if (matrix1[idxColumn, idxRow] != matrix2[idxColumn, idxRow])
						isSame = false;
				}
			}
			Assert.IsFalse(isSame);
		}
	}
}
