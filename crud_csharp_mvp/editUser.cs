using crud_csharp_mvp_ApplicationController.presenters.concrete;
using crud_csharp_mvp_ApplicationController.presenters.interfaces;
using crud_csharp_mvp_ApplicationController.services.concrete;
using crud_csharp_mvp_ApplicationController.services.interfaces;
using crud_csharp_mvp_ApplicationController.views_interface;
using crud_csharp_mvp_BusinessLogicLayer.domain_model;
using crud_csharp_mvp_BusinessLogicLayer.persistence_model.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace crud_csharp_mvp
{
    public partial class editUser : Form , IeditUserView
    {
        private user user { get; set; }
        private IUserContext userContext;
        private IeditUserPresenter presenter;
        public editUser(user user, IUserContext db)
        {
            this.user = user;
            this.userContext = db;
           
            this.presenter = new editUserPresenter(this, userContext);
            InitializeComponent();
            loadComboBoxAccountType();
            loadValues(user);
            wireEvents();
        }

        private void loadComboBoxAccountType()
        {
            populateCmbAccountType.populateAccountType(ref select_accountType);
            select_accountType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void loadValues(crud_csharp_mvp_BusinessLogicLayer.domain_model.user user)
        {
            txtUsername.Text = user.username;
            select_accountType.Text = user.accountType;
        }

        private void wireEvents()
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            btnSave.Click += save;
        }

        private void save(object sender, EventArgs e)
        {
            presenter.saveChangesToUser();
        }


        public user getUser()
        {
            return user;
        }

        public bool hasNoErrors()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errors.Add("username must not be blank");
                return false;
            }
            if (string.IsNullOrWhiteSpace(select_accountType.Text))
            {
                errors.Add("account type must not be blank");
                return false;
            }

            return true; //no more errors.
        }
        private List<string> errors = new List<string>();
        public void showErrors()
        {
            string e = "";
            foreach (string error in errors)
            {
                e += error + Environment.NewLine;
            }
            MessageBox.Show(e);
            errors = new List<string>();
        }

        public user getUpdatedUser()
        {
            user.updateUsername(txtUsername.Text);
            user.updateAccountType(select_accountType.Text);
            return user;
        }


        public void showErrors(string p)
        {
            errors.Add(p);
            showErrors();
        }

        public void confirmAndClose()
        {
            MessageBox.Show("user updated successfully! form will now close");
            this.Close();
        }

        public string getInputUsername()
        {
            return txtUsername.Text;
        }
    }
}
