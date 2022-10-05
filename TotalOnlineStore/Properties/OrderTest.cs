using System;
using NUnit.Framework;

namespace TotalOnlineStore
{
	/// <summary>
	/// Order test.
	/// </summary>
	[TestFixture()]
	public class OrderTest
	{
		/// <summary>
		/// Adds the order test.
		/// </summary>
		[Test()]
		public void AddOrderTest()
		{
			Management testmanage = new Management();

			Order order1 = new Order("TingFung", "QUARTZ INEO FIRST OW-30", 3, "Pending");
			Order order2 = new Order("Didier", "HI-PERF 4T RACING 10W-50", 4, "Sending");
			Order order3 = new Order("Kokwui", "RUBIA FLEET HD 300 15W-40", 2, "Pending");

			testmanage.AddOrder(order1);
			testmanage.AddOrder(order2);
			testmanage.AddOrder(order3);

			Assert.AreEqual(order1, testmanage.Order[0]);
			Assert.AreEqual(order2, testmanage.Order[1]);
			Assert.AreEqual(order3, testmanage.Order[2]);
			Assert.AreEqual(3, testmanage.Order.Count);

			Order order4 = new Order("Jason", "HI-PERF 4T SPORT+ 10W-40", 3, "Pending");
			testmanage.AddOrder(order4);

			Assert.AreEqual(order4, testmanage.Order[3]);
			Assert.AreEqual(4, testmanage.Order.Count);
		}

		/// <summary>
		/// Deletes the order test.
		/// </summary>
		[Test()]
		public void DeleteOrderTest()
		{
			Management testmanage = new Management();

			Order order1 = new Order("TingFung", "QUARTZ INEO FIRST OW-30", 3, "Pending");
			Order order2 = new Order("Didier", "HI-PERF 4T RACING 10W-50", 4, "Sending");
			Order order3 = new Order("Kokwui", "RUBIA FLEET HD 300 15W-40", 2, "Pending");

			testmanage.AddOrder(order1);
			testmanage.AddOrder(order2);
			testmanage.AddOrder(order3);

			Assert.AreEqual(order1, testmanage.Order[0]);
			Assert.AreEqual(order2, testmanage.Order[1]);
			Assert.AreEqual(order3, testmanage.Order[2]);
			Assert.AreEqual(3, testmanage.Order.Count);

			testmanage.RemoveOrder(order3);

			Assert.AreEqual(2, testmanage.Order.Count);
		}

		/// <summary>
		/// Checks the order length test.
		/// </summary>
		[Test()]
		public void CheckOrderLengthTest()
		{
			Management testmanage = new Management();

			Order order1 = new Order("TingFung", "QUARTZ INEO FIRST OW-30", 3, "Pending");
			Order order2 = new Order("Didier", "HI-PERF 4T RACING 10W-50", 4, "Sending");
			Order order3 = new Order("Kokwui", "RUBIA FLEET HD 300 15W-40", 2, "Pending");

			testmanage.AddOrder(order1);
			testmanage.AddOrder(order2);
			testmanage.AddOrder(order3);

			Assert.AreEqual(3, testmanage.Order.Count);
		}
	}
}
