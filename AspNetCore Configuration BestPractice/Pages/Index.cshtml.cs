using AspNetCore_Configuration_BestPractice.Database;
using AspNetCore_Configuration_BestPractice.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace AspNetCore_Configuration_BestPractice.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _dbContext;
        public readonly MapSettings _mapSettings;
        public List<User>? Users { get; set; }
        // add IOptionsSnapShot<T> Registered In DI Container with Singleton LifeTime
        // we could aslo use IOptions<T>. but if values in json settings change runtime the T class will not change
        public IndexModel(IOptionsSnapshot<MapSettings> mapSettings, AppDbContext dbContext)
        {
            _mapSettings = mapSettings.Value;
            _dbContext = dbContext;
        }

        public void OnGet()
        {
            Users = _dbContext.Users.ToList();
        }
        public void OnPost()
        {

        }
    }
}