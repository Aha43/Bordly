using Bordly.Business.ViewController;
using Microsoft.AspNetCore.Components;

namespace Bordly.Razor
{
    public partial class Player
    {
        [Inject] PlayerViewController Controller { get; set; }
    }
}