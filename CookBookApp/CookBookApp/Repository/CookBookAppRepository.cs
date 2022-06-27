using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookBookApp.Interfaces.Services;
using CookBookApp.Models;
using CookBookApp.Interfaces.Repository;
using Microsoft.Data.Sqlite;
using System.Data;

namespace CookBookApp.Repository
{
    public class CookBookAppRepository : ICookBookAppRepository
    {

        #region Ctor
        public CookBookAppRepository()
        {
            builder.DataSource = "./myDB.db";
            using (SqliteConnection conn = new SqliteConnection(builder.ConnectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS ItemType (ItemTypeID integer NOT NULL PRIMARY KEY AUTOINCREMENT,ItemTypeName TEXT) ";
                command.ExecuteNonQuery();

                 command = conn.CreateCommand();
                command.CommandText = "insert into ItemType (ItemTypeName) values('Indian'); insert into ItemType (ItemTypeName) values('Chainees'); ";
                command.ExecuteNonQuery();

                command = conn.CreateCommand();
                command.CommandText = "CREATE TABLE IF NOT EXISTS CookBook ( ItemID integer NOT NULL PRIMARY KEY AUTOINCREMENT,ItemTypeID integer  NOT NULL,ItemName TEXT  NOT NULL,Recipe TEXT  NOT NULL) ";
                command.ExecuteNonQuery();

            }

        }
        #endregion Ctor

        #region Fields/Properties

        SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder();

        #endregion Fields/Properties
        public void DeleteAsync(int ItemID)
        {
            using (SqliteConnection conn =new SqliteConnection(builder.ConnectionString))
            {
                conn.Open();
            var command= conn.CreateCommand();
                command.CommandText = "delete from CookBook where ItemID="+ ItemID;
                command.ExecuteNonQueryAsync();

             
            }
                
        }

        public DataTable GetAllAsync()
        {
          DataTable dt = new DataTable();
            using (SqliteConnection conn = new SqliteConnection(builder.ConnectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "select * from CookBook c inner join ItemType i on i.ItemtypeID=c.ItemtypeID ";
                using (var r = command.ExecuteReader())
                {
                    dt.Load(r);

                }


            }
            return dt;
        }

        public void SaveAsync(CookBookRequest cookBookRequest)
        {
            try
            {
                using (SqliteConnection conn = new SqliteConnection(builder.ConnectionString))
                {
                    conn.Open();
                    var command = conn.CreateCommand();
                    command.CommandText = "insert into CookBook (ItemTypeID ,ItemName ,Recipe) values (" + cookBookRequest.ItemTypeID + ",'" + cookBookRequest.ItemName + "','" + cookBookRequest.Recipe + "')";
                    command.ExecuteNonQueryAsync();


                }
            }
            catch(Exception ex)
            {

            }
        }

        public void UpdateAsync(CookBookRequest cookBookRequest)
        {
            using (SqliteConnection conn = new SqliteConnection(builder.ConnectionString))
            {
                conn.Open();
                var command = conn.CreateCommand();
                command.CommandText = "Update CookBook set ItemTypeID=" + cookBookRequest.ItemTypeID + ",ItemName='" + cookBookRequest.ItemName + "',Recipe='" + cookBookRequest.Recipe + "' where ItemID="+ cookBookRequest.ItemID ;
                command.ExecuteNonQueryAsync();


            }
        }
    }
}
