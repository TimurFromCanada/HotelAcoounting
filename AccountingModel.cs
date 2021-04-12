using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAccounting
{
    //создайте класс AccountingModel здесь
    public class AccountingModel : ModelBase
    {
        private double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0) throw new ArgumentException();
                price = value;
                total = price * nightsCount * (1 - discount / 100);
                Notify(nameof(Price));
                Notify(nameof(Total));
            }
        }

        private int nightsCount;
        public int NightsCount
        {
            get
            {
                return nightsCount;
            }
            set
            {
                if (value <= 0) throw new ArgumentException();
                nightsCount = value;
                total = price * nightsCount * (1 - discount / 100);
                Notify(nameof(NightsCount));
                Notify(nameof(Total));
            }
        }

        private double discount;
        public double Discount
        {
            get
            {
                return discount;
            }
            set
            {
                if (value > 100)
                    throw new ArgumentException();
                discount = value;
                total = price * nightsCount * (1 - discount / 100);
                Notify(nameof(Discount));
                Notify(nameof(Total));
            }
        }

        private double total;
        public double Total
        {
            get { return total; }
            set
            {
                if (value < 0)
                    throw new ArgumentException();
                total = value;
                discount = 100 - (total * 100 / (price * nightsCount));
                Notify(nameof(Total));
                Notify(nameof(Discount));
            }
        }
    }
}

