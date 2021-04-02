using System;

namespace events
{
    public delegate void myEventHandler(string amount);

    class Program
    {
        static void Main(string[] args)
        {
            PiggyBank myPig = new PiggyBank() { Balance = 0 };
            myPig.myEvent += delegate(string amt)
            {
                Console.WriteLine("YOU REACHED YOUR TARGET OF 500! YOU NOW HAVE {0}", amt);
            };

            do
            {
                Console.WriteLine("How much to deposit?");
                string input = Console.ReadLine();
                if (input.Equals("exit")) break;
                myPig.Balance += decimal.Parse(input);
                Console.WriteLine("Balance in piggy bank is {0}", myPig.Balance);
            } while (true);
        }
    }

    class PiggyBank
    {
        public event myEventHandler myEvent;

        private decimal _Balance;
        public decimal Balance
        {
            get { return _Balance; }
            set
            {
                _Balance = value;
                if (_Balance >= 500) myEvent(_Balance.ToString());
            }
        }
    }
}
