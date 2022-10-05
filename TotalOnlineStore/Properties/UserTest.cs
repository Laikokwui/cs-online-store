using System;
using NUnit.Framework;

namespace TotalOnlineStore
{
	/// <summary>
	/// User test.
	/// </summary>
	[TestFixture()]
	public class UserTest
	{
		/// <summary>
		/// Adds the user test.
		/// </summary>
		[Test()]
		public void AddUserTest()
		{
			Management testmanage = new Management();
			Customer cust1 = new Customer("Jason", "000325", "customer");
			Salesman sales1 = new Salesman("Jaron", "000721", "salesman");

			testmanage.CreateAccount(cust1);
			testmanage.CreateAccount(sales1);

			Assert.AreEqual(cust1, testmanage.User[0]);
			Assert.AreEqual(sales1, testmanage.User[1]);
			Assert.AreEqual(2, testmanage.User.Count);

			Deliveryman deliver1 = new Deliveryman("Jenny", "000421", "deliveryman");
			testmanage.CreateAccount(deliver1);

			Assert.AreEqual(deliver1, testmanage.User[2]);
			Assert.AreEqual(3, testmanage.User.Count);
		}

		/// <summary>
		/// Changes the username test.
		/// </summary>
		[Test()]
		public void ChangeUsernameTest()
		{
			Management testmanage = new Management();

			testmanage.CreateAccount(new Customer("Jason", "000325", "customer"));
			testmanage.User[0].Username = "Kok Wui";

			Assert.AreEqual(testmanage.User[0].Username, "Kok Wui");
		}

		/// <summary>
		/// Changes the password test.
		/// </summary>
		[Test()]
		public void ChangePasswordTest()
		{
			Management testmanage = new Management();

			testmanage.CreateAccount(new Customer("Jason", "000325", "customer"));
			testmanage.User[0].Password = "000721";

			Assert.AreEqual(testmanage.User[0].Password, "000721");
		}
	}
}
