﻿using ConstantConnect.Repository.Entities.CRM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstantConnect.Repository.Entities.Contexts
{
    public class CRMContext : DbContext
    {
        public CRMContext()
            : base("name=CRMEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<New_clientroom> New_clientroom { get; set; }
        public virtual DbSet<Incident> Incident { get; set; }
        public virtual DbSet<New_clientequipmemtipdata> New_clientequipmemtipdata { get; set; }
        public virtual DbSet<New_clientequipment> New_clientequipment { get; set; }
        public virtual DbSet<New_documentation> New_documentation { get; set; }
        public virtual DbSet<New_documentfilename> New_documentfilename { get; set; }
        public virtual DbSet<new_clientrooms_warrantylines> new_clientrooms_warrantylines { get; set; }
        public virtual DbSet<New_Warranty> New_Warranty { get; set; }
        public virtual DbSet<New_manufacturer> New_manufacturer { get; set; }
        public virtual DbSet<New_clientequipmentdescription> New_clientequipmentdescription { get; set; }
        public virtual DbSet<New_clientequipmentstatus> New_clientequipmentstatus { get; set; }
        public virtual DbSet<New_clientequipmentfunction> New_clientequipmentfunction { get; set; }
        public virtual DbSet<SubjectBase> SubjectBase { get; set; }
        public virtual DbSet<new_clientroom_projectfile> new_clientroom_projectfile { get; set; }
        public virtual DbSet<StringMap> StringMaps { get; set; }

        //Stored Procedure Calls
        public virtual ObjectResult<Dashboard_ActiveRooms_Result> Dashboard_ActiveRooms(Nullable<System.Guid> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(System.Guid));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Dashboard_ActiveRooms_Result>("Dashboard_ActiveRooms", userIDParameter);
        }

        public virtual ObjectResult<Dashboard_ServiceTicketTrends_Result> Dashboard_ServiceTicketTrends(Nullable<System.Guid> userID, Nullable<System.DateTime> reportStart, Nullable<System.DateTime> reportEnd, string groupBy, Nullable<System.Guid> roomID, string subject)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(System.Guid));

            var reportStartParameter = reportStart.HasValue ?
                new ObjectParameter("ReportStart", reportStart) :
                new ObjectParameter("ReportStart", typeof(System.DateTime));

            var reportEndParameter = reportEnd.HasValue ?
                new ObjectParameter("ReportEnd", reportEnd) :
                new ObjectParameter("ReportEnd", typeof(System.DateTime));

            var groupByParameter = groupBy != null ?
                new ObjectParameter("GroupBy", groupBy) :
                new ObjectParameter("GroupBy", typeof(string));

            var roomIDParameter = roomID.HasValue ?
                new ObjectParameter("RoomID", roomID) :
                new ObjectParameter("RoomID", typeof(System.Guid));

            var subjectParameter = subject != null ?
                new ObjectParameter("Subject", subject) :
                new ObjectParameter("Subject", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Dashboard_ServiceTicketTrends_Result>("Dashboard_ServiceTicketTrends", userIDParameter, reportStartParameter, reportEndParameter, groupByParameter, roomIDParameter, subjectParameter);
        }

        public virtual ObjectResult<Equipment_ClientUpdate_Result> Equipment_ClientUpdate(Nullable<System.Guid> equipmentID, Nullable<System.Guid> clientRoomID, Nullable<System.Guid> serviceLocationID, Nullable<System.Guid> manufacturerID, Nullable<System.Guid> equipmentTypeID, Nullable<System.Guid> functionID, Nullable<System.Guid> statusID, string deviceName, string modelNumber, string serialNumber, string partNumber, string description, string location, string assetID, string barcode, string bENAssetTag, string bENAssetNumber, string firmware, Nullable<bool> loanable, string loanContactName, string loanContactInfo, string pONumber, string rMANumber, string wCITTag, string notes)
        {
            var equipmentIDParameter = equipmentID.HasValue ?
                new ObjectParameter("EquipmentID", equipmentID) :
                new ObjectParameter("EquipmentID", typeof(System.Guid));

            var clientRoomIDParameter = clientRoomID.HasValue ?
                new ObjectParameter("ClientRoomID", clientRoomID) :
                new ObjectParameter("ClientRoomID", typeof(System.Guid));

            var serviceLocationIDParameter = serviceLocationID.HasValue ?
                new ObjectParameter("ServiceLocationID", serviceLocationID) :
                new ObjectParameter("ServiceLocationID", typeof(System.Guid));

            var manufacturerIDParameter = manufacturerID.HasValue ?
                new ObjectParameter("ManufacturerID", manufacturerID) :
                new ObjectParameter("ManufacturerID", typeof(System.Guid));

            var equipmentTypeIDParameter = equipmentTypeID.HasValue ?
                new ObjectParameter("EquipmentTypeID", equipmentTypeID) :
                new ObjectParameter("EquipmentTypeID", typeof(System.Guid));

            var functionIDParameter = functionID.HasValue ?
                new ObjectParameter("FunctionID", functionID) :
                new ObjectParameter("FunctionID", typeof(System.Guid));

            var statusIDParameter = statusID.HasValue ?
                new ObjectParameter("StatusID", statusID) :
                new ObjectParameter("StatusID", typeof(System.Guid));

            var deviceNameParameter = deviceName != null ?
                new ObjectParameter("DeviceName", deviceName) :
                new ObjectParameter("DeviceName", typeof(string));

            var modelNumberParameter = modelNumber != null ?
                new ObjectParameter("ModelNumber", modelNumber) :
                new ObjectParameter("ModelNumber", typeof(string));

            var serialNumberParameter = serialNumber != null ?
                new ObjectParameter("SerialNumber", serialNumber) :
                new ObjectParameter("SerialNumber", typeof(string));

            var partNumberParameter = partNumber != null ?
                new ObjectParameter("PartNumber", partNumber) :
                new ObjectParameter("PartNumber", typeof(string));

            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));

            var locationParameter = location != null ?
                new ObjectParameter("Location", location) :
                new ObjectParameter("Location", typeof(string));

            var assetIDParameter = assetID != null ?
                new ObjectParameter("AssetID", assetID) :
                new ObjectParameter("AssetID", typeof(string));

            var barcodeParameter = barcode != null ?
                new ObjectParameter("Barcode", barcode) :
                new ObjectParameter("Barcode", typeof(string));

            var bENAssetTagParameter = bENAssetTag != null ?
                new ObjectParameter("BENAssetTag", bENAssetTag) :
                new ObjectParameter("BENAssetTag", typeof(string));

            var bENAssetNumberParameter = bENAssetNumber != null ?
                new ObjectParameter("BENAssetNumber", bENAssetNumber) :
                new ObjectParameter("BENAssetNumber", typeof(string));

            var firmwareParameter = firmware != null ?
                new ObjectParameter("Firmware", firmware) :
                new ObjectParameter("Firmware", typeof(string));

            var loanableParameter = loanable.HasValue ?
                new ObjectParameter("Loanable", loanable) :
                new ObjectParameter("Loanable", typeof(bool));

            var loanContactNameParameter = loanContactName != null ?
                new ObjectParameter("LoanContactName", loanContactName) :
                new ObjectParameter("LoanContactName", typeof(string));

            var loanContactInfoParameter = loanContactInfo != null ?
                new ObjectParameter("LoanContactInfo", loanContactInfo) :
                new ObjectParameter("LoanContactInfo", typeof(string));

            var pONumberParameter = pONumber != null ?
                new ObjectParameter("PONumber", pONumber) :
                new ObjectParameter("PONumber", typeof(string));

            var rMANumberParameter = rMANumber != null ?
                new ObjectParameter("RMANumber", rMANumber) :
                new ObjectParameter("RMANumber", typeof(string));

            var wCITTagParameter = wCITTag != null ?
                new ObjectParameter("WCITTag", wCITTag) :
                new ObjectParameter("WCITTag", typeof(string));

            var notesParameter = notes != null ?
                new ObjectParameter("Notes", notes) :
                new ObjectParameter("Notes", typeof(string));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Equipment_ClientUpdate_Result>("Equipment_ClientUpdate", equipmentIDParameter, clientRoomIDParameter, serviceLocationIDParameter, manufacturerIDParameter, equipmentTypeIDParameter, functionIDParameter, statusIDParameter, deviceNameParameter, modelNumberParameter, serialNumberParameter, partNumberParameter, descriptionParameter, locationParameter, assetIDParameter, barcodeParameter, bENAssetTagParameter, bENAssetNumberParameter, firmwareParameter, loanableParameter, loanContactNameParameter, loanContactInfoParameter, pONumberParameter, rMANumberParameter, wCITTagParameter, notesParameter);
        }

        public virtual ObjectResult<Dashboard_GetProjectFiles_Result> Dashboard_GetProjectFiles(Nullable<System.Guid> roomID)
        {
            var roomIDParameter = roomID.HasValue ?
                new ObjectParameter("RoomID", roomID) :
                new ObjectParameter("RoomID", typeof(System.Guid));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Dashboard_GetProjectFiles_Result>("Dashboard_GetProjectFiles", roomIDParameter);
        }

        public virtual ObjectResult<Document_Write_Result> Document_Write(Nullable<System.Guid> documentID, string name, Nullable<System.Guid> organizationID, Nullable<System.Guid> projectID, Nullable<System.Guid> projectRoomID, Nullable<System.Guid> clientRoomID, string notes, Nullable<int> type, Nullable<int> status, Nullable<bool> share)
        {
            var documentIDParameter = documentID.HasValue ?
                new ObjectParameter("DocumentID", documentID) :
                new ObjectParameter("DocumentID", typeof(System.Guid));

            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));

            var organizationIDParameter = organizationID.HasValue ?
                new ObjectParameter("OrganizationID", organizationID) :
                new ObjectParameter("OrganizationID", typeof(System.Guid));

            var projectIDParameter = projectID.HasValue ?
                new ObjectParameter("ProjectID", projectID) :
                new ObjectParameter("ProjectID", typeof(System.Guid));

            var projectRoomIDParameter = projectRoomID.HasValue ?
                new ObjectParameter("ProjectRoomID", projectRoomID) :
                new ObjectParameter("ProjectRoomID", typeof(System.Guid));

            var clientRoomIDParameter = clientRoomID.HasValue ?
                new ObjectParameter("ClientRoomID", clientRoomID) :
                new ObjectParameter("ClientRoomID", typeof(System.Guid));

            var notesParameter = notes != null ?
                new ObjectParameter("Notes", notes) :
                new ObjectParameter("Notes", typeof(string));

            var typeParameter = type.HasValue ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(int));

            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(int));

            var shareParameter = share.HasValue ?
                new ObjectParameter("Share", share) :
                new ObjectParameter("Share", typeof(bool));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Document_Write_Result>("Document_Write", documentIDParameter, nameParameter, organizationIDParameter, projectIDParameter, projectRoomIDParameter, clientRoomIDParameter, notesParameter, typeParameter, statusParameter, shareParameter);
        }
    }
}

