using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PortalRazor.Pages;

public class IndexModel : PageModel
{
    
    public IndexModel()
    {
        
    }
    public void OnGet()
    {
        
    }
    public string PrintDateTime() => DateTime.Now.ToString();
}
