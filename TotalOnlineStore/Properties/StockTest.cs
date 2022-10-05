using System;
using NUnit.Framework;

namespace TotalOnlineStore
{
	/// <summary>
	/// Stock test.
	/// </summary>
	[TestFixture()]
	public class StockTest
	{
		/// <summary>
		/// Adds the stock test.
		/// </summary>
		[Test()]
		public void AddStockTest()
		{
			Management testmanage = new Management();

			Stock stock1 = new Stock("QUARTZ INEO FIRST OW-30", 47, StockType.cars);
			Stock stock2 = new Stock("QUARTZ INEO HTC 5W-30", 50, StockType.cars);
			Stock stock3 = new Stock("HI-PERF 4T SPECIAL 20W-50", 50, StockType.motorcycles);

			testmanage.AddStock(stock1);
			testmanage.AddStock(stock2);
			testmanage.AddStock(stock3);

			Assert.AreEqual(stock1, testmanage.Stock[0]);
			Assert.AreEqual(stock2, testmanage.Stock[1]);
			Assert.AreEqual(stock3, testmanage.Stock[2]);
			Assert.AreEqual(3, testmanage.Stock.Count);

			Stock stock4 = new Stock("HI-PERF 4T SPECIAL 20W-40", 50, StockType.motorcycles);
			Stock stock5 = new Stock("RUBIA FLEET HD 300 15W-40", 48, StockType.truckandbus);
			Stock stock6 = new Stock("RUBIA FLEET HD 700 15W-40", 50, StockType.truckandbus);

			testmanage.AddStock(stock4);
			testmanage.AddStock(stock5);
			testmanage.AddStock(stock6);

			Assert.AreEqual(stock4, testmanage.Stock[3]);
			Assert.AreEqual(stock5, testmanage.Stock[4]);
			Assert.AreEqual(stock6, testmanage.Stock[5]);
			Assert.AreEqual(6, testmanage.Stock.Count);
		}

		/// <summary>
		/// Deletes the stock test.
		/// </summary>
		[Test()]
		public void DeleteStockTest()
		{
			Management testmanage = new Management();

			Stock stock1 = new Stock("QUARTZ INEO FIRST OW-30", 47, StockType.cars);
			Stock stock2 = new Stock("QUARTZ INEO HTC 5W-30", 50, StockType.cars);
			Stock stock3 = new Stock("HI-PERF 4T SPECIAL 20W-50", 50, StockType.motorcycles);

			testmanage.AddStock(stock1);
			testmanage.AddStock(stock2);
			testmanage.AddStock(stock3);

			Assert.AreEqual(stock1, testmanage.Stock[0]);
			Assert.AreEqual(stock2, testmanage.Stock[1]);
			Assert.AreEqual(stock3, testmanage.Stock[2]);
			Assert.AreEqual(3, testmanage.Stock.Count);

			testmanage.RemoveStock(stock3);

			Assert.AreEqual(2, testmanage.Stock.Count);
		}

		/// <summary>
		/// Edits the stcok details test.
		/// </summary>
		[Test()]
		public void EditStcokDetailsTest()
		{
			Management testmanage = new Management();

			Stock stock1 = new Stock("QUARTZ INEO FIRST OW-30", 47, StockType.cars);

			testmanage.AddStock(stock1);

			stock1.Title = "HI-PERF 4T SPECIAL 20W-50";

			Assert.AreEqual("HI-PERF 4T SPECIAL 20W-50", testmanage.Stock[0].Title);

			stock1.Quantity = 50;

			Assert.AreEqual(50, testmanage.Stock[0].Quantity);

			stock1.Type = StockType.motorcycles;

			Assert.AreEqual(StockType.motorcycles, testmanage.Stock[0].Type);
		}
	}
}
