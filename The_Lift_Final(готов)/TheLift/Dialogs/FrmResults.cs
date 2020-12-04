using LiftModel;
using System.Windows.Forms;
using System.Drawing;

namespace TheLift.Dialogs
{
    public partial class FrmResults : Form
    {
        public IResultable resultable;

        public FrmResults(Lift lift)
        {
            InitializeComponent();
            resultable = new ResultPresenter(this, lift);
        }


        Point lastPoint;
        private void FrmResults_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void FrmResults_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void label2_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
