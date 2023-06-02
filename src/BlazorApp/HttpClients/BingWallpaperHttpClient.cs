using System.Net.Http.Json;
using System.Text.Json;
using System.Web;
using BlazorApp.Converters;
using BlazorApp.Models;

namespace BlazorApp.HttpClients
{
    public class BingWallpaperHttpClient
    {
        private const string BASEADDRESS = "https://www.bing.com";
        private readonly HttpClient _client;
        private readonly ILogger<BingWallpaperHttpClient> _logger;

        public BingWallpaperHttpClient(HttpClient httpClient, ILogger<BingWallpaperHttpClient> logger)
        {
            SetUpBingClient(httpClient);
            _client = httpClient;
            _logger = logger;
        }

        public async Task<IReadOnlyList<Wallpaper>> GetBingWallpapers()
        {
            var requestUri = GenerateUri(_client).ToString();

            _logger.LogInformation("RequestUri:{RequestUri}", requestUri);

            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters =
                {
                    new CustomDateTimeConverter("yyyyMMddHHmm"),
                    new CustomDateOnlyConverter("yyyyMMdd")
                }
            };
            try
            {
                var res = await new HttpClient().GetAsync(requestUri);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            var root = await _client.GetFromJsonAsync<WallpaperRoot>(requestUri, jsonSerializerOptions);
            return root?.Images;
        }

        private static void SetUpBingClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(BASEADDRESS);
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Add(
                "Accept",
                "application/json; charset=utf-8");
            httpClient.DefaultRequestHeaders.Add(
                "User-Agent",
                "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Mobile Safari/537.36");
            httpClient.DefaultRequestHeaders.Add(
                "Cookie",
                "SRCHD=AF=NOFORM; SRCHUID=V=2&GUID=E2F538C2466245A08EAD52E572494469&dmnchg=1; _EDGE_V=1; MUID=39A88A6FF7F86FE136528709F6D66E24; MUIDB=39A88A6FF7F86FE136528709F6D66E24; MSCC=1; _TTSS_OUT=hist=[]; ANON=A=8AC4A7383D0B3CA8FF579218FFFFFFFF&E=1750&W=1; NAP=V=1.9&E=16f6&C=JHOpVqAtpfFlTGfQgVsm9RDJ7m2NVsI3_89bTkfojhky-syTiXho-g&W=1; imgv=lodlg=1&gts=20191020&lts=20191109; _FP=hta=off; ENSEARCH=BENVER=1; SerpPWA=reg=1; MSTC=ST=1; _EDGE_S=mkt=zh-cn&SID=0BD56B2AA1696FDD1046655BA0476EF5; BPF=X=1; _tarLang=default=en; _SS=SID=0BD56B2AA1696FDD1046655BA0476EF5&bIm=366063; _UR=QS=0; ipv6=hit=1581836246179&t=4; SRCHUSR=DOB=20190524&T=1581832647000&POEX=W; ULC=P=5474|465:@142&H=!5474|465:142&T=5474|465:142:4; SRCHHPGUSR=CW=1080&CH=1802&DPR=1.5&UTC=480&WTS=63717429443&HV=1581834797");
        }

        private static UriBuilder GenerateUri(HttpClient httpClient)
        {
            var parameters = GenerateParameters();
            var builder = new UriBuilder($"{httpClient.BaseAddress}/HPImageArchive.aspx");
            var query = HttpUtility.ParseQueryString(builder.Query);
            foreach (var kv in parameters) query[kv.Key] = kv.Value.ToString();

            builder.Query = query.ToString();
            return builder;
        }

        private static List<KeyValuePair<string, object>> GenerateParameters(int idx = -1, int n = 8)
        {
            const string format = "js";
            const string mkt = "en-US";

            var parameters = new List<KeyValuePair<string, object>>
            {
                new(nameof(format), format),
                new(nameof(idx), idx),
                new(nameof(n), n),
                new(nameof(mkt), mkt)
            };
            return parameters;
        }
    }
}