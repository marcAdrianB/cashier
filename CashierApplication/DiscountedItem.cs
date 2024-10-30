using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ItemNamespace
{
    public class DiscountedItem : Item
    {
        private double item_discount;
        private double discounted_price;
        private double payment_amount;
        private double change;

        public DiscountedItem(string name, double price, int quantity, double discount) 
            : base(name, price, quantity)
        {
            this.item_name = name;
            this.item_price = price;
            this.item_quantity = quantity;
            this.item_discount = discount;

        }

        public override double getTotalPrice()
        {
            discounted_price = (item_price) - item_price * item_discount;
            double total_price = discounted_price * item_quantity;
            return total_price; 
        }

        public void setPayment(double amount)
        {
            payment_amount = amount;
        }

        public double getChange()
        {
            double total = getTotalPrice();
            double change = payment_amount - total;
            return change;
        }
    }

}
