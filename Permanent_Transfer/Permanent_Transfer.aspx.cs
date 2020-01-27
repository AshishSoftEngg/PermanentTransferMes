using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Payroll_Master_Permanent_Transfer : System.Web.UI.Page
{
    CommonCode cc = new CommonCode();
    PL_Permanent_Transfer pl = new PL_Permanent_Transfer();
    BL_Permanent_Transfer bl = new BL_Permanent_Transfer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("JourneyFrom");
            dt.Columns.Add("JourneyTo");
            dt.Columns.Add("Mode_of_Conveyance");
            dt.Columns.Add("Class");
            dt.Columns.Add("Distance");
            dt.Columns.Add("Rate");
            dt.Columns.Add("Amount");
            ViewState["dt"] = dt;

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Name");
            dt1.Columns.Add("Age");
            dt1.Columns.Add("Relation");
                      
            ViewState["dt1"] = dt1;

            bind_FinancialYear();
            binddesig_type();
            bindchildgrd();
            bindgrdData();

            

        }
    }

    protected void bind_FinancialYear()
    {
        try
        {
            CultureInfo Cult = new CultureInfo("hi-IN");
            int previousyear = Convert.ToDateTime(DateTime.Now, Cult).Year - 1;
            int currentyear = Convert.ToDateTime(DateTime.Now, Cult).Year;
            string str = "select * from [M_Financial_Year] order by year_id asc";
            DataTable dt = SQL_DBCS.ExecuteDataTable(str);


            if (dt.Rows.Count > 0)
            {
                ddlFinancial.DataTextField = "fin_year";
                ddlFinancial.DataValueField = "fin_year";
                ddlFinancial.DataSource = dt;
                ddlFinancial.DataBind();

                ddlFinancial.Items.Insert(0, "--Select--");
            }
            int year = Convert.ToDateTime(DateTime.Now).Year;
            year = Convert.ToDateTime(DateTime.Now).Year;
            if (year == 2019)
            {
                ddlFinancial.SelectedValue = "2019-2020";
            }
            else if (year == 2020)
            {
                ddlFinancial.SelectedValue = "2020-2021";
            }
            else if (year == 2021)
            {
                ddlFinancial.SelectedValue = "2021-2022";
            }
            else if (year == 2022)
            {
                ddlFinancial.SelectedValue = "2022-2023";
            }


        }
        catch (Exception ex)
        {
            Messagebox.Show(ex.Message);
        }
    }
    public void binddesig_type()
    {
        string str = "select DES_Type_Name, DES_Type_Id from M_Designation_Type";        
        DataTable dt = SQL_DBCS.ExecuteDataTable(str);
        if (dt.Rows.Count > 0)
        {
            ddlEmpType.DataSource = dt;
            ddlEmpType.DataTextField = "DES_Type_Name";
            ddlEmpType.DataValueField = "DES_Type_Id";
            ddlEmpType.DataBind();
            ddlEmpType.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }

    protected void ddlEmpType_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_emp();
    }

    private void bind_emp()
    {
        string str = "";
        if (ddlEmpType.SelectedIndex > 0)
        {
            str = " select NAME+' ('+CODE+')' NAME, CODE from V_paybill where DESG_TYPE='" + ddlEmpType.SelectedValue.ToString().Trim() + "' and GPF_TYPE='" + ddlGpsMps.SelectedItem.Text + "' order by NAME";
        }
        else
        {
            str = " select NAME+' ('+CODE+')' NAME, CODE from V_paybill  order by NAME";

        }
        DataTable dt = cc.EQ(str);
        if (dt.Rows.Count > 0)
        {
            ddl_emp.DataTextField = "NAME";
            ddl_emp.DataValueField = "CODE";
            ddl_emp.DataSource = dt;
            ddl_emp.DataBind();
            ddl_emp.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        else
        {
            ddl_emp.Items.Clear();
        }
    }

    protected void Add_Click(object sender, EventArgs e)
    {
        if (txtJourneyFrom.Text.Trim() != "" && txtJourneyTo.Text != "" && txtModeofConveyance.Text.Trim() != "" && txtClass.Text.Trim() != "" && txtDistance.Text.Trim() != "" && txtRate.Text.Trim() != "" && txtDoJAmount.Text.Trim() != "")
        {
            DataTable dt = ViewState["dt"] as DataTable;
            dt.Rows.Add(txtJourneyFrom.Text.Trim(), txtJourneyTo.Text, txtModeofConveyance.Text.Trim(), txtClass.Text.Trim(), txtDistance.Text.Trim(), txtRate.Text.Trim(), txtDoJAmount.Text.Trim());
            ViewState["dt"] = dt;
            bindchildgrd();

            txtJourneyFrom.Text = string.Empty;
            txtJourneyTo.Text = string.Empty;
            txtModeofConveyance.Text = string.Empty;
            txtClass.Text = string.Empty;
            txtDistance.Text = string.Empty;
            txtRate.Text = string.Empty;
            txtDoJAmount.Text = string.Empty;

        }
        else
        {
            Messagebox.Show("Please Fill All Fields Mandatory (*) Fields!");
        }
    }

    protected void AddChild1_Click(object sender, EventArgs e)
    {
        if (txtfamMemName.Text.Trim() != "" && ddlAge.SelectedItem.Text.ToString() != "" && ddlRelation.SelectedItem.Text.ToString() != "" )
        {
            DataTable dt1 = ViewState["dt1"] as DataTable;
            dt1.Rows.Add(txtfamMemName.Text.Trim(), ddlAge.SelectedItem.Text.ToString(), ddlRelation.SelectedItem.Text.ToString());
            ViewState["dt1"] = dt1;
            bindchildgrd();

            txtfamMemName.Text = string.Empty;
            ddlAge.SelectedIndex = 0;
            ddlRelation.SelectedIndex = 0;

        }
        else
        {
            Messagebox.Show("Please Fill All Fields Mandatory (*) Fields!");
        }
    }
    public void bindchildgrd()
    {
        Grd.DataSource = ViewState["dt"] as DataTable;
        Grd.DataBind();
        Grd1.DataSource = ViewState["dt1"] as DataTable;
        Grd1.DataBind();
    }
 

    protected void grd_data_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grd_data.PageIndex = e.NewPageIndex;
           
        }
        catch (Exception ex)
        {

            Messagebox.Show(ex.Message);
        }
    }

    public bool validate()
    {

        if (ddlFinancial.SelectedIndex == 0)
        {
            Messagebox.Show("Please Select Financial Year No.");
            return false;
        }
        if (ddlEmpType.SelectedIndex == 0)
        {
            Messagebox.Show("Please Select Designation Type.");
            return false;
        }
        if (ddl_emp.SelectedIndex == 0)
        {
            Messagebox.Show("Please Select Employee Name.");
            return false;
        }
        if (ddlGpsMps.SelectedIndex == 0)
        {
            Messagebox.Show("Please Select Gpf/Nps.");
            return false;
        }


        if (txtTransferedFrom.Text == "")
        {
            Messagebox.Show("Please Enter Transfered From.");
            return false;
        }
        if (txtRuleTrSr.Text == "")
        {
            Messagebox.Show("Please Enter Rule in TR/SR.");
            return false;
        }
        if (txtReferenceNo.Text == "")
        {
            Messagebox.Show("Please Enter Reference No.");
            return false;
        }
        if (txtPlace.Text == "")
        {
            Messagebox.Show("Please Enter Place.");
            return false;
        }
        if (txtArrival.Text == "")
        {
            Messagebox.Show("Please Enter Arrival.");
            return false;
        }
        if (txtDailyAllAdult.Text == "")
        {
            Messagebox.Show("Please Enter Daily Allowance For Adults.");
            return false;
        }
        if (txtNoAdult.Text == "")
        {
            Messagebox.Show("Please Enter No Of Adult.");
            return false;
        }
        if (txtAdultdays.Text == "")
        {
            Messagebox.Show("Please Enter Days.");
            txtAdultdays.Focus();
            return false;            
        }
        if (txtAdultAmount.Text == "")
        {
            Messagebox.Show("Please Enter Amount.");
            txtAdultAmount.Focus();
            return false;
        }

        if (txtDailyallownMinors.Text == "")
        {
            Messagebox.Show("Please Enter Daily Allowance For Minors.");
            txtDailyallownMinors.Focus();
            return false;
        }        
        if (txtNoOfMinors.Text == "")
        {
            Messagebox.Show("Please Enter No Of Minors.");
            return false;
        }
        if (txtMinorsDays.Text == "")
        {
            Messagebox.Show("Please Enter Days.");
            txtMinorsDays.Focus();
            return false;

        }
        if (txtDeparture.Text == "")
        {
            Messagebox.Show("Please Enter Departure.");
            txtDeparture.Focus();
            return false;

        }
        if (txtMinorAmount.Text == "")
        {
            Messagebox.Show("Please Enter Amount.");
            txtMinorAmount.Focus();
            return false;
        }

        if (txtluggage.Text == "")
        {
            Messagebox.Show("Please Enter Luggage.");
            txtluggage.Focus();
            return false;
        }
        if (txtWeight.Text == "")
        {
            Messagebox.Show("Please Enter Weight.");
            txtWeight.Focus();
            return false;
        }
        if (txtLuggageConveyance.Text == "")
        {
            Messagebox.Show("Please Enter Luggage Conveyance.");
            txtLuggageConveyance.Focus();
            return false;
        }
        if (txtCartageResBOffice.Text == "")
        {
            Messagebox.Show("Please Enter Cartage-Residence to Booking Office.");
            txtCartageResBOffice.Focus();
            return false;
        }
        if (txtCartageBookingOfficetoRes.Text == "")
        {
            Messagebox.Show("Please Enter Cartage-Booking Office to Residence.");
            txtCartageBookingOfficetoRes.Focus();
            return false;
        }


        return true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (validate() == true)
            {

                Save();
            }

        }
        catch (Exception ex)
        {
            Messagebox.Show(ex.ToString());

        }
    }
    void BindGridDisplay()
    {
        DataSet ds = new DataSet();

        if (ds.Tables.Count > 0)
        {
            grd_data.DataSource = ds.Tables[0];
            grd_data.DataBind();
        }
        else
        {
            grd_data.EmptyDataText = "No Record Available";
            grd_data.DataSource = null;
            grd_data.DataBind();
        }
    }
    private void Save()
    {

        CultureInfo cult = new CultureInfo("hi-IN");
        string ref_no = "";
        if (Ddl_advancerefNo.SelectedIndex > 0)
        {
            ref_no = Ddl_advancerefNo.SelectedItem.Text;
        }
        else
        {
            ref_no = "";
        }
        pl.fin_year = ddlFinancial.SelectedValue;
        pl.EmpType = ddlEmpType.SelectedValue;
        pl.ECODE = ddl_emp.SelectedValue;
        pl.EMP_NAME = ddl_emp.SelectedItem.Text;
        pl.GPS_NPS = ddlGpsMps.SelectedValue;
        pl.refrence_no = ref_no;
        pl.freeze_flage = "N";

        pl.CorpOffice = lblCorpOffice.Text;
        pl.PersonalNo = lblPersonalNo.Text;
        pl.PayAccount = lblPayAccount.Text;
        pl.BasicPay = Convert.ToDecimal(lblBasicPay.Text);
        pl.TransferedFrom = txtTransferedFrom.Text.ToString();
        pl.RuleTrSr = txtRuleTrSr.Text.ToString();
        pl.REFRENCENo = txtReferenceNo.Text.ToString();
        pl.Place = txtPlace.Text.ToString();
        pl.Date_of_L = txtDate.Text.ToString();
        pl.Departure = txtDeparture.Text.ToString();
        pl.Arrival = txtArrival.Text.ToString();
        pl.DailyAllowanceFor_Adults =Convert.ToDecimal(txtDailyAllAdult.Text.Trim());
        pl.NoOf_Adult = Convert.ToDecimal(txtNoAdult.Text.Trim());
        pl.Days_Adults = Convert.ToDecimal(txtAdultdays.Text.Trim());
        pl.Amount_Adults = Convert.ToDecimal(txtAdultAmount.Text.Trim());
        pl.DailyAllowanceFor_Minor = Convert.ToDecimal(txtDailyallownMinors.Text.Trim());
        pl.NoOf_Minor = Convert.ToDecimal(txtNoOfMinors.Text.Trim());
        pl.Days_Minor = Convert.ToDecimal(txtMinorsDays.Text.Trim());
        pl.Amount_Minor = Convert.ToDecimal(txtMinorAmount.Text.Trim());
        pl.Luggage = txtluggage.Text.ToString();
        pl.Weight = Convert.ToDecimal(txtWeight.Text.Trim());
        pl.LuggageConveyance = Convert.ToDecimal(txtLuggageConveyance.Text.Trim());
        pl.Cartage_Residence_Booking_Office = txtCartageResBOffice.Text.ToString();
        pl.Cartage_Booking_Office_to_Residence = txtCartageBookingOfficetoRes.Text.ToString();


        if (btnSave.Text == "Save")
        {
            pl.sptype = 1;
            pl.CreatedBy = Session["USERID"].ToString();

        }


        else
        {
            pl.UpdatedBy = Session["UserID"].ToString();
            pl.TableID = Convert.ToInt32(lblRecordID.Text);
            pl.sptype = 2;
        }

        List<PL_Details_JourneyChild> objlist = new List<PL_Details_JourneyChild>();
        for (int row = 0; row < Grd.Rows.Count; row++)

        {
            PL_Details_JourneyChild pd = new PL_Details_JourneyChild();

            pd.JourneyFrom = Grd.Rows[row].Cells[0].Text;
            pd.JourneyTo = Grd.Rows[row].Cells[1].Text;
            pd.Mode_of_Conveyance = Grd.Rows[row].Cells[2].Text;
            pd.Class = Grd.Rows[row].Cells[3].Text;
            pd.Distance = Convert.ToDecimal(Grd.Rows[row].Cells[4].Text);
            pd.Rate = Convert.ToDecimal(Grd.Rows[row].Cells[5].Text);
            pd.Amount = Convert.ToDecimal(Grd.Rows[row].Cells[6].Text);
            objlist.Add(pd);
        }
        string xmlDoc = CommonCode.ConvertToXMLFormat<PL_Details_JourneyChild>(ref objlist);

        List<PL_Details_Family_Members> objlist1 = new List<PL_Details_Family_Members>();
        for (int row = 0; row < Grd1.Rows.Count; row++)
        {
            PL_Details_Family_Members pd1 = new PL_Details_Family_Members();
            pd1.Name = Grd1.Rows[row].Cells[0].Text;                   
            pd1.Age = Grd1.Rows[row].Cells[1].Text;
            pd1.Relation = Grd1.Rows[row].Cells[2].Text;            
            objlist1.Add(pd1);
        }
        string xmlDoc1 = CommonCode.ConvertToXMLFormat<PL_Details_Family_Members>(ref objlist1);

        int result = bl.Insert(pl, xmlDoc, xmlDoc1);
        if (result > 0)
        {
            Reset();
            bindgrdData();

            Messagebox.Show(pl.MSG);


        }
        else
        {

            Messagebox.Show(pl.MSG);

        }
    }

    private void bindgrdData()
    {
        pl.sptype = 3;
        DataTable dt = new DataTable();
        dt = bl.bindData(pl);
        if (dt.Rows.Count > 0)
        {
            grd_data.DataSource = dt;
            grd_data.DataBind();

        }
        else
        {
            grd_data.DataSource = null;
            grd_data.DataBind();

        }       

    }

    private void Reset()
    {
        ddlEmpType.SelectedIndex = 0;      
        ddlGpsMps.SelectedIndex = 0;      
        Ddl_advancerefNo.Items.Clear();
        lblamonut.Text = "";
        //ChildField               
        txtJourneyFrom.Text = "";
        txtJourneyTo.Text = "";
        txtModeofConveyance.Text = "";
        txtClass.Text = "";
        txtDistance.Text = "";
        txtRate.Text = "";
        txtDoJAmount.Text = "";

        btnSave.Text = "Save";
        btnSave.Visible = true;
        DataTable dt = new DataTable();
        dt.Columns.Add("JourneyFrom");
        dt.Columns.Add("JourneyTo");
        dt.Columns.Add("Mode_of_Conveyance");
        dt.Columns.Add("Class");
        dt.Columns.Add("Distance");
        dt.Columns.Add("Rate");
        dt.Columns.Add("Amount");
        ViewState["dt"] = dt;
        //Child2
        txtfamMemName.Text = "";
        ddlAge.SelectedItem.Text = "";
        ddlRelation.SelectedItem.Text = "";

        DataTable dt1 = new DataTable();
        dt.Columns.Add("Name");
        dt.Columns.Add("Age");
        dt.Columns.Add("Relation");
        ViewState["dt1"] = dt1;

        bindchildgrd();
        //bindchildgrd1();
        ddlEmpType.Enabled = true;
        ddlGpsMps.Enabled = true;
        ddl_emp.Enabled = true;
        Ddl_advancerefNo.Visible = true;
        reimburse.Visible = true;        
        btnSave.Visible = true;
        Ddl_advancerefNo.Enabled = true;


        //Parentdatareset
        lblShowName.Text = "";
        lblCorpOffice.Text = "";
        lblPersonalNo.Text = "";
        lblPayAccount.Text = "";
        lblBasicPay.Text = "";
        txtTransferedFrom.Text = "";
        txtRuleTrSr.Text = "";
        txtReferenceNo.Text = "";
        txtPlace.Text = "";
        txtDate.Text = "";
        txtDeparture.Text = "";
        txtArrival.Text = "";
        txtDailyAllAdult.Text = "";
        txtNoAdult.Text = "";
        txtAdultdays.Text = "";
        txtAdultAmount.Text = "";
        txtDailyallownMinors.Text = "";
        txtNoOfMinors.Text = "";
        txtMinorsDays.Text = "";
        txtMinorAmount.Text = "";
        txtluggage.Text = "";
        txtWeight.Text = "";
        txtLuggageConveyance.Text = "";
        txtCartageResBOffice.Text = "";
        txtCartageBookingOfficetoRes.Text = "";


    }



    protected void lnk_Click(object sender, EventArgs e)
    {

        GridViewRow gvr = (GridViewRow)((LinkButton)sender).NamingContainer;
        gvr.ForeColor = System.Drawing.Color.Red;
        int index = gvr.RowIndex;
        Label lbltabid = (Label)grd_data.Rows[index].FindControl("lbltabid");
        Label lbl = (Label)grd_data.Rows[index].FindControl("lblflag");
        Label refrenceno = (Label)grd_data.Rows[index].FindControl("lblrefrenceno");
        Label advance_amt = (Label)grd_data.Rows[index].FindControl("lbladvanceamt");

        pl.TABLEID = Convert.ToInt16(lbltabid.Text);
        pl.sptype = 5;

        DataTable dt = bl.getData(pl);
        if (dt.Rows.Count > 0)
        {

            ddlGpsMps.SelectedValue = dt.Rows[0]["GPS_NPS"].ToString();
            ddlFinancial.SelectedValue = dt.Rows[0]["fin_year"].ToString();
            string st = dt.Rows[0]["EmpType"].ToString();
            ddlEmpType.SelectedValue = st.Trim();
            bind_emp();
            ddl_emp.SelectedValue = dt.Rows[0]["ECODE"].ToString();
            //lblShowName.Text = dt.Rows[0]["EMP_NAME"].ToString();
            BindRefrenceno();
            lblflage.Text = dt.Rows[0]["freeze_flage"].ToString();
            lblRecordID.Text = dt.Rows[0]["TABID"].ToString();
            BindGridForEdit(Convert.ToInt32(lblRecordID.Text));
            BindGridForEdit1(Convert.ToInt32(lblRecordID.Text));
            if (Ddl_advancerefNo.Items.Count > 0 && refrenceno.Text != "")
            {
                Ddl_advancerefNo.SelectedValue = dt.Rows[0]["refrence_no"].ToString();
                Ddl_advancerefNo.SelectedValue = refrenceno.Text;

            }
            lblrefno.Text = "";
            if (Ddl_advancerefNo.Items.Count <= 0)
            {
                //Ddl_advancerefNo.Visible = false;
                lblrefno.Visible = true;
                lblrefno.Text = refrenceno.Text;
            }
            if (advance_amt.Text != "")
            {
                lblamonut.Text = advance_amt.Text;
            }

            ddlEmpType.Enabled = false;
            ddlGpsMps.Enabled = false;
            ddl_emp.Enabled = false;
            if (lblflage.Text == "Y")
            {
                Ddl_advancerefNo.Visible = false;
                reimburse.Visible = true;
                //BindRefrenceno();
                btnSave.Visible = false;
                Ddl_advancerefNo.Enabled = true;
            }
            else
            {
                Ddl_advancerefNo.Visible = true;
                // reimburse.Visible = false;
                btnSave.Visible = true;
            }

            lblShowName.Text = dt.Rows[0]["Emp_Name"].ToString();
            lblCorpOffice.Text = dt.Rows[0]["CorpOffice"].ToString();
            lblPersonalNo.Text = dt.Rows[0]["PersonalNo"].ToString();
            lblPayAccount.Text = dt.Rows[0]["PayAccount"].ToString();
            lblBasicPay.Text = dt.Rows[0]["BasicPay"].ToString();
            txtTransferedFrom.Text = dt.Rows[0]["TransferedFrom"].ToString();
            txtRuleTrSr.Text = dt.Rows[0]["RuleTrSr"].ToString();
            txtReferenceNo.Text = dt.Rows[0]["REFRENCENo"].ToString();
            txtPlace.Text = dt.Rows[0]["Place"].ToString();
            txtDate.Text = dt.Rows[0]["Date_of_L"].ToString();
            txtDeparture.Text = dt.Rows[0]["Departure"].ToString();
            txtArrival.Text = dt.Rows[0]["Arrival"].ToString();
            txtDailyAllAdult.Text = dt.Rows[0]["DailyAllowanceFor_Adults"].ToString();
            txtNoAdult.Text = dt.Rows[0]["NoOf_Adult"].ToString();
            txtAdultdays.Text = dt.Rows[0]["Days_Adults"].ToString();
            txtAdultAmount.Text = dt.Rows[0]["Amount_Adults"].ToString();
            txtDailyallownMinors.Text = dt.Rows[0]["DailyAllowanceFor_Minor"].ToString();
            txtNoOfMinors.Text = dt.Rows[0]["NoOf_Minor"].ToString();
            txtMinorsDays.Text = dt.Rows[0]["Days_Minor"].ToString();
            txtMinorAmount.Text = dt.Rows[0]["Amount_Minor"].ToString();
            txtluggage.Text = dt.Rows[0]["Luggage"].ToString();
            txtWeight.Text = dt.Rows[0]["Weight"].ToString();
            txtLuggageConveyance.Text = dt.Rows[0]["LuggageConveyance"].ToString();
            txtCartageResBOffice.Text = dt.Rows[0]["Cartage_Residence_Booking_Office"].ToString();
            txtCartageBookingOfficetoRes.Text = dt.Rows[0]["Cartage_Booking_Office_to_Residence"].ToString();


            btnSave.Text = "Update";
        }
    }
    protected void BindGridForEdit(int Rowid)
    {
        pl.sptype = 6;
        pl.TABLEID = Rowid;
        DataTable dtSaveRecord = new DataTable();
        dtSaveRecord = bl.bindData(pl);
        if (dtSaveRecord.Rows.Count > 0)
        {
            ViewState["dt"] = dtSaveRecord;
            

        }
     

        bindchildgrd();
    }
    protected void BindGridForEdit1(int Rowid)
    {
        pl.sptype = 10;
        pl.TABLEID = Rowid;
        DataTable dtSaveRecord1 = new DataTable();
        dtSaveRecord1 = bl.bindData1(pl);
        if (dtSaveRecord1.Rows.Count > 0)
        {            
            ViewState["dt1"] = dtSaveRecord1;
        }        
        bindchildgrd();
    }
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
        DataTable dt = ViewState["dt"] as DataTable;
        dt.Rows.RemoveAt(row.RowIndex);
        ViewState["dt"] = dt;
        bindchildgrd();
    }

    protected void lnkdelete1_Click(object sender, EventArgs e)
    {
        GridViewRow row = (sender as LinkButton).NamingContainer as GridViewRow;
        DataTable dt1 = ViewState["dt1"] as DataTable;
        dt1.Rows.RemoveAt(row.RowIndex);
        ViewState["dt1"] = dt1;
        bindchildgrd();
    }
    protected void masterdelete_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow grdRow = (GridViewRow)lnk.Parent.Parent;
            int rowIndex = grdRow.RowIndex;

            Label lbltabid = (Label)grd_data.Rows[rowIndex].FindControl("TABID");
            lbltabid.Text = lbltabid.Text;
            pl.TABLEID = Convert.ToInt32(lbltabid.Text);
            pl.sptype = 7;
            bl.Delete(pl);
            Messagebox.Show(pl.MSG);
            bindgrdData();
            Reset();
        }
        catch (Exception ex)
        {
            Messagebox.Show(ex.ToString());
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        Reset();
        Response.Redirect("Permanent_Transfer.aspx");
    }

    protected void btn_freeze_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow grdRow = (GridViewRow)lnk.Parent.Parent;
            int rowIndex = grdRow.RowIndex;
            Label lbltabid = (Label)grd_data.Rows[rowIndex].FindControl("lbltabid");
            Label refrenceno = (Label)grd_data.Rows[rowIndex].FindControl("lblrefrenceno");
            lbltabid.Text = lbltabid.Text;
            pl.TABLEID = Convert.ToInt32(lbltabid.Text);
            pl.refrence_no = refrenceno.Text;
            pl.ref_status = "Settled";
            pl.sptype = 8;
            pl.freeze_flage = "Y";

            bl.Freeze(pl);
            Messagebox.Show(pl.MSG);
            bindgrdData();
            Reset();

        }
        catch (Exception ex)
        {
            Messagebox.Show(ex.ToString());
        }
    }

    protected void Grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void grd_data_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow row in grd_data.Rows)
        {
            Label lbl = (Label)row.Cells[5].FindControl("lblflag");
            Label lblmsg = (Label)row.Cells[5].FindControl("lblfreeze");
            var linkButton = (LinkButton)row.Cells[5].FindControl("btn_freeze");
            //var lnk = (LinkButton)row.Cells[0].FindControl("lnkbtn");
            if (lbl.Text == "Y")
            {
                lblmsg.Visible = true;
                lblmsg.Text = "FREEZED";
                linkButton.Visible = false;
                //lnk.Visible = false;
            }
            else
            {
                lblmsg.Visible = false;
                linkButton.Visible = true;
                lbl.Text = "Freeze";

            }
        }
    }

    protected void ddl_emp_SelectedIndexChanged(object sender, EventArgs e)
    {
        string str = "";
        str = "select ESS.ECODE,ESS.BASIC,ESS.PAY_BAND,ESS.CUR_PAY_GRADE,ESS.IT_Amount,MEM.Emp_Name,MEM.DATE_OF_BIRTH,ESS.GPF_ACCT_NO from  M_Emp_mast MEM inner join EMP_SALARY_STRUCTURE ESS ON MEM.ECODE=ESS.ECODE Where  ESS.ECODE='" + ddl_emp.SelectedValue + "'";
        
        DataTable dt = SQL_DBCS.ExecuteDataTable(str);

        if (dt.Rows.Count > 0)
        {
            lblShowName.Text = dt.Rows[0]["EMP_NAME"].ToString();
           
            lblPersonalNo.Text = dt.Rows[0]["ECODE"].ToString();
            lblBasicPay.Text = dt.Rows[0]["BASIC"].ToString();
            lblPayAccount.Text = dt.Rows[0]["GPF_ACCT_NO"].ToString();
            //lblGPFNo.Text = dt.Rows[0]["GPF_ACCT_NO"].ToString();
            // lblRank.Text = ddlEmpType.SelectedItem.ToString();
            cc.FillDDL(ref ddlHdtrOffice, "---Select Department---", "DepartmentName", "DepartmentCode", "M_Department");
            ddlHdtrOffice.SelectedIndex = 1;
            lblCorpOffice.Text = ddlHdtrOffice.SelectedItem.ToString();


            BindRefrenceno();
        }
        else
        {
            lblShowName.Visible = false;
        }

        BindRefrenceno();
    }
    public void BindRefrenceno()
    {
        try
        {
            string str = "";
            str = "select * from Advance_Reimburse_Master where emp_pk='" + ddl_emp.SelectedValue + "' and ref_status='Pending' and Freeze_flag='Y' and Reimburse_Type='3'";
            DataTable dt = cc.EQ(str);
            if (dt.Rows.Count > 0)
            {
                Ddl_advancerefNo.DataTextField = "advance_refno";
                Ddl_advancerefNo.DataValueField = "advance_refno";
                Ddl_advancerefNo.DataSource = dt;
                Ddl_advancerefNo.DataBind();
                Ddl_advancerefNo.Items.Insert(0, "---Select ---");
            }
            else
            {                
                Ddl_advancerefNo.Items.Clear();
            }
        }
        catch (Exception ex)
        {
            Messagebox.Show(ex.Message);
        }
    }

    protected void Ddl_advancerefNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        string str = "";
        str = "select * from Advance_Reimburse_Master where advance_refno='" + Ddl_advancerefNo.SelectedValue + "' and ref_status='Pending' and Freeze_flag='Y'";
        DataTable dt = cc.EQ(str);
        if (dt.Rows.Count > 0)
        {
            lblamonut.Text = dt.Rows[0]["advance_amt"].ToString();
        }
    }

    protected void ddlGpsMps_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlEmpType.SelectedIndex = 0;
        ddl_emp.Items.Clear();
    }


   
}