namespace ATM_App.Model
{
    internal class Card
    {
        public required Guid CardNumber { get; set; }
        public required string OwnerFirstName { get; set; }

        public required string OwnerLastName { get; set; }

        public required string Cvv { get; set; }

        public required string PIN { get; set; }

        public required bool IsBlocked { get; set; }

        public required int Balance { get; set; }

    }
}
