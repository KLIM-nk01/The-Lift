using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftModel
{
    public class StatusLift
    {
        private Lift Lifft;

        private int CountMovingLifts { get; set; }

        public StatusLift(Lift lift)
        {
            Lifft = lift;

            if (Lifft.IsMove)
                CountMovingLifts = 1;
            else
                CountMovingLifts = 0;
        }

        public string MovingLifts()
        {
            return "Количество движущихся лифтов - " + CountMovingLifts.ToString();
        }

        public string StoppingLifts()
        {
            return "Количество остановленных лифтов - " + (1 - CountMovingLifts).ToString();
        }

        public string People()
        {
            return "Количество перевезенных человек - " + (Lifft.History.Count + Lifft.Pessengers.Count).ToString();
        }
    }
}
