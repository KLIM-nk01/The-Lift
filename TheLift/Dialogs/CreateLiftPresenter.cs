﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftModel;

namespace TheLift
{
    public class CreateLiftPresenter : ILiftCreatable
    {
        private FrmCreateLift View;

        public CreateLiftPresenter(FrmCreateLift frm)
        {
            View = frm;
            View.btnOK.Click += BtnOK_Click;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            LiftCreate();
            View.Close();
        }

        public void LiftCreate()
        {
            View.NewLift = new Lift(Convert.ToInt32(View.nudFloors.Value));
        }
    }
}
