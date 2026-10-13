using Microsoft.AspNetCore.Components;

namespace NorthWind.RazorComponents.NavBars;

public partial class NavMenu
{
    [Parameter]
    public RenderFragment NavBarBrand { get; set; } = default!;

    [Parameter]
    public RenderFragment NavBarItems { get; set; } = default!;

    bool CollapseNavMenu = true;

    string? NavMenuCssClass => CollapseNavMenu ? "collapse" : null;

    void ToggleNavMenu()
    {
        CollapseNavMenu = !CollapseNavMenu;
    }
}
