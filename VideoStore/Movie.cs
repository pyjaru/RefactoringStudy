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
    }
}
