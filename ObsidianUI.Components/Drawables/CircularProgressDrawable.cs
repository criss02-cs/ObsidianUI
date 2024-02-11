using System;
using System.Collections.Generic;
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
        canvas.FillColor = cp.IncaveColor;
        canvas.StrokeSize = strokeWith;
        canvas.DrawEllipse(
            rect.X + halfStrokeWith, rect.Y + halfStrokeWith, rect.Width - strokeWith, rect.Height - strokeWith);

        strokeWith = cp.ProgressThickness;
        canvas.FillColor = cp.ProgressColor;// cp.ProgressColor;
        canvas.StrokeColor = cp.ProgressColor;// cp.ProgressColor;
        canvas.StrokeSize = strokeWith;
        canvas.Rotate(cp.Speed, rect.Width / 2, rect.Height / 2);
        canvas.StrokeLineCap = LineCap.Round;
        canvas.DrawArc(
            new Rect(rect.X + halfStrokeWith, rect.Y + halfStrokeWith, rect.Width - strokeWith, rect.Height - strokeWith),
            0,
            (int)Math.Round(360.0 / cp.MaxValue * cp.Value),
            true,
            false);

    }
}