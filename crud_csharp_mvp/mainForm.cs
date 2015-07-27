using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using crud_csharp_mvp_BusinessLogicLayer.domain_model;
using crud_csharp_mvp_BusinessLogicLayer.persistence_model.interfaces;
using crud_csharp_mvp_ApplicationController.views_interface;
using crud_csharp_mvp_ApplicationController.presenters.interfaces;
using crud_csharp_mvp_ApplicationController.presenters.concrete;

namespace crud_csharp_mvp {
    public partial class mainForm : Form, ImainFormView{
        private static mainForm instance;
        private ImainFormPresenter presenter;
        public static mainForm getInstance(user loggedUser, IUserContext userContext)
        {
            if (instance == null || instance.IsDisposed)
            {
                
                instance = new mainForm(loggedUser, userContext);
            }
            return instance;
        }

        public user loggedUser { get; private set; }
        private IUserContext userContext;

        private mainForm(user loggedUser, IUserContext userContext)
        {
            this.loggedUser = loggedUser;
            this.userContext = userContext;
            this.presenter= new mainFormPresenter(this, userContext);
            InitializeComponent();
            prepare();
            WireEvents();
        }

        private void prepare()
        {
            //you can use the designer's form close event to program the form close and open the login
            //but i code it here for you to know these techniques. (learn: delegates, anonymous functions/lambda expressions) 
            //again, the objective of mvp (and other mvc variants) is to make the GUI loosely coupled (if not decoupled) with the application code 

            btn_dgridview_edit.Enabled = false; //enable if datagridview has a selected record
            datagridview_userResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            datagridview_userResult.ReadOnly = true; // this is just my preference. i like to edit entries on a form instead on a datagridview.
            datagridview_userResult.MultiSelect = false;
            listview_userResult.MultiSelect = false;
            listview_userResult.HideSelection = false;

        }

        private void WireEvents()
        {
           
            this.FormClosing += (object sender, FormClosingEventArgs e) =>
            {
                //yoda expression. this is just my preference of coding
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to log out?","prompt", MessageBoxButtons.YesNo))
                {
                    e.Cancel = false; // though no need to code this part, i just code it for readability
                    loginForm.getInstance().Show();
                }
                else
                {
                    e.Cancel = true;
                }
            };
            //here's another approach. anonymous function using delegate.
            this.btnLoadAllUsers_datagridview.Click += delegate
            {
                presenter.loadAllUsers_datagridview();
            };
           
            datagridview_userResult.Click += delegate
            {
                if (datagridview_userResult.SelectedCells.Count != 0)
                {
                    btn_dgridview_edit.Enabled = true;
                }
                else { 
                    btn_dgridview_edit.Enabled = false; 
                }
            
            };
            //this approach is what i recommend. becuse it lets you easily find each method/function in visual studio. disadvantage: so many codes (named functions/subroutines).
            //make a private void or function that calls the presenter what to do. 
            //the view is not responsible of doing stuff, 
            //it's responsible for sending commands to the controller (presenter),
            //and receiving data from the controller and formats it (like putting them in a listview or redirecting to another form)
            this.btnLoadAllUsers_listview.Click += loadAllUsers_listview_click;
            btn_dgridview_edit.Click += editUserInGridView;
            btnListViewEdit.Click += editUserInListView;
            btnDeleteItemInDgridview.Click += deleteUserInGridView;
            btnDeleteItemInListView.Click += deleteUserInListView;
            btnAddNewUser.Click += addNewUser;
        }
        private void addNewUser(object sender, EventArgs e)
        {
            using (addUser addUserFrm = new addUser(userContext))
            {
                addUserFrm.ShowDialog();
            }
            //refresh. just click the loadUsers button. (gridview, listview)
        }
        private void deleteUserInListView(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("are you sure you want to delete the selected item from the list?", "prompt", MessageBoxButtons.YesNo))
            {
                try
                {
                    presenter.deleteUserById(presenter.getUserById(getSelectedUserFromListView().id));
                    refreshListView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                    
                    
                    MessageBox.Show("item deleted successfully!");
            }
        }

        private void deleteUserInGridView(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("are you sure you want to delete the selected item from the data grid?", "prompt", MessageBoxButtons.YesNo))
            {
                try
                {
                    presenter.deleteUserById(presenter.getUserById(getSelectedUserFromDgridView().id));
                    refreshDataGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                    MessageBox.Show("item deleted successfully!");
            }
        }
        private void editUserInListView(object sender, EventArgs e)
        {
            using (editUser editUser = new editUser(getSelectedUserFromListView(), userContext))
            {
                editUser.ShowDialog();
            }
            refreshListView();
        }

        private user getSelectedUserFromListView()
        {
            if (listview_userResult.SelectedItems.Count == 0)
            {
                return null;
            }
            return presenter.getUserById(int.Parse(listview_userResult.SelectedItems[0].SubItems[0].Text));
            
        }

        private void refreshListView()
        {
            btnLoadAllUsers_listview.PerformClick();
        }
        private user getSelectedUserFromDgridView()
        {
            if (datagridview_userResult.SelectedCells.Count == 0)
            {
                return null;
            }
            return presenter.getUserById(int.Parse(datagridview_userResult.SelectedCells[0].Value.ToString()));
            //why not call db.getUserById instead? you can. but it's good practice 
            //that we only call from presenter/controllers.
            //because presenter has the data access and the services needed.
        }
        private void editUserInGridView(object sender, EventArgs e)
        {
            using(editUser editUser = new editUser(getSelectedUserFromDgridView() ,userContext)){
                editUser.ShowDialog();
            }
            refreshDataGridView();
        }

        private void refreshDataGridView()
        {
            btnLoadAllUsers_datagridview.PerformClick();
        }
        private void loadAllUsers_listview_click(object sender, EventArgs e)
        {
            presenter.loadAllUsers_listview();
        }
        public void loadAllLUsers_datagridview(object users)
        {
            datagridview_userResult.DataSource = users;
            formatDataGridViewOutput();
        }

        private void formatDataGridViewOutput()
        {
            datagridview_userResult.Columns[0].Visible = false; //hide the column ID. but it's there.
            datagridview_userResult.Columns[2].Visible = false; //hide the column password. but it's there.


            datagridview_userResult.Refresh();
        }

        
        public void error(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }



        public void loadAllLUsers_listview(List<user> users)
        {
            if (listview_userResult.Items.Count > 0)
            {
                listview_userResult.Items.Clear();
            }
            for (int i = 0; i<= users.Count - 1; i++){
                listview_userResult.Items.Add(users[i].id.ToString());
                listview_userResult.Items[i].SubItems.Add(users[i].username);
                listview_userResult.Items[i].SubItems.Add(users[i].accountType.ToString());
            }
            formatListViewOutput();
        }

        private void formatListViewOutput()
        {
            listview_userResult.Columns[0].Width = 0; //hide column 'id'
        }
        
    }
}
