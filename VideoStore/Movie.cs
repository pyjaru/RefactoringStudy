using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStore
{
    class Movie
    {
        public const int CHILDREN = 2;
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;

        private string _title;
        private int _priceCode;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public int PriceCode
        {
            get { return _priceCode; }
            set { _priceCode = value; }
        }

        public Movie(string title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }

        public double GetCharge(int daysRented)
        {
            double result = 0;

            switch (this.PriceCode)
            {
                case Movie.REGULAR:
                    result += 2;
                    if (daysRented > 2)
                        result += (daysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    result += daysRented * 3;
                    break;
                case Movie.CHILDREN:
                    result += 1.5;
                    if (daysRented > 3)
                        result += (daysRented - 3) * 1.5;
                    break;
            }
            return result;
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            if ((this.PriceCode == NEW_RELEASE) && (daysRented > 1))
                return 2;
            else
                return 1;
        }
    }
}
