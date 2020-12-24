using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLift.Dialogs
{
    public class ResultPresenter : IResultable
    {
        private FrmResults View;
        private LiftModel.Statistics stat;

        public ResultPresenter(FrmResults frm, LiftModel.Lift lift)
        {
            View = frm;
            stat = new LiftModel.Statistics(lift);

            View.btnOK.Click += BtnOK_Click;
            View.btnToWord.Click += BtnToWord_Click;
            View.btnToExcel.Click += BtnToExcel_Click;
            Result();
        }

        private void BtnToWord_Click(object sender, EventArgs e)
        {
            stat.ToWord();
        }

        private void BtnToExcel_Click(object sender, EventArgs e)
        {
            stat.ToExcel();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            View.Close();
        }

        public void Result()
        {
            View.txtPeople.Text = stat.People();
            View.txtAllWeight.Text = stat.ResultWeight();
            View.txtTrips.Text = stat.AllTrips();
            View.txtEmptyTrips.Text = stat.AllEmptyTrips();
            //View.txtTime.Text = stat.AllTime();
        }
    }
}
