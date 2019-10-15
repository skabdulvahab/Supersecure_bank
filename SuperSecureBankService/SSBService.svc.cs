using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Threading;

namespace SuperSecureBankService
{
	public class SSBService : ISerializable
	{
		public Int64 CreateUser(string username, string email, string pass)
		{
			try
			{
				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString);
				conn.Open();
				insertUser = String.Format(insertUser, username, email, pass);
				SqlCommand command = new SqlCommand(insertUser, conn);
				Int64 userID = Convert.ToInt64(command.ExecuteScalar());
				conn.Close();
				return userID;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public Int64 LookupSession(string sessionValue)
		{
			Int64 userID = 0;
			Int64 sessionID = 0;
			if (Int64.TryParse(sessionValue, out sessionID))
			{
				SqlDataAdapter getUserID = new SqlDataAdapter("SELECT userID FROM sessions WHERE sessionID = {0}", myConnection);
				using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString))
				{
					conn.Open();
					getUserID = String.Format(getUserID, sessionValue);
					SqlCommand command = new SqlCommand(getUserID, conn);
					SqlDataReader reader = command.ExecuteReader();

					while (reader.Read())
					{
						userID = reader.GetInt64 (0);
					}
				}
			}
			return userID;
		}

		public string LookupUsername(Int64 userID)
		{
			string userName = "";

			string getUserName = "SELECT userName FROM Users WHERE userID = {0}";
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString))
			{
				conn.Open();
				getUserName = String.Format(getUserName, userID);
				SqlCommand command = new SqlCommand(getUserName, conn);
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					userName = reader.GetString(0);
				}
			}
			return userName;
		}

		public Int64 CheckUser(string username, string password)
		{
			Int64 userID = 0;

			string getUserID = "SELECT userID FROM Users WHERE userName = '{0}' AND password = '{1}'";
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString))
			{
				conn.Open();
				getUserID = String.Format(getUserID, username, password);
				SqlCommand command = new SqlCommand(getUserID, conn);
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					userID = reader.GetInt64 (0);
				}
			}
			return userID;
		}


		public void Transfer(Int64 FromAccount, Int64 ToAccount, Int64 Amount)
		{
			try
			{
				Int64 FromAccountBalance = GetBalance(FromAccount);
				Int64 ToAccountBalance = GetBalance(ToAccount);

				UpdateBalance(ToAccount, ToAccountBalance + Amount);
				Thread.Sleep(new Random());
				UpdateBalance(FromAccount, FromAccountBalance - Amount);
			}
			catch
			{
				throw;
			}
		}

		