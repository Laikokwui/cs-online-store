using System;

namespace TotalOnlineStore
{
	/// <summary>
	/// Salesman.
	/// </summary>
	public class Salesman : User
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:TotalOnlineStore.Salesman"/> class.
		/// </summary>
		/// <param name="username">Username.</param>
		/// <param name="password">Password.</param>
		public Salesman(string username, string password, string role) : base(username,password,role)
		{
		}

		/// <summary>
		/// Displaies the menu.
		/// </summary>
		/// <returns>The menu.</returns>
		public override string DisplayMenu()
		{
			return "\n(S1) Stock Management\n(S2) Check Stock Availability\n(S3) View Stock List\n(S4) View Order List\n(S5) Sale Details\n(S6) Update Order Status\n(S7) Log Out";
		}
	}
}
