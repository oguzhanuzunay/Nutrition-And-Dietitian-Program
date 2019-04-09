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

namespace WindowsFormsApplication4
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            ShowVar();
            Catagory();

        }
        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-UO8AT4Q\\SQLEXPRESS;Initial Catalog=Nutritions;Integrated Security=True");

        private void Catagory()
        {
            comboBox1.Items.Clear();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from Catagory", connect);
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                comboBox1.Items.Add(read["Cat_Name"].ToString());
            }
            connect.Close();
        }

        private void ShowVar()
        {
            listView1.Items.Clear();
            connect.Open();
            SqlCommand cmd = new SqlCommand("select * from Nutrients", connect);
            SqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                ListViewItem add = new ListViewItem();
                add.Text = read["ID"].ToString();
                add.SubItems.Add(read["Name"].ToString());
                add.SubItems.Add(read["Catagory"].ToString());
                add.SubItems.Add(read["Weight"].ToString());
                add.SubItems.Add(read["Calori"].ToString());
                add.SubItems.Add(read["Protein"].ToString());
                add.SubItems.Add(read["Carb"].ToString());
                add.SubItems.Add(read["Fat"].ToString());

                listView1.Items.Add(add);
            }
            
            connect.Close();


        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText= "INSERT INTO Nutrients(Name,Catagory,Weight,Calori,Protein,Carb,Fat) values('" 
                +textBox1.Text+"','" + comboBox1.Text + "','" + int.Parse(textBox2.Text) + "','" + int.Parse(textBox3.Text) + "','"
                + int.Parse(textBox4.Text) + "','" + int.Parse(textBox5.Text) + "','" + int.Parse(textBox6.Text) + "')";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connect.Close();

            ShowVar();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        int id = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand("Delete From Nutrients where ID=(" + id + ")", connect);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connect.Close();
            ShowVar();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[7].Text;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Nutrients set Name='"+textBox1.Text+"',Catagory='"+comboBox1.Text+"',Weight='"+ int.Parse(textBox2.Text) +
                                            "',Calori='"+ int.Parse(textBox3.Text)+"',Protein='"+ int.Parse(textBox4.Text)+
                                            "',Carb='"+ int.Parse(textBox5.Text)+"',Fat='"+ int.Parse(textBox6.Text)+"'where ID=@id",connect);

            cmd.Parameters.AddWithValue("@id", int.Parse(listView1.SelectedItems[0].SubItems[0].Text));
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            connect.Close();
            ShowVar();
        }
    }
}
