using System;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage;

namespace blobdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Geting the values from config files
            
            var blobName="my-photo.json";
            var filName="./Config.json";

            try
            {
                // CloudStorageAccount account = CloudStorageAccount.Parse(connectionString);
                // CloudBlobClient blobClient = account.CreateCloudBlobClient();

                // //Create(blobClient, containerName);
                // UploadFile(blobClient,containerName,blobName,filName);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            Console.ReadLine();
        }

        static async void Create(CloudBlobClient blobClient, string name)
        {

            try
            {
                CloudBlobContainer container = blobClient.GetContainerReference(name);
                await container.CreateAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static async void UploadFile(CloudBlobClient blobClient,string containerName,string blobName,string fileName){
            try
            {
                CloudBlobContainer container=blobClient.GetContainerReference(containerName);
                
                var blob=container.GetBlockBlobReference(blobName);
                await blob.UploadFromFileAsync(fileName);

            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
