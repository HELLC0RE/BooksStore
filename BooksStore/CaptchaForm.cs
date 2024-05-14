using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksStore
{
    public partial class CaptchaForm : Form
    {
        private Bitmap captchaImage;
        private string expectedCaptchaText;
        public CaptchaForm(Bitmap captchaImage, string captchaText)
        {
            InitializeComponent();
            this.captchaImage = captchaImage;
            this.expectedCaptchaText = captchaText;
            pictureBox1.Image = captchaImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string enteredText = textBox1.Text.Trim();

            if (enteredText.Equals(expectedCaptchaText, StringComparison.OrdinalIgnoreCase))
            {
                // Капча введена верно
                MessageBox.Show("Капча пройдена успешно!");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                // Капча введена неверно
                MessageBox.Show("Неверный код капчи. Пожалуйста, попробуйте еще раз.");
                textBox1.Clear();
            }
        }
    }
}
