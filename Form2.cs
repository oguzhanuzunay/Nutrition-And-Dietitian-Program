using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApplication4
{
    public partial class Form2 : Form
    {
        #region Guncel Varaibles

        double G_kal = 0;
        double G_Prot = 0;
        double G_Carb = 0;
        double G_Fat = 0;
        int Check = 0;
        int gram = 100;



        #endregion

        public Form2()
        {
           
            
            InitializeComponent();
            comboBox3.Items.Add("Morning");
            comboBox3.Items.Add("1st Snack");
            comboBox3.Items.Add("Midday");
            comboBox3.Items.Add("2st Snack");
            comboBox3.Items.Add("Evening");
            comboBox3.SelectedIndex = 0;
            textBox2.Text = ("100");
            comboBox1.SelectedItem = 0;
            Food();
            show();
            

            Form1 frm1 = new Form1();


            #region First Output

            textBox1.Text = "Name And Surname : " + Form1.name + Environment.NewLine +
                            "Sex : " + Form1.Sex2 + "     " + "Age : " + Form1.Age + Environment.NewLine +
                            "Weight : " + Form1.Weight + " KG      " + "Height : " + Form1.Height + " Cm " + Environment.NewLine +
                            "Body Type : " + Form1.body + Environment.NewLine + Environment.NewLine +
                            "Diet List : " + Environment.NewLine +
                            "Calori : " + Convert.ToInt32(Form1.calori) + "\t" +
                            "Protein : " + Convert.ToInt32(Form1.protein) + "\t" +
                            "Carb : " + Convert.ToInt32(Form1.carb) + "\t" +
                            "Fat : " + Convert.ToInt32(Form1.fat) + "  " +Environment.NewLine ;


            #endregion

        }

        #region Show()

        void show()
        {
            label9.Text = Convert.ToInt32(Form1.calori) + "/" + (G_kal / 100) * gram;
            label15.Text= Convert.ToInt32(Form1.protein) + "/" + (G_Prot / 100) * gram;
            label16.Text = Convert.ToInt32(Form1.carb) + "/" + (G_Carb / 100) * gram;
            label17.Text= Convert.ToInt32(Form1.fat) + "/" + (G_Fat / 100) * gram;
            if (G_kal >= Form1.calori)
            {
                label9.ForeColor = Color.Red;
            }
            if (G_Prot >= Form1.protein)
            {
                label15.ForeColor = Color.Red;
            }
            if (G_Carb >= Form1.carb)
            {
                label16.ForeColor = Color.Red;
            }
            if (G_Fat >= Form1.fat)
            {
                label17.ForeColor = Color.Red;
            }

        }

        #endregion


        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-UO8AT4Q\\SQLEXPRESS;Initial Catalog=Nutritions;Integrated Security=True");

        private void Food()
        {
            comboBox1.Items.Clear();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from Nutrients", connect);
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                comboBox1.Items.Add(read["Name"].ToString());
                label10.Text = read["Calori"].ToString();
                label11.Text = read["Protein"].ToString();
                label12.Text = read["Carb"].ToString();
                label13.Text = read["Fat"].ToString();

                

            }
            connect.Close();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            this.Visible = false;
            frm3.ShowDialog();
            this.Visible = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            gram = Convert.ToInt32(textBox2.Text);

//if else Statment For ComboBox3.

            #region Morning
            if (comboBox3.SelectedItem== "Morning")
            {
                if(Check == 1){
                    textBox1.Text = textBox1.Text +"   "+ Environment.NewLine +
                        comboBox1.Text + "         " + textBox2.Text + " Gr" + Environment.NewLine;
                     
                }
                else
                {
                    textBox1.Text = textBox1.Text +  Environment.NewLine + comboBox3.Text + "-------------------" +
                                    Environment.NewLine + comboBox1.Text + "         " + textBox2.Text + " Gr" + Environment.NewLine; ;
                    Check = 1;
                }

                G_kal =( (G_kal / 100) * gram) + Convert.ToInt32(label10.Text);
                G_Prot =( (G_Prot / 100) * gram) + Convert.ToInt32(label11.Text);
                G_Carb =( (G_Carb / 100) * gram) + Convert.ToInt32(label12.Text);
                G_Fat = ( (G_Fat / 100) * gram) + Convert.ToInt32(label13.Text);
                show();
            }
            #endregion

            #region 1st Snack
            if (comboBox3.SelectedItem == "1st Snack")
            {
                if (Check == 2)
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine +
                        comboBox1.Text + "         " + textBox2.Text + " Gr" + Environment.NewLine;

                }
                else
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine + comboBox3.Text + "-------------------" +
                                    Environment.NewLine + comboBox1.Text + "         " + textBox2.Text + " Gr" + Environment.NewLine; ;
                    Check = 2;
                }
                G_kal = ((G_kal / 100) * gram) + Convert.ToInt32(label10.Text);
                G_Prot = ((G_Prot / 100) * gram) + Convert.ToInt32(label11.Text);
                G_Carb = ((G_Carb / 100) * gram) + Convert.ToInt32(label12.Text);
                G_Fat = ((G_Fat / 100) * gram) + Convert.ToInt32(label13.Text);
                show();
            }
            #endregion

            #region Midday
            if (comboBox3.SelectedItem == "Midday")
            {
                if (Check == 3)
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine +
                        comboBox1.Text + "         " + textBox2.Text + " Gr" + Environment.NewLine;

                }
                else
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine + comboBox3.Text + "-------------------" +
                                    Environment.NewLine + comboBox1.Text + "         " + textBox2.Text + " Gr" + Environment.NewLine; ;
                    Check = 3;
                }

                G_kal = ((G_kal / 100) * gram) + Convert.ToInt32(label10.Text);
                G_Prot = ((G_Prot / 100) * gram) + Convert.ToInt32(label11.Text);
                G_Carb = ((G_Carb / 100) * gram) + Convert.ToInt32(label12.Text);
                G_Fat = ((G_Fat / 100) * gram) + Convert.ToInt32(label13.Text);
                show();
            }
            #endregion

            #region 2st Snack
            if (comboBox3.SelectedItem == "2st Snack")
            {
                if (Check == 4)
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine +
                        comboBox1.Text + "         " + textBox2.Text + " Gr" + Environment.NewLine;

                }
                else
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine + comboBox3.Text + "-------------------" +
                                    Environment.NewLine + comboBox1.Text + "         " + textBox2.Text + " Gr" + Environment.NewLine; ;
                    Check = 4;
                }

                G_kal = ((G_kal / 100) * gram) + Convert.ToInt32(label10.Text);
                G_Prot = ((G_Prot / 100) * gram) + Convert.ToInt32(label11.Text);
                G_Carb = ((G_Carb / 100) * gram) + Convert.ToInt32(label12.Text);
                G_Fat = ((G_Fat / 100) * gram) + Convert.ToInt32(label13.Text);
                show();
            }

            #endregion

            #region Evening
            if (comboBox3.SelectedItem == "Evening")
            {
                if (Check == 5)
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine +
                        comboBox1.Text + "         " + textBox2.Text + " Gr" + Environment.NewLine;

                }
                else
                {
                    textBox1.Text = textBox1.Text + Environment.NewLine + comboBox3.Text + "-------------------" +
                                    Environment.NewLine + comboBox1.Text + "         " + textBox2.Text + " Gr" + Environment.NewLine; ;
                    Check = 5;
                }

                G_kal = ((G_kal / 100) * gram) + Convert.ToInt32(label10.Text);
                G_Prot = ((G_Prot / 100) * gram) + Convert.ToInt32(label11.Text);
                G_Carb = ((G_Carb / 100) * gram) + Convert.ToInt32(label12.Text);
                G_Fat = ((G_Fat / 100) * gram) + Convert.ToInt32(label13.Text);
                show();
            }
            #endregion

//İf else Statment end.

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            saveFileDialog1.Title = Form1.name;
            saveFileDialog1.Filter = "Text|*.text";
            StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
            sw.Write(textBox1.Text);
            sw.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            saveFileDialog1.Title = "Open txt File";
            openFileDialog1.Filter = "Text|*.text";
            StreamReader sr = new StreamReader(openFileDialog1.FileName);

                textBox1.Text = sr.ReadToEnd();
                sr.Close();

            
            

           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from Nutrients where Name='" + comboBox1.Text +"';", connect);
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                
                label10.Text = read["Calori"].ToString();
                label11.Text = read["Protein"].ToString();
                label12.Text = read["Carb"].ToString();
                label13.Text = read["Fat"].ToString();



            }
            connect.Close();



        }
    }
}
