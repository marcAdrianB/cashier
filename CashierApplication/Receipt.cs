using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashierApplication
{
    public partial class Receipt : Form
    {
        public Receipt(string nameT, int quantityT, 
            double discountT, string totalPriceT, string changeT)
        {




            item.Text = $"{nameT}";
            quantity.Text = $"{quantityT.ToString()}";
            discount.Text = $"{discountT.ToString()}%";
            totalPrice.Text = $"{totalPriceT}";
            change.Text = $"{changeT}";


            InitializeComponent();
        }
    }
}
