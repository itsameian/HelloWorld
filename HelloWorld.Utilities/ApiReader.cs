using HelloWorld.Entities;
using HelloWorld.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HelloWorld.Utilities
{
    /// <summary>
    /// Implementation of the IApiReader Interface
    /// </summary>
    public class ApiReader :IApiReader
    {
        private HttpClient client = new HttpClient();

        /// <summary>
        /// Returns the message property from the HWModel object of ID "index"
        /// </summary>
        /// <param name="index">The id property for the HWModel object to be returned</param>
        /// <returns></returns>
        public async Task<string> GetMessage(int index)
        {
            HWModel model = new HWModel();
            HttpResponseMessage response = await client.GetAsync("api/HW/" + index.ToString());
            if (response.IsSuccessStatusCode)
            {
                model = await response.Content.ReadAsAsync<HWModel>();
            }
            return model.Message;
        }

        /// <summary>
        /// Sets the default uri, with port, to read from
        /// If hosting on a server, change this to the page address
        /// </summary>
        /// <param name="uriAddress">The Base Address for the API</param>
        public void SetClient(Uri uriAddress)
        {
            client.BaseAddress = uriAddress;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
