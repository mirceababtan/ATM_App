using ATM_App.Model;

namespace ATM_App
{
    internal class CardActions
    {
        private readonly Card _card;
        public CardActions(Card card)
        {
            _card = card;
        }

        public void WithdrawMoney()
        {
            Console.WriteLine("How much?");
            int answer;
            try
            {
                answer = Int32.Parse(Console.ReadLine() ?? string.Empty);
            }
            catch
            {
                Console.WriteLine("Input not valid.");
                return;
            }
            if (_card.Balance > answer)
            {
                _card.Balance -= answer;
                Console.WriteLine("Processing...");
                Thread.Sleep(1000);
                Console.WriteLine("Money withdraw successful.");
                Console.WriteLine($"New balance is {_card.Balance}");
            }
        }

        public void DepositMoney()
        {
            Console.WriteLine("How much?");
            int answer;
            try
            {
                answer = Int32.Parse(Console.ReadLine() ?? string.Empty);
            }
            catch
            {
                Console.WriteLine("Input not valid.");
                return;
            }

            _card.Balance += answer;
            Console.WriteLine("Processing...");
            Thread.Sleep(1000);
            Console.WriteLine("Deposit succeeded!");
            Console.WriteLine($"New balance is {_card.Balance}");
        }

        public void PayBills()
        {
            Console.WriteLine("Not working.");
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Your card balance\n[{_card.Balance}]");
        }

        public void WithdrawCard()
        {
            
        }
    }
}
