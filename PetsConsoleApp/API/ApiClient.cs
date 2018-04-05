using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace PetsConsoleApp.API
{
    /// <summary>
    /// ApiClient is an abstract class. To be used by other classes requiring access to data via API. 
    /// This is a generic class. 
    /// </summary>
    public abstract class ApiClient
    {
        /// <summary>
        /// Generic method to get data from API a specified API URL.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns>Payload of type T or Exception</returns>
        protected T Get<T>(string path) where T : class
        {
            try
            {
                T result = null;
                using (var client = new HttpClient())
                {
                    client.GetAsync(path).ContinueWith((task) =>
                    {
                        var response = task.Result;
                        var jsonString = response.Content.ReadAsStringAsync();
                        jsonString.Wait();
                        result = JsonConvert.DeserializeObject<T>(jsonString.Result);

                    }).Wait();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected exception thrown. See inner exception for details.", ex);
            }
        }
    }
}
