using MyHarvest.Base;
using MyHarvest.Services.Enum;
using MyHarvest.ViewModels;
using Newtonsoft.Json;
using Plugin.Toast.Abstractions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyHarvest.Services
{
    public static class Api
    {
        public static string LoginAdress(string controller, string controllerMethod)
        {
            return $"{ApiConfig.ConnectionString + controller + controllerMethod}";
        }

        //public static string LogErrorAddress(string controller, string controllerMethod, string message, string logLevel)
        //{
        //    return $"{ApiConfig.ConnectionString + controller + controllerMethod + "?message=" + message + "&logLevel=" + logLevel + "&token=" + LocalConfig.LoginModel.Token}";
        //}

        //public static string BuildAdress(string controller, string controllerMethod)
        //{
        //    return BuildAdress(controller, controllerMethod, null, null);
        //}

        //public static string BuildAdress(string controller, string controllerMethod, string parameterName, string parameterValue, string secondParameterName = "&token=")
        //{
        //    return $"{ApiConfig.ConnectionString + controller + controllerMethod + parameterName + parameterValue + secondParameterName + LocalConfig.LoginModel.Token}";
        //}

        public async static Task<T> RequestAndSerialize<T>(Method requestMethod, string apiAddress)
        {
            return await RequestAndSerialize<T>(requestMethod, apiAddress, null);
        }

        public async static Task<T> RequestAndSerialize<T>(Method requestMethod, string apiAddress, object data)
        {
            T ret = default(T);

            var response = await Request(requestMethod, apiAddress, data);

            if (response != null)
                ret = JsonConvert.DeserializeObject<T>(response.ToString());

            return ret;
        }

        public async static Task<Object> Request(Method requestMethod, string apiAddress)
        {
            return await Request(requestMethod, apiAddress, null);
        }

        public async static Task<Object> Request(Method requestMethod, string apiAddress, object data)
        {
            string responseContent = null;

            if (!BaseService.InternetConnection())
                return responseContent;

            var client = new RestClient(apiAddress);
            client.Timeout = -1;
            var request = new RestRequest(requestMethod);

            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            if (data != null)
            {
                request.Parameters.Clear();
                var json = JsonConvert.SerializeObject(data);
                request.AddParameter("application/json", json, ParameterType.RequestBody);
            }

            IRestResponse response = client.Execute(request);

            if (!String.IsNullOrEmpty(response.Content))
            {
                var res = JsonConvert.DeserializeObject<BaseVm>(response.Content);

                if (res.MessageType == (int)MesseageType.Error)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                    {
                        ToastMessage.ShowToastError(res.Message, ToastLength.Long);
                    });
                }
                if (res.MessageType == (int)MesseageType.Warning)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                    {
                        ToastMessage.ShowToastWarning(res.Message, ToastLength.Long);
                    });
                }

                return res.ReturnedObject;
            }
            else
                return null;
        }
    }
}