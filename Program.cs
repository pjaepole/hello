﻿using System;
using System.Data;
using Dapper;
using hello.Data;
using hello.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace hello
{

    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            DataContextDapper dapper = new DataContextDapper(config);
            DataContextEF entityFramework = new DataContextEF(config);

            DateTime rightNow = dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");

            // Console.WriteLine(rightNow);

            Computer myComputer = new Computer()
            {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.78M,
                VideoCard = "RTX 2060"
            };



            string sql = @"INSERT INTO TutorialAppSchema.Computer(
                Motherboard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard 
            ) VALUES ('" + myComputer.Motherboard
             + "', '" + myComputer.HasWifi
             + "', '" + myComputer.HasLTE
             + "', '" + myComputer.ReleaseDate
             + "', '" + myComputer.Price
             + "', '" + myComputer.VideoCard
             + "')";


            File.WriteAllText("log.txt", "\n" + sql + "\n");

            using StreamWriter openFile = new("log.txt", append: true);

            openFile.WriteLine("\n" + sql + "\n");

            openFile.Close();

            string fileText = File.ReadAllText("log.txt");

            Console.WriteLine(fileText);
        }
    }
}
