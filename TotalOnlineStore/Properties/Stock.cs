using System;

namespace TotalOnlineStore
{
	/// <summary>
	/// Stock.
	/// </summary>
	public class Stock
	{
		private string _title;
		private int _quantity;
		private StockType _type;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:TotalOnlineStore.Stock"/> class.
		/// </summary>
		/// <param name="title">Title.</param>
		/// <param name="quantity">Quantity.</param>
		/// <param name="type">Type.</param>
		public Stock(string title, int quantity, StockType type)
		{
			_title = title;
			_quantity = quantity;
			_type = type;
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
		/// Gets or sets the type.
		/// </summary>
		/// <value>The type.</value>
		public StockType Type
		{
			get { return _type; }
			set { _type = value; }
		}
	}
}