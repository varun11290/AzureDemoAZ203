using Microsoft.Azure.Storage;

namespace blobdemo
{
    //This method will return the storage account object based on connection string.
    public static class StorageAccount
    {
        public static CloudStorageAccount GetCloudStorageAccount(){
            
            CloudStorageAccount account;
            var config = Config.GetConfigValue();
            string connectionString = config["AZURE_STORAGE_CONNECTION_STRING"];

            try
            {
                account=CloudStorageAccount.Parse(connectionString);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return account;

        }
    }
}