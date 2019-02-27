using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShoppingCartPrompt
{    

    class Catalog
    {
        private List<Item> _catalog;

        public List<Item> ShoppingCatalog
        {
            get { return _catalog; }
            set { _catalog = value; }
        }

        public Catalog()
        {
            _catalog = GetCatalog();
        }

        private List<Item> GetCatalog()
        {
            List<Item> catalog;

            using (StreamReader rdr = new StreamReader(@"../../catalog.json"))
            {
                string json = rdr.ReadToEnd();
                catalog = JsonConvert.DeserializeObject<List<Item>>(json);
            }

            return catalog;
        }


    }
}
