using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LiftModel
{
    public class Lift
    {
        public int Floors { get; set; }
        public int LimitWeight { get; set; } = 400;

        private int timeMoving = 1000;
        public int trevoga = 0;
        public int CurrentMin = 0;
        public int CurrentSec = 0;

        public int GetTimeMoving()
        {
            return timeMoving;
        }

        public void SetTimeMoving(int value)
        {
            timeMoving = value;
        }

    

        public int CurrentFloor { get; set; } = 1;

        public int TripsCounter { get; set; } = 1; // первая поездка не идет в счет (1. смена направления 2. поездка после ожидания)
        public int EmptyTripsCounter { get; set; } = 1;
        

        public List<Person> Pessengers { get; set; } = new List<Person>();
        public List<Person> Queue { get; set; } = new List<Person>();
        public List<Person> Queue1 { get; set; } = new List<Person>();
        public int ActiveUsers => Pessengers.Count + Queue.Count; 

        public List<LiftButton> Buttons { get; set; } = new List<LiftButton>();
   

        public List<Person> History { get; set; } = new List<Person>();
        public List<Person> History2 { get; set; } = new List<Person>();


        public bool IsMove { get; set; } = false;
        public bool IsEmpty { get; set; } = true;

        Direction LiftDirection = Direction.Up;

        public int Weight { get
            {
                return Pessengers.Sum(item => item.Weight);
            }
        }

        public Lift(int floors)
        {
            Floors = floors;
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            for (int i = 1; i <= Floors; i++)
            {
                LiftButton lb = new LiftButton(i, false);
                Buttons.Add(lb);
            
            }
        }
        public void TimerUpdate()
        {
            CurrentSec++;
            if (CurrentSec > 60)
            {
                CurrentSec = 0;
                CurrentMin++;
            }
        }

        public void AddToQueue(Person person)
        {
            Queue.Add(person);

            RefreshLiftButtons();
        }

        public void RefreshLiftButtons()
        {

            foreach (LiftButton lbtn in Buttons)
            {
                lbtn.IsActive = false;//текущая кнопка

                foreach (Person pe in Queue)// для всех кто в очереди
                {
                    if (lbtn.Number == pe.StartFloor)
                    {
                        lbtn.ChangeActivity(true);
                    }
                }

                foreach (Person pe in Pessengers)
                {
                    if (lbtn.Number == pe.TargetFloor)
                    {
                        lbtn.ChangeActivity(true);
                    }
                }
            }
        }

       

        private void Enter()
        {
            List<Person> CriticalPerson = new List<Person>();
            CriticalPerson = Queue.FindAll(item => item.StartFloor == CurrentFloor);
            Pessengers.AddRange(CriticalPerson);
            Queue.RemoveAll(item => item.StartFloor == CurrentFloor);
            
        }

        private void ExitFrom()
        {
            List<Person> CriticalPerson = new List<Person>();
            CriticalPerson = Pessengers.FindAll(item => item.TargetFloor == CurrentFloor);
            History.AddRange(CriticalPerson);
            History2.AddRange(CriticalPerson);
            Pessengers.RemoveAll(item => item.TargetFloor == CurrentFloor);
        }

        private void Transfer()
        {

            if (Pessengers.FindAll(item => item.TargetFloor == CurrentFloor).Count + Queue.FindAll(item => item.StartFloor == CurrentFloor).Count > 0)
            {
                ExitFrom();
                Enter();
                RefreshLiftButtons();
            }
            else
            {
                GoToNextFloor();
            }
        }

        public void Move()
        {
            History.Clear();
            if (trevoga == 1)
            {
                if (CurrentFloor > 1)
                {
                    LiftDirection = Direction.Down;
                    Transfer();
                }

                return;
            }
            if (ActiveUsers > 0)
            {
                IsMove = true;
                if (Pessengers.Count == 0)
                {
                    if(!IsEmpty)
                    {
                        IsEmpty = true;
                        EmptyTripsCounter++;
                        TripsCounter++;
                    }
                    SetDirectionIfEmpty();
                }
                else
                {
                    CheckState();
                }
                Transfer();
                if(Pessengers.Count > 0)
                {
                    IsEmpty = false;
                }
            }
            else
            {

                Wait();
            }
        }

        private void Wait()
        {
            
        }

        private void GoToNextFloor()
        {
            if (CheckWeight())
            {
                Pessengers.Remove(Pessengers.Last());
            }
            else
            {
                if (LiftDirection == Direction.Up)
                    CurrentFloor++;
                else CurrentFloor--;
            }
        }

        private void CheckState()
        {
            // будем менять направление движения?
            bool IsChangeDirection = true;

            foreach (Person pe in Pessengers)
            {
                // если текущее направление - вверх и есть пассажиры с целевым этажом больше текущего, то направление движения не меняем.
                if (LiftDirection == Direction.Up)
                {
                    if (pe.TargetFloor > CurrentFloor)
                        IsChangeDirection = false;
                }
                // если текущее направление -вниз и есть пассажиры с целевым этажом меньше текущего, то направление движения не меняем.
                else
                {
                    if (pe.TargetFloor < CurrentFloor)
                        IsChangeDirection = false;
                }
            }

            // смена направления
            if (IsChangeDirection)
            {
                TripsCounter++;

                if (LiftDirection == Direction.Up)
                    LiftDirection = Direction.Down;
                else LiftDirection = Direction.Up;
            }

    
        }

        private void SetDirectionIfEmpty()
        {
            Person TargetPerson = null;//чтобы найти человека,который едет
            int way = this.Floors + 1; // чтобы записать сюда первого человека и дальше с ним сравнивать.
            foreach (Person pe in Queue)
            {
                if (Math.Abs(pe.StartFloor - CurrentFloor) < way)  // находим ближайшего
                {
                    way = Math.Abs(pe.StartFloor - CurrentFloor);
                    TargetPerson = pe;
                }
            }

            if (TargetPerson.StartFloor >= CurrentFloor)
            {
                LiftDirection = Direction.Up;
            }
            else
            {
                LiftDirection = Direction.Down;
            }
        }

        public bool CheckWeight()
        {
            if (Weight > LimitWeight)
                return true;
            else
                return false;
        }
    }

    internal enum Direction
    {
        Up,
        Down
    }
}
