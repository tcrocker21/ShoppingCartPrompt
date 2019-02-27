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
                n.LoadItemPrice();

                _contents.Add(n);
            }
        }

        public float getTotal()
        {
            float total = 0;

            foreach (Item i in _contents)
            {
                total += i.Price;
            }

            return total;
        }

    }
}
