using System;
using System.Linq;
using System.Text;
using Abio.Library.DatabaseModels;

public class Program
{
    static void Main(string[] args)
    {
        MainAsync().Wait();
    }

    public static readonly string path = "..\\..\\..\\..\\Abio.Library\\DatabaseModels\\";
    public static readonly string apiServiceFiles = "..\\..\\..\\..\\Abio.Console.Application\\Services\\ApiService";
    public static readonly string constantsFile = "..\\..\\..\\..\\Abio.Console.Application\\Services\\Constants";

    public static async Task MainAsync()
    {
        var path = "..\\..\\..\\..\\Abio.Library\\DatabaseModels\\";
        if (File.Exists("..\\..\\..\\..\\Abio.Library\\DatabaseModels\\AbioContext.cs"))
        {
            var fileDirectories = Directory.GetFiles(path).Where(p => !p.Contains("Context"));
            List<string> files = new List<string>();
            foreach (var file in fileDirectories)
            {
                files.Add(Path.GetFileNameWithoutExtension(file)); 
            }

            await GenerateRestUrls(files);
            await GenerateRestServices(files);
        }
    }

    public static void GenerateFiles(string fileText, string filePath)
    {
        File.WriteAllText(string.Concat(filePath,".cs"), fileText);
    }

    public static async Task GenerateRestUrls(List<string> abioClasses)
    {
        StringBuilder stringBuilder = new StringBuilder();
        string header = "using System;\r\nusing System.Collections.Generic;\r\nusing System.Linq;\r\nusing System.Text;\r\nusing System.Threading.Tasks;\r\nusing System.Net.Http;\r\n\r\nnamespace Abio.Console.Application.Services\r\n{\r\n    internal class Constants\r\n    {        \r\n        private static HttpClient client = new HttpClient();\r\n        public static HttpClient GetClient()\r\n        {\r\n            return client;\r\n        }\r\n        public static string RestUrl = \"http://localhost:5096/api/\";";
        string footer = "\t}\r\n}";
        stringBuilder.AppendLine(header).AppendLine();
        foreach (var abioClass in abioClasses)
        {
            stringBuilder.AppendLine(string.Format("\t\tpublic static string {0}Url = string.Concat(RestUrl,\"{0}s\");",abioClass));
        }
        stringBuilder.Append(footer);
        GenerateFiles(stringBuilder.ToString(), constantsFile);
    }

    public static async Task GenerateRestServices(List<string> abioClasses)
    {
        string header = "using Abio.Library.DatabaseModels;\r\nusing Newtonsoft.Json;\r\nusing System.Text;\r\n\r\nnamespace Abio.Console.Application.Services\r\n{\r\n\tpublic class ApiService\r\n\t{";
        string footer = "\t}\r\n}";
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendLine(header);
        foreach (var abioClass in abioClasses)
        {
            var classNameLower = string.Concat(abioClass[0].ToString().ToLower(), abioClass.Remove(0, 1));
            var classNameUpper = abioClass;
            stringBuilder = GenerateCreateService(classNameUpper,classNameLower, stringBuilder);
            stringBuilder = GeneratePostService(classNameUpper, classNameLower, stringBuilder);
        }
        stringBuilder.Append(footer).ToString();
        GenerateFiles(stringBuilder.ToString(), apiServiceFiles);
    }

    public static StringBuilder GenerateCreateService(string classNameUpper, string classNameLower, StringBuilder stringBuilder)
    {
        // CREATE
        var createFunctionName = string.Format("\t\tpublic static async Task<List<{0}>> Get{0}s()", classNameUpper);
        var openingBracket = "\t\t{";
        var getURL = string.Format("\t\t\tstring result = await Constants.GetClient().GetStringAsync(Constants.{0}Url);", classNameUpper);
        var deserializeJson = string.Format("\t\t\tvar deserializedResult = JsonConvert.DeserializeObject<List<{0}>>(result);", classNameUpper);
        var returnStatement = string.Format("\t\t\treturn deserializedResult;");
        var closingBracket = "\t\t}";
        stringBuilder.AppendLine(createFunctionName)
                     .AppendLine(openingBracket)
                            .AppendLine(getURL)
                            .AppendLine(deserializeJson)
                            .AppendLine(returnStatement)
                     .AppendLine(closingBracket)
                    .AppendLine();

        return stringBuilder;
    }


    private static StringBuilder GeneratePostService(string classNameUpper, string classNameLower, StringBuilder stringBuilder)
    {
        // CREATE
        var createFunctionName = string.Format("\t\tpublic static async Task<HttpResponseMessage> Post{0}({0} {1})", classNameUpper, classNameLower);
        var openingBracket = "\t\t{";
        var jsonChore = string.Format("\t\t\tstring jsonChore = JsonConvert.SerializeObject({0});",classNameLower);
        var httpContent = string.Format("\t\t\tStringContent httpContent = new StringContent(jsonChore, Encoding.UTF8, \"application/json\");");
        var result = string.Format("\t\t\tHttpResponseMessage result = await Constants.GetClient().PostAsync(Constants.{0}Url,httpContent);", classNameUpper);
        var returnStatement = string.Format("\t\t\treturn result;");
        var closingBracket = "\t\t}";
        stringBuilder.AppendLine(createFunctionName)
                     .AppendLine(openingBracket)
                            .AppendLine(jsonChore)
                            .AppendLine(httpContent)
                            .AppendLine(result)
                            .AppendLine(returnStatement)
                     .AppendLine(closingBracket)
                    .AppendLine();
        return stringBuilder;
    }

}