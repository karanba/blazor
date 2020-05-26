using System;
using Microsoft.AspNetCore.Components;

namespace WebApplication1.Pages
{
    public class MyAlert
    {
        [Parameter]
        public bool Show { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}