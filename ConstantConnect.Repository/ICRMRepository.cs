using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConstantConnect.Repository.Entities.CRM;
using ConstantConnect.Repository.Entities.Shared;

namespace ConstantConnect.Repository
{
    public interface ICRMRepository
    {
        #region Incident
        Incident GetIncident(Guid id, Guid? new_clientroomId);
        IQueryable<Incident> GetIncidents();
        IQueryable<Incident> GetIncidents(Guid? new_clientroomId);
        #endregion

        #region New_clientequipmentdata
        IQueryable<New_clientequipmemtipdata> GetNew_clientequipmemtipdatas();
        IQueryable<New_clientequipmemtipdata> GetNew_clientequipmentipdatas(Guid? new_clientroomId);
        New_clientequipmemtipdata GetNew_clientequipmentipdata(Guid id, Guid? new_clientroomId);
        #endregion

        #region New_clientequipment
        //New_clientequipment GetNew_clientequipment(Guid id);
        New_clientequipment GetNew_clientequipment(Guid id, Guid? new_clientroomId);
        IQueryable<New_clientequipment> GetNew_clientequipmentForRoom(Guid? new_clientRoomId);
        RepositoryActionResult<New_clientequipment> UpdateNew_clientequipment(New_clientequipment entity);
        #endregion

        #region New_documentation
        //New_documentation GetNew_documentation(Guid id);
        New_documentation GetNew_documentation(Guid id, Guid? new_clientroomId);
        IQueryable<New_documentation> GetNew_documentation(Guid? new_clientRoomId);
        #endregion

        #region new_clientrooms_warrantylines
        IQueryable<new_clientrooms_warrantylines> Getnew_clientrooms_warrantylines(Guid new_clientroomId);
        #endregion

        #region New_Warranty
        IQueryable<New_Warranty> GetNew_Warranty(Guid new_clientroomId);
        #endregion

        #region New_manufacturer
        New_manufacturer GetNew_manufacturer(Guid id);
        IQueryable<New_manufacturer> GetNew_manufacturer();
        #endregion

        #region New_clientequipmentfunction
        New_clientequipmentfunction GetNew_clientequipmentfunction(Guid id);
        IQueryable<New_clientequipmentfunction> GetNew_clientequipmentfunction();
        #endregion

        #region New_clientequipmentdescription
        New_clientequipmentdescription GetNew_clientequipmentdescription(Guid id);
        IQueryable<New_clientequipmentdescription> GetNew_clientequipmentdescription();
        #endregion

        #region New_clientequipmentstatus
        New_clientequipmentstatus GetNew_clientequipmentstatus(Guid id);

        IQueryable<New_clientequipmentstatus> GetNew_clientequipmentstatus();

        #endregion

        #region SubjectBase

        SubjectBase GetSubjectBase(Guid id);
        IQueryable<SubjectBase> GetSubjectBase();

        #endregion

        #region new_clientroom_projectfile
        new_clientroom_projectfile Getnew_clientroom_projectfile(Guid id, Guid? new_clientroomId);
        IQueryable<new_clientroom_projectfile> Getnew_clientroom_projectfile(Guid? new_clientroomId);
        #endregion

        #region New_clientroom
        New_clientroom GetNew_clientroom(Guid id);
        IQueryable<New_clientroom> GetNew_clientrooms();
        IQueryable<New_clientroom> GetNew_clientrooms(IEnumerable<ActiveRooms> listOfAutorizedRooms);
        IQueryable<New_clientroom> GetNew_clientroomsWithIncidents();
        IQueryable<New_clientroom> GetNew_clientroomsWithIncidents(IEnumerable<ActiveRooms> listOfAutorizedRooms);
        IQueryable<New_clientroom> GetNew_clientroomsWithIncidentsAndNew_clientequipmentipdatas();
        IQueryable<New_clientroom> GetNew_clientroomsWithIncidentsAndNew_clientequipmentipdatas(IEnumerable<ActiveRooms> listOfAutorizedRooms);
        IQueryable<New_clientroom> GetNew_clientroomsWithNew_clientequipmentipdatas();
        IQueryable<New_clientroom> GetNew_clientroomsWithNew_clientequipmentipdatas(IEnumerable<ActiveRooms> listOfAutorizedRooms);

        New_clientroom GetNew_clientroomWithIncidents(Guid id);
        New_clientroom GetNew_clientroomWithIncidentsAndNew_clientequipmentipdatas(Guid id);
        New_clientroom GetNew_clientroomWithIncidentsAndNew_clientequipmentipdatasAndNew_clientequipment(Guid id);
        New_clientroom GetNew_clientroomWithNew_clientequipmentipdatas(Guid id);

        #endregion

        #region Dashboard_ServiceTicketTrends_Result
        List<Entities.CRM.Dashboard_ServiceTicketTrends_Result> GetCRMTicketTrends(Guid _Id, DateTime _startDate, DateTime _endDate, string _groupBy, Guid? _roomId, string _subject);
        #endregion

        #region Dashboard_GetProjectFiles_Result
        List<Dashboard_GetProjectFiles_Result> GetProjectFiles(Guid clientRoomId);
        #endregion

        #region RoomFiles
        List<Document> GetRoomDocuments(Guid Id);
        #endregion

        #region Document_Write
        Document_Write_Result Document_Write(Nullable<System.Guid> documentID, string name, Nullable<System.Guid> organizationID, Nullable<System.Guid> projectID, Nullable<System.Guid> projectRoomID, Nullable<System.Guid> clientRoomID, string notes, Nullable<int> type, Nullable<int> status, Nullable<bool> share);
        #endregion

    }
}