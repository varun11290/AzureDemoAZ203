using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace blobdemo
{
    public static class BlobOperation
    {
        private const string containerName = "demo";
        private const string fileToUpload = "demo.txt";

        public static void BlobOperations()
        {

            //upload file;
            FileUpload();
            Console.ReadLine();
            //Download file
            DownloadFile("demo2.txt");
            Console.ReadLine();
            DeleteFile("demo2.txt");
            Console.ReadLine();
            DeletContainer();
            Console.ReadLine();

        }
        private static async Task<CloudBlobContainer> CreateContainer()
        {
            //Create storage account
            CloudStorageAccount storageAccount = StorageAccount.GetCloudStorageAccount();

            // Create a blob client for interacting with the blob service.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Create a container for organizing blobs within the storage account.
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            try
            {
                await container.CreateIfNotExistsAsync();
                return container;
            }
            catch (StorageException)
            {
                throw;
            }

        }

        private static async void FileUpload()
        {
            Console.WriteLine("1. Creating Container");
            CloudBlobContainer container = await CreateContainer();
            Console.WriteLine("1. Created Container");
            // Upload a BlockBlob to the newly created container
            Console.WriteLine("2. Uploading BlockBlob");
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileToUpload);
            try
            {
                blockBlob.Properties.ContentType = "txt";
                await blockBlob.UploadFromFileAsync(fileToUpload);
                Console.WriteLine("2. Uploaded BlockBlob");
                Console.WriteLine("3. List Blobs in Container");
                foreach (IListBlobItem blob in container.ListBlobs())
                {
                    Console.WriteLine("- {0} (type: {1})", blob.Uri, blob.GetType());
                }

            }
            catch (StorageException)
            {
                throw;
            }
        }

        private static async void DownloadFile(string fileName)
        {

            CloudBlobContainer container = await CreateContainer();
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

            try
            {
                Console.WriteLine("4. Download Blob from {0}", blockBlob.Uri.AbsoluteUri);
                await blockBlob.DownloadToFileAsync(string.Format("./CopyOf{0}", fileName), FileMode.Create);
                Console.WriteLine("4. Downloaded Blob from {0}", blockBlob.Uri.AbsoluteUri);
            }
            catch (StorageException)
            {
                throw;
            }

        }
        private static async void DeleteFile(string fileName)
        {

            CloudBlobContainer container = await CreateContainer();
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);

            try
            {
                Console.WriteLine("5. Delet Blob from {0}", blockBlob.Uri.AbsoluteUri);
                await blockBlob.DeleteIfExistsAsync();
                Console.WriteLine("5. Deleted Blob from {0}", blockBlob.Uri.AbsoluteUri);
            }
            catch (StorageException)
            {
                throw;
            }

        }

        private static async void DeletContainer()
        {
            CloudBlobContainer container = await CreateContainer();
            try
            {
                Console.WriteLine("6. Deleting Container");
                await container.DeleteIfExistsAsync();
                Console.WriteLine("6. Deleted Container");
            }
            catch (System.Exception)
            {

                throw;
            }

        }

    }
}