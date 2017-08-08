using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void goButton_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(urlText.Text);
        }

        //Event listener on click of decrypt button
        private void decryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Creating an instance of encryption/decryption service
                EncryptionServiceReference.ServiceClient encryptionService = new EncryptionServiceReference.ServiceClient();
                //Calling the decrypt method of the service on click of decrypt button
                string decrypted = encryptionService.Decrypt(DecryptText.Text);
                //Assigning the decrypted string to the label 
                DecryptedString.Text = decrypted.ToString();
            }
            //Catching the exception when an invalid String is entered 
            catch (Exception excep)
            {
                DecryptedString.Text = "Please enter a valid string";
            }
            
        }

        //Event listener on clic of encrypt button
        private void encryptButton_Click(object sender, EventArgs e)
        {
            //Creating an instance of encryption/decryption service
            EncryptionServiceReference.ServiceClient encryptionService = new EncryptionServiceReference.ServiceClient();
            //Calling the encrypt method of the service on click of encrypt button
            string encrypted = encryptionService.Encrypt(encryptText.Text);
            //Assigning the encrypted string to the label 
            encryptedText.Text = encrypted.ToString();
            //Assigning the encrypted string to the decrypt textbox 
            DecryptText.Text = encrypted.ToString();
        }

        //Event listener on click of Get Quotes button
        private void GetQuotesButton_Click(object sender, EventArgs e)
        {
            //Creating an instance of StockQuote service
            StockQuoteService.ServiceClient getStockService = new StockQuoteService.ServiceClient();
            //Getting the quote info from the service
            String quoteInfo = getStockService.getStockquote(CompanyText.Text);
            //Setting the label to the returned info
            QuoteInfoText.Text = quoteInfo;
        }

    }
}
