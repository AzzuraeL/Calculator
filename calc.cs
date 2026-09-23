using System;
using System.Windows.Forms;
using System.Drawing;

public class KalkulatorForm : Form
{
    private TextBox textBox1, textBox2, textBox3;
    private Label label1, label2, label3;
    private Button buttonTambah, buttonKurang, buttonKali, buttonBagi, buttonClear;

    public KalkulatorForm()
    {
        this.Text = "Form1";
        this.Size = new Size(350, 450);

        label1 = new Label() { Text = "Nilai 1 :", Location = new Point(40, 50), AutoSize = true };
        textBox1 = new TextBox() { Location = new Point(120, 48), Width = 150 };

        label2 = new Label() { Text = "Nilai 2 :", Location = new Point(40, 100), AutoSize = true };
        textBox2 = new TextBox() { Location = new Point(120, 98), Width = 150 };

        label3 = new Label() { Text = "Hasil :", Location = new Point(40, 150), AutoSize = true };
        textBox3 = new TextBox() { Location = new Point(120, 148), Width = 150 };
        textBox3.ReadOnly = true;

        buttonTambah = new Button() { Text = "+", Location = new Point(70, 220), Size = new Size(60, 50) };
        buttonKali = new Button() { Text = "*", Location = new Point(140, 220), Size = new Size(60, 50) };

        buttonClear = new Button() { Text = "C", Location = new Point(210, 220), Size = new Size(60, 110) };

        buttonKurang = new Button() { Text = "-", Location = new Point(70, 280), Size = new Size(60, 50) };
        buttonBagi = new Button() { Text = "/", Location = new Point(140, 280), Size = new Size(60, 50) };


        buttonTambah.Click += new EventHandler(buttonTambah_Click);
        buttonKurang.Click += new EventHandler(buttonKurang_Click);
        buttonKali.Click += new EventHandler(buttonKali_Click);
        buttonBagi.Click += new EventHandler(buttonBagi_Click);
        buttonClear.Click += new EventHandler(buttonClear_Click);

        this.Controls.Add(label1);
        this.Controls.Add(textBox1);
        this.Controls.Add(label2);
        this.Controls.Add(textBox2);
        this.Controls.Add(label3);
        this.Controls.Add(textBox3);
        this.Controls.Add(buttonTambah);
        this.Controls.Add(buttonKurang);
        this.Controls.Add(buttonKali);
        this.Controls.Add(buttonBagi);
        this.Controls.Add(buttonClear);
    }


    private void buttonTambah_Click(object sender, EventArgs e)
    {
        Hitung('+');
    }

    private void buttonKurang_Click(object sender, EventArgs e)
    {
        Hitung('-');
    }

    private void buttonKali_Click(object sender, EventArgs e)
    {
        Hitung('*');
    }

    private void buttonBagi_Click(object sender, EventArgs e)
    {
        Hitung('/');
    }

    private void Hitung(char operasi)
    {
        try
        {
            double nilai1 = double.Parse(textBox1.Text);
            double nilai2 = double.Parse(textBox2.Text);
            double hasil = 0;

            switch (operasi)
            {
                case '+': hasil = nilai1 + nilai2; break;
                case '-': hasil = nilai1 - nilai2; break;
                case '*': hasil = nilai1 * nilai2; break;
                case '/':
                    if (nilai2 == 0)
                    {
                        MessageBox.Show("Tidak bisa membagi dengan nol!", "Error");
                        return;
                    }
                    hasil = nilai1 / nilai2;
                    break;
            }

            textBox3.Text = hasil.ToString();
        }
        catch (FormatException)
        {
            MessageBox.Show("Harap masukkan angka yang valid.", "Input Error");
        }
    }


    private void buttonClear_Click(object sender, EventArgs e)
    {
        textBox1.Text = "";
        textBox2.Text = "";
        textBox3.Text = "";
        textBox1.Focus();
    }

    [STAThread]
    public static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new KalkulatorForm());
    }
}