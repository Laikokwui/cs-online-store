using System;

namespace TotalOnlineStore
{
	/// <summary>
	/// Order.
	/// </summary>
	public class Order
	{
		private string _username;
		private string _title;
		private int _quantity;
		private string _status;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:TotalOnlineStore.Order"/> class.
		/// </summary>
		/// <param name="username">Username.</param>
		/// <param name="title">Title.</param>
		/// <param name="quantity">Quantity.</param>
		/// <param name="status">Status.</param>
		public Order(string username, string title, int quantity, string status)
		{
			_username = username;
			_title = title;
			_quantity = quantity;
			_status = status;
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
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}

		/// <summary>
		/// Gets or sets the quantity.
		/// </summary>
		/// <value>The quantity.</value>
		public int Quantity
		{
			get { return _quantity; }
			set { _quantity = value; }
		}

		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		public string Status
		{
			get { return _status; }
			set { _status = value; }
		}
	}
}