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
                Thread.Sleep(2000);
                return;
            }
            if (_card.Balance > answer)
            {
                _card.Balance -= answer;
                Console.WriteLine("Processing...");
                Thread.Sleep(1000);
                Console.WriteLine("Money withdraw successful.");
                Console.WriteLine($"New balance is {_card.Balance}");

                _card.Transactions.Add(new Transaction
                {
                    Name = "Money Withdrawal",
                    TransactionType = "Withdrawal",
                    Description = "Money to you.",
                    Amount = answer,
                    DateTime = DateTime.Now,
                });

                Thread.Sleep(2000);
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
                Thread.Sleep(2000);
                return;
            }

            _card.Balance += answer;
            Console.WriteLine("Processing...");
            Thread.Sleep(1000);
            Console.WriteLine("Deposit succeeded!");
            Console.WriteLine($"New balance is {_card.Balance}");

            _card.Transactions.Add(new Transaction
            {
                Name = "Money Deposit",
                TransactionType = "Deposit",
                Description = "Deposited money to your account.",
                Amount = answer,
                DateTime = DateTime.Now,
            });

            Thread.Sleep(2000);
        }

        public void PayBills()
        {
            Console.WriteLine("Bills:\n");
            int c = 0;
            _card.Bills.ForEach(b => Console.WriteLine($"###[{c++}]####\nName:{b.Name}\nProvider:{b.Provider}\nDescription:{b.Description}\nDue Date:{b.DueDate}\nAmount:{b.Amount}"));
            Console.WriteLine($"#######\nBalance:{_card.Balance}\nSelect bill:");

            int answer;
            try
            {
                answer = Int32.Parse(Console.ReadLine() ?? string.Empty);
                if (answer < 0 || answer > _card.Bills.Count - 1)
                {
                    Console.WriteLine("Input not valid.");
                    Thread.Sleep(2000);
                    return;
                }
            }
            catch
            {
                Console.WriteLine("Input not valid.");
                Thread.Sleep(2000);
                return;
            }

            Bill bill = _card.Bills[answer];
            if (bill.Amount > _card.Balance)
            {
                Console.WriteLine("Not enough money to pay the bill.");
                Thread.Sleep(2000);
                return;
            }

            _card.Bills.Remove(bill);
            _card.Balance -= bill.Amount;
            Console.WriteLine($"Bill paid.\nNew balance:{_card.Balance}");

            _card.Transactions.Add(new Transaction { 
                Name = bill.Name, 
                TransactionType = "Bill Payment",
                Description = bill.Description,
                Amount  = bill.Amount,
                DateTime = DateTime.Now,
            });

            Thread.Sleep(2000);

        }

        public void ShowBalance()
        {
            Console.WriteLine($"Your card balance\n[{_card.Balance}]");
            Console.WriteLine($"Your transactions:");
            foreach(var item in  _card.Transactions)
            {

                Console.Write($"\nName: {item.Name}\nTransactionType: {item.TransactionType}\nDescription: {item.Description}\nMoney Amount: {item.Amount}\nTime: {item.DateTime}\n");
            }
            Console.ReadLine();

        }

    }
}
