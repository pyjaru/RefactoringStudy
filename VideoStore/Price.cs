using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStore
{
    abstract class Price
    {
        public abstract int PriceCode { get; }

        public abstract double GetCharge(int daysRented);

        public virtual int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }

    class RegularPrice : Price
    {
        public override int PriceCode => Movie.REGULAR;
        
        public override double GetCharge(int daysRented)
        {
            double result = 2;
            if (daysRented > 2) result += (daysRented - 2) * 1.5;
            return result;
        }
    }

    class NewReleasePrice : Price
    {
        public override int PriceCode => Movie.NEW_RELEASE;

        public override double GetCharge(int daysRented)
        {
            return daysRented * 3; ;
        }

        public override int GetFrequentRenterPoints(int daysRented)
        {
            return (daysRented > 1) ? 2 : 1;
        }
    }

    class ChildrenPrice : Price
    {
        public override int PriceCode => Movie.CHILDREN;

        public override double GetCharge(int daysRented)
        {
            double result = 1.5;
            if (daysRented > 3) result += (daysRented - 3) * 1.5;
            return result;
        }
    }
}
