using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinesweeperTools;

namespace MinesweeperAnalyser.UnitTest
{
	[TestClass]
	public class AnalyserTest
	{
		bool[,] _bombsMatrix;

		[TestInitialize]
		public void Initialize()
		{
			_bombsMatrix = CreateTestBombsMatrix();
		}

		[TestMethod]
		public void FindBombs_WhenTwoArround_ReturnTwo()
		{
			Analyser analyser = new Analyser(_bombsMatrix);

			int nbrBomb = analyser.FindBombs(2, 1);

			Assert.AreEqual(2, nbrBomb);
		}

		[TestMethod]
		public void FindBombs_WhenOneArround_ReturnOne()
		{
			Analyser analyser = new Analyser(_bombsMatrix);

			int nbrBomb = analyser.FindBombs(0, 0);

			Assert.AreEqual(1, nbrBomb);
		}

		[TestMethod]
		public void FindBombs_WhenNoneArround_ReturnZero()
		{
			Analyser analyser = new Analyser(_bombsMatrix);

			int nbrBomb = analyser.FindBombs(3, 0);

			Assert.AreEqual(0, nbrBomb);
		}

		[TestMethod]
		[ExpectedException(typeof(OutsideMatrixException))]
		public void FindBombs_WhenOutsideOfMatrix_CoordinateX_ThrowException()
		{
			Analyser analyser = new Analyser(_bombsMatrix);

			int nbrBomb = analyser.FindBombs(5, 0);
		}

		[TestMethod]
		[ExpectedException(typeof(OutsideMatrixException))]
		public void FindBombs_WhenOutsideOfMatrix_CoordinateY_ThrowException()
		{
			Analyser analyser = new Analyser(_bombsMatrix);

			int nbrBomb = analyser.FindBombs(0, 5);
		}

		[TestMethod]
		[ExpectedException(typeof(OutsideMatrixException))]
		public void FindBombs_WhenOutsideOfMatrix_CoordinateXandY_ThrowException()
		{
			Analyser analyser = new Analyser(_bombsMatrix);

			int nbrBomb = analyser.FindBombs(9, 9);
		}

		[TestMethod]
		public void FindBombs_WhenOnABomb_ReturnMinusOne()
		{
			Analyser analyser = new Analyser(_bombsMatrix);

			int nbrBomb = analyser.FindBombs(1, 1);

			Assert.AreEqual(-1, nbrBomb);
		}

		bool[,] CreateTestBombsMatrix()
		{
			bool[,] bombsMatrix = new bool[4, 4] 
			{
				{false, false, false, false},
				{false, false, false, false},
				{false, false, true, false},
				{false, false, false, false},
			};

			bombsMatrix[1, 1] = true;
			bombsMatrix[2, 2] = true;
			return bombsMatrix;
		}
	}
}
