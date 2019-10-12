using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using TMM_Asp.Models;

namespace TMM_Asp.Data
{

    public class DBModel : DbContext
    {
        public DBModel() { }

        public DBModel(DbContextOptions<DBModel> options)
            : base(options)
        {

        }
        public DbSet<MemberModel> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=TeamMemberDB.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MemberModel>().ToTable("TeamMember");
        }

        static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=TeamMemberDB.db; Version = 3; New = True; Compress = True; ");
         // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return sqlite_conn;
        }

        static void CreateTable(SQLiteConnection conn, string TableName)
        {

            SQLiteCommand sqlite_cmd;
            string CreateTable = "CREATE TABLE " + TableName + "(";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = CreateTable;
            
            sqlite_cmd.ExecuteNonQuery();
            //SQLiteCommand sqlite_cmd;
            //string Createsql = "CREATE TABLE SampleTable(Col1 VARCHAR(20), Col2 INT)";
            //string Createsql1 = "CREATE TABLE SampleTable1(Col1 VARCHAR(20), Col2 INT)";
            //sqlite_cmd = conn.CreateCommand();
            //sqlite_cmd.CommandText = Createsql;
            //sqlite_cmd.ExecuteNonQuery();
            //sqlite_cmd.CommandText = Createsql1;
            //sqlite_cmd.ExecuteNonQuery();

        }

        static void InsertData(SQLiteConnection conn, string TableName, List<string> Values)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            if (TableName == "TeamMember")
                sqlite_cmd.CommandText = "INSERT INTO " + TableName +
                                         "(FirstName, LastName, Address, EmailAddress, PhoneNumber, Position, Department, StartDate, EndDate, EmploymentStatus, Shift, Manager, Photo, FavoriteColor) VALUES(/'" +
                                         Values[0] + "/','" + Values[1] + "/','" + Values[2] + "/','" + Values[3] +
                                         "/','" + Values[4] + "/','" + Values[5] + "/','" + Values[6] + "/','" +
                                         Values[7] + "/','" + Values[8] + "/','" + Values[9]
                                         + "/','" + Values[10] + "/','" + Values[11] + "/','" + Values[12] + "/','" +
                                         Values[13] + "/','" + Values[14] + "'); ";
            else if (TableName == "TeamMemberHistory")
                sqlite_cmd.CommandText = "INSERT INT0 " + TableName;
            //SQLiteCommand sqlite_cmd;
            //sqlite_cmd = conn.CreateCommand();
            //sqlite_cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES('Test Text ', 1); ";
            //sqlite_cmd.ExecuteNonQuery();
            //sqlite_cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES('Test1 Text1 ', 2); ";
            //sqlite_cmd.ExecuteNonQuery();
            //sqlite_cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES('Test2 Text2 ', 3); ";
            //sqlite_cmd.ExecuteNonQuery();


            //sqlite_cmd.CommandText = "INSERT INTO SampleTable1(Col1, Col2) VALUES('Test3 Text3 ', 3); ";
            //sqlite_cmd.ExecuteNonQuery();

        }

        static void ReadData(SQLiteConnection conn)
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM SampleTable";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            conn.Close();
        }
    }
}
