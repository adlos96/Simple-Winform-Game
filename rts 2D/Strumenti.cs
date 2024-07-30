using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace rts_2D
{
    internal class Strumenti
    {
        
    }
    public class ProgressBarEx : ProgressBar
    {
        public ProgressBarEx()
        {
            // Abilita il rendering personalizzato
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Ottieni l'area della ProgressBar
            Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);
            // Calcola il fattore di scala in base al valore corrente
            double scaleFactor = (((double)Value - (double)Minimum) / ((double)Maximum - (double)Minimum));

            // Disegna lo sfondo della ProgressBar
            if (ProgressBarRenderer.IsSupported)
            {
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);
            }

            // Riduci l'area del rettangolo per evitare di disegnare sui bordi
            rec.Width = (int)(rec.Width * scaleFactor);
            rec.Height = rec.Height - 4;
            rec.X = 2;
            rec.Y = 2;

            // Usa ForeColor per il colore della barra di avanzamento
            // e BackColor per il colore di sfondo (se necessario)
            using (Brush brush = new SolidBrush(this.ForeColor))
            {
                e.Graphics.FillRectangle(brush, rec);
            }
        }
    }
    public class ProgressBarEx_2 : ProgressBar
    {
        private SolidBrush brush = null;

        public ProgressBarEx_2()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            LinearGradientBrush brush = null;
            Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);
            double scaleFactor = (((double)Value - (double)Minimum) / ((double)Maximum - (double)Minimum));

            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);

            rec.Width = (int)((rec.Width * scaleFactor) - 4);
            rec.Height -= 4;
            brush = new LinearGradientBrush(rec, this.ForeColor, this.BackColor, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height);
        }
    }
}
