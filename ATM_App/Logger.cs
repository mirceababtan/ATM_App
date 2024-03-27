using ATM_App.Model;

namespace ATM_App
{
    internal class Logger
    {
        private readonly Card _card;

        public Logger(Card card)
        {
            _card = card;
        }

        public bool Login()
        {
            int tries = 3;
            if (_card.IsBlocked)
            {
                Console.WriteLine("This card is blocked.");
                return false;
            }
            Console.WriteLine("Please provide a PIN:");
            while (tries != 0)
            {
                string PIN = Console.ReadLine() ?? string.Empty;

                if (_card.PIN == PIN)
                {
                    Console.WriteLine("Login successful.\nWhat do you want to do?");
                    return true;
                }
                else
                {
                    tries--;
                    if (tries > 0) Console.WriteLine($"Pin is wrong. Try again.\nAttempts left: {tries}");
                }

            }
            return false;
        }
    }
}
