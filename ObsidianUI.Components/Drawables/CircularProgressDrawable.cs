using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObsidianUI.Components.Controls;

namespace ObsidianUI.Components.Drawables;

internal class CircularProgressDrawable(CircularProgress cp) : IDrawable
{
    public void Draw(ICanvas canvas, RectF rect)
    {
        canvas.Antialias = true;

        var strokeWith = cp.ProgressThickness;
        var halfStrokeWith = strokeWith / 2;
        canvas.StrokeDashPattern = null;
        canvas.StrokeColor = cp.IncaveColor;
        canvas.StrokeSize = strokeWith;
        canvas.DrawEllipse(
            rect.X + halfStrokeWith, rect.Y + halfStrokeWith, rect.Width - strokeWith, rect.Height - strokeWith);

        strokeWith = cp.ProgressThickness;
        canvas.FillColor = cp.ProgressColor;
        canvas.StrokeColor = cp.ProgressColor;

        canvas.FontColor = cp.ProgressColor;
        canvas.FontSize = 20;
        canvas.DrawString(cp.Text, rect, cp.HorizontalAlignment, cp.VerticalAlignment);

        canvas.StrokeSize = strokeWith;
        canvas.Rotate(cp.Step, rect.Width / 2, rect.Height / 2);
        canvas.StrokeLineCap = cp.LineCap;
        if (cp.Value == cp.MaxValue) cp.Value = cp.MaxValue - 1;
        canvas.StrokeLineJoin = LineJoin.Bevel;
        canvas.DrawArc(
            new Rect(rect.X + halfStrokeWith, rect.Y + halfStrokeWith, rect.Width - strokeWith, rect.Height - strokeWith),
            0,
            (int)Math.Round(360.0 / cp.MaxValue * cp.Value) * -1,
            true,
            false);

    }
}