using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class Price
    {
        public decimal Amount { get; private set; }
        public Currency Currency { get; private set; }

        private Price() { } 

        public Price(decimal amount, Currency currency)
        {
            if (amount < 0)
                throw new ArgumentException("Price cannot be negative", nameof(amount));

            Amount = amount;
            Currency = currency;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Price other)
                return false;

            return Amount == other.Amount && Currency == other.Currency;
        }

        public override int GetHashCode() => HashCode.Combine(Amount, Currency);

        public override string ToString() => $"{Amount} {Currency}";
    }

}
