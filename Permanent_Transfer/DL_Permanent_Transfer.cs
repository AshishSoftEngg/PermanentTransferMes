using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.SqlTypes;
/// <summary>
/// Summary description for DL_Permanent_Transfer
/// </summary>
public class DL_Permanent_Transfer
{
    public DL_Permanent_Transfer()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    MyConnection con = new MyConnection();
    public int Insert(PL_Permanent_Transfer pl, string xmlDoc,string xmlDoc1)
    {
        con.cmd.CommandText = "USP_PERMANENT_TRANSFER";
        con.cmd.CommandType = CommandType.StoredProcedure;
        con.cmd.Parameters.AddWithValue("@sptype", pl.sptype);
        con.cmd.Parameters.AddWithValue("@ECODE", pl.ECODE);
        con.cmd.Parameters.AddWithValue("@EMP_NAME", pl.EMP_NAME);
        con.cmd.Parameters.AddWithValue("@EmpType", pl.EmpType);
        con.cmd.Parameters.AddWithValue("@fin_year", pl.fin_year);
        con.cmd.Parameters.AddWithValue("@GPS_NPS", pl.GPS_NPS);

        con.cmd.Parameters.AddWithValue("@CorpOffice", pl.CorpOffice);
        con.cmd.Parameters.AddWithValue("@PersonalNo", pl.PersonalNo);
        con.cmd.Parameters.AddWithValue("@PayAccount", pl.PayAccount);
        con.cmd.Parameters.AddWithValue("@BasicPay", pl.BasicPay);

        con.cmd.Parameters.AddWithValue("@TransferedFrom", pl.TransferedFrom);
        con.cmd.Parameters.AddWithValue("@RuleTrSr", pl.RuleTrSr);
        con.cmd.Parameters.AddWithValue("@REFRENCENo", pl.REFRENCENo);
        con.cmd.Parameters.AddWithValue("@Place", pl.Place);
        con.cmd.Parameters.AddWithValue("@Date_of_L", pl.Date_of_L);
        con.cmd.Parameters.AddWithValue("@Departure", pl.Departure);
        con.cmd.Parameters.AddWithValue("@Arrival", pl.Arrival);

        con.cmd.Parameters.AddWithValue("@DailyAllowanceFor_Adults", pl.DailyAllowanceFor_Adults);
        con.cmd.Parameters.AddWithValue("@NoOf_Adult", pl.NoOf_Adult);
        con.cmd.Parameters.AddWithValue("@Days_Adults", pl.Days_Adults);
        con.cmd.Parameters.AddWithValue("@Amount_Adults", pl.Amount_Adults);

        con.cmd.Parameters.AddWithValue("@DailyAllowanceFor_Minor", pl.DailyAllowanceFor_Minor);
        con.cmd.Parameters.AddWithValue("@NoOf_Minor", pl.NoOf_Minor);
        con.cmd.Parameters.AddWithValue("@Days_Minor", pl.Days_Minor);
        con.cmd.Parameters.AddWithValue("@Amount_Minor", pl.Amount_Minor);
        con.cmd.Parameters.AddWithValue("@Luggage", pl.Luggage);
        con.cmd.Parameters.AddWithValue("@Weight", pl.Weight);
        con.cmd.Parameters.AddWithValue("@LuggageConveyance", pl.LuggageConveyance);
        con.cmd.Parameters.AddWithValue("@Cartage_Residence_Booking_Office", pl.Cartage_Residence_Booking_Office);
        con.cmd.Parameters.AddWithValue("@Cartage_Booking_Office_to_Residence", pl.Cartage_Booking_Office_to_Residence);


        con.cmd.Parameters.AddWithValue("@TableID", pl.TableID);
        con.cmd.Parameters.AddWithValue("@freeze_flage", pl.freeze_flage);
        con.cmd.Parameters.AddWithValue("@refrence_no", pl.refrence_no);
        con.cmd.Parameters.AddWithValue("@CREATEDBY", pl.CreatedBy);
        con.cmd.Parameters.AddWithValue("@xmlDoc", xmlDoc);
        con.cmd.Parameters.AddWithValue("@xmlDoc1", xmlDoc1);

        SqlParameter p2 = new SqlParameter("@P_MSG", SqlDbType.VarChar, 200);
        p2.Direction = ParameterDirection.Output;
        con.cmd.Parameters.Add(p2);
        try
        {
            con.Open();
            int RetValue = con.cmd.ExecuteNonQuery();
            pl.MSG = con.cmd.Parameters["@P_MSG"].Value.ToString();
            return RetValue;
        }
        catch (Exception ex)
        {
            // pl.MSG = con.cmd.Parameters["@P_MSG"].Value.ToString();
            con.Close();
            return 0;
        }
        finally
        {
            con.Close();
            con.cmd.Dispose();
        }

    }

