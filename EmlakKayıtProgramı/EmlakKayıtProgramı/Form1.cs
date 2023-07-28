namespace EmlakKayıtProgramı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="nuri@"&&textBox2.Text=="123")
            {
                Form2 emlakkayit = new Form2();
                emlakkayit.Show();
                this.Hide();

            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus(); 
                MessageBox.Show("kulanıcı adı veya şifre yanlış");
            }


        }
    }
}