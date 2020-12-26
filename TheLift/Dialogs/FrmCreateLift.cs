using System;
using System.Drawing;
using System.Windows.Forms;
using LiftModel;
using System.Collections.Generic;

namespace TheLift
{
    public partial class FrmCreateLift : Form
    {
        public Lift NewLift;
        //public Lift NewLift2;
        public List<Person> Queue { get; set; } = new List<Person>();
        public ILiftCreatable creatable;


        public FrmCreateLift()
        {
            InitializeComponent();
            creatable = new CreateLiftPresenter(this);
        }

     
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        Point lastPoint;
        private void FrmCreateLift_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void FrmCreateLift_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
}
