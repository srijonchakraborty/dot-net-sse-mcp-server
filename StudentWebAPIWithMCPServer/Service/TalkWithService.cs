namespace StudentWebAPIWithMCPServer.Service
{
    public class TalkWithService
    {
        public async Task<string> FetchContentFromUrl(string url)
        {
            string result = "";
            if (!IsValidUrl(url))
            {
                return "❌ The input is not a valid URL.";
            }
            else
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        result = $"For URL : {url} Response Is => " + await client.GetStringAsync(url);
                        Console.WriteLine(result);
                    }
                }
                catch (HttpRequestException e)
                {
                    result = $"For URL: {url} ,Error fetching data: " + e.Message;
                }
            }
            return result;
        }

        private static bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
