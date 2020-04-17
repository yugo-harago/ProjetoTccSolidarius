using System;
using System.Collections;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestApiWorkshop.Client.Models;

namespace RestApiWorkshop.Client
{
    internal class Program
    {
        private const string ApiUrl = "https://localhost:44371";

        private static async Task Main(string[] args)
        {
            await CmdGetBlogs();

            Console.ReadLine();
        }

        private static async Task CmdGetBlogs()
        {
            var json = await ApiUrl
                .AppendPathSegment("items")
                .GetStringAsync();

            /*
             * ApiUrl - Flurl utiliza a string do endereço para criar uma instância de Flurl.Url
             *      var url = new Flurl.Url(ApiUrl);
             *
             * .AppendPathSegment("blogs") - Flurl.Url permite a manipulação da URL de forma fluente. Aqui está sendo adicionado o "/blogs" que será acessado.
             *      url = url.AppendPathSegment("blogs");
             *
             * .GetStringAsync() - Esse método de extensão cria e executa a requisição, utilizando uma instância de System.Net.Http.HttpClient. Ao receber o retorno, lê o conteúdo como string.
             *      var request = new Flurl.FlurlRequest(url);
             *      var response = await request.SendAsync(HttpMethod.Get);
             *      var json = response.ReceiveString();
             */

            OutputJson(json);

            var blogs = await ApiUrl
                .AppendPathSegment("items")
                .GetJsonAsync<Item[]>();

            /*
             * .GetJsonAsync<Blog[]>() - Flurl utiliza Newtonsoft.Json para ler o retorno da chamada e já converter para o modelo do objeto. Todas as regras de parse/format se aplicam
             */

            OutputObject(blogs);
        }

        private static void OutputJson(string json)
        {
            var text = JToken.Parse(json).ToString(Formatting.Indented);
            Console.WriteLine("** Begin Json String **");
            Console.WriteLine(text);
            Console.WriteLine("** End Json String **");
            Console.WriteLine();
        }

        private static void OutputObject(object obj, int level = 0)
        {
            if (level == 0)
                Console.WriteLine("** Begin Object Output **");

            switch (obj)
            {
                case string str:
                    Console.WriteLine(str);
                    break;

                case IEnumerable enumerable:
                    {
                        if (level == 0)
                            Console.WriteLine("Root:");
                        else
                            Console.WriteLine();

                        level++;
                        var index = 0;

                        foreach (var e in enumerable)
                        {
                            Console.WriteLine($"{" ".PadRight(level * 2)}{e.GetType().Name}[{index++}]:");
                            OutputObject(e, level + 1);
                        }

                        level--;
                    }
                    break;

                default:
                    {
                        var type = obj.GetType();

                        if (type.IsClass)
                        {
                            var properties = type.GetProperties();
                            foreach (var property in properties)
                            {
                                Console.Write($"{" ".PadRight(level * 2)}{property.Name}: ");
                                OutputObject(property.GetValue(obj, null), level + 1);
                            }
                        }
                        else
                        {
                            Console.WriteLine(obj);
                        }

                        break;
                    }
            }

            if (level == 0)
            {
                Console.WriteLine("** End Object Output **");
                Console.WriteLine();
            }
        }
    }
}