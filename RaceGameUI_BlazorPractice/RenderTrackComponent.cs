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

            Debug.Print("In Render hounds, length hounds: " + LocalData.hounds.Count);

            if (LocalData.hounds.Count == 0)
            {
                AddRectangle(builder, k, 10, 20);
                AddRectangle(builder, k, 10, 70);
                AddRectangle(builder, k, 10, 120);
                AddRectangle(builder, k, 10, 170);
            } else
            {
                AddRectangle(builder, k, 10 + LocalData.hounds[0].getCurrentPosition() * 8, 20);
                AddRectangle(builder, k, 10 + LocalData.hounds[1].getCurrentPosition() * 8, 70);
                AddRectangle(builder, k, 10 + LocalData.hounds[2].getCurrentPosition() * 8, 120);
                AddRectangle(builder, k, 10 + LocalData.hounds[3].getCurrentPosition() * 8, 170);
            }

            builder.CloseElement();
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
        
        public void Refresh()
        {
            StateHasChanged();
        }

    }

}
