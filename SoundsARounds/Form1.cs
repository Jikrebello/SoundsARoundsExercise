using System;
using System.Windows.Forms;

namespace SoundsARounds
{
    public partial class Form1 : Form
    {
        // Fields
        private const string CURRENCEY_SYMBOL = "R ";
        private int quantityTape;
        private int quantityRecord;
        private int quantityCD;

        private float tapePrice;
        private float recordPrice;
        private float cdPrice;

        private float tapeSubtotal;
        private float recordSubtotal;
        private float cdSubtotal;

        private float subTotal;
        private float subTotalDiscount;
        private float discountRate;


        // Constructor        
        public Form1()
        {
            InitializeComponent();
        }

        // Methods
        private void Form1_Load(object sender, EventArgs e)
        {
            tapePrice = 9.99f;
            recordPrice = 2.99f;
            cdPrice = 15.99f;
            discountRate = 0.90f;
            Clear();
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            quantityTape = Convert.ToInt32(NumTapeQuantity.Text);
            quantityRecord = Convert.ToInt32(NumRecordQuantity.Text);
            quantityCD = Convert.ToInt32(NumCDQuantity.Text);

            tapeSubtotal = quantityTape * tapePrice;
            recordSubtotal = quantityRecord * recordPrice;
            cdSubtotal = quantityCD * cdPrice;

            LblTapeTotal.Text = CURRENCEY_SYMBOL + tapeSubtotal.ToString();
            LblRecordTotal.Text = CURRENCEY_SYMBOL + recordSubtotal.ToString();
            LblCDTotal.Text = CURRENCEY_SYMBOL + cdSubtotal.ToString();

            subTotal = tapeSubtotal + recordSubtotal + cdSubtotal;

            LblSubtotal.Text = CURRENCEY_SYMBOL + subTotal.ToString();

            if (CheckDiscount.Checked)
            {
                subTotalDiscount = subTotal * 0.10f;
                LblDiscount.Text = CURRENCEY_SYMBOL + Math.Round(subTotalDiscount, 2).ToString();

                subTotal *= discountRate;
                LblTotal.Text = CURRENCEY_SYMBOL + Math.Round(subTotal, 2).ToString();
            }
            else
            {
                LblDiscount.Text = "- - - -";
                LblTotal.Text = CURRENCEY_SYMBOL + Math.Round(subTotal, 2).ToString();
            }

        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            quantityTape = 0;
            quantityRecord = 0;
            quantityCD = 0;
            tapeSubtotal = 0;
            recordSubtotal = 0;
            cdSubtotal = 0;
            subTotal = 0;

            LblTapeTotal.Text = "- - - -";
            LblRecordTotal.Text = "- - - -";
            LblCDTotal.Text = "- - - -";
            LblDiscount.Text = "- - - -";
            LblSubtotal.Text = "- - - -";
            LblTotal.Text = "- - - -";

            if (CheckDiscount.Checked)
            {
                CheckDiscount.Checked = false;
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
