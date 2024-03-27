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
            Balance = 23143,
            Bills = new() {
                new Bill()
                {
                    Id = Guid.NewGuid(),
                    Name = "Electricity Bill",
                    Provider = "Electricity Company",
                    Description = "Energy used in the last month or so. No fee changes.",
                    DueDate = DateTime.Now.AddDays(5),
                    Amount = 89
                },
                new Bill()
                {
                    Id = Guid.NewGuid(),
                    Name = "Internet Bill",
                    Provider = "Digi Ro",
                    Description = "Standard internet plan bill. No aditional charges.",
                    DueDate = DateTime.Now.AddDays(9),
                    Amount = 145
                },
                new Bill()
                {
                    Id = Guid.NewGuid(),
                    Name = "Water Bill",
                    Provider = "Water Company",
                    Description = "Running water and sewage bill.",
                    DueDate = DateTime.Now.AddDays(7),
                    Amount = 76
                }
            }
        };

        ATM atm = new ATM(myCard);

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