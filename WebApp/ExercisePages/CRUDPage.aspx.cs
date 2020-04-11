using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DBSystem.BLL;
using DBSystem.ENTITIES;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;

namespace WebApp.ExercisePages
{
    public partial class CRUDPage : System.Web.UI.Page
    {
        static string pagenum = "";
        static string pid = "";
        static string add = "";
        List<string> errormsgs = new List<string>();
        private static List<Entity02> Entity02List = new List<Entity02>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();
            if (!Page.IsPostBack)
            {
                pagenum = Request.QueryString["page"];
                pid = Request.QueryString["pid"];
                add = Request.QueryString["add"];
                BindTeamList();
                BindGuardianList();
                if (string.IsNullOrEmpty(pid))
                {
                    Response.Redirect("~/Default.aspx");
                }
                else if (add == "yes")
                {
                    UpdateButton.Enabled = false;
                    DeleteButton.Enabled = false;
                }
                else
                {
                    AddButton.Enabled = false;
                    Controller02 sysmgr = new Controller02();
                    Entity02 info = null;
                    info = sysmgr.Player_Find(int.Parse(pid));
                    if (info == null)
                    {
                        errormsgs.Add("Record is no longer on file.");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                        Clear_Click(sender, e);
                    }
                    else
                    {
                        PlayerID.Text = info.PlayerID.ToString();
                        FirstName.Text = info.FirstName;
                        LastName.Text = info.LastName;
                        Age.Text = info.Age.ToString();
                        Gender.Text = info.Gender;
                        AlbertaHealthcareNumber.Text = info.AlbertaHealthCareNumber;
                        MedicalAlertDetails.Text = info.MedicalAlertDetails == null ? "" : info.MedicalAlertDetails;
                        if (info.TeamID.HasValue)
                        {
                            TeamList.SelectedValue = info.TeamID.ToString();
                        }
                        else
                        {
                            TeamList.SelectedIndex = 0;
                        }
                        if (info.GuardianID.HasValue)
                        {
                            GuardianList.SelectedValue = info.GuardianID.ToString();
                        }
                        else
                        {
                            GuardianList.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        protected Exception GetInnerException(Exception ex)
        {
            while(ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        protected void BindTeamList()
        {
            try
            {
                Controller01 sysmgr = new Controller01();
                List<Entity01> info = null;
                info = sysmgr.List();
                info.Sort((x,y) => x.TeamName.CompareTo(y.TeamName));
                TeamList.DataSource = info;
                TeamList.DataTextField = nameof(Entity01.TeamName);
                TeamList.DataValueField = nameof(Entity01.TeamID);
                TeamList.DataBind();
                TeamList.Items.Insert(0,"Select . . .");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void BindGuardianList()
        {
            try
            {
                Controller03 sysmgr = new Controller03();
                List<Entity03> info = null;
                info = sysmgr.List();
                info.Sort((x,y) => x.GuardianName.CompareTo(y.GuardianName));
                GuardianList.DataSource = info;
                GuardianList.DataTextField = nameof(Entity03.GuardianName);
                GuardianList.DataTextField = nameof(Entity03.GuardianID);
                GuardianList.DataBind();
                GuardianList.Items.Insert(0,"Select . . . ");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }

        protected void Validation(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FirstName.Text))
            {
                errormsgs.Add("First Name is required!");
            }
            if (string.IsNullOrEmpty(LastName.Text))
            {
                errormsgs.Add("Last Name is required!");
            }
            int age = 0;
            if (string.IsNullOrEmpty(Age.Text))
            {
                errormsgs.Add("Age is required!");
            }
            else
            {
                if (int.TryParse(Age.Text, out age))
                {
                    if (age < 6 || age > 14)
                    {
                        errormsgs.Add("Age must be between 4 and 16!");
                    }
                }
                else
                {
                    errormsgs.Add("Age must be a real number!");
                }
            }
            if (string.IsNullOrEmpty(AlbertaHealthcareNumber.Text))
            {
                errormsgs.Add("Alberta Healthcare Number is Required!");
            }
            else
            {
                if (!AlbertaHealthcareNumber.Text.StartsWith("1"))
                {
                    errormsgs.Add("Alberta Health care number must start with number 1");
                }
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            if (pagenum == "4")
            {
                Response.Redirect("Exercise9.aspx");
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            PlayerID.Text = "";
            TeamList.ClearSelection();
            GuardianList.ClearSelection();
            FirstName.Text = "";
            LastName.Text = "";
            Age.Text = "";
            Gender.Text = "";
            AlbertaHealthcareNumber.Text = "";
            MedicalAlertDetails.Text = "";
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Validation(sender, e);
            if (errormsgs.Count > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    Controller02 sysmgr = new Controller02();
                    Entity02 item = new Entity02();
                    
                    if (TeamList.SelectedIndex == 0)
                    {
                        item.TeamID = null;
                    }
                    else
                    {
                        item.TeamID = int.Parse(TeamList.SelectedValue);
                    }
                    item.GuardianID = int.Parse(GuardianList.SelectedValue);
                    item.FirstName = FirstName.Text.Trim();
                    item.LastName = LastName.Text.Trim();
                    item.Age = int.Parse(Age.Text);
                    item.Gender = string.IsNullOrEmpty(Gender.Text) ? null : Gender.Text;
                    item.AlbertaHealthCareNumber = AlbertaHealthcareNumber.Text;
                    item.MedicalAlertDetails = string.IsNullOrEmpty(MedicalAlertDetails.Text) ? null : MedicalAlertDetails.Text;
                    int newID = sysmgr.Add(item);
                    PlayerID.Text = newID.ToString();
                    errormsgs.Add("Record has been added!");
                    LoadMessageDisplay(errormsgs, "alert alert-success");
                    UpdateButton.Enabled = true;
                    DeleteButton.Enabled = true;
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(PlayerID.Text))
            {
                errormsgs.Add("Search for a record to update");
            }
            else if (!int.TryParse(PlayerID.Text, out id))
            {
                errormsgs.Add("ID is invalid");
            }
            Validation(sender, e);
            if (errormsgs.Count > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
            else
            {
                try
                {
                    Controller02 sysmgr = new Controller02();
                    Entity02 item = new Entity02();

                    if (TeamList.SelectedIndex == 0)
                    {
                        item.TeamID = null;
                    }
                    else
                    {
                        item.TeamID = int.Parse(TeamList.SelectedValue);
                    }
                    item.GuardianID = int.Parse(GuardianList.SelectedValue);
                    item.FirstName = FirstName.Text.Trim();
                    item.LastName = LastName.Text.Trim();
                    item.Age = int.Parse(Age.Text);
                    item.Gender = string.IsNullOrEmpty(Gender.Text) ? null : Gender.Text;
                    item.AlbertaHealthCareNumber = AlbertaHealthcareNumber.Text;
                    item.MedicalAlertDetails = string.IsNullOrEmpty(MedicalAlertDetails.Text) ? null : MedicalAlertDetails.Text;
                    int rowsaffected = sysmgr.Update(item);
                    if (rowsaffected > 0)
                    {
                        errormsgs.Add("Record has been updated");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                    }
                    else
                    {
                        errormsgs.Add("Record was not found");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(PlayerID.Text))
            {
                errormsgs.Add("Search for a record to delete");
            }
            else if (!int.TryParse(PlayerID.Text, out id))
            {
                errormsgs.Add("Player ID is invalid");
            }
            if (errormsgs.Count > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    Controller02 sysmgr = new Controller02();
                    int rowsaffected = sysmgr.Delete(id);
                    if (rowsaffected > 0)
                    {
                        errormsgs.Add("Record has been deleted");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        Clear_Click(sender, e);
                    }
                    else
                    {
                        errormsgs.Add("Record was not found");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                    }
                    UpdateButton.Enabled = false;
                    DeleteButton.Enabled = false;
                    AddButton.Enabled = true;
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }
    }
}