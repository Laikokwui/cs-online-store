using System;

namespace TotalOnlineStore
{
	/// <summary>
	/// Customer.
	/// </summary>
	public class Customer : User
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:TotalOnlineStore.Customer"/> class.
		/// </summary>
		/// <param name="username">Username.</param>
		/// <param name="password">Password.</param>
		public Customer(string username, string password, string role) : base(username, password,role)
		{
		}

		/// <summary>
		/// Displaies the menu.
		/// </summary>
		/// <returns>The menu.</returns>
		public override string DisplayMenu()
		{
			return "\n(C1) User Management\n(C2) Check Stock Availability\n(C3) Add Order\n(C4) Delete Order\n(C5) View Order List\n(c6) Logout";
		}
	}
}
