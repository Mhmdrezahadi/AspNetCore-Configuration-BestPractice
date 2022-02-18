using AspNetCore_Configuration_BestPractice.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace AspNetCore_Configuration_BestPractice.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public readonly MapSettings _mapSettings;
        // add IOptionsSnapShot<T> Registered In DI Container with Singleton LifeTime
        // we could aslo use IOptions<T>. but if values in json settings change runtime the T class will not change
        public IndexModel(ILogger<IndexModel> logger, IOptionsSnapshot<MapSettings> mapSettings)
        {
            _logger = logger;
            _mapSettings = mapSettings.Value;
        }

        public void OnGet()
        {
           
        }
        public void OnPost()
        {

        }
    }
}