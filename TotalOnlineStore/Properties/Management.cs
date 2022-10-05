using System;
using System.Collections.Generic;

namespace TotalOnlineStore
{
	/// <summary>
	/// Management Class.
	/// </summary>
	public class Management
	{
		private List<Order> _order;
		private List<Stock> _stock;
		private List<User> _user;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:TotalOnlineStore.Management"/> class.
		/// </summary>
		public Management()
		{
			_order = new List<Order>();
			_stock = new List<Stock>();
			_user = new List<User>();
		}

		/// <summary>
		/// Creates the account.
		/// </summary>
		/// <param name="user">User.</param>
		public void CreateAccount(User user)
		{
			_user.Add(user);
		}

		/// <summary>
		/// Deletes the account.
		/// </summary>
		/// <param name="user">User.</param>
		public void DeleteAccount(User user)
		{
			_user.Remove(user);
		}

		/// <summary>
		/// Adds the order.
		/// </summary>
		/// <param name="order">Order.</param>
		public void AddOrder(Order order)
		{
			_order.Add(order);
		}

		/// <summary>
		/// Removes the order.
		/// </summary>
		/// <param name="order">Order.</param>
		public void RemoveOrder(Order order)
		{
			_order.Remove(order);
		}


		/// <summary>
		/// Views All order list.
		/// </summary>
		public void ViewFullOrderList()
		{
			if (_order.Count > 0)
			{
				int j = 1;
				Console.WriteLine("Your Order List:");
				for (int i = 0; i < _order.Count; i++)
				{
					Console.WriteLine(j + ") username: " + _order[i].Username + " stock name: " + _order[i].Title + " x " + _order[i].Quantity + " Order status: " + _order[i].Status);
					j += 1;
				}
			}
			else
			{
				Console.WriteLine("Your Order List is Empty!");
			}
		}

		/// <summary>
		/// Views the order list.
		/// </summary>
		public void ViewOrderList(int index, string name)
		{
			if (_user[index].Role == "customer")
			{
				int j = 1;
				Console.WriteLine("Your Order List:");
				for (int i = 0; i < _order.Count; i++)
				{
					if (name == _order[i].Username)
					{
						Console.WriteLine(j + ") username: " + _order[i].Username + " stock name: " + _order[i].Title + " x " + _order[i].Quantity + " Order status: " + _order[i].Status);
						j += 1;
					}
					else
					{
						j += 1;
					}
				}
				Console.WriteLine("\nThis is Your Order List");
			}
			else if (_user[index].Role == "salesman")
			{
				int j = 1;
				Console.WriteLine("\nOrder List:");
				for (int i = 0; i < _order.Count; i++)
				{
					if (_order[i].Status == "Not Ready")
					{
						Console.WriteLine(j + ") username: " + _order[i].Username + " stock name:" + _order[i].Title + " x " + _order[i].Quantity + " Order status: " + _order[i].Status);
						j += 1;
					}
					else
					{
						j += 1;
					}
				}
			}
			if (_user[index].Role == "deliveryman")
			{
				int j = 1;
				Console.WriteLine("\nOrder List:");
				for (int i = 0; i < _order.Count; i++)
				{
					if (_order[i].Status == "Ready")
					{
						Console.WriteLine(j + ") username: " + _order[i].Username + " stock name:" + _order[i].Title + " x " + _order[i].Quantity + " Order status: " + _order[i].Status);
						j += 1;
					}
					else if (_order[i].Status == "Sending")
					{
						Console.WriteLine(j + ") username: " + _order[i].Username + " stock name:" + _order[i].Title + " x " + _order[i].Quantity + " Order status: " + _order[i].Status);
						j += 1;
					}
					else 
					{
						j += 1;
					}
				}
			}
		}

		/// <summary>
		/// Adds the stock.
		/// </summary>
		/// <param name="stock">Stock.</param>
		public void AddStock(Stock stock)
		{
			_stock.Add(stock);
		}

		/// <summary>
		/// Removes the stock.
		/// </summary>
		/// <param name="stock">Stock.</param>
		public void RemoveStock(Stock stock)
		{
			_stock.Remove(stock);
		}

		/// <summary>
		/// Views the stock list.
		/// </summary>
		public void ViewStockList()
		{
			if (_stock.Count > 0)
			{
				int j = 1;
				Console.WriteLine("\nStock List:");
				for (int i = 0; i < _stock.Count; i++)
				{
					Console.WriteLine(j + ") stock name:" + _stock[i].Title + " stock type: " + _stock[i].Type + " x " + _stock[i].Quantity);
					j += 1;
				}
			}
			else
			{
				Console.WriteLine("Stock List is Empty");
			}
		}

		/// <summary>
		/// Updates the order status.
		/// </summary>
		public void UpdateOrderStatus(int i)
		{
			if (_user[i].Role == "deliveryman")
			{
				Console.Write("\nEnter the order to update (number):");
				string index = Console.ReadLine();
				int indexs;
				bool valid = int.TryParse(index, out indexs);
				if (valid)
				{
					if (_order[indexs - 1].Status == "Not Ready")
					{
						Console.WriteLine("\nDelivery Man Are Not Allowed to change order delivery status when the order's is Not Ready to send yet!");
					}
					else if (_order[indexs - 1].Status == "Ready")
					{
						_order[indexs - 1].Status = "Sending";
						Console.WriteLine("\nThis Order's Status has been changed to Sending!");
					}
					else if (_order[indexs - 1].Status == "Sending")
					{
						_order[indexs - 1].Status = "Delivered";
						Console.WriteLine("\nThis Order's Status has been changed to Delivered!");
					}
					else
					{
						Console.WriteLine("\nThis Order is already delivered!");
					}
				}
				else 
				{
					Console.WriteLine("Error 109: Invalid Input!");
				}
			}
			else if (_user[i].Role == "salesman")
			{
				Console.Write("\nEnter the order to update (number):");
				string index = Console.ReadLine();
				int indexs = int.Parse(index);

				if (_order[indexs - 1].Status == "Not Ready")
				{
					_order[indexs - 1].Status = "Ready";
					Console.WriteLine("\nThis Order's Status has been changed to Ready!");
				}
				else
				{
					Console.WriteLine("\nSales Man Are Not Allowed to change order delivery status!");
				}
			}
			else
			{
				Console.WriteLine("\nYou are not allowed to change order's status");
			}
		}

		/// <summary>
		/// Views the sales detail.
		/// </summary>
		public void ViewSalesDetail()
		{
			int total = 0;
			for (int i = 0; i < _order.Count; i++)
			{
				if (_order[i].Status == "Delivered")
				{
					total += _order[i].Quantity;
				}
				else
				{
					total += 0;
				}
			}

			Console.WriteLine("Total Sales " + total);
		}

		/// <summary>
		/// Gets or sets the stock.
		/// </summary>
		/// <value>The stock.</value>
		public List<Stock> Stock
		{
			get { return _stock; }
		}

		/// <summary>
		/// Gets or sets the order.
		/// </summary>
		/// <value>The order.</value>
		public List<Order> Order
		{
			get { return _order; }
		}

		/// <summary>
		/// Gets or sets the user.
		/// </summary>
		/// <value>The user.</value>
		public List<User> User
		{
			get { return _user; }
		}
	}
}