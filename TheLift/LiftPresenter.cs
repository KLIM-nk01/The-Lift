using System;
using LiftModel;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TheLift
{
    public class LiftPresenter : IPersonCreatable
    {
        public Lift OurLift;
      //  public Lift OurLift2;
       
        private FrmLift View;

        Thread MovingLift, TimerThread;

        public LiftPresenter(FrmLift frm)
        {
            View = frm;
            TimerThread = new Thread(new ThreadStart(RefreshTimer));
            MovingLift = new Thread(new ThreadStart(Control));
          
            TimerThread.Start();
            TimerThread.Suspend();
            MovingLift.Start();
            MovingLift.Suspend();

            View.btnCreatePerson.Click += BtnCreatePerson_Click;
            View.btnControl.Click += BtnControl_Click;
            View.button1.Click += BtnCreateLift_Click;
            View.button2.Click += TsmiShowStat_Click;
            View.button3.Click += TimePerFloor_Click; 
            View.button4.Click += BtnTrevoga;
            View.TableButtons.Click += TableButtons_Click;
           // View.TableButtons2.Click += TableButtons_Click;
            View.FormClosing += View_FormClosing;
            //View.btnGo.Click += BtnGo_Click;

        }


        private void TableButtons_Click(object sender, EventArgs e)//стата
        {

            RefreshButtons();
          
        }
       

        private void TimePerFloor_Click(object sender, EventArgs e)
        {
            try
            {
               OurLift.SetTimeMoving(Int32.Parse(View.TimePerFloorTextBox.Text) * 1000);
            }
            catch(Exception)
            {
                MessageBox.Show("Введите целое число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsmiShowStat_Click(object sender, EventArgs e)
        {
            if (OurLift != null)
            {
                if (OurLift.History.Count != 0)
                {
                    Dialogs.FrmResults frr = new Dialogs.FrmResults(OurLift);
                    frr.ShowDialog();
                }
                else
                    MessageBox.Show("Лифт не совершил ни одной поездки", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Необходимо создать лифт.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     /*   private void BtnGo_Click(object sender, EventArgs e)
        {
           //OurLift.Move();

           // Refresh();
        }*/

        private void BtnCreateLift_Click(object sender, EventArgs e)
        {
            FrmCreateLift fcr = new FrmCreateLift();
            DialogResult dr = fcr.ShowDialog();

            if (dr == DialogResult.Yes)
            {
               
                this.OurLift = fcr.NewLift;
               // this.OurLift2 = fcr.NewLift2;
                fcr.Close();

                View.nudCurrentFloor.Maximum = OurLift.Floors;
                View.nudTargetFloor.Maximum = OurLift.Floors;

                View.txtCurrentFloor.Text = OurLift.CurrentFloor.ToString();
               // View.textBox2.Text = OurLift2.CurrentFloor.ToString();
                RefreshButtons();
            }
        }
        private void BtnTrevoga(object sender, EventArgs e)
        {
            //Dialogs.FormTrevoga f = new Dialogs.FormTrevoga();
            //f.ShowDialog();
            if (OurLift != null)
            {
                View.Trevoga++;
                View.Trevoga %= 2;
                if (View.Trevoga == 1)
                {
                    View.button4.Text = "Остановить тревогу";
                    OurLift.trevoga = 1;
                    OurLift.Queue.Clear();
                    OurLift.Pessengers.Clear();
                    OurLift.RefreshLiftButtons();
                }
                else
                {
                    View.button4.Text = "Пожарная тревога";
                    OurLift.trevoga = 0;
                }
            }
            else { MessageBox.Show("Необходимо создать лифт.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }


        }

        private void View_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            //MovingLift.Suspend();
            if (MovingLift.ThreadState == ThreadState.Running)
            {
               // MovingLift.Suspend();
                MovingLift.Abort();
            }
        }

        private void BtnControl_Click(object sender, EventArgs e)
        {
            if (OurLift != null)
            {
               View.IsActive = !View.IsActive;
                if (View.IsActive)
                {
                    MovingLift.Resume();
                    TimerThread.Resume();
                    View.btnControl.Text = "Остановить систему";
                    View.splitContainer2.Enabled = true;
                    View.button1.Visible = false;
                }
                else
                {
                    MovingLift.Suspend();
                    TimerThread.Suspend();
                    View.btnControl.Text = "Запустить систему";
                    View.splitContainer2.Enabled = false;
                    View.button1.Visible = true;
                }
            } else { MessageBox.Show("Необходимо создать лифт.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

      

        public void Control()
        {
            while (View.IsActive)
            {
                if (OurLift.trevoga == 1 && OurLift.CurrentFloor != 1)
                {
                    OurLift.Move();
                    Thread.Sleep(OurLift.GetTimeMoving());//на 1 сек

                    Refresh();
                }
                if (OurLift.ActiveUsers > 0)
                {
                    OurLift.Move();
                    Thread.Sleep(OurLift.GetTimeMoving());//на 1 сек

                    Refresh();
                }
                else
                {
                    OurLift.IsMove = false;
                    StatusStripRefresh();
                }
            }
        }

        private void BtnCreatePerson_Click(object sender, EventArgs e)
        {
            PersonCreate();
            //RefreshQueue();
            //RefreshButtons();
        }

        public void PersonCreate()
        { 
            int StartFloor = Convert.ToInt32(View.nudCurrentFloor.Value);
            int TargetFloor = Convert.ToInt32(View.nudTargetFloor.Value);
            int Weight = Convert.ToInt32(View.nudWeight.Value);
            CheckVorotWeight(Weight);
            Person person = new Person(StartFloor, TargetFloor, Weight);
            OurLift.AddToQueue(person);
          //  OurLift2.AddToQueue(person);
        }

        public void CheckVorotWeight(int w)
        {
            if (w == 150) MessageBox.Show("Добрый день, Юрий Иосифович!");
        }

        public void RefreshQueue()// обновление элементов управления
        {
           
            View.lbQueue.Items.Clear();
            View.lbQueue.DisplayMember = "Info";
            foreach(Person pe in OurLift.Queue)
            {
                View.lbQueue.Items.Add(pe);
            }
        }

        public void RefreshButtons()
        {
            View.TableButtons.Items.Clear();
          //  View.TableButtons2.Items.Clear();
            foreach (LiftButton btn in OurLift.Buttons)
            {
                View.TableButtons.Items.Add(btn.Number.ToString(), btn.IsActive);

            }
            //foreach (LiftButton btn in OurLift2.Buttons)
            //{
            //    View.TableButtons2.Items.Add(btn.Number.ToString(), btn.IsActive);

            //}
        }

        public void RefreshPessengers()
        {
            if (OurLift.trevoga == 1)
            {
                View.lbPessengers.Items.Clear();
                View.lbPessengers.Items.Add("ТРЕВОГА!!!");
                return;
            }
            View.lbPessengers.Items.Clear();
            View.lbPessengers.DisplayMember = "Info";
            foreach (Person pe in OurLift.Pessengers)
            {
                View.lbPessengers.Items.Add(pe);
            }
        }

        public void RefreshHistory()
        {
            //View.lbHistory.Items.Clear();
            View.lbHistory.DisplayMember = "Info";
            foreach (Person pe in OurLift.History)
            {
                View.lbHistory.Items.Add(pe);
            }
        }

        public void RefreshInfo()
        {
            View.txtCurrentFloor.Text = OurLift.CurrentFloor.ToString();
            View.txtWeight.Text = OurLift.Weight.ToString();
            
            if(OurLift.CheckWeight())
            {
                View.lblLimit.Text = "ПЕРЕГРУЗКА";
            }
            else
            {
                View.lblLimit.Text = "";
            }
        }

        public void RefreshTimer()
        {
            while (View.IsActive) { 
            OurLift.TimerUpdate();
            View.timerLabel.Text = "Время работы: " + OurLift.CurrentMin.ToString() + " мин " + OurLift.CurrentSec.ToString() + " сек";
                Thread.Sleep(1000);
        }
        }

        private void StatusStripRefresh()
        {
            StatusLift status = new StatusLift(OurLift);
            View.tsslPeople.Text = status.People();

        }

        public void Refresh()
        {
           
            RefreshQueue();
            RefreshButtons();
            RefreshPessengers();
            RefreshHistory();
            RefreshInfo();
            StatusStripRefresh();
        }
    }
}
