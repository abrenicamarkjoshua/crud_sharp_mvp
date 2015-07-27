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
    public partial class addUser : Form
    {
        private IUserContext userContext;
        public addUser(IUserContext userContext)
        {
            //because this is fairly simple, i won't add a presenter layer.
            //the view (this form) will include the controller (presenter).
            //advantage: faster development and simplicity. disadvantage: coupled with the view, hard to update the view
            
            //the editUser form, and the mainForm i demonstrated a full implementation of the  MVP architecture
            this.userContext = userContext;
            InitializeComponent();
            populateCmbAccountType.populateAccountType(ref select_accountType);
            wireEvents();
        }

        private void wireEvents()
        {
            btnSave.Click += save; //notice that instead of wiring it to the presenter, we wire it here. this view is now also the presenter.
        }
        private void save(object sender, EventArgs e)
        {
            //notice that this view is now responsible for the 'sequence' of the program (like, validation first, then execution, then some optional cross cutting, then affirmation...)
            //but in MVP  it should be the presenter or the application controller be responsible for the 'what to do' of the program.
            //but for simplicity's sake, this will do for now.
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(select_accountType.Text))
            {
                MessageBox.Show("all fields must be supplied");
                return;
            }
            else
            {
                string hashedPassword = hashing.CalculateSHA1(txtPassword.Text, new UTF8Encoding()).Substring(0,20).ToLower();
                user newUser = user.newUser(
                    txtUsername.Text,
                    hashedPassword,
                    select_accountType.Text);

                userContext.addUser(newUser);

                MessageBox.Show("User successfully registered!");
                clearInput();
            }
            
        }

        private void clearInput()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
    }
}
