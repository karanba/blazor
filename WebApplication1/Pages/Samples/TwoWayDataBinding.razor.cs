using System;
using Microsoft.AspNetCore.Components;

namespace WebApplication1.Pages.Samples
{
    public class TwoWayDataBindingBase : ComponentBase
    {
        protected string FullName { get; set; } = "Altay Karakuş";
        protected int Age { get; set; } = 40;
        protected DateTime BirthDate { get; set; } = new DateTime(1979, 10, 2);


        protected void getName()
        {
            FullName = "Altay Karakuş";
        }
    }
}