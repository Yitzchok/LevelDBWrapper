using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LevelDBWrapper.Native;

namespace LevelDBWrapper.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            var dbAccessor = new DBAccessor();
            var status = dbAccessor.open(new Options
            {
                ErrorIfExists = false,
                CreateIfMissing = true,
                Compression = CompressionType.SnappyCompression,

            }, "./Data");

            if (status.IsReady())
            {
                Console.WriteLine("LevelDB startup OK");

                var readOptions = new ReadOptions { FillCache = false };
                var user = dbAccessor.get(readOptions, "user/yitzchok");

                if (string.IsNullOrEmpty(user))
                {
                    //load some data into storage
                    var transaction = new DBWriteBatch();
                    transaction.Put("user/yitzchok", "Yitzchok");
                    transaction.Put("user/other", "Other User");
                    dbAccessor.write(new WriteOptions(), transaction);
                }
                else
                {
                    user = dbAccessor.get(readOptions, "user/yitzchok");
                }

                Console.WriteLine(user);
                Console.WriteLine(dbAccessor.get(readOptions, "user/other"));
            }
            else if (status.IsNotFound())
            {
                Console.WriteLine("LevelDB not found");
            }
            else
            {
                Console.WriteLine("LevelDB not setup correctly");
            }

            Console.ReadLine();
        }
    }
}
