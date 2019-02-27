using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ShoppingCartPrompt
{
    class Item
    {
        private string _name;
        private float _price;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public float Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public Item(string Name)
        {
            _name = Name;
        }

        public void LoadItemPrice()
        {
            Catalog c = new Catalog();

            try { 
                _price = c.ShoppingCatalog.First(n => n._name.ToLower() == this._name.ToLower())._price;
            }
            catch (InvalidOperationException e)
            {
                _price = 0;
            }
        }

    }
}
