using System.Drawing;
using System.Windows.Forms;

namespace MidChess.controls
{
    internal class TransparentButton : Button
    {
        public TransparentButton()
        {
            BackColor = Color.Transparent;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.MouseDownBackColor = Color.FromArgb(50, Color.Gray);
            FlatAppearance.MouseOverBackColor = Color.FromArgb(50, Color.White);
            ForeColor = Color.White;
        }
    }
}