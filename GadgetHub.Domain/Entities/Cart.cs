using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GadgetHub.Domain.Entities
{
    public class CartLine
    {
        public Gadget Gadget { get; set; }
        public int Quantity { get; set; }
    }

    // Cart Operations
    public class Cart
    {
        // Cart List
        private List<CartLine> lineCollection = new List<CartLine>();

        // Cart Content
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        // Add item and quantity to cart
        public void AddItem(Gadget myGadget, int myQuantity)
        {
            CartLine line = lineCollection
                            .Where(g => g.Gadget.GadgetID == myGadget.GadgetID)
                            .FirstOrDefault();

            // Add new item to cart
            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Gadget = myGadget,
                    Quantity = myQuantity
                });
            }

            // Adjust quantity of cart items
            else
            {
                line.Quantity = myQuantity;
            }
        }

        // Remove product
        public void RemoveLine(Gadget myGadget)
        {
            lineCollection.RemoveAll(line => line.Gadget.GadgetID == myGadget.GadgetID);
        }

        // Total Cost of Cart
        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e  => e.Gadget.GadgetPrice * e.Quantity);        
        }

        // Empty Cart
        public void Clear()
        {
            lineCollection.Clear();
        }
    }
}
