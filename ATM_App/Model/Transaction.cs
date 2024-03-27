using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_App.Model
{
    internal class Transaction
    {
        public required string Name;

        public required string TransactionType;

        public required string Description;

        public required int Amount;

        public required DateTime DateTime;

    }
}
