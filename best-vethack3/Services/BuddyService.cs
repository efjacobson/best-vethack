using best_vethack3.Models.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace best_vethack3.Services
{
    public class BuddyService
    {
        public static async Task<int> Create(Buddy Buddy)
        {
            int id = -1;

            //get connection string from web.config
            string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    await sqlConnection.OpenAsync();
                }
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "[dbo].[Buddy_Create]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@firstName", Buddy.FirstName);
                sqlCommand.Parameters.AddWithValue("@lastName", Buddy.LastName);
                sqlCommand.Parameters.AddWithValue("@age", Buddy.Age);
                sqlCommand.Parameters.AddWithValue("@isActive", Buddy.IsActive);
                sqlCommand.Parameters.AddWithValue("@branch", Buddy.Branch);
                sqlCommand.Parameters.AddWithValue("@rank", Buddy.Rank);
                sqlCommand.Parameters.AddWithValue("@yearsServed", Buddy.YearsServed);
                sqlCommand.Parameters.AddWithValue("@location", Buddy.Location);
                sqlCommand.Parameters.AddWithValue("@currentOccupation", Buddy.CurrentOccupation);
                sqlCommand.Parameters.AddWithValue("@tagline", Buddy.TagLine);
                sqlCommand.Parameters.AddWithValue("@bio", Buddy.Bio);

                object returnedObject = await sqlCommand.ExecuteScalarAsync();
                int.TryParse(returnedObject.ToString(), out id);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return id;
        }

        public static async Task<List<Buddy>> GetAll()
        {
            List<Buddy> allBuddys = new List<Buddy>();

            //get connection string from web.config
            string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    await sqlConnection.OpenAsync();
                }
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "[dbo].[Buddy_GetAll]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                IDataReader dataReader = await sqlCommand.ExecuteReaderAsync();

                while (dataReader.Read())
                {
                    Buddy Buddy = new Buddy();
                    int colpos = 0;

                    Buddy.Id = dataReader.GetInt32(colpos++);
                    Buddy.FirstName = dataReader.GetString(colpos++);
                    Buddy.LastName = dataReader.GetString(colpos++);
                    Buddy.Age = dataReader.GetInt32(colpos++);
                    Buddy.IsActive = dataReader.GetInt32(colpos++);
                    Buddy.Branch = dataReader.GetString(colpos++);
                    Buddy.Rank = dataReader.GetString(colpos++);
                    Buddy.YearsServed = dataReader.GetInt32(colpos++);
                    Buddy.Location = dataReader.GetString(colpos++);
                    Buddy.CurrentOccupation = dataReader.GetString(colpos++);
                    Buddy.TagLine = dataReader.GetString(colpos++);
                    Buddy.Bio = dataReader.GetString(colpos++);
                    allBuddys.Add(Buddy);
                }

                dataReader.Close();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Close();
                }
            }

            return allBuddys;
        }
    }
}