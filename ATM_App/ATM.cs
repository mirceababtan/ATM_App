using ATM_App.Model;

namespace ATM_App
{
    internal class ATM
    {

        private bool isCardIntroduced = false;
        private readonly Card _card;
        private readonly CardActions _action;

        public ATM(Card card)
        {
            _card = card;
            _action = new CardActions(card);
        }
        public void InsertCard()
        {
            Logger logger = new Logger(_card);

            if (logger.Login())
            {
                isCardIntroduced = true;
                Console.WriteLine("Login successful.\nWhat do you want to do?");
                string answer;

                do
                {
                    Console.WriteLine("[0] Withdraw money.\n[1] Deposit money.\n[2] Pay bills.\n[3] ShowBalance.\n[4] Withdraw card.");
                    answer = Console.ReadLine() ?? string.Empty;
                    switch(answer)
                    {
                        case "0":
                            /*Console.WriteLine("How much?");
                            answer = Console.ReadLine() ?? string.Empty;
                            try
                            {
                                _action.WithdrawMoney(Int32.Parse(answer));
                            }
                            catch {
                                Console.WriteLine("Input not valid.");
                            }*/
                            _action.WithdrawMoney();
                            break;
                        case "1":
                            _action.DepositMoney();
                            break;
                        case "2":
                            _action.PayBills();
                            break;
                        case "3":
                            _action.ShowBalance();
                            break;
                        default:
                            break;
                    }

                } while (answer != "4");
            }
            else
            {
                Console.WriteLine("Too many wrong tries.\nYour card is now blocked.\nPlease go to the bank to retrieve it.");
                _card.IsBlocked = true;
            }

        }

        public void BlockCard()
        {
            if (!isCardIntroduced)
            {

            }
        }

    }
}
