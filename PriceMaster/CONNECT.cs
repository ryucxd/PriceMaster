using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceMaster
{
    class CONNECT
    {
        public const string ConnectionString = "user id=sa;" +
                                 "password=Dodid1;Network Address=192.168.0.150\\sqlexpress;" +
                                 "Trusted_Connection=no;" +
                                 "database=price_master; " +
                                 "connection timeout=30";

        public const string ConnectionStringUser = "user id=sa;" +
                               "password=Dodid1;Network Address=192.168.0.150\\sqlexpress;" +
                               "Trusted_Connection=no;" +
                               "database=user_info; " +
                               "connection timeout=30";

        public static string note;
        public static string materialType;
        public static int staffID;
        public static string staffFullName;
        public static int skipLoss;
    }
}
