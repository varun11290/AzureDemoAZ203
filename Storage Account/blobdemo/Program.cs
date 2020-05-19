using System;

namespace blobdemo
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Start the demo");
                BlobOperation.BlobOperations();
                Console.WriteLine("Finish the demo");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
