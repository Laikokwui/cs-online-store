using System;

namespace TotalOnlineStore
{
	/// <summary>
	/// Deliveryman.
	/// </summary>
	public class Deliveryman : User
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:TotalOnlineStore.Deliveryman"/> class.
		/// </summary>
		/// <param name="username">Username.</param>
		/// <param name="password">Password.</param>
		public Deliveryman(string username, string password, string role) : base(username,password,role)
		{
		}

		/// <summary>
		/// Displaies the menu.
		/// </summary>
		/// <returns>The menu.</returns>
		public override string DisplayMenu()
		{
			return "\n(D1) Update Order Status\n(D2) Log Out";
		}
	}
}
