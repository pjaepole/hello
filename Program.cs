using System;
using System.Data;
using Dapper;
using hello.Models;
using Microsoft.Data.SqlClient;

namespace hello
{

    internal class Program
    {
        static void Main(string[] args)
        {
            //windwos authentication
            string connectionString = "Server=localhost;Database=DotNetCourseDatabase; TrustServerCertificate=true;Trusted_Connection=true;";

            //If using mac or linux
            //Need to set 
            //Trusted_Connection=false
            //User Id=sa;Password=Password123
            // string connectionString = "Server=localhost;Database=DotNetCourseDatabase; TrustServerCertificate=true;Trusted_Connection=false;User Id=sa;Password=Password123";



            IDbConnection dbConnection = new SqlConnection(connectionString);

            string sqlCommand = "SELECT GETDATE()";

            DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);
            Console.WriteLine(rightNow);

            Computer myComputer = new Computer()
            {
                Motherboard = "ASUS",
                CPUCores = 4,
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 1000.00M,
                VideoCard = "Nvidia"
            };
            // Console.WriteLine(myComputer.Motherboard);
            // Console.WriteLine(myComputer.VideoCard);
            // Console.WriteLine(myComputer.Price);
            // Console.WriteLine(myComputer.ReleaseDate);

        }
    }
}
