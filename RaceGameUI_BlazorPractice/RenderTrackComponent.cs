using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System.Diagnostics;

namespace RaceGameUI_BlazorPractice
{
    // based on Lupusa87 CompChildWalls.cs
    public class RenderTrackComponent : ComponentBase
    {
        protected override void OnAfterRender(bool firstRender)
        {
            if (LocalData.PaintedDogs == null)
            {
                LocalData.PaintedDogs = this;
            }
            base.OnAfterRender(firstRender);
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            RenderHounds(0, builder);
            base.BuildRenderTree(builder);
        }

        public void RenderHounds(int k, RenderTreeBuilder builder)
        {
            builder.OpenElement(k++, "g");
            builder.AddAttribute(k++, "fill", "grey");

            foreach (GreyHound hound in LocalData.hounds)
            {
                AddRectangle(builder, k, 10 + hound.getCurrentPosition() * 8, + 50 * hound.GetId() + 20);
            }

            builder.CloseElement();

            //foreach (GreyHound hound in LocalData.hounds)
            //{
            //    AddText(builder, k, 10, +50 * hound.GetId() + 35);
            //}

        }

        public void AddRectangle(RenderTreeBuilder builder, int k, int posX, int posY)
        {
            builder.OpenElement(k++, "rect");
            builder.AddAttribute(k++, "x", posX);
            builder.AddAttribute(k++, "y", posY);
            builder.AddAttribute(k++, "width", 40);
            builder.AddAttribute(k++, "height", 20);
            builder.CloseElement();
        }

        public void AddText(RenderTreeBuilder builder, int k, int posX, int posY)
        {
            builder.OpenElement(k++, "text");
            builder.AddAttribute(k++, "x", posX);
            builder.AddAttribute(k++, "y", posY);
            builder.CloseElement();
        }
        
        public void Refresh()
        {
            StateHasChanged();
        }

    }

}
