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
        
        public Cart()
        {
            _contents = new List<Item>();
        }

        public void addContents(string input)
        {
            List<String> raw = input.Split(',').ToList();

            foreach (string i in raw)
            {
                Item n = new Item(i);
                n.LoadItemInformation();

                _contents.Add(n);
            }
        }

        public void clearContents()
        {
            _contents.Clear();
        }

        public string printContents()
        {
            string p = "";

            foreach (Item i in _contents)
            {
                p += i.Name + " - [" + i.Price.ToString() + "]" + System.Environment.NewLine; 
            }

            p += "Order total - " + getTotal().ToString();

            return p;
        }

        private void sortContents()
        {
            _contents.Sort((a, b) => (a.Price.CompareTo(b.Price)));
        }

        private void processOffers()
        {
            int bogoCount = 0;
            int threeForTwoCount = 0;

            List<Item> bogo = new List<Item>();
            List<Item> threeForTwo = new List<Item>();
            List<Item> discounts = new List<Item>();

            bogo = _contents.Where(i => i.Offer == 1).ToList();
            bogo.Sort((a, b) => (a.Price.CompareTo(b.Price)));

            bogoCount = bogo.Count / 2;

            for (int i = 0; i < bogoCount; i++)
            {
                Item n = new Item("BOGO Discount - " + bogo[i].Name, -(bogo[i].Price), 0);

                discounts.Add(n);
            }

            threeForTwo = _contents.Where(i => i.Offer == 2).ToList();
            threeForTwo.Sort((a, b) => (a.Price.CompareTo(b.Price)));

            threeForTwoCount = threeForTwo.Count / 3;

            for (int i = 0; i < threeForTwoCount; i++)
            {
                Item n = new Item("Three For Two Discount - " + threeForTwo[i].Name, -(threeForTwo[i].Price), 0);

                discounts.Add(n);
            }

            _contents.AddRange(discounts);

        }


        public double getTotal()
        {
            sortContents();
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
