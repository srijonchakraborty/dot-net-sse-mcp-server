using ModelContextProtocol.Server;
using System.ComponentModel;

namespace StudentWebAPIWithMCPServer.Tools
{
    [McpServerToolType]
    public static class TalkWithSwaggerTool
    {
        [McpServerTool, Description("Gets Infomations from one url")]
        public static async Task<string> GetContentFromUrl(string url)
        {
            var service = new Service.TalkWithService();
            return await service.FetchContentFromUrl(url);
        }

        [McpServerTool, Description("Gets students with only specified fields")]
        public static string GetContentsFromUrls(List<string> urls)
        {
            var service = new Service.TalkWithService();
            List<string> results = new List<string>();
            foreach (var url in urls)
            {
                var result = service.FetchContentFromUrl(url).GetAwaiter().GetResult();
                if (!string.IsNullOrEmpty(result))
                {
                    results.Add(result);
                }
            }
            return string.Join(Environment.NewLine, results);
        }

    }
}
