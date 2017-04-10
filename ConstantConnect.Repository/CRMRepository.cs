using ConstantConnect.Repository.Entities.Contexts;
using ConstantConnect.Repository.Entities.CRM;
using ConstantConnect.Repository.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ConstantConnect.Repository
{
    public class CRMRepository : ICRMRepository
    {
        CRMContext _CRMcontext;

        #region Constructors
        public CRMRepository(CRMContext crmContext)
        {
            _CRMcontext = crmContext;
            _CRMcontext.Configuration.LazyLoadingEnabled = false;
        }

        #endregion

        #region Incident

        public Incident GetIncident(Guid id, Guid? new_clientroomId)
        {
            return _CRMcontext.Incident.FirstOrDefault(e => e.IncidentId == id && (new_clientroomId == null || e.New_ClientRoomId == new_clientroomId));
        }

        public IQueryable<Incident> GetIncidents(Guid? new_clientroomId)
        {
            var correctEntity = _CRMcontext.New_clientroom.FirstOrDefault(x => x.New_clientroomId == new_clientroomId);
            if (correctEntity != null)
                return _CRMcontext.Incident.Where(x => x.New_ClientRoomId == new_clientroomId);
            else
                return null;
        }

        public IQueryable<Incident> GetIncidents()
        {
            return _CRMcontext.Incident;
        }

        #endregion

        #region New_clientequipmemtipdata

        public New_clientequipmemtipdata GetNew_clientequipmentipdata(Guid id, Guid? new_clientroomId)
        {
            return _CRMcontext.New_clientequipmemtipdata.FirstOrDefault(e => e.New_clientequipmemtipdataId == id && (new_clientroomId == null || e.New_ClientRoomId == new_clientroomId));
        }

        public IQueryable<New_clientequipmemtipdata> GetNew_clientequipmentipdatas(Guid? new_clientroomId)
        {
            var correctEntity = _CRMcontext.New_clientroom.FirstOrDefault(x => x.New_clientroomId == new_clientroomId);
            if (correctEntity != null)
                return _CRMcontext.New_clientequipmemtipdata.Where(x => x.New_ClientRoomId == new_clientroomId);
            else
                return null;
        }

        public IQueryable<New_clientequipmemtipdata> GetNew_clientequipmemtipdatas()
        {
            return _CRMcontext.New_clientequipmemtipdata;
        }

        #endregion

        #region New_clientequipment
        //public New_clientequipment GetNew_clientequipment(Guid id)
        //{
        //    try
        //    {
        //        var result = _CRMcontext.New_clientequipment.FirstOrDefault(e => e.New_clientequipmentId == id);
        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw;
        //    }
        //}
        public New_clientequipment GetNew_clientequipment(Guid id, Guid? new_clientroomId)
        {
            try
            {
                var result = _CRMcontext.New_clientequipment.FirstOrDefault(e => e.New_clientequipmentId == id && (new_clientroomId == null || e.New_ClientRoomEquipmentId == new_clientroomId));
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        public IQueryable<New_clientequipment> GetNew_clientequipmentForRoom(Guid? new_clientRoomId)
        {
            var correctEntity = _CRMcontext.New_clientroom.FirstOrDefault(x => x.New_clientroomId == new_clientRoomId);
            if (correctEntity != null)
            {
                var result = _CRMcontext.New_clientequipment.Where(x => x.New_ClientRoomEquipmentId == new_clientRoomId);
                return result;
            }

            else
                return null;
        }
        public RepositoryActionResult<New_clientequipment> UpdateNew_clientequipment(New_clientequipment entity)
        {
            try
            {
                var existingEntity = _CRMcontext.New_clientequipment.FirstOrDefault(e => e.New_clientequipmentId == entity.New_clientequipmentId);
                if (existingEntity == null)
                {
                    return new RepositoryActionResult<New_clientequipment>(entity, RepositoryActionStatus.NotFound);
                }
                //Change the original entity status to detached, otherwise, we get an err on attach.
                //because the entity is already in the dbset.


                var result = _CRMcontext.Database.SqlQuery<Entities.CRM.Equipment_ClientUpdate_Result>("Equipment_ClientUpdate @EquipmentID, @ClientRoomID, @ServiceLocationID, @ManufacturerID, @EquipmentTypeID, @FunctionID, @StatusID, @DeviceName, @ModelNumber ,@SerialNumber ,@PartNumber ,@Description ,@Location ,@AssetID ,@Barcode ,@BENAssetTag ,@BENAssetNumber ,@Firmware ,@Loanable ,@LoanContactName ,@LoanContactInfo ,@PONumber ,@RMANumber ,WCITTag ,@Notes",
                new SqlParameter() { ParameterName = "@EquipmentID", Value = entity.New_clientequipmentId == null ? DBNull.Value : (object)entity.New_clientequipmentId },
                new SqlParameter() { ParameterName = "@ClientRoomID", Value = entity.New_ClientRoomEquipmentId == null ? DBNull.Value : (object)entity.New_ClientRoomEquipmentId },
                new SqlParameter() { ParameterName = "@ServiceLocationID", Value = entity.new_ServiceEquipmentId == null ? DBNull.Value : (object)entity.new_ServiceEquipmentId },
                new SqlParameter() { ParameterName = "@ManufacturerID", Value = entity.New_ManufacturerId == null ? DBNull.Value : (object)entity.New_ManufacturerId },
                new SqlParameter() { ParameterName = "@EquipmentTypeID", Value = entity.New_EquipmentType == null ? DBNull.Value : (object)entity.New_EquipmentType },
                new SqlParameter() { ParameterName = "@FunctionID", Value = entity.New_EquipmentFunctionId == null ? DBNull.Value : (object)entity.New_EquipmentFunctionId },
                new SqlParameter() { ParameterName = "@StatusID", Value = entity.New_EquipmentStatusId == null ? DBNull.Value : (object)entity.New_EquipmentStatusId },
                new SqlParameter() { ParameterName = "@DeviceName", Value = entity.New_name == null ? DBNull.Value : (object)entity.New_name},
                new SqlParameter() { ParameterName = "@ModelNumber", Value = entity.New_ModelNumber == null ? DBNull.Value : (object)entity.New_ModelNumber },
                new SqlParameter() { ParameterName = "@SerialNumber", Value = entity.New_SerialNumber == null ? DBNull.Value : (object)entity .New_SerialNumber},
                new SqlParameter() { ParameterName = "@PartNumber", Value = entity.New_PartNumber == null ? DBNull.Value : (object)entity.New_PartNumber },
                new SqlParameter() { ParameterName = "@Description", Value = entity.New_ComponentDescription == null ? DBNull.Value : (object)entity.New_ComponentDescription},
                new SqlParameter(){ParameterName="@Location", Value = entity.New_ComponentLocation == null ? DBNull.Value : (object)entity.New_ComponentLocation },
                new SqlParameter(){ParameterName="@AssetID", Value = entity.New_AssetID == null ? DBNull.Value : (object)entity.New_AssetID},
                new SqlParameter(){ParameterName="@Barcode", Value = entity.New_Barcode == null ? DBNull.Value : (object)entity.New_Barcode },
                new SqlParameter(){ParameterName="@BENAssetTag", Value = entity.New_MiscTag == null ? DBNull.Value : (object)entity .New_MiscTag},
                new SqlParameter(){ParameterName="@BENAssetNumber", Value = entity.New_BENAssetNumber == null ? DBNull.Value : (object)entity.New_BENAssetNumber },
                new SqlParameter(){ParameterName="@Firmware", Value = entity.New_Firmware == null ? DBNull.Value : (object)entity.New_Firmware },
                new SqlParameter(){ParameterName="@Loanable", Value = entity.New_Loanable == null ? DBNull.Value : (object)entity.New_Loanable },
                new SqlParameter(){ParameterName="@LoanContactName", Value = entity.New_LoanContactName == null ? DBNull.Value : (object)entity.New_LoanContactName },
                new SqlParameter(){ParameterName="@LoanContactInfo", Value = entity.New_LoanContactInfo == null ? DBNull.Value : (object)entity.New_LoanContactInfo },
                new SqlParameter(){ParameterName="@PONumber", Value = entity.New_PartNumber == null ? DBNull.Value : (object)entity.New_PartNumber },
                new SqlParameter(){ParameterName="@RMANumber", Value = entity.New_RMANumber == null ? DBNull.Value : (object)entity.New_RMANumber },
                new SqlParameter(){ParameterName="@WCITTag", Value = entity.New_WCITTag == null ? DBNull.Value : (object)entity.New_WCITTag },
                new SqlParameter(){ParameterName="@Notes", Value = entity.New_EquipmentNotes == null ? DBNull.Value : (object)entity.New_EquipmentNotes }).ToList();




                //_CRMcontext.Entry(existingEntity).State = System.Data.Entity.EntityState.Detached;

                //_CRMcontext.New_clientequipment.Attach(entity);
                //_CRMcontext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                //var result = _CRMcontext.SaveChanges();
                var updated = result.FirstOrDefault(r => r.Updated.HasValue);
                if (updated.Updated == true)
                    return new RepositoryActionResult<New_clientequipment>(entity, RepositoryActionStatus.Updated);
                else
                    return new RepositoryActionResult<New_clientequipment>(entity, RepositoryActionStatus.NothingModified, null);
            }
            catch (Exception e)
            {
                return new RepositoryActionResult<New_clientequipment>(null, RepositoryActionStatus.Error, e);
            }
        }
        #endregion

        #region New_documentation

        //public New_documentation GetNew_documentation(Guid id)
        //{
        //    try
        //    {
        //        var result = _CRMcontext.New_documentation.FirstOrDefault(e => e.New_documentationId == id);
        //        return result;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw;
        //    }
        //}

        public New_documentation GetNew_documentation(Guid id, Guid? new_clientroomId)
        {
            try
            {
                var result = _CRMcontext.New_documentation.FirstOrDefault(e => e.New_documentationId == id && (new_clientroomId == null || e.New_ClientRoomId == new_clientroomId));
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public IQueryable<New_documentation> GetNew_documentation(Guid? new_clientRoomId)
        {
            var correctEntity = _CRMcontext.New_documentation.FirstOrDefault(x => x.New_ClientRoomId == new_clientRoomId);
            if (correctEntity != null)
            {
                var result = _CRMcontext.New_documentation.Where(x => x.New_ClientRoomId == new_clientRoomId);
                return result;
            }

            else
                return null;
        }

        #endregion

        #region new_clientrooms_warrantylines
        public IQueryable<new_clientrooms_warrantylines> Getnew_clientrooms_warrantylines(Guid new_clientroomId)
        {
            var correctEntity = _CRMcontext.New_clientroom.FirstOrDefault(x => x.New_clientroomId == new_clientroomId);
            if (correctEntity != null)
            {
                var result = _CRMcontext.new_clientrooms_warrantylines.Where(x => x.new_clientroomid == new_clientroomId);
                return result;
            }

            else
                return null;
        }

        #endregion

        #region New_Warranty

        public IQueryable<New_Warranty> GetNew_Warranty(Guid new_clientroomId)
        {
            var list = from line in _CRMcontext.new_clientrooms_warrantylines
                       where line.new_clientroomid.Equals(new_clientroomId)
                       select line.new_warrantyid;

            if (list != null)
            {
                var result = _CRMcontext.New_Warranty.Where(w => list.Contains(w.New_WarrantyId) && w.StatusCode == 1);
                return result;
            }

            else
                return null;
        }

        #endregion

        #region New_clientroom
        public New_clientroom GetNew_clientroom(Guid id)
        {
            return _CRMcontext.New_clientroom.FirstOrDefault(x => x.New_clientroomId == id);
        }

        public New_clientroom GetNew_clientroomWithIncidents(Guid id)
        {
            return _CRMcontext.New_clientroom.Include("Incident").FirstOrDefault(x => x.New_clientroomId == id);
        }

        public New_clientroom GetNew_clientroomWithNew_clientequipmentipdatas(Guid id)
        {
            var correctEntity = _CRMcontext.New_clientroom.FirstOrDefault(x => x.New_clientroomId == id);
            if (correctEntity != null)
            {
                correctEntity.New_clientequipmemtipdata = _CRMcontext.New_clientequipmemtipdata.Where(x => x.New_ClientRoomId == id).ToList();
                return correctEntity;
            }
            else
                return null;
            //var result = _CRMcontext.New_clientroom.Include("New_clientequipmentipdata").FirstOrDefault(x => x.New_clientroomId == id);
            //return result;
        }

        public New_clientroom GetNew_clientroomWithIncidentsAndNew_clientequipmentipdatas(Guid id)
        {
            try
            {
                var correctEntity = _CRMcontext.New_clientroom.FirstOrDefault(x => x.New_clientroomId == id);
                if (correctEntity != null)
                {
                    correctEntity.New_clientequipmemtipdata = _CRMcontext.New_clientequipmemtipdata.Where(x => x.New_ClientRoomId == id).ToList();
                    correctEntity.Incident = _CRMcontext.Incident.Where(x => x.New_ClientRoomId == id).ToList();
                    return correctEntity;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw;
            }
        }
        public New_clientroom GetNew_clientroomWithIncidentsAndNew_clientequipmentipdatasAndNew_clientequipment(Guid id)
        {
            try
            {
                var correctEntity = _CRMcontext.New_clientroom.FirstOrDefault(x => x.New_clientroomId == id);
                if (correctEntity != null)
                {
                    correctEntity.New_clientequipmemtipdata = _CRMcontext.New_clientequipmemtipdata.Where(x => x.New_ClientRoomId == id).ToList();
                    correctEntity.New_clientequipment = _CRMcontext.New_clientequipment.Where(x => x.New_ClientRoomEquipmentId == id).ToList();
                    correctEntity.Incident = _CRMcontext.Incident.Where(x => x.New_ClientRoomId == id).ToList();
                    return correctEntity;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); throw;
            }
        }
        public IQueryable<New_clientroom> GetNew_clientrooms()
        {
            return _CRMcontext.New_clientroom;
        }

        public IQueryable<New_clientroom> GetNew_clientroomsWithIncidents()
        {
            return _CRMcontext.New_clientroom.Include("Incident");
        }

        public IQueryable<New_clientroom> GetNew_clientroomsWithNew_clientequipmentipdatas()
        {
            return _CRMcontext.New_clientroom.Include("New_clientequipmentipdata");
        }

        public IQueryable<New_clientroom> GetNew_clientroomsWithIncidentsAndNew_clientequipmentipdatas()
        {
            return _CRMcontext.New_clientroom.Include("Incident").Include("New_clientequipmentipdata");
        }

        public IQueryable<New_clientroom> GetNew_clientroomsWithIncidents(IEnumerable<ActiveRooms> listOfAutorizedRooms)
        {
            var list = from ar in listOfAutorizedRooms
                       select ar.RoomID;

            return _CRMcontext.New_clientroom.Include("Incident").Where(r => list.Contains(r.New_clientroomId));
        }

        public IQueryable<New_clientroom> GetNew_clientroomsWithNew_clientequipmentipdatas(IEnumerable<ActiveRooms> listOfAutorizedRooms)
        {
            var list = from ar in listOfAutorizedRooms
                       select ar.RoomID;

            return _CRMcontext.New_clientroom.Include("New_clientequipmentipdata").Where(r => list.Contains(r.New_clientroomId));
        }

        public IQueryable<New_clientroom> GetNew_clientroomsWithIncidentsAndNew_clientequipmentipdatas(IEnumerable<ActiveRooms> listOfAutorizedRooms)
        {
            var list = from ar in listOfAutorizedRooms
                       select ar.RoomID;

            return _CRMcontext.New_clientroom.Include("Incident").Include("New_clientequipmentipdata").Where(r => list.Contains(r.New_clientroomId));
        }

        public IQueryable<New_clientroom> GetNew_clientrooms(IEnumerable<ActiveRooms> listOfAutorizedRooms)
        {
            var list = from ar in listOfAutorizedRooms
                       select ar.RoomID;

            var result = _CRMcontext.New_clientroom.Where(r => list.Contains(r.New_clientroomId));
            return result;
        }




        #endregion

        #region New_manufacturer

        public New_manufacturer GetNew_manufacturer(Guid id)
        {
            return _CRMcontext.New_manufacturer.FirstOrDefault(e => e.New_manufacturerId == id);
        }

        public IQueryable<New_manufacturer> GetNew_manufacturer()
        {
            return _CRMcontext.New_manufacturer;
        }

        #endregion

        #region New_clientequipmentfunction

        public New_clientequipmentfunction GetNew_clientequipmentfunction(Guid id)
        {
            return _CRMcontext.New_clientequipmentfunction.FirstOrDefault(e => e.New_clientequipmentfunctionId == id);
        }

        public IQueryable<New_clientequipmentfunction> GetNew_clientequipmentfunction()
        {
            return _CRMcontext.New_clientequipmentfunction;
        }

        #endregion

        #region New_clientequipmentdescription

        public New_clientequipmentdescription GetNew_clientequipmentdescription(Guid id)
        {
            return _CRMcontext.New_clientequipmentdescription.FirstOrDefault(e => e.New_clientequipmentdescriptionId == id);
        }

        public IQueryable<New_clientequipmentdescription> GetNew_clientequipmentdescription()
        {
            return _CRMcontext.New_clientequipmentdescription;
        }

        #endregion

        #region New_clientequipmentstatus

        public New_clientequipmentstatus GetNew_clientequipmentstatus(Guid id)
        {
            return _CRMcontext.New_clientequipmentstatus.FirstOrDefault(e => e.New_clientequipmentstatusId == id);
        }

        public IQueryable<New_clientequipmentstatus> GetNew_clientequipmentstatus()
        {
            return _CRMcontext.New_clientequipmentstatus;
        }

        #endregion

        #region SubjectBase
        public SubjectBase GetSubjectBase(Guid id)
        {
            return _CRMcontext.SubjectBase.FirstOrDefault(e => e.SubjectId == id);
        }

        public IQueryable<SubjectBase> GetSubjectBase()
        {
            return _CRMcontext.SubjectBase;
        }


        #endregion

        #region new_clientroom_projectfile

        public new_clientroom_projectfile Getnew_clientroom_projectfile(Guid id, Guid? new_clientroomId)
        {
            return _CRMcontext.new_clientroom_projectfile.FirstOrDefault(e => e.new_clientroom_projectfileId == id && (new_clientroomId == null || e.new_clientroomid == new_clientroomId));
        }

        public IQueryable<new_clientroom_projectfile> Getnew_clientroom_projectfile(Guid? new_clientroomId)
        {
            var correctEntity = _CRMcontext.new_clientroom_projectfile.FirstOrDefault(x => x.new_clientroomid == new_clientroomId);
            if (correctEntity != null)
            {
                var result = _CRMcontext.new_clientroom_projectfile.Where(x => x.new_clientroomid == new_clientroomId);
                return result;
            }

            else
                return null;
        }

        #endregion

        #region Dashboard_ServiceTicketTrends_Result

        public List<Entities.CRM.Dashboard_ServiceTicketTrends_Result> GetCRMTicketTrends(Guid _Id, DateTime _startDate, DateTime _endDate, string _groupBy, Guid? _roomId, string _subject)
        {
            var id = new SqlParameter { ParameterName = "@UserID", Value = _Id };
            var startDate = new SqlParameter { ParameterName = "@ReportStart", Value = _startDate };
            var endDate = new SqlParameter { ParameterName = "@ReportEnd", Value = _endDate };
            //var groupBy = new SqlParameter { ParameterName = "@GroupBy", Value = _groupBy == null ? String.Empty : _groupBy};
            //var roomId = new SqlParameter { ParameterName = "@RoomID", Value = _roomId == null ? Guid.NewGuid() : _roomId };
            //var subject = new SqlParameter { ParameterName = "@Subject", Value = _subject == null ? String.Empty : _subject };

            var result = _CRMcontext.Database.SqlQuery<Entities.CRM.Dashboard_ServiceTicketTrends_Result>("Dashboard_ServiceTicketTrends @UserID, @ReportStart, @ReportEnd", id, startDate, endDate).ToList();
            return result;
        }


        #endregion

        #region Dashboard_GetProjectFiles_Result

        public List<Dashboard_GetProjectFiles_Result> GetProjectFiles(Guid clientRoomId)
        {
            var id = new SqlParameter { ParameterName = "@RoomID", Value = clientRoomId };

            var result = _CRMcontext.Database.SqlQuery<Dashboard_GetProjectFiles_Result>("Dashboard_GetProjectFiles @RoomID", id).ToList();
            return result;
        }

        #endregion

        #region StringMap
        public StringMap GetStringMap(int objectTypeCode, int? attributeValue)
        {
            var result = _CRMcontext.StringMaps.FirstOrDefault(s => s.ObjectTypeCode == objectTypeCode && s.AttributeValue == attributeValue);
            return result;
        }

        #endregion

        #region RoomFiles
        public List <Document> GetRoomDocuments(Guid Id)
        {
            //var projectFiles = GetProjectFiles(Id);
            var documents = GetNew_documentation(Id);
           
            var result = new List<Document>();

            //foreach(var pf in projectFiles)
            //{
            //    result.Add(
            //        new Document
            //        {
            //            Id = pf.ProjectFileId,
            //            RoomId = Id,
            //            Name = pf.ProjectFileName,
            //            CreatedOn = pf.CreatedOn,
            //            ModifiedOn = pf.ModifiedOn,
            //            FolderName = pf.ProjectFolderName,
            //            Type = pf.FileTypeName,
            //            isProtected = true
            //        }
            //    );
            //}
            if (documents != null)
            {
                foreach (var d in documents)
                {
                    if (d.New_ShareDocument == true)
                    {
                        result.Add(
                            new Document
                            {
                                Id = d.New_documentationId,
                                RoomId = Id,
                                OrganizationId = d.New_DocumentOwnerId,
                                Name = d.New_name,
                                CreatedOn = d.CreatedOn,
                                ModifiedOn = d.ModifiedOn,
                                FolderName = d.New_documentationId.ToString(),
                                Type = GetStringMap(10070, d.New_DocumentType).Value.ToString(),
                                isProtected = false
                            }
                        );
                    }
                }
            }

            return result;
        }


        #endregion

        #region Document_Write

        public Document_Write_Result Document_Write(Nullable<System.Guid> documentID, string name, Nullable<System.Guid> organizationID, Nullable<System.Guid> projectID, Nullable<System.Guid> projectRoomID, Nullable<System.Guid> clientRoomID, string notes, Nullable<int> type, Nullable<int> status, Nullable<bool> share)
        {
            var documentIDParameter = documentID.HasValue ?
                new SqlParameter ("@DocumentID", documentID ) :
                new SqlParameter("@DocumentID", DBNull.Value);

            var nameParameter = name != null ?
                new SqlParameter("@Name", name) :
                new SqlParameter("@Name", DBNull.Value);

            var organizationIDParameter = organizationID.HasValue ?
                new SqlParameter("@OrganizationID", organizationID) :
                new SqlParameter("@OrganizationID", DBNull.Value);

            var projectIDParameter = projectID.HasValue ?
                new SqlParameter("@ProjectID", projectID) :
                new SqlParameter("@ProjectID", DBNull.Value);

            var projectRoomIDParameter = projectRoomID.HasValue ?
                new SqlParameter("@ProjectRoomID", projectRoomID) :
                new SqlParameter("@ProjectRoomID", DBNull.Value);

            var clientRoomIDParameter = clientRoomID.HasValue ?
                new SqlParameter("@ClientRoomID", clientRoomID) :
                new SqlParameter("@ClientRoomID", DBNull.Value);

            var notesParameter = notes != null ?
                new SqlParameter("@Notes", notes) :
                new SqlParameter("@Notes", DBNull.Value);

            var typeParameter = type.HasValue ?
                new SqlParameter("@Type", type) :
                new SqlParameter("@Type", DBNull.Value);

            var statusParameter = status.HasValue ?
                new SqlParameter("@Status", status) :
                new SqlParameter("@Status", DBNull.Value);

            var shareParameter = share.HasValue ?
                new SqlParameter("@Share", share) :
                new SqlParameter("@Share", DBNull.Value);

            try
            {
                var result = _CRMcontext.Database.SqlQuery<Document_Write_Result>("Document_Write @DocumentID, @Name, @OrganizationID, @ProjectID, @ProjectRoomID, @ClientRoomID, @Notes, @Type, @Status, @Share",
                    documentIDParameter, nameParameter, organizationIDParameter, projectIDParameter, projectRoomIDParameter, clientRoomIDParameter, notesParameter, typeParameter, statusParameter, shareParameter).FirstOrDefault();
                return result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;

        }

        #endregion


    }
}
