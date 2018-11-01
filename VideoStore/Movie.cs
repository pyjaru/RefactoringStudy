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
        private Price _price;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public int PriceCode
        {
            get { return _price.PriceCode; }
            set
            {
                switch(value)
                {
                    case REGULAR:
                        _price = new RegularPrice();
                        break;
                    case CHILDREN:
                        _price = new ChildrenPrice(); 
                        break;
                    case NEW_RELEASE:
                        _price = new NewReleasePrice();
                        break;
                    default:
                        throw new ArgumentException("Incorrect Price Code");
                }
            }
        }

        public Movie(string title, int priceCode)
        {
            _title = title;
            PriceCode = priceCode;
        }

        public double GetCharge(int daysRented)
        {
            return _price.GetCharge(daysRented);
        }

        public int GetFrequentRenterPoints(int daysRented)
        {
            return _price.GetFrequentRenterPoints(daysRented);
        }
    }
}