    internal DataTable bindData(PL_Permanent_Transfer pl)
    {

        con.cmd.CommandText = "USP_PERMANENT_TRANSFER";
        con.cmd.CommandType = CommandType.StoredProcedure;
        con.cmd.Parameters.AddWithValue("@SpType", pl.sptype);
        con.cmd.Parameters.AddWithValue("@TableID", pl.TABLEID);
        SqlParameter p2 = new SqlParameter("@P_MSG", SqlDbType.VarChar, 350);
        p2.Direction = ParameterDirection.Output;
        con.cmd.Parameters.Add(p2);
        SqlDataAdapter da = new SqlDataAdapter(con.cmd);
        DataTable ds = new DataTable();
        da.Fill(ds);
        return ds;

    }
    internal DataTable bindData1(PL_Permanent_Transfer pl)
    {

        con.cmd.CommandText = "USP_PERMANENT_TRANSFER";
        con.cmd.CommandType = CommandType.StoredProcedure;
        con.cmd.Parameters.AddWithValue("@SpType", pl.sptype);
        con.cmd.Parameters.AddWithValue("@TableID", pl.TABLEID);
        SqlParameter p2 = new SqlParameter("@P_MSG", SqlDbType.VarChar, 350);
        p2.Direction = ParameterDirection.Output;
        con.cmd.Parameters.Add(p2);
        SqlDataAdapter da = new SqlDataAdapter(con.cmd);
        DataTable ds = new DataTable();
        da.Fill(ds);
        return ds;

    }
    public DataTable getData(PL_Permanent_Transfer pl)
    {

        con.cmd.CommandText = "USP_PERMANENT_TRANSFER";
        con.cmd.CommandType = CommandType.StoredProcedure;
        con.cmd.Parameters.AddWithValue("@SpType", pl.sptype);
        con.cmd.Parameters.AddWithValue("@TableID", pl.TABLEID);

        SqlParameter p2 = new SqlParameter("@P_MSG", SqlDbType.VarChar, 350);
        p2.Direction = ParameterDirection.Output;
        con.cmd.Parameters.Add(p2);
        SqlDataAdapter da = new SqlDataAdapter(con.cmd);
        DataTable ds = new DataTable();
        da.Fill(ds);
        return ds;

    }
    public virtual int Delete(PL_Permanent_Transfer pl)
    {
        con.cmd.CommandText = "USP_PERMANENT_TRANSFER";
        con.cmd.CommandType = CommandType.StoredProcedure;
        con.cmd.Parameters.AddWithValue("@SpType", pl.sptype);
        con.cmd.Parameters.AddWithValue("@TableID", pl.TABLEID);

        SqlParameter p2 = new SqlParameter("@P_MSG", SqlDbType.VarChar, 2000);
        p2.Direction = ParameterDirection.Output;
        con.cmd.Parameters.Add(p2);
        System.Data.SqlTypes.SqlDateTime getDate;
        getDate = SqlDateTime.Null;

        try
        {
            con.Open();
            int RetValue = con.cmd.ExecuteNonQuery();
            con.Close();
            pl.MSG = con.cmd.Parameters["@P_MSG"].Value.ToString();
            return RetValue;
        }
        catch (Exception ex)
        {
            pl.MSG = ex.Message.ToString();
            return 0;
        }
        finally
        {
            if (con.Mycon.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.cmd.Dispose();
        }

    }

    public virtual int Freeze(PL_Permanent_Transfer pl)
    {
        MyConnection Mycon = new MyConnection();
        Mycon.cmd.CommandText = "USP_PERMANENT_TRANSFER";
        Mycon.cmd.CommandType = CommandType.StoredProcedure;
        Mycon.cmd.Parameters.AddWithValue("@sptype", pl.sptype);
        Mycon.cmd.Parameters.AddWithValue("@TABLEID", pl.TABLEID);
        Mycon.cmd.Parameters.AddWithValue("@refrence_no", pl.refrence_no);
        Mycon.cmd.Parameters.AddWithValue("@freeze_flage", pl.freeze_flage);
        Mycon.cmd.Parameters.AddWithValue("@ref_status", pl.ref_status);
        SqlParameter p2 = new SqlParameter("@P_MSG", SqlDbType.VarChar, 8000);
        p2.Direction = ParameterDirection.Output;
        Mycon.cmd.Parameters.Add(p2);

        try
        {
            Mycon.Open();
            int RetValue = Mycon.cmd.ExecuteNonQuery();
            pl.MSG = Mycon.cmd.Parameters["@P_MSG"].Value.ToString();
            return RetValue;
        }
        catch (Exception ex)
        {
            pl.MSG = ex.Message.ToString();
            return 0;
        }
        finally
        {
            if (Mycon.Mycon.State == ConnectionState.Open)
            {
                Mycon.Close();
            }
            Mycon.cmd.Dispose();
        }

    }
}