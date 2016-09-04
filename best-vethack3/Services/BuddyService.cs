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
                sqlCommand.Parameters.AddWithValue("@phoneNumber", Buddy.PhoneNumber);
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

        public static async Task<Buddy> GetById(int id)
        {
            Buddy buddy = new Buddy();

            //get connection string from web.config
            string connectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            if (sqlConnection.State == ConnectionState.Closed)
            {
                await sqlConnection.OpenAsync();
            }

            try
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "[dbo].[Buddy_GetById]";
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", id);
                IDataReader dataReader = sqlCommand.ExecuteReader();


                int colpos;
                while (dataReader.Read()) {
                    colpos = 0;
                    buddy.Id = dataReader.GetInt32(colpos++);
                    buddy.FirstName = dataReader.GetString(colpos++);
                    buddy.LastName = dataReader.GetString(colpos++);
                    buddy.PhoneNumber = dataReader.GetString(colpos++);
                    buddy.Age = dataReader.GetInt32(colpos++);
                    buddy.IsActive = dataReader.GetInt32(colpos++);
                    buddy.Branch = dataReader.GetString(colpos++);
                    buddy.Rank = dataReader.GetString(colpos++);
                    buddy.YearsServed = dataReader.GetInt32(colpos++);
                    buddy.Location = dataReader.GetString(colpos++);
                    buddy.CurrentOccupation = dataReader.GetString(colpos++);
                    buddy.TagLine = dataReader.GetString(colpos++);
                    buddy.Bio = dataReader.GetString(colpos++);
                    buddy.ImageUrl = dataReader.GetString(colpos++);
                }

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
            return buddy;
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
                    Buddy buddy = new Buddy();
                    int colpos = 0;

                    buddy.Id = dataReader.GetInt32(colpos++);
                    buddy.FirstName = dataReader.GetString(colpos++);
                    buddy.LastName = dataReader.GetString(colpos++);
                    buddy.PhoneNumber = dataReader.GetString(colpos++);
                    buddy.Age = dataReader.GetInt32(colpos++);
                    buddy.IsActive = dataReader.GetInt32(colpos++);
                    buddy.Branch = dataReader.GetString(colpos++);
                    buddy.Rank = dataReader.GetString(colpos++);
                    buddy.YearsServed = dataReader.GetInt32(colpos++);
                    buddy.Location = dataReader.GetString(colpos++);
                    buddy.CurrentOccupation = dataReader.GetString(colpos++);
                    buddy.TagLine = dataReader.GetString(colpos++);
                    buddy.Bio = dataReader.GetString(colpos++);
                    buddy.ImageUrl = dataReader.GetString(colpos++);
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