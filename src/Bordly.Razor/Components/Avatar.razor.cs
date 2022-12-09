using Bordly.Business.ViewController;
using Microsoft.AspNetCore.Components;

namespace Bordly.Razor.Components
{
    public partial class Avatar
    {
        [Inject] PlayerViewController Controller { get; set; }
    }
}