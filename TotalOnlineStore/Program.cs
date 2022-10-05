using System;

namespace TotalOnlineStore
{
	/// <summary>
	/// MainClass.
	/// </summary>
	class MainClass
	{
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main(string[] args)
		{
			bool verify = false;
			string option = "";
			int errorcount = 0;
			int index = 0; 
			int indexs = 0;

			Management manage = new Management();

			User[] user = {
				new Customer("KokWui", "cs1001", "customer"),
				new Customer("TingFung", "cs2002", "customer"),
				new Customer("Didier", "cs3003", "customer"),
				new Salesman("Alan", "ad1001", "salesman"),
				new Salesman("Alvin", "ad2002", "salesman"),
				new Salesman("Simon", "ad3003", "salesman"),
				new Deliveryman("Jackie", "de1001", "deliveryman"),
				new Deliveryman("Karen", "de2002", "deliveryman"),
				new Deliveryman("JingPing", "de3003", "deliveryman")
			};

			Order[] order = {
				new Order("TingFung","QUARTZ INEO FIRST OW-30", 3, "Not Ready"),
				new Order("Didier","HI-PERF 4T RACING 10W-50", 4, "Sending"),
				new Order("KokWui","RUBIA FLEET HD 300 15W-40", 2, "Ready"),
				new Order("Didier","QUARTZ INEO MC3 5W-30", 2, "Not Ready"),
				new Order("TingFung","HI-PERF 4T SPORT+ 10W-40", 2, "Not Ready")
			};

			Stock[] stock = {
				new Stock("QUARTZ INEO FIRST OW-30", 47, StockType.cars),
				new Stock("QUARTZ INEO HTC 5W-30", 50, StockType.cars),
				new Stock("QUARTZ INEO MC3 5W-30", 50, StockType.cars),
				new Stock("QUARTZ 9000 5W-40", 50, StockType.cars),
				new Stock("QUARTZ 9000 ENERGY OW-40", 50, StockType.cars),
				new Stock("QUARTZ 9000 FUTURE GF5 OW-20", 50, StockType.cars),
				new Stock("HI-PERF 4T RACING 10W-50", 46, StockType.motorcycles),
				new Stock("HI-PERF 4T SPORT+ 10W-40", 50, StockType.motorcycles),
				new Stock("HI-PERF 4T SPECIAL 20W-40", 50, StockType.motorcycles),
				new Stock("HI-PERF 4T SPECIAL 20W-50", 50, StockType.motorcycles),
				new Stock("HI-PERF 4T MCO 20W-40", 50, StockType.motorcycles),
				new Stock("HI-PERF 4T MCO SAE 40", 50, StockType.motorcycles),
				new Stock("RUBIA FLEET HD 300 15W-40", 48, StockType.truckandbus),
				new Stock("RUBIA FLEET HD 700 15W-40", 50, StockType.truckandbus),
				new Stock("RUBIA TIR 7400 15W-40", 50, StockType.truckandbus)
			};

			for (int i = 0; i < user.Length; i++)
			{
				manage.CreateAccount(user[i]);
			}

			for (int i = 0; i < order.Length; i++)
			{
				manage.AddOrder(order[i]);
			}

			for (int i = 0; i < stock.Length; i++)
			{
				manage.AddStock(stock[i]);
			}

			while (errorcount < 4)
			{
				Console.WriteLine("Welcome to Total Online Store\n\n(M1) Log in\n(M2) Register\n(M3) Quit");
				Console.Write("\nEnter your option: ");
				option = Console.ReadLine().ToLower();

				// Log In
				if (option == "m1")
				{
					Console.Write("\nLog in \nUsername: "); // Enter Username
					string lname = Console.ReadLine();
					Console.Write("Password: "); // Enter Password
					string lpwd = Console.ReadLine();

					// Check _user List from Class Management
					for (int i = 0; i < manage.User.Count; i++)
					{
						if (lname == manage.User[i].Username && lpwd == manage.User[i].Password)
						{
							verify = true;
							index = i;
							i = manage.User.Count; // End the search
						}
						else
						{
							verify = false;
						}
					}

					// Log In Success
					if (verify)
					{
						errorcount = 0; // reset error count
						Console.WriteLine("\nlogin Successful!");

						while (errorcount < 4)
						{
							Console.WriteLine("\nWelcome Back! " + lname);
							Console.WriteLine(manage.User[index].DisplayMenu()); // Print the menu for different user
							Console.Write("\nEnter your Option:"); // Enter Option
							option = Console.ReadLine().ToLower(); // lowercase the user input

							if (manage.User[index].Role == "customer") // Only user that have customer role access
							{
								// User Management
								if (option == "c1")
								{
									while (errorcount < 4)
									{
										errorcount = 0; // reset error count

										Console.Write("\nUser Management\n\n(A) Change Name\n(B) Change Password\n(C) Delete Account\n(D) Back\n\nEnter your option:");
										option = Console.ReadLine().ToLower(); // lowercase the user input
										// Change Name
										if (option == "a")
										{
											Console.Write("\nEnter New Account Name:"); // Enter New name.
											string nname = Console.ReadLine();
											Console.Write("\nEnter Password to proceed:"); // Enter password
											string npwd = Console.ReadLine();
											if (npwd == lpwd)
											{
												verify = manage.User.Contains(new Customer(nname, lpwd, "customer")); // check the name availability
												if (verify == false)
												{
													for (int i = 0; i < manage.Order.Count; i++)
													{
														if (manage.Order[i].Username == lname)
														{
															manage.Order[i].Username = nname;
														}
														else
														{
															i += 0;
														}
													}
													manage.User[index].Username = nname; // Change the username
													lname = nname; // So at the user menu the name will change as well!
													Console.WriteLine("\nYou Changed your name!");
												}
												else
												{
													Console.WriteLine("\nAction Cancelled! Because the name had taken");
												}
											}
											else
											{
												Console.WriteLine("\nAction Cancelled! Because the password you enter is wrong!");
											}
										}
										// Change Password
										else if (option == "b")
										{
											Console.Write("\nEnter New Password:"); // Enter new password
											lpwd = Console.ReadLine();
											manage.User[index].Password = lpwd; // Change Password
											Console.WriteLine("\nYou Changed your password!");
										}
										// Delete Account
										else if (option == "c")
										{
											Console.Write("\nAre You Sure? This cannot be undone [Y/N]:"); // confirm the action
											option = Console.ReadLine().ToLower(); // convert to lowercase
											if (option == "y")
											{
												Console.WriteLine("\nYour Account has been deleted!");
												manage.DeleteAccount(manage.User[index]); // Delete Account
												errorcount = 4; // close the program
											}
											else
											{
												Console.WriteLine("\nAction Cancelled!");
											}
										}
										// Back
										else if (option == "d")
										{
											break; // back!
										}
										// Error
										else
										{
											Console.WriteLine("\nError 109: Option Not Found :(");
											errorcount += 1; // errorcount plus 1
										}
									}
								}

								// Search And Check Availability of a stock
								else if (option == "c2")
								{
									Console.Write("\nEnter the name of the stock:");
									string oname = Console.ReadLine().ToUpper(); // Convert to uppercase
									// Run through the Stock List
									for (int i = 0; i < manage.Stock.Count; i++)
									{
										if (oname == manage.Stock[i].Title)
										{
											indexs = i;
											verify = true;
											i = manage.Stock.Count;
										}
										else
										{
											verify = false;
										}
									}

									if (verify)
									{
										Console.WriteLine(oname + " currently have " + manage.Stock[indexs].Quantity + ".");
									}
									else
									{
										Console.WriteLine("Sorry " + oname + " is unavailable.");
									}
								}

								// Place Order
								else if (option == "c3")
								{
									int quantity;
									manage.ViewStockList();
									Console.Write("\nEnter the name of the stock:"); // enter name of the stock
									string oname = Console.ReadLine().ToUpper(); // turn to Uppercase
									Console.Write("\nEnter the quantity(in positive number):"); // enter the quantity
									string oquantity = Console.ReadLine();
									bool valid = int.TryParse(oquantity, out quantity);

									if (valid)
									{
										for (int i = 0; i < manage.Stock.Count; i++)
										{
											if (oname == manage.Stock[i].Title)
											{
												verify = true;
												indexs = i;
												i = manage.Stock.Count;
											}
											else
											{
												verify = false;
											}
										}
										if (verify)
										{
											if (quantity > 0) // quantity of the order must be more than 0
											{
												if (quantity > manage.Stock[indexs].Quantity) // check the quantity of the stock is enough for the user
												{
													Console.WriteLine("\nSorry " + oname + " currently have " + manage.Stock[index].Quantity + " only.");
												}
												else
												{
													manage.AddOrder(new Order(lname, oname, quantity, "Pending"));
													Console.WriteLine("\nYour Order has been Added to your order list!");
													manage.Stock[indexs].Quantity -= quantity;
												}
											}
											else 
											{
												Console.WriteLine("\nYour quantity must be more than 0");
											}
										}
										else
										{
											Console.WriteLine("\nSorry " + oname + " is unavailable.");
										}
									}
									else
									{
										Console.WriteLine("Please Enter Number!");
									}
								}
								// Remove Order
								else if (option == "c4")
								{
									manage.ViewOrderList(index,lname); // Show Order List
									Console.Write("\nEnter which order (number):"); // Enter Order Number
									string snumber = Console.ReadLine();
									int number;
									bool valid = int.TryParse(snumber, out number);

									if (valid && number < manage.Order.Count && number > 0 && lname == manage.User[index].Username)
									{
										manage.RemoveOrder(manage.Order[number - 1]);
										Console.WriteLine("\nOrder Deleted!");
									}
									else
									{
										Console.WriteLine("\nError 404: Input Not Valid!");
										Console.WriteLine("\nAction Cancelled!");
									}
								}
								// View User's Order List
								// Only user's order will appear
								else if (option == "c5")
								{
									manage.ViewOrderList(index, lname);
								}
								// Log Out
								else if (option == "c6")
								{
									Console.WriteLine("\nLogout Successsful!");
									break;
								}
								// Error
								else
								{
									Console.WriteLine("\nError 109: Option Not Found :(");
									errorcount += 1;
								}
							}
							// Only Saleman are allow to access this part
							else if (manage.User[index].Role == "salesman")
							{
								// Stock Management
								if (option == "s1")
								{
									errorcount = 0; // reset errorcount

									while (errorcount < 4)
									{
										Console.Write("\nStock Management\n\n(A) Add New Stock\n(B) Remove Stock\n(C) Edit Stock\n(D) Clear Stock List\n(E) Back\n\nEnter your option:");
										option = Console.ReadLine().ToLower(); // convert to lowercase

										// Add Stock
										if (option == "a")
										{
											manage.ViewStockList(); // for salemans to look at the current stock list
											Console.Write("\nEnter the name of the stock:");
											string sname = Console.ReadLine().ToUpper();
											// Prevent salesman to add stock that have the same name!
											for (int i = 0; i < manage.Stock.Count; i++)
											{
												if (manage.Stock[i].Title == sname)
												{
													verify = false;
													i = manage.Stock.Count;
												}
												else 
												{
													verify = true;
												}
											}
											// If stock not exist continue!
											if (verify)
											{
												Console.Write("\n(A1)Cars\n(A2)Motorcycles\n(A3)Truck & Bus\n\nEnter the Type of Stock:");
												option = Console.ReadLine().ToLower();
												Console.Write("\nEnter the quantity that you want to add(in numeral):");
												string squantity = Console.ReadLine();
												int quantity;
												bool valid = int.TryParse(squantity, out quantity);

												if (valid && quantity > 0 && option == "a1" || option == "a2" || option == "a3")
												{
													if (option == "a1")
													{
														manage.AddStock(new Stock(sname, quantity, StockType.cars));
														Console.WriteLine("\nStock Added!");
													}
													else if (option == "a2")
													{
														manage.AddStock(new Stock(sname, quantity, StockType.motorcycles));
														Console.WriteLine("\nStock Added!");
													}
													else
													{
														manage.AddStock(new Stock(sname, quantity, StockType.truckandbus));
														Console.WriteLine("\nStock Added!");
													}
												}
												else
												{
													Console.WriteLine("\nError 404: Input Not Valid!");
													Console.WriteLine("\nAction Cancelled!");
												}
											}
											else
											{
												Console.Write("\nThe Stock is already Exist!\nYou cannot add a stock that exist already!\nIf you want to change the quantity\n Please go to edit stock instead!");
											}
										}

										// Delete Stock
										else if (option == "b")
										{
											manage.ViewStockList(); // Show Stock List
											Console.Write("\nEnter which stock (number):"); // Enter Stcok Number
											string snumber = Console.ReadLine();
											int number;
											bool valid = int.TryParse(snumber, out number);

											if (valid && number <= manage.Stock.Count && number > 0)
											{
												manage.RemoveStock(manage.Stock[number - 1]);
												Console.WriteLine("\nStock Deleted!");
											}
											else
											{
												Console.WriteLine("\nError 404: Input Not Valid!");
												Console.WriteLine("\nAction Cancelled!");
											}
										}

										// Edit Stock Details
										else if (option == "c")
										{
											Console.Write("\n(C1)Change Stock Name\n(C2)Change Stock Type\n(C3)Change Stock's Quantity\n\nSelect your option:");
											option = Console.ReadLine().ToLower();

											// Change Stock Name
											if (option == "c1")
											{
												Console.Write("\nEnter which stock (number):");
												string snumber = Console.ReadLine();
												int number;
												bool valid = int.TryParse(snumber, out number);

												if (valid && number <= manage.Stock.Count && number > 0)
												{
													Console.Write("\nEnter new name:");
													string name = Console.ReadLine();
													manage.Stock[number - 1].Title = name;
													Console.WriteLine("\nStock's Name Changed!");
												}
												else
												{
													Console.WriteLine("\nError 404: Input Not Valid!");
													Console.WriteLine("\nAction Cancelled!");
												}
											}

											// Change Stock Type
											else if (option == "c2")
											{
												manage.ViewStockList(); // Show stock list
												Console.Write("\nEnter which stock (number):"); // Enter Stock Number
												string snumber = Console.ReadLine();
												int number;
												bool valid = int.TryParse(snumber, out number); // Return true or false for integer validation

												if (valid && number <= manage.Stock.Count && number > 0) // It is an integer and it is in range
												{
													Console.Write("\n(ST1)Cars\n(ST2)Motorcycles\n(ST3)Truck & Bus\n\nEnter Stock's Type(number):"); // Display type of stock
													option = Console.ReadLine().ToLower();
													if (option == "st1")
													{
														manage.Stock[number - 1].Type = StockType.cars;
														Console.WriteLine("\nStock's Type Changed to Cars!");
													}
													else if (option == "st2")
													{
														manage.Stock[number - 1].Type = StockType.motorcycles;
														Console.WriteLine("\nStock's Type Changed to Motorcycles!");
													}
													else if (option == "st3")
													{
														manage.Stock[number - 1].Type = StockType.truckandbus;
														Console.WriteLine("\nStock's Type Changed to truck & bus!");
													}
													else
													{
														Console.WriteLine("\nError 404: Stock Type Not Found :(");
														Console.WriteLine("\nAction Cancelled!");
													}
												}
												else
												{
													Console.WriteLine("\nError 404: Input Not Valid!");
													Console.WriteLine("\nAction Cancelled!");
												}
											}

											// Change Stock's Quantity
											else if (option == "c3")
											{
												Console.Write("\nEnter which stock (number):"); // Enter Stock Number
												string snumber = Console.ReadLine();
												int number;
												bool valid = int.TryParse(snumber, out number); // Return true or false for integer validation

												if (valid && number <= manage.Stock.Count && number > 0)
												{
													Console.Write("\nEnter new quantity(number):"); // Enter Stock Quantity
													string squantity = Console.ReadLine();
													int quantity;
													valid = int.TryParse(squantity, out quantity); // Return true or false for integer validation

													if (valid && quantity > 0) // It is an integer and it is over 0
													{
														manage.Stock[number - 1].Quantity = quantity;
														Console.WriteLine("\nStock's Quantity Changed!");
													}
													else
													{
														Console.WriteLine("\nError 404: Input Not Valid!");
														Console.WriteLine("\nAction Cancelled!");
													}
												}
												else
												{
													Console.WriteLine("\nError 404: Input Not Valid!");
													Console.WriteLine("\nAction Cancelled!");
												}
											}

											// Error Checker
											else
											{
												Console.WriteLine("\nError 109: Option Not Found :(");
												Console.WriteLine("\nAction Cancelled!");
											}
										}

										// Clear Stock List
										else if (option == "d")
										{
											manage.Stock.Clear(); // .clear() is use to cler out the list
										}

										// Back
										else if (option == "e")
										{
											break; // back to previous menu
										}

										// Error Checker
										else
										{
											Console.WriteLine("\nError 109: Option Not Found :(");
											errorcount += 1;
										}
									}
								}

								// Search And Check Availability of a Stock
								else if (option == "s2")
								{
									Console.Write("\nEnter the name of the stock:");
									string oname = Console.ReadLine().ToUpper();

									for (int i = 0; i < manage.Stock.Count; i++)
									{
										if (oname == manage.Stock[i].Title)
										{
											indexs = i;
											verify = true;
											i = manage.Stock.Count;
										}
										else
										{
											verify = false;
										}
									}
									if (verify)
									{
										Console.WriteLine(oname + " currently have " + manage.Stock[indexs].Quantity + ".");
									}
									else
									{
										Console.WriteLine("Sorry " + oname + " is unavailable.");
									}
								}

								// View Stock List
								else if (option == "s3")
								{
									manage.ViewStockList();
								}

								// View All User's Order List
								else if (option == "s4")
								{
									manage.ViewFullOrderList();
								}

								// view Sales Details
								else if (option == "s5")
								{
									manage.ViewSalesDetail();
								}
								// Update order status
								else if (option == "s6")
								{
									manage.ViewOrderList(index, lname);
									manage.UpdateOrderStatus(index);
								}

								// Log Out
								else if (option == "s7")
								{
									Console.WriteLine("\nLogout Successsful!");
									break;
								}

								// Error
								else
								{
									Console.WriteLine("\nError 109: Option Not Found :(");
									errorcount += 1;
								}
							}
							else if (manage.User[index].Role == "deliveryman")
							{
								// Update Order's Status
								if (option == "d1")
								{
									manage.ViewOrderList(index, lname);
									manage.UpdateOrderStatus(index);
								}

								// Log Out
								else if (option == "d2")
								{
									Console.WriteLine("\nLogout Successsful!");
									break;
								}
								else
								{
									Console.WriteLine("\nError 109: Option Not Found :(");
									errorcount += 1;
								}
							}

							// Error
							else
							{
								Console.WriteLine("\nError 404: Role Undefined!");
								errorcount += 1;
							}
						}
					}

					// Log in Failed
					else
					{
						Console.WriteLine("Invalid Name or Password Please Try Again!");
						errorcount += 1;
					}
				}

				// Register
				else if (option == "m2")
				{
					Console.Write("\nRegister\nUsername: ");
					string rname = Console.ReadLine();
					Console.Write("Password: ");
					string rpwd = Console.ReadLine();

					// Validate Name and password
					if (rname == "" || rpwd == "")
					{
						Console.WriteLine("\nName and Password cannot be empty!");
					}
					else
					{
						for (int i = 0; i < manage.User.Count; i++)
						{
							if (rname == manage.User[i].Username)
							{
								verify = true;
								i = manage.User.Count;
							}
							else
							{
								verify = false;
							}
						}

						if (verify)
						{
							Console.WriteLine("\nThe name had been taken");
						}
						else
						{
							manage.CreateAccount(new Customer(rname, rpwd, "customer"));
							Console.WriteLine("\nRegister Successful!");
						}
					}
				}

				// Terminate Program
				else if (option == "m3")
				{
					System.Environment.Exit(0);
				}

				// Error Checker
				else
				{
					Console.WriteLine("\nError 109: Option Not Found :(");
					errorcount += 1;
				}
			}
		}
	}
}