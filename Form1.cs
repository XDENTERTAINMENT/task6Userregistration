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
using System.Xml.Linq;

namespace registration
{
    public partial class Form1 : Form
    {

        datareg_tb data = new datareg_tb();

        public Form1()
        {
            InitializeComponent();
            

        }

       

        private void txtusername_Enter(object sender, EventArgs e)
        {
            if (txtusername.Text == "Username")
            {
                txtusername.Text = "";
                txtusername.ForeColor= Color.Black;
            }
        }

        private void txtusername_Leave(object sender, EventArgs e)
        {
            if(txtusername.Text =="")
            {
                txtusername.Text = "Username";
                txtusername.ForeColor= Color.LightSlateGray;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmailAddress.Text == "Email Address")
            {
                txtEmailAddress.Text = "";
                txtEmailAddress.ForeColor = Color.Black;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmailAddress.Text == "")
            {
                txtEmailAddress.Text = "Email Address";
                txtEmailAddress.ForeColor = Color.LightSlateGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if(txtPassword.Text=="Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.LightSlateGray;
            }
        }

        private void txtConfirmpassword_Enter(object sender, EventArgs e)
        {
            if(txtConfirmpassword.Text=="Confirm Password")
            {
                txtConfirmpassword.Text = ("");
                txtConfirmpassword.ForeColor = Color.Black;
            }
        }

        private void txtConfirmpassword_Leave(object sender, EventArgs e)
        {
            if(txtConfirmpassword.Text =="")
            {
                txtConfirmpassword.Text = "Confirm Password";
                txtConfirmpassword.ForeColor= Color.LightSlateGray;
            }
        }

        private void txtname_Enter(object sender, EventArgs e)
        {
            if (txtname.Text == ("Name"))
            {
                txtname.Text = ("");
                txtname.ForeColor = Color.Black;
            }
        }

        private void txtname_Leave(object sender, EventArgs e)
        {
            if(txtname.Text=="")
            { txtname.Text =  "Name";
              txtname.ForeColor= Color.LightSlateGray;
            }
        }

        private void txtphone_Enter(object sender, EventArgs e)
        {
            if(txtphone.Text == ("Phone"))
                {
                txtphone.Text = "";
                txtphone.ForeColor = Color.Black;
            }
        }

        private void txtphone_Leave(object sender, EventArgs e)
        {
            if (txtphone.Text == "")
            {
                txtphone.Text = "Phone";
                txtphone.ForeColor= Color.LightSlateGray;

            }
        }

        private void txtdate_Enter(object sender, EventArgs e)
        {
            if (txtdate.Text == "Date")

            {
                txtdate.Text = "";
                txtdate.ForeColor= Color.Black;
            }
        }

        private void txtdate_Leave(object sender, EventArgs e)
        {
            if (txtdate.Text == "")
            {
                txtdate.Text= "Date";
                txtdate.ForeColor = Color.LightSlateGray;

            }
        }

        private void txtfamiy_Enter(object sender, EventArgs e)
        {
            if (txtfamiy.Text == "Family")
            {
                txtfamiy.Text = "";
                txtfamiy.ForeColor= Color.Black;
            }
        }

        private void txtfamiy_Leave(object sender, EventArgs e)
        {
            if (txtfamiy.Text=="")
            {
                txtfamiy.Text = "Family";
                txtfamiy.ForeColor = Color.LightSlateGray;
            }
        }

        private void txtmobile_Enter(object sender, EventArgs e)
        {
            if(txtmobile.Text =="Mobile")
            {
                txtmobile.Text = "";
                txtmobile.ForeColor= Color.Black;
            }
        }

        private void txtmobile_Leave(object sender, EventArgs e)
        {
            if (txtmobile.Text=="")
            {
                txtmobile.Text = "Mobile";
                txtmobile.ForeColor = Color.LightSlateGray;
            }
        }

        private void txtbirthplace_Enter(object sender, EventArgs e)
        {
            if(txtbirthplace.Text=="Birth place")
            {
                txtbirthplace.Text = "";
                txtbirthplace.ForeColor = Color.Black;
            }
        }

        private void txtbirthplace_Leave(object sender, EventArgs e)
        {
            if (txtbirthplace.Text == "")
            {
                txtbirthplace.Text = "Birth place";
                txtbirthplace.ForeColor= Color.LightSlateGray;
            }
        }

        private void txtRegister_Click(object sender, EventArgs e)
        {
            RegistrationEntities3 registration = new RegistrationEntities3();
            data.Username= txtusername.Text;
            data.Email = txtEmailAddress.Text;
            data.Password = txtPassword.Text;
            data.Confirm_password = txtConfirmpassword.Text;
            data.Name = txtname.Text;
            data.Date = txtdate.Text;
            data.Phone = txtphone.Text;
          
            data.Family = txtfamiy.Text;
            data.Mobile = txtmobile.Text;
            data.Birth_place = txtbirthplace.Text;
            if(data.id==0)
            registration.datareg_tb.Add(data);
            else
                registration.Entry(data).State =System.Data.Entity.EntityState.Modified;

            registration.SaveChanges();

            MessageBox.Show("Registered ");

            populateDataGridView();



        }

        


        private void populateDataGridView()
        {
            RegistrationEntities3 db = new RegistrationEntities3();
            dataGridView1.DataSource = db.datareg_tb.ToList<datareg_tb>();

        }

       

        

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if  (dataGridView1.CurrentRow.Index != -1)
            {
                data.id = (int)dataGridView1.CurrentRow.Cells["id"].Value;
                RegistrationEntities3 db = new RegistrationEntities3();
                data = db.datareg_tb.Where(x => x.id == data.id).FirstOrDefault();
                txtusername.Text = data.Username;
                txtEmailAddress.Text = data.Email;
                txtPassword.Text = data.Password;
                txtConfirmpassword.Text = data.Confirm_password;
                txtname.Text = data.Name;
                txtdate.Text = data.Date;
                txtphone.Text = data.Phone;
                txtmobile.Text = data.Mobile;
                txtfamiy.Text = data.Family;
                txtmobile.Text = data.Mobile;
                txtbirthplace.Text = data.Birth_place;
            }
            txtRegister.Text = "UPDATE";

        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            populateDataGridView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            RegistrationEntities3 db = new RegistrationEntities3();
            var entry = db.Entry(data);
            if (entry.State == System.Data.Entity.EntityState.Detached)
                db.datareg_tb.Attach(data);
            db.datareg_tb.Remove(data);
            db.SaveChanges();
            populateDataGridView();

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            
                data.id = (int)dataGridView1.CurrentRow.Cells["id"].Value;
                RegistrationEntities3 db = new RegistrationEntities3();
                
            
        }

        private void txtsearchfordata_Enter(object sender, EventArgs e)
        {
            if(txtsearchfordata.Text==("Search for data"))
            {
                txtsearchfordata.Text = "";
                txtsearchfordata.ForeColor=Color.Black;    

            }
            
        }

        private void txtsearchfordata_Leave(object sender, EventArgs e)
        {
            if (txtsearchfordata.Text == ""){


                txtsearchfordata.Text = "Search for data";
                txtsearchfordata.ForeColor = Color.LightGray;

            }
        }

        private void txtsearchfordata_TextChanged(object sender, EventArgs e)
        {
            RegistrationEntities3 db = new RegistrationEntities3();
            dataGridView1.DataSource = db.datareg_tb.Where(x => x.Username.Contains(txtsearchfordata.Text)).ToList();
            dataGridView1.DataSource = db.datareg_tb.Where(x => x.Email.Contains(txtsearchfordata.Text)).ToList();
        }
    }
    }
