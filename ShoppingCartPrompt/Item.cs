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
        private double _price;
        private int _offer;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int Offer
        {
            get { return _offer; }
            set { _offer = value; }
        }

        [JsonConstructor]
        public Item(string Name)
        {
            _name = Name;
        }

        public Item(string nName,double nPrice,int nOffer)
        {
            _name = nName;
            _price = nPrice;
            _offer = nOffer;
        }

        public void LoadItemInformation()
        {
            Catalog c = new Catalog();

            try { 
                _price = c.ShoppingCatalog.First(n => n._name.ToLower() == this._name.ToLower())._price;
                _offer = c.ShoppingCatalog.First(n => n._name.ToLower() == this._name.ToLower())._offer;                
            }
            catch (InvalidOperationException e)
            {
                _price = 0;
                _offer = 0;
            }
        }

    }
}
