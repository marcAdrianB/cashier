using ItemNamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CashierApplication
{
    public partial class frmPurchaseDiscountedItem : Form
    {
        string missingText1 = "Please fill this up.";
        string missingText2 = "Missing";
        string changeformattedValue;
        string formattedValue;
        double discountT;
        public frmPurchaseDiscountedItem()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void placeHolder(TextBox textBox)
        {
            AddPlaceHolder(textBox);
            textBox.Enter += (s, e) => RemovePlaceholder(textBox);
        }
        private void placeHolder2(TextBox textBox)
        {
            AddPlaceHolder2(textBox);
            textBox.Enter += (s, e) => RemovePlaceholder(textBox);
        }
        private void AddPlaceHolder(TextBox textBox)
        {
            textBox.Font = new Font(textBox.Font, FontStyle.Italic);
            textBox.ForeColor = Color.Red;
            textBox.Text = missingText1;
        }
        private void AddPlaceHolder2(TextBox textBox)
        {
            textBox.Font = new Font(textBox.Font, FontStyle.Italic);
            textBox.ForeColor = Color.Red;
            textBox.Text = missingText2;
        }
        private void RemovePlaceholder(TextBox textBox)
        {
            textBox.Text = "";
            textBox.ForeColor = Color.Black;
            textBox.Font = new Font(textBox.Font, FontStyle.Regular);
        }

        


        private void compute_Click(object sender, EventArgs e)
        {
            try 
            {
                bool notIncomplete = true;

                if (itemName.Text == "" || itemName.Text == " " || itemName.Text == missingText1)
                {
                    placeHolder(itemName);
                    notIncomplete = false;
                }
                if (price.Text == "" || price.Text == " " || price.Text == missingText1)
                {
                    placeHolder(price);
                    notIncomplete = false;
                }
                if (discount.Text == "" || discount.Text == " " || discount.Text == missingText2)
                {
                    placeHolder2(discount);
                    notIncomplete = false;
                }
                if (quantity.Text == "" || quantity.Text == " " || quantity.Text == missingText2)
                {
                    placeHolder2(quantity);
                    notIncomplete = false;
                }
                else if (notIncomplete)
                {
                    
                    double priceT = double.Parse(price.Text);
                    discountT = double.Parse(discount.Text)*0.01;
                    int quantityT = int.Parse(quantity.Text);
                    string name = itemName.Text;
                    
                    if (discountT > 1 || discountT < 0)
                    {
                        MessageBox.Show("Discount price cannot exceed 100%\nnor go below 0%", "Invalid Discount", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (discountT < 1 && !(discountT < 0))
                    {
                        DiscountedItem d = new DiscountedItem(name, priceT, quantityT, discountT);
                        formattedValue = String.Format("{0:F2}", d.getTotalPrice());
                        totalAmount.Text = $"PHP {formattedValue}";
                    }
                    

                }

                

            } 
            catch (FormatException) 
            {
                MessageBox.Show("Please only enter valid inputs!", "Invalid Input", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void submit_Click(object sender, EventArgs e)
        {
            try
            {
                bool notIncomplete = true;

                if (paymentReceived.Text == "" || paymentReceived.Text == " " || paymentReceived.Text == missingText1)
                {
                    placeHolder(paymentReceived);
                    notIncomplete = false;
                }
                else if (notIncomplete)
                {
                    double priceT = double.Parse(price.Text);
                    discountT = double.Parse(discount.Text) * 0.01;
                    int quantityT = int.Parse(quantity.Text);
                    string name = itemName.Text;

                    double payment = double.Parse(paymentReceived.Text);

                    DiscountedItem d = new DiscountedItem(name, priceT, quantityT, discountT);
                    d.setPayment(payment);

                    if (payment < d.getTotalPrice())
                    {
                        MessageBox.Show("Please pay a sufficient amount.", "Insufficient Payment", MessageBoxButtons.OK, 
                            MessageBoxIcon.Exclamation);
                    }
                    else if (payment >= d.getTotalPrice())
                    {
                        changeformattedValue = String.Format("{0:F2}", d.getChange());
                        change.Text = $"PHP {changeformattedValue}";
                    }
                }
            }
            catch (FormatException)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            itemName.Clear();
            price.Clear();
            discount.Clear();
            quantity.Clear();
            paymentReceived.Clear();
            totalAmount.Text = "PHP 0.00";
            change.Text = "PHP 0.00";
        }
    }
}
