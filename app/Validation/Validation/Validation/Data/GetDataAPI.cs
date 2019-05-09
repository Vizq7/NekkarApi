using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;


namespace ConsoleProgram
{
    public class GetDataAPI
    {
        private const string URL = "https://nekkar.herokuapp.com/";

        public static async System.Threading.Tasks.Task<Dictionary<int, string[]>> Login(string username, string password)
        {
            Dictionary <int, string[]> resultado  = new Dictionary <int, string[]>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Clear();
                try
                {
                    HttpResponseMessage response = client.GetAsync($"api/v1/CheckUserExists/{ username}/{password}").Result;
                    var result = await response.Content.ReadAsStringAsync();
                    dynamic Query = JsonConvert.DeserializeObject(result);

                    if (response.IsSuccessStatusCode)
                    {
                        string id = Convert.ToString(Query.message.IdUser);
                        string photo = Convert.ToString(Query.message.UserAvatar);
                        //meter cuando todo funciona bien
                        resultado.Add(0, new[] {id, photo});
                    }
                    else
                    {
                        string message = Convert.ToString(Query.message);
                        resultado.Add(0, new[] {response.StatusCode.ToString(), message});
                    }
                }
                catch (Exception e)
                {
                    resultado.Add(0, new[] { e.Message });
                }
                return resultado;
            }
        }

        public static async System.Threading.Tasks.Task<Dictionary<int, string[]>> UserTask(string userid)
        {
            Dictionary<int, string[]> resultado = new Dictionary<int, string[]>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                client.DefaultRequestHeaders.Accept.Clear();
                try
                {
                    HttpResponseMessage response = client.GetAsync($"api/v1/CheckUserExists/{userid}").Result;
                    var result = await response.Content.ReadAsStringAsync();
                    dynamic Query = JsonConvert.DeserializeObject(result);

                    if (response.IsSuccessStatusCode)
                    {
                        string id = Convert.ToString(Query.message.IdUser);
                        string photo = Convert.ToString(Query.message.UserAvatar);
                        //meter cuando todo funciona bien
                        resultado.Add(0, new[] { id, photo });
                    }
                    else
                    {
                        string message = Convert.ToString(Query.message);
                        resultado.Add(0, new[] { response.StatusCode.ToString(), message });
                    }
                }
                catch (Exception e)
                {
                    resultado.Add(0, new[] { e.Message });
                }
                return resultado;
            }
        }

    }
}