using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStore
{
    class Rental
    {
        private Movie _movie;
        private int _daysRented;

        public Movie Movie
        {
            get { return _movie; }
        }

        public int DaysRented
        {
            get { return _daysRented; }
        }

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }

        public double GetCharge()
        {
            double result = 0;
            switch (this.Movie.PriceCode)
            {
                case Movie.REGULAR:
                    result += 2;
                    if (this.DaysRented > 2)
                        result += (this.DaysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    result += this.DaysRented * 3;
                    break;
                case Movie.CHILDREN:
                    result += 1.5;
                    if (this.DaysRented > 3)
                        result += (this.DaysRented - 3) * 1.5;
                    break;
            }

            return result;
        }
    }
}
