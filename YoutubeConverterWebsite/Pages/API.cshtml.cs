using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeConverterWebsite.Pages
{
    public class APIModel : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            var id = PageContext.RouteData.Values["id"];
            var obj = await Backend.ConverterHelper.GetUrl($"https://www.youtube.com/watch?v={id}");
            var json = JsonConvert.SerializeObject(obj);
            var bytes = Encoding.UTF8.GetBytes(json);
            return File(bytes, "application/json");
        }
    }
}
