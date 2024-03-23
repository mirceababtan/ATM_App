using ATM_App;
using ATM_App.Model;

internal class Program
{
    private static void Main(string[] args)
    {
        Card myCard = new()
        {
            CardNumber = Guid.NewGuid(),
            OwnerFirstName = "Mircea",
            OwnerLastName = "Babtan",
            Cvv = "123",
            PIN = "0000",
            IsBlocked = false,
            Balance = 23143
        };

        ATM atm = new ATM(myCard);

        /*        Console.WriteLine("Welcome at the ATM. Please select an action:");
                Console.WriteLine("[0] Insert card.\n[1] Withdraw card. \n[2] Block card.\n[3] Leave the ATM.");
                string answer = Console.ReadLine() ?? string.Empty;*/

        string answer;
        do
        {
            Console.WriteLine("Welcome at the ATM. Please select an action:");
            Console.WriteLine("[0] Insert card.\n[1] Block card.\n[2] Leave the ATM.");
            answer = Console.ReadLine() ?? string.Empty;

            if (answer == "0") atm.InsertCard();
            else if (answer == "1") atm.BlockCard();
            Console.Clear();
        } while (answer != "2" && answer != string.Empty);


    }
}