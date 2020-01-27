using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BL_Permanent_Transfer
/// </summary>
public class BL_Permanent_Transfer
{
    public BL_Permanent_Transfer()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Insert(PL_Permanent_Transfer pl, string xmlDoc, string xmlDoc1)
    {
        DL_Permanent_Transfer obj = new DL_Permanent_Transfer();
        return obj.Insert(pl, xmlDoc, xmlDoc1);
    }

    public DataTable bindData(PL_Permanent_Transfer pl)
    {
        DL_Permanent_Transfer obj = new DL_Permanent_Transfer();
        return obj.bindData(pl);
    }
    public DataTable bindData1(PL_Permanent_Transfer pl)
    {
        DL_Permanent_Transfer obj = new DL_Permanent_Transfer();
        return obj.bindData1(pl);
    }

    public DataTable getData(PL_Permanent_Transfer pl)
    {
        DL_Permanent_Transfer obj = new DL_Permanent_Transfer();
        return obj.getData(pl);
    }
    public virtual int Delete(PL_Permanent_Transfer pl)
    {
        DL_Permanent_Transfer objDAL = new DL_Permanent_Transfer();
        return objDAL.Delete(pl);
    }

    public virtual int Freeze(PL_Permanent_Transfer pl)
    {
        DL_Permanent_Transfer objDAL = new DL_Permanent_Transfer();
        return objDAL.Freeze(pl);
    }
}