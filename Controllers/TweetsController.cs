using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TwitterAnalyzer.Models;

namespace TwitterAnalyzer.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TweetsController : Controller
    {
        private readonly HttpClient _httpClient;

        public TweetsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost("classify")]
        public async Task<IActionResult> Classify([FromBody] TweetRequest tweetRequest)
        {
            var json = JsonConvert.SerializeObject(tweetRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("http://localhost:5001/classify", content);
            var classificationResult = await response.Content.ReadAsStringAsync();

            return Ok(classificationResult);
        }
    }
}
