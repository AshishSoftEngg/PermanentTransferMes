USE [MES]
GO
/****** Object:  StoredProcedure [dbo].[USP_PERMANENT_TRANSFER]    Script Date: 27-Jan-20 7:59:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Select * from M_TuitionFee_Head
--Select * from M_TuitionFee_Child


ALTER Procedure [dbo].[USP_PERMANENT_TRANSFER] 
(
	@TableID int =null, 
	@ECODE varchar (50)= NULL,
	@EMP_NAME varchar (150) = NULL,
	@EmpType char (5) = NULL,
	@GPS_NPS varchar (50) = NULL,
	@fin_year char (9) = NULL,
	@freeze_flage char(1)=NULL,
	@refrence_no varchar(50)=NULL,
	@ref_status varchar(50)=NULL,  
	--NewParentTbl
	@CorpOffice varchar(150)=Null,
	@PersonalNo varchar(150) = NULL,
	@PayAccount varchar(150) = NULL,
	@BasicPay numeric(18,2) = NULL,

	@TransferedFrom varchar(100) = NULL,
	@RuleTrSr varchar(50) = NULL,
	@REFRENCENo varchar(30) = NULL,
	@Place varchar(200) = NULL,
	@Date_of_L varchar(20) = NULL,
	@Departure varchar(50) = NULL,
	@Arrival varchar(50) = NULL,

	@DailyAllowanceFor_Adults numeric(10,2) = NULL,
	@NoOf_Adult numeric(10,2) = NULL,
	@Days_Adults numeric(10,2) = NULL,
	@Amount_Adults numeric(10,2) = NULL,

	@DailyAllowanceFor_Minor numeric(10,2) = NULL,
	@NoOf_Minor numeric(10,2) = NULL,
	@Days_Minor numeric(10,2) = NULL,
	@Amount_Minor numeric(10,2) = NULL,

	@Luggage varchar(50) = NULL,
	@Weight numeric(10,2) = NULL,
	@LuggageConveyance numeric(10,2) = NULL,
	@Cartage_Residence_Booking_Office varchar(200) = NULL,
	@Cartage_Booking_Office_to_Residence varchar(200) = NULL,

	@CREATEDBY varchar (120) = NULL,			   
    @xmlDoc XML = null,
	@xmlDoc1 XML = null,    
    @P_MSG  varchar(max) output  , 
	 @sptype int
	
)
as 
BEGIN

if (@sptype=1)
begin	
--if exists (select* from PermanentTransfer_Head WHERE ECODE=@ECODE and fin_year=@fin_year)

--begin
--	set @P_MSG='Record Already Exist For '+ @EMP_NAME+' / Financial Year ' +@fin_year+'';
--end
--else
begin
  INSERT
  INTO PermanentTransfer_Head
    (	ECODE ,
		EMP_NAME,
		EmpType ,
		GPS_NPS,
		fin_year,

		CorpOffice,
		PersonalNo,
		PayAccount,
		BasicPay,
		TransferedFrom,
		RuleTrSr,
		REFRENCENo,
		Place,
		Date_of_L,
		Departure,
		Arrival,

		DailyAllowanceFor_Adults,
		NoOf_Adult,
		Days_Adults,
		Amount_Adults,
		DailyAllowanceFor_Minor,
		NoOf_Minor,
		Days_Minor,
		Amount_Minor,
		Luggage,
		Weight,
		LuggageConveyance,
		Cartage_Residence_Booking_Office,
		Cartage_Booking_Office_to_Residence,

		freeze_flage,
		refrence_no,
		CREATEDBY ,
		CREATEDDATE
    )
    VALUES
    (     
		@ECODE ,
		@EMP_NAME ,
		@EmpType ,      
		@GPS_NPS,
		@fin_year ,

		@CorpOffice,
		@PersonalNo,
		@PayAccount,
		@BasicPay,
		@TransferedFrom,
		@RuleTrSr,
		@REFRENCENo,
		@Place,
		@Date_of_L,
		@Departure,
		@Arrival,

		@DailyAllowanceFor_Adults,
		@NoOf_Adult,
		@Days_Adults,
		@Amount_Adults,
		@DailyAllowanceFor_Minor,
		@NoOf_Minor,
		@Days_Minor,
		@Amount_Minor,
		@Luggage,
		@Weight,
		@LuggageConveyance,
		@Cartage_Residence_Booking_Office,
		@Cartage_Booking_Office_to_Residence,

		@freeze_flage,
		@refrence_no,
		@CREATEDBY ,   
		GETDATE()
    )
	 SET @TableID = SCOPE_IDENTITY()

---Child data
Insert into Permanent_Transfer_DetailsJourney_Child(TAHEADID,JourneyFrom,JourneyTo,Mode_of_Conveyance,Class,Distance,Rate,Amount) 
		SELECT @TableID,
			ParamValues.Data.value('JourneyFrom[1]','varchar(120)'),			
			ParamValues.Data.value('JourneyTo[1]','varchar(120)'),
			ParamValues.Data.value('Mode_of_Conveyance[1]','varchar(60)'),
			ParamValues.Data.value('Class[1]','varchar(20)'),
			ParamValues.Data.value('Distance[1]','numeric(18,2)'),
			ParamValues.Data.value('Rate[1]','numeric(18,2)'),
			ParamValues.Data.value('Amount[1]','numeric(18,2)')

			from @xmlDoc.nodes('root/data') AS ParamValues (data)

---Child2 data
Insert into PermanentTransfer_FamilyMem_Child(TAHEADID,Name,Age,Relation) 
		SELECT @TableID,
			ParamValues.Data.value('Name[1]','varchar(120)'),						
			ParamValues.Data.value('Age[1]','varchar(120)'),
			ParamValues.Data.value('Relation[1]','varchar(120)')			
			from @xmlDoc1.nodes('root/data') AS ParamValues (data)
			
	set @P_MSG='Record Save Successfully.';
    
  end
END;
if(@SpType=2)--Update Data into T_DRCActivities
begin
Update PermanentTransfer_Head
set 
ECODE=@ECODE,
EMP_NAME=@EMP_NAME ,
EmpType=@EmpType ,      
GPS_NPS=@GPS_NPS,
fin_year=@fin_year ,
		CorpOffice=@CorpOffice,
		PersonalNo=@PersonalNo,
		PayAccount=@PayAccount,
		BasicPay=@BasicPay,
		TransferedFrom=@TransferedFrom,
		RuleTrSr=@RuleTrSr,
		REFRENCENo=@REFRENCENo,
		Place=@Place,
		Date_of_L=@Date_of_L,
		Departure=@Departure,
		Arrival=@Arrival,
		DailyAllowanceFor_Adults=@DailyAllowanceFor_Adults,
		NoOf_Adult=@NoOf_Adult,
		Days_Adults=@Days_Adults,
		Amount_Adults=@Amount_Adults,
		DailyAllowanceFor_Minor=@DailyAllowanceFor_Minor,
		NoOf_Minor=@NoOf_Minor,
		Days_Minor=@Days_Minor,
		Amount_Minor=@Amount_Minor,
		Luggage=@Luggage,
		Weight=@Weight,
		LuggageConveyance=@LuggageConveyance,
		Cartage_Residence_Booking_Office=@Cartage_Residence_Booking_Office,
		Cartage_Booking_Office_to_Residence=@Cartage_Booking_Office_to_Residence,
freeze_flage=@freeze_flage,
CREATEDBY=@CREATEDBY , 
refrence_no=@refrence_no,
UPDATEDDATE=getdate()
where TABID=@TableID
-----Child data
Delete from Permanent_Transfer_DetailsJourney_Child where TAHEADID=@TableID	

Insert into Permanent_Transfer_DetailsJourney_Child(taheadid,JourneyFrom,JourneyTo,Mode_of_Conveyance,Class,Distance,Rate,Amount) 
		SELECT @TableID,
			ParamValues.Data.value('JourneyFrom[1]','varchar(120)'),			
			ParamValues.Data.value('JourneyTo[1]','varchar(120)'),
			ParamValues.Data.value('Mode_of_Conveyance[1]','varchar(60)'),
			ParamValues.Data.value('Class[1]','varchar(20)'),
			ParamValues.Data.value('Distance[1]','numeric(18,2)'),
			ParamValues.Data.value('Rate[1]','numeric(18,2)'),
			ParamValues.Data.value('Amount[1]','numeric(18,2)')

			from @xmlDoc.nodes('root/data') AS ParamValues (data)
-----Child2 data
Delete from PermanentTransfer_FamilyMem_Child where TAHEADID=@TableID
Insert into PermanentTransfer_FamilyMem_Child(TAHEADID,Name,Age,Relation) 
		SELECT @TableID,
			ParamValues.Data.value('Name[1]','varchar(120)'),						
			ParamValues.Data.value('Age[1]','varchar(120)'),
			ParamValues.Data.value('Relation[1]','varchar(120)')			
			from @xmlDoc1.nodes('root/data') AS ParamValues (data)
			

			set @P_MSG='Record  Successfully Updated'
end

if(@SpType=3) --Bind Grid
begin

Select * from PermanentTransfer_Head
left outer join M_Designation_Type  on M_Designation_Type.DES_Type_Id= PermanentTransfer_Head.EmpType
left outer join Advance_Reimburse_Master  on Advance_Reimburse_Master.Advance_refno= PermanentTransfer_Head.refrence_no
end
if(@SpType=5) --Select Record to update
begin    
Select TABID,ECODE,EMP_NAME,EmpType,GPS_NPS,fin_year,freeze_flage,refrence_no,CREATEDBY,CorpOffice,
		PersonalNo,
		PayAccount,
		BasicPay,
		TransferedFrom,
		RuleTrSr,
		REFRENCENo,
		Place,
		Date_of_L,
		Departure,
		Arrival,
		DailyAllowanceFor_Adults,
		NoOf_Adult,
		Days_Adults,
		Amount_Adults,
		DailyAllowanceFor_Minor,
		NoOf_Minor,
		Days_Minor,
		Amount_Minor,
		Luggage,
		Weight,
		LuggageConveyance,
		Cartage_Residence_Booking_Office,
		Cartage_Booking_Office_to_Residence from PermanentTransfer_Head where TABID=@TableID
end     
if (@sptype=6)--edit Child table
		Begin
		Select JourneyFrom,JourneyTo,Mode_of_Conveyance,Class,Distance,Rate,Amount from Permanent_Transfer_DetailsJourney_Child where  TAHEADID=@TableID
		Select Name,Age,Relation from PermanentTransfer_FamilyMem_Child where  TAHEADID=@TableID
		end
		if (@sptype=10)--edit Child table
		Begin		
		Select Name,Age,Relation from PermanentTransfer_FamilyMem_Child where  TAHEADID=@TableID
		end
		if (@sptype=7)--DELETE HEAD AND CHILD
		Begin
		DELETE FROM PermanentTransfer_Head WHERE TABID=@TableID
		delete from Permanent_Transfer_DetailsJourney_Child where TAHEADID=@TableID
		set @P_MSG='Record Deleted Successfully!'	
		end

		if (@sptype=8)--Freeze HEAD AND CHILD
		Begin
		update  PermanentTransfer_Head 
		set
		    freeze_flage=@freeze_flage
			where TABID=@TableID
        update Advance_Reimburse_Master
		set 
		   ref_status=@ref_status
		   where advance_refno=@refrence_no
		set @P_MSG=' Record Successfully Frozen'
		end
		if(@SpType=9) --Bind Grid
begin
select Convert(varchar,( advance_Date))+ +'/' + advance_refno as Refrenceno from Advance_Reimburse_Master
end
end

