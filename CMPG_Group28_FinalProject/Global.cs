﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace CMPG_Group28_FinalProject
{
    class Global
    {
        //Manier om Data basis te connect sonder om elke keer die connection string te verander

        static string directory = Directory.GetCurrentDirectory();

        public static string ConString => $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={directory}\GYM_DB.mdf;Integrated Security = True";


        //public static string ConString => @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\plain\Documents\GitHub\CPMG223_Group28_FinalProject\CMPG_Group28_FinalProject\bin\Debug\GYM_DB.mdf;Integrated Security = True; Connect Timeout = 30";





    }

}
