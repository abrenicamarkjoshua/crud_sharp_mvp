using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using crud_csharp_mvp_ApplicationController.views_interface;
using crud_csharp_mvp_BusinessLogicLayer.persistence_model.interfaces;
using crud_csharp_mvp_BusinessLogicLayer.domain_model;
using crud_csharp_mvp_ApplicationController.presenters.interfaces;
using crud_csharp_mvp_ApplicationController.presenters.concrete;
using crud_csharp_mvp_ApplicationController.services.concrete;
using crud_csharp_mvp_BusinessLogicLayer.persistence_model.concrete;
using crud_csharp_mvp_ApplicationController.services.interfaces;
using System.Data.Entity;

namespace crud_csharp_mvp {
    public partial class loginForm : Form, IloginView {
        //singleton.
        public static loginForm instance;
        public static loginForm getInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new loginForm();
                
            }
            return instance;
        }
        private IloginPresenter presenter;
        private List<string> errors = new List<string>();
        
        private loginForm()
        {
            InitializeComponent();
            try
            {
                //START HERE
                //choose if ORM or data mapper.
                IUserContext userContext_framework = new UserContext_framework("name = mysqlCon"); //orm framework using Entity Framework
                IUserContext userContext_odbc= new UserContext_customDAL("name = mysqlCon2"); //data mapper using odbc
               
                presenter = new loginPresenter(this, userContext_odbc);
            }
            catch (Exception ex)
            {
                //more exception handling here
                MessageBox.Show(ex.Message);
            }
            WireEvents();
        }

        private void WireEvents()
        {
            btnLogin.Click += delegate
            {
                presenter.login();
            };
        }

        public bool noErrors()
        {
            //check for errors
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errors.Add("username must not be blank");
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errors.Add("password must not be blank");
            }

            //output true or false if there are NO errors
            if (errors.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void displayErrors()
        {
            string listOfErrors = "";
            foreach (string error in errors)
            {
                listOfErrors += error + Environment.NewLine;
            }
            MessageBox.Show(listOfErrors);
            errors.Clear(); //reset
        }

        public string getUsername()
        {
            return this.txtUsername.Text;
        }

        public string getHashedPassword()
        {

            string hashedPassword = hashing.CalculateSHA1(txtPassword.Text, new UTF8Encoding()).Substring(0,20);
            return hashedPassword.ToLower();
        }

        public void RedirectToMainForm(user user, IUserContext userContext)
        {
            this.Hide();
            mainForm.getInstance(user, userContext).Show();
        }

        public void displayUserLoginFailed()
        {
            MessageBox.Show("Access denied. Username/password combination no match.");
        }

       

        public void clearFields()
        {
            //normaly i would call a function that would loop/recurse inside group controls and set textboxes to blank, 
            //but for now this will do.
            txtUsername.Text = "";
            txtPassword.Text = "";
        }


        public void hide()
        {
            this.Hide();
        }
    }
}
