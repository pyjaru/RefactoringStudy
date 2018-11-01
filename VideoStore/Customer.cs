using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStore
{
    class Customer
    {
        private string _name;
        private List<Rental> _rentals;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Rental> Rentals
        {
            get { return _rentals; }
            set { _rentals = value; }
        }

        public void AddRental(Rental arg)
        {
            _rentals.Add(arg);
        }

        public string Statement()
        {
            double totalAmount = 0;
            int frequentRenterPoint = 0;
            var rentals = _rentals.GetEnumerator();
            string result = $"Rental Record for {this.Name}\n";

            while (rentals.MoveNext())
            {
                Rental each = rentals.Current;

                //포인트(frequent, renter oints)추가
                frequentRenterPoint++;
                //최신(new release)을 이틀 이상 대여하는 경우 추가 포이늩 제공
                if ((each.Movie.PriceCode == Movie.NEW_RELEASE) && (each.DaysRented > 1))
                    frequentRenterPoint++;

                //이 대여에 대한 요금 계산 결과 표시
                result += $"\t{each.Movie.Title}\t{each.GetCharge()}\n";
                totalAmount += each.GetCharge();
            }

            // 풋터(footer)추가
            result += $"Amount owed is {totalAmount}\n";
            result += $"You earned {frequentRenterPoint} frequent reter points";
            return result;
        }
    }
}
