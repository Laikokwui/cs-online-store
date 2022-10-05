using System;

namespace TotalOnlineStore
{
	/// <summary>
	/// User class Abstract.
	/// </summary>
	public abstract class User
	{
		private string _username;
		private string _password;
		private string _role;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:TotalOnlineStore.User"/> class.
		/// </summary>
		/// <param name="username">Username.</param>
		/// <param name="password">Password.</param>
		public User(string username, string password, string role)
		{
			_username = username;
			_password = password;
			_role = role;
		}

		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		/// <value>The username.</value>
		public string Username
		{
			get { return _username; }
			set { _username = value; }
		}

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>The password.</value>
		public string Password
		{
			get { return _password; }
			set { _password = value; }
		}

		/// <summary>
		/// Gets or sets the role.
		/// </summary>
		/// <value>The role.</value>
		public string Role
		{
			get { return _role; }
			set { _role = value; }
		}

		/// <summary>
		/// Displaies the menu.
		/// </summary>
		/// <returns>The menu.</returns>
		public abstract string DisplayMenu();
	}
}