using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        int DropDownWidth(ComboBox myCombo)
        {
            int maxWidth = 0;
            int temp = 0;
            Label label1 = new Label();

            foreach (var obj in myCombo.Items)
            {
                label1.Text = obj.ToString();
                temp = label1.PreferredWidth;
                if (temp > maxWidth)
                {
                    maxWidth = temp;
                }
            }
            label1.Dispose();
            return maxWidth;
        }

// Bmi Foksiyonu
        double BMI(double w, double height)
        {
            double h = height / 100;
            double h2 = h * h;
            double bmı = w / h2;

            return bmı;

        }

//Body Type Fonksiyonu
        string bodytype(double bmı)
        {
            string body = "";
            if (radioButton1.Checked)
            {


                if (bmı < 20.7)
                {
                    body = "Weak";
                }
                else if (bmı >= 20.7 && bmı <= 26.4)
                {
                    body = "Normal";
                }
                else if (bmı >= 26.5 && bmı <= 27.8)
                {
                    body = "Light Fat";
                }
                else if (bmı >= 27.9 && bmı <= 31.1)
                {
                    body = "Fat";
                }
                else if (bmı >= 31.2 && bmı <= 45.5)
                {
                    body = "Obese and Extreme Fat";
                }
                else if (bmı > 45.6)
                {
                    body = "Very Risky Obese";

                }
            }

            if (radioButton2.Checked)
            {


                if (bmı < 19.1)
                {
                    body = "Weak";
                }
                if (bmı >= 19.1 && bmı <= 25.8)
                {
                    body = "Normal";
                }
                if (bmı >= 25.9 && bmı <= 27.3)
                {
                    body = "Light Fat";
                }
                if (bmı >= 27.4 && bmı <= 32.2)
                {
                    body = "Fat";
                }
                if (bmı >= 32.3 && bmı <= 44.8)
                {
                    body = "Obese and Extreme Fat";
                }
                if (bmı > 48.8)
                {
                    body = "Very Risky Obese";

                }

            }

            return body;
        }

// Cinsiyet Fonksiyonu
        int SEX()
        {
            int sex;
            string Sex2;
            if (radioButton1.Checked)
            {
                sex = 0;
                
            }
            else
            {
                sex = 1;
                
            }
            return sex;
            
        }

// Calori fonksiyonu
        double CAL(int sex, double weight, double height, int age)
        {

            double bmh;
            if (sex == 0)
            {
                bmh = 66 + (13.75 * weight) + (5 * height) - (6.8 * age);
            }
            else
            {
                bmh = 655 + (9.6 * weight) + (1.7 * height) - (4.7 * age);
            }

            return bmh;

        }

//Egzersiz fonksiyonu:
        double Exercise(double bmh)
        {
            double calori = 0;
            if (comboBox3.SelectedItem == "Sedentary - Little Or No Exercise")
            {
                calori = bmh * 1.2;
            }
            if (comboBox3.SelectedItem == "Lighly Active - Exercise/Sports 1-3 times/week")
            {
                calori = bmh * 1.375;
            }
            if (comboBox3.SelectedItem == "Moderatetely Active - Exercise/Sports 3-5 times/week")
            {
                calori = bmh * 1.55;
            }
            if (comboBox3.SelectedItem == "Very Active -Exercise/Sports 6-7 times/week")
            {
                calori = bmh * 1.725;
            }

            return calori;

        }

//Hedef Fonksiyonu
        double goal(double calori)
        {
            if (comboBox1.SelectedItem == "-Gaining weight")
            {
                calori = calori + 500;
            }
            if (comboBox1.SelectedItem == "-Lose weight")
            {
                calori = calori - 500;
            }
            if (comboBox1.SelectedItem == "-Gaining weight")
            {
                calori = calori;
            }

            return calori;


        }



        public Form1()
        {
            InitializeComponent();

 //Combo Box Item
            #region İtems
            comboBox1.Items.Add("-Gaining weight");
            comboBox1.Items.Add("-Lose weight");
            comboBox1.Items.Add("-Protect weight");
            comboBox2.Items.Add("-High Carb(60/25/15)");
            comboBox2.Items.Add("-Modarate(50/30/20)");
            comboBox2.Items.Add("-Zone Diet(40/30/30)");
            comboBox2.Items.Add("-Low Carb(25/45/30)");
            comboBox3.Items.Add("Sedentary - Little Or No Exercise");
            comboBox3.Items.Add("Lighly Active - Exercise/Sports 1-3 times/week");
            comboBox3.Items.Add("Moderatetely Active - Exercise/Sports 3-5 times/week");
            comboBox3.Items.Add("Very Active -Exercise/Sports 6-7 times/week");

            comboBox3.DropDownWidth = DropDownWidth(comboBox3);


            #endregion
 // Default Degerler
            #region Defaults

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            radioButton1.Checked=true;

            #endregion
        }

//Reset Functions    
        #region Reset
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.ResetText();
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.ResetText();
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.ResetText();
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.ResetText();
        }
        #endregion

//All Varaibles
        #region Varaibles
        internal static string name;
        internal static string Sex2;
        internal static double protein = 0, carb = 0, fat = 0;
        internal static double calori;
        internal static double CarbRate, ProtRate, FatRate;
        internal static int sex;
        internal static int Age;
        internal static double Weight;
        internal static double Height;
        internal static double Bmi;
        internal static string body;
  

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
         
            
            name = textBox1.Text;
            Age = Convert.ToInt32(textBox2.Text);
            Height = Convert.ToDouble(textBox3.Text);
            Weight = Convert.ToDouble(textBox4.Text);
            Bmi = BMI(Weight, Height);
            body = bodytype(Bmi);
            sex = SEX();
// Sex Name
            #region
            if (sex == 0)
            {
                Sex2 = "Male";
            }
            if( sex == 1)
            {
                Sex2 = "Female";
            }
            #endregion

            calori = CAL(sex, Weight, Height, Age);
            calori = Exercise(calori);
            calori = goal(calori);
// diet type
            #region DietType
            if (comboBox2.SelectedItem == "-High Carb(60/25/15)")
            {
                CarbRate = 0.6;
                ProtRate = 0.25;
                FatRate = 0.15;
                protein = (calori * ProtRate) / 4;
                carb = (calori * CarbRate) / 4;
                fat = (calori * FatRate) / 9;

            }
            if (comboBox2.SelectedItem == "-Modarate(50/30/20)")
            {
                CarbRate = 0.5;
                ProtRate = 0.3;
                FatRate = 0.2;
                protein = (calori * ProtRate) / 4;
                carb = (calori * CarbRate) / 4;
                fat = (calori * FatRate) / 9;

            }
            if (comboBox2.SelectedItem == "-Zone Diet(40/30/30)")
            {
                CarbRate = 0.4;
                ProtRate = 0.3;
                FatRate = 0.3;
                protein = (calori * ProtRate) / 4;
                carb = (calori * CarbRate) / 4;
                fat = (calori * FatRate) / 9;

            }
            if (comboBox2.SelectedItem == "-Low Carb(25/45/30)")
            {
                CarbRate = 0.25;
                ProtRate = 0.45;
                FatRate = 0.30;
                protein = (calori * ProtRate) / 4;
                carb = (calori * CarbRate) / 4;
                fat = (calori * FatRate) / 9;

            }

            #endregion

           

            Form2 frm2 = new Form2();
            this.Visible = false;
            frm2.ShowDialog();
            this.Visible = true;



        }







    }
}
