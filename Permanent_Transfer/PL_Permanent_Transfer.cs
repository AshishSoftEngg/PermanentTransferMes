using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for PL_Permanent_Transfer
/// </summary>
public class PL_Permanent_Transfer
{
    public PL_Permanent_Transfer()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int sptype { get; set; }
    public int TableID { get; set; }
    public string ECODE { get; set; }
    public string EMP_NAME { get; set; }
    public string EmpType { get; set; }
    public string GPS_NPS { get; set; }
    public string fin_year { get; set; }

    public string CorpOffice { get; set; }
    public string PersonalNo { get; set; }
    public string PayAccount { get; set; }
    public decimal BasicPay { get; set; }

    public string TransferedFrom { get; set; }
    public string RuleTrSr { get; set; }
    public string REFRENCENo { get; set; }
    public string Place { get; set; }
    public string Date_of_L { get; set; }
    public string Departure { get; set; }
    public string Arrival {get; set;}


        public decimal DailyAllowanceFor_Adults { get; set; }

        public decimal NoOf_Adult { get; set; }

        public decimal Days_Adults { get; set; }

        public decimal Amount_Adults { get; set; }

        public decimal DailyAllowanceFor_Minor { get; set; }

        public decimal NoOf_Minor { get; set; }

        public decimal Days_Minor { get; set; }

        public decimal Amount_Minor { get; set; }

        public string Luggage { get; set; }

        public decimal Weight { get; set; }

        public decimal LuggageConveyance { get; set; }

        public string Cartage_Residence_Booking_Office { get; set; }

        public string Cartage_Booking_Office_to_Residence { get; set; }


    public string CreatedBy { get; set; }
    public string UpdatedBy { get; set; }
    public int TABLEID { get; set; }
    public string xml { get; set; }
    public string MSG { get; set; }
    public string freeze_flage { get; set; }
    public string refrence_no { get; set; }
    public string ref_status { get; set; }

}
public class PL_Details_JourneyChild
{
    public string JourneyFrom { get; set; }
    public string JourneyTo { get; set; }
    public string Mode_of_Conveyance { get; set; }
    public string Class { get; set; }
    public decimal Distance { get; set; }
    public decimal Rate { get; set; }
    public decimal Amount { get; set; }



}
public class PL_Details_Family_Members
{
    public string Name { get; set; }
    public decimal Age { get; set; }
    public decimal Relation { get; set; }

}