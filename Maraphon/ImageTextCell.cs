using System;
using System.Drawing;
using System.Windows.Forms;

public class ImageTextCell : DataGridViewTextBoxCell
{
    public Image ImageValue { get; set; }

    public ImageTextCell() : base()
    {
    }

    public ImageTextCell(Image imageValue) : base()
    {
        ImageValue = imageValue;
    }

    public override object Clone()
    {
        ImageTextCell cell = (ImageTextCell)base.Clone();
        cell.ImageValue = this.ImageValue;
        return cell;
    }

    protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
    {
        base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

        if (ImageValue != null)
        {
            Rectangle imageBounds = new Rectangle(cellBounds.X, cellBounds.Y, cellBounds.Height, cellBounds.Height);
            graphics.DrawImage(ImageValue, imageBounds);
        }
    }
}
