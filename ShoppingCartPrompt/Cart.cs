using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCartPrompt
{
    class Cart
    {
        private List<Item> _contents;

        public List<Item> CartContents
        {
            get { return _contents; }
            set { _contents = value;  }
        }
        
        public Cart(string input)
        {
            _contents = new List<Item>();
            List<String> raw = input.Split(',').ToList();

            foreach (string i in raw)
            {
                Item n = new Item(i);
                n.LoadItemInformation();

                _contents.Add(n);
            }
        }

        public void processOffers()
        {
            int bogoCount = 0;
            int threeForTwoCount = 0;

            List<Item> discounts = new List<Item>();

            foreach (Item i in _contents) {
                if(i.Offer == 1)
                {
                    if (bogoCount < 1)
                    {
                        bogoCount++;
                    }
                    else if (bogoCount == 1)
                    {
                        Item n = new Item("Bogo Discount", -i.Price, 0);
                        discounts.Add(n);

                        bogoCount = 0;
                    }
                }
                else if (i.Offer == 2)
                {
                    if (threeForTwoCount < 2)
                    {
                        threeForTwoCount++;
                    }
                    else if (threeForTwoCount == 2)
                    {
                        Item n = new Item("Three For Two Discount", -i.Price, 0);
                        discounts.Add(n);

                        threeForTwoCount = 0;
                    }
                }

            }

            _contents.AddRange(discounts);
        }

        public double getTotal()
        {
           processOffers();

            double total = 0;

            foreach (Item i in _contents)
            {
                total += i.Price;
            }

            return total;
        }

    }
}
