using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_App.Model
{
    internal class Bill
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Provider {  get; set; }

        public required string Description { get; set; }

        public DateTime DueDate { get; set; }

        public int Amount { get; set; }
    }
}
