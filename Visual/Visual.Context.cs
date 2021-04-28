﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Visual
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class VisualEntities : DbContext
    {
        public VisualEntities()
            : base("name=VisualEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblMRPController> tblMRPController { get; set; }
        public virtual DbSet<tblShipping> tblShipping { get; set; }
        public virtual DbSet<tblShippingAction> tblShippingAction { get; set; }
        public virtual DbSet<tblShippingComment> tblShippingComment { get; set; }
        public virtual DbSet<tblShippingCommentType> tblShippingCommentType { get; set; }
        public virtual DbSet<tblShippingDetailStatus> tblShippingDetailStatus { get; set; }
        public virtual DbSet<tblShippingMasterStatus> tblShippingMasterStatus { get; set; }
        public virtual DbSet<tblShippingPart> tblShippingPart { get; set; }
        public virtual DbSet<tblShippingReasonCode> tblShippingReasonCode { get; set; }
        public virtual DbSet<tblShippingStatus> tblShippingStatus { get; set; }
        public virtual DbSet<vwShippingStatus> vwShippingStatus { get; set; }
        public virtual DbSet<vwShippingComments> vwShippingComments { get; set; }
        public virtual DbSet<vwShippingStatusHistory> vwShippingStatusHistory { get; set; }
        public virtual DbSet<tblOptions> tblOptions { get; set; }
        public virtual DbSet<tblPart> tblPart { get; set; }
        public virtual DbSet<tblPartBearing> tblPartBearing { get; set; }
        public virtual DbSet<tblPartDisp> tblPartDisp { get; set; }
        public virtual DbSet<tblPartPackage> tblPartPackage { get; set; }
        public virtual DbSet<tblPartPort> tblPartPort { get; set; }
        public virtual DbSet<tblPartSeal> tblPartSeal { get; set; }
        public virtual DbSet<tblPartSeries> tblPartSeries { get; set; }
        public virtual DbSet<tblPartShaft> tblPartShaft { get; set; }
        public virtual DbSet<tblPartSpecial> tblPartSpecial { get; set; }
        public virtual DbSet<tblPath> tblPath { get; set; }
        public virtual DbSet<tblPartRineerMotor> tblPartRineerMotor { get; set; }
        public virtual DbSet<tblPartRineerMotorType> tblPartRineerMotorType { get; set; }
        public virtual DbSet<tblPartRineerPath> tblPartRineerPath { get; set; }
        public virtual DbSet<vwPartRineerMatch2> vwPartRineerMatch2 { get; set; }
        public virtual DbSet<vwPartBomValueStream> vwPartBomValueStream { get; set; }
        public virtual DbSet<tblPartFolder> tblPartFolder { get; set; }
        public virtual DbSet<tblPartFolderPPT> tblPartFolderPPT { get; set; }
        public virtual DbSet<tblPartFolderPPTPics> tblPartFolderPPTPics { get; set; }
        public virtual DbSet<tblDSB_Status> tblDSB_Status { get; set; }
        public virtual DbSet<tblValueStream> tblValueStream { get; set; }
        public virtual DbSet<tblValueMachine> tblValueMachine { get; set; }
        public virtual DbSet<tblValueMachineWC> tblValueMachineWC { get; set; }
        public virtual DbSet<tblValueMachineSetup> tblValueMachineSetup { get; set; }
        public virtual DbSet<tblValueMachineCastings> tblValueMachineCastings { get; set; }
        public virtual DbSet<tblValueMachinePartSetup> tblValueMachinePartSetup { get; set; }
        public virtual DbSet<tblValueMachineOpList> tblValueMachineOpList { get; set; }
        public virtual DbSet<tblValueMachineOrder> tblValueMachineOrder { get; set; }
        public virtual DbSet<tblValueMachineOrderOp> tblValueMachineOrderOp { get; set; }
        public virtual DbSet<tblValueMachineOrderStatus> tblValueMachineOrderStatus { get; set; }
        public virtual DbSet<tblValueMachinePart> tblValueMachinePart { get; set; }
        public virtual DbSet<tblValueMachineStatus> tblValueMachineStatus { get; set; }
        public virtual DbSet<vwValueMachineOrder> vwValueMachineOrder { get; set; }
        public virtual DbSet<vwSerialPartWO> vwSerialPartWO { get; set; }
        public virtual DbSet<tblValueMachineCastingPart> tblValueMachineCastingPart { get; set; }
        public virtual DbSet<tblValueMachineCommentType> tblValueMachineCommentType { get; set; }
        public virtual DbSet<tblValueMachineOrderComment> tblValueMachineOrderComment { get; set; }
        public virtual DbSet<tblValueMachineWCSetup> tblValueMachineWCSetup { get; set; }
        public virtual DbSet<vwValueMachinePartCross> vwValueMachinePartCross { get; set; }
        public virtual DbSet<vwValueMachinePartCrossExt> vwValueMachinePartCrossExt { get; set; }
        public virtual DbSet<tblValueMachineOpArea> tblValueMachineOpArea { get; set; }
        public virtual DbSet<tblValueMachineOpListWC> tblValueMachineOpListWC { get; set; }
        public virtual DbSet<tblCustomerNumber> tblCustomerNumber { get; set; }
        public virtual DbSet<vwValueMachinePartCast_Search> vwValueMachinePartCast_Search { get; set; }
        public virtual DbSet<vwPartBOM> vwPartBOM { get; set; }
        public virtual DbSet<tblIssue> tblIssue { get; set; }
        public virtual DbSet<tblPrinter> tblPrinter { get; set; }
        public virtual DbSet<tblKitter> tblKitter { get; set; }
        public virtual DbSet<tblKitterLog> tblKitterLog { get; set; }
        public virtual DbSet<tblKitterStatus> tblKitterStatus { get; set; }
        public virtual DbSet<tblKitterAuditError> tblKitterAuditError { get; set; }
        public virtual DbSet<vwKitter> vwKitter { get; set; }
        public virtual DbSet<vwKitterAudited> vwKitterAudited { get; set; }
        public virtual DbSet<tblPartBOMComp> tblPartBOMComp { get; set; }
        public virtual DbSet<tblPartBOMParent> tblPartBOMParent { get; set; }
        public virtual DbSet<tblKitterAuditQuestions> tblKitterAuditQuestions { get; set; }
        public virtual DbSet<tblBuilding> tblBuilding { get; set; }
        public virtual DbSet<tblValueMachineHealth> tblValueMachineHealth { get; set; }
        public virtual DbSet<tblKitterAudit> tblKitterAudit { get; set; }
        public virtual DbSet<tblValueMachineDown> tblValueMachineDown { get; set; }
        public virtual DbSet<tblValueMachineReasonCodes> tblValueMachineReasonCodes { get; set; }
        public virtual DbSet<vwValueMachineComment_History> vwValueMachineComment_History { get; set; }
        public virtual DbSet<vwValueMachineDown> vwValueMachineDown { get; set; }
        public virtual DbSet<vwPartFolderSHID> vwPartFolderSHID { get; set; }
        public virtual DbSet<vwPartBOM_Details> vwPartBOM_Details { get; set; }
        public virtual DbSet<tblPartModelCodeBreakdown> tblPartModelCodeBreakdown { get; set; }
        public virtual DbSet<tblSparePartsDelivery> tblSparePartsDelivery { get; set; }
        public virtual DbSet<tblSparePartsDeliveryStatus> tblSparePartsDeliveryStatus { get; set; }
        public virtual DbSet<tblSparePartsDeliveryRole> tblSparePartsDeliveryRole { get; set; }
        public virtual DbSet<tblSparePartsInspections> tblSparePartsInspections { get; set; }
        public virtual DbSet<tblSparePartsInspQuestions> tblSparePartsInspQuestions { get; set; }
        public virtual DbSet<tblSparePartsComments> tblSparePartsComments { get; set; }
        public virtual DbSet<tblValueMachineSupplier> tblValueMachineSupplier { get; set; }
        public virtual DbSet<tblValueMachineOrderOpManualConfirm> tblValueMachineOrderOpManualConfirm { get; set; }
        public virtual DbSet<tblValueMachineOrderOpManualConfirmErr> tblValueMachineOrderOpManualConfirmErr { get; set; }
        public virtual DbSet<vwValueMachineOrderManualConfirmErr> vwValueMachineOrderManualConfirmErr { get; set; }
        public virtual DbSet<vwValueMachineOrderLostCapacity> vwValueMachineOrderLostCapacity { get; set; }
        public virtual DbSet<vwValueMachineOrderOp> vwValueMachineOrderOp { get; set; }
        public virtual DbSet<tblValueMachineOrderCastingEmail> tblValueMachineOrderCastingEmail { get; set; }
        public virtual DbSet<tblValueMachineScrapCode> tblValueMachineScrapCode { get; set; }
        public virtual DbSet<tblValueMachinePC> tblValueMachinePC { get; set; }
        public virtual DbSet<tblValueMachinePCLink> tblValueMachinePCLink { get; set; }
        public virtual DbSet<tblValueMachinePrinter> tblValueMachinePrinter { get; set; }
        public virtual DbSet<tblValueMachineWC_VMID> tblValueMachineWC_VMID { get; set; }
        public virtual DbSet<tblValueMachinePCPrinters> tblValueMachinePCPrinters { get; set; }
        public virtual DbSet<vwValueMachineOrderOpCon_SAP> vwValueMachineOrderOpCon_SAP { get; set; }
        public virtual DbSet<vwValueMachineOrderManualConfirm> vwValueMachineOrderManualConfirm { get; set; }
        public virtual DbSet<vwValueMachineOrderManualConfirmLog_Last> vwValueMachineOrderManualConfirmLog_Last { get; set; }
        public virtual DbSet<vwValueMachineOrderOpManualConfirmQUE> vwValueMachineOrderOpManualConfirmQUE { get; set; }
        public virtual DbSet<vwSparePartsInspectionsSumUp> vwSparePartsInspectionsSumUp { get; set; }
        public virtual DbSet<vwSparePartsInspectionsTotals> vwSparePartsInspectionsTotals { get; set; }
        public virtual DbSet<aaaPKOldLeakTest> aaaPKOldLeakTest { get; set; }
        public virtual DbSet<tblFPYBreaks> tblFPYBreaks { get; set; }
        public virtual DbSet<tblFPYResults> tblFPYResults { get; set; }
        public virtual DbSet<tblFPYTargets> tblFPYTargets { get; set; }
        public virtual DbSet<tblLeakTestCycleTime> tblLeakTestCycleTime { get; set; }
        public virtual DbSet<tblFPYResultsTest> tblFPYResultsTest { get; set; }
        public virtual DbSet<tblFPYTargetsTest> tblFPYTargetsTest { get; set; }
        public virtual DbSet<tblTestStandCycleTime> tblTestStandCycleTime { get; set; }
    
        public virtual int p_tblShipping_DSB_v4(Nullable<int> oPID, Nullable<int> sHCTID, Nullable<int> cnt, string sH_Desc, string cSN_Desc, string pART_Desc, string mRP, string location, string packed, Nullable<int> export, Nullable<int> goTo, string start, string end)
        {
            var oPIDParameter = oPID.HasValue ?
                new ObjectParameter("OPID", oPID) :
                new ObjectParameter("OPID", typeof(int));
    
            var sHCTIDParameter = sHCTID.HasValue ?
                new ObjectParameter("SHCTID", sHCTID) :
                new ObjectParameter("SHCTID", typeof(int));
    
            var cntParameter = cnt.HasValue ?
                new ObjectParameter("Cnt", cnt) :
                new ObjectParameter("Cnt", typeof(int));
    
            var sH_DescParameter = sH_Desc != null ?
                new ObjectParameter("SH_Desc", sH_Desc) :
                new ObjectParameter("SH_Desc", typeof(string));
    
            var cSN_DescParameter = cSN_Desc != null ?
                new ObjectParameter("CSN_Desc", cSN_Desc) :
                new ObjectParameter("CSN_Desc", typeof(string));
    
            var pART_DescParameter = pART_Desc != null ?
                new ObjectParameter("PART_Desc", pART_Desc) :
                new ObjectParameter("PART_Desc", typeof(string));
    
            var mRPParameter = mRP != null ?
                new ObjectParameter("MRP", mRP) :
                new ObjectParameter("MRP", typeof(string));
    
            var locationParameter = location != null ?
                new ObjectParameter("Location", location) :
                new ObjectParameter("Location", typeof(string));
    
            var packedParameter = packed != null ?
                new ObjectParameter("Packed", packed) :
                new ObjectParameter("Packed", typeof(string));
    
            var exportParameter = export.HasValue ?
                new ObjectParameter("Export", export) :
                new ObjectParameter("Export", typeof(int));
    
            var goToParameter = goTo.HasValue ?
                new ObjectParameter("GoTo", goTo) :
                new ObjectParameter("GoTo", typeof(int));
    
            var startParameter = start != null ?
                new ObjectParameter("Start", start) :
                new ObjectParameter("Start", typeof(string));
    
            var endParameter = end != null ?
                new ObjectParameter("End", end) :
                new ObjectParameter("End", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_tblShipping_DSB_v4", oPIDParameter, sHCTIDParameter, cntParameter, sH_DescParameter, cSN_DescParameter, pART_DescParameter, mRPParameter, locationParameter, packedParameter, exportParameter, goToParameter, startParameter, endParameter);
        }
    
        public virtual int p_tblValueMachinePart_Add(string part)
        {
            var partParameter = part != null ?
                new ObjectParameter("Part", part) :
                new ObjectParameter("Part", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_tblValueMachinePart_Add", partParameter);
        }
    
        public virtual int p_tblValueMachineOrderOpManualConfirmLog_Add(Nullable<int> vVID, Nullable<int> vQID)
        {
            var vVIDParameter = vVID.HasValue ?
                new ObjectParameter("VVID", vVID) :
                new ObjectParameter("VVID", typeof(int));
    
            var vQIDParameter = vQID.HasValue ?
                new ObjectParameter("VQID", vQID) :
                new ObjectParameter("VQID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("p_tblValueMachineOrderOpManualConfirmLog_Add", vVIDParameter, vQIDParameter);
        }
    }
}