using ConstantConnect.Constants.Dictionaries;
using ConstantConnect.DTO.Shared;
using ConstantConnect.MVCClient.Extensions;
using ConstantConnect.MVCClient.Helpers;
using ConstantConnect.MVCClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConstantConnect.MVCClient.Controllers
{
    [Authorize]
    public class RoomController : Controller
    {
        public ActionResult Details(DTO.Shared.Room room)
        {
            //if (Id == null)
            //    return View(null);

            //var client = ConstantConnectHttpClient.GetClient();
            //var data = client.GetAsync("api/new_clientrooms/" + Id);

            //if (data.Result != null)
            //{
            //    try
            //    {
            //        var result = data.Result.Content.ReadAsStringAsync().Result;
            //        var model = JsonConvert.DeserializeObject<DTO.CRM.New_clientroom>(result);
            //        return PartialView(model);
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(e.Message);
            //        throw;
            //    }
            //}
            return PartialView(room);
        }

        public ActionResult Performance(DTO.Shared.Room room)
        {
            //var model = new PerformanceModel();
            //model.Id = Id.ToString();
            return PartialView(room);
        }

        public ActionResult ServiceTickets(DTO.Shared.Room room)
        {
            if (room == null)
                return PartialView();

            var client = ConstantConnectHttpClient.GetClient();
            var data = client.GetAsync("api/new_clientrooms/" + room.Id + "/incidents");

            if (data.Result != null)
            {
                try
                {
                    var result = data.Result.Content.ReadAsStringAsync().Result;
                    var model = JsonConvert.DeserializeObject<List<DTO.CRM.Incident>>(result);
                    return PartialView(model);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
            return PartialView();
        }



        public ActionResult Inventory(DTO.Shared.Room room)
        {
            if (room == null)
                return View();

            var client = ConstantConnectHttpClient.GetClient();
            var data = client.GetAsync("api/new_clientrooms/" + room.Id + "/New_clientequipment");

            if (data.Result != null)
            {
                try
                {
                    var result = data.Result.Content.ReadAsStringAsync().Result;
                    var model = JsonConvert.DeserializeObject<List<DTO.CRM.New_clientequipment>>(result);
                    return PartialView(model);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
            return PartialView();
        }

        public ActionResult Devices()
        {
            return PartialView();
        }
        public ActionResult Warranty(Guid? Id)
        {
            if (Id == null)
                return PartialView();

            var client = ConstantConnectHttpClient.GetClient();
            var data = client.GetAsync("api/new_clientrooms/" + Id + "/new_warranty");

            if (data.Result != null)
            {
                try
                {
                    var result = data.Result.Content.ReadAsStringAsync().Result;
                    var model = JsonConvert.DeserializeObject<List<DTO.CRM.New_Warranty>>(result);
                    return View(model);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
            return View();
        }

        public ActionResult DevicesIpData(DTO.Shared.Room room)
        {
            if (room == null)
                return View();

            var client = ConstantConnectHttpClient.GetClient();
            var data = client.GetAsync("api/new_clientrooms/" + room.Id + "/new_clientequipmemtipdata");

            if (data.Result != null)
            {
                try
                {
                    var result = data.Result.Content.ReadAsStringAsync().Result;
                    var model = JsonConvert.DeserializeObject<List<DTO.CRM.New_clientequipmemtipdata>>(result);
                    return PartialView(model);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
            return PartialView();
        }

        //public ActionResult ModalAction(Guid Id, string Name)
        public ActionResult ModalAction(DTO.Shared.Room model)
        {
            //var model = new Modal()
            //{
            //    Id = Id,
            //    Name = Name
            //};

            return PartialView("ModalContent", model);
        }
        public ActionResult Documents(DTO.Shared.Room room)
        {
            var model = new DocumentModel();
            model.RoomId = room.Id;
            model.ParentId = room.OrganizationId;
            model.Attachments = new List<AttachmentsModel>();

            var client = ConstantConnectHttpClient.GetClient();
            var RoomFiles = new List<DTO.CRM.Dashboard_GetProjectFiles_Result>();
            var RoomDocuments = new List<DTO.Shared.Document>();

            var data = client.GetAsync("api/documents/projectfiles/" + room.Id);

            if (data.Result != null)
            {
                try
                {
                    var result = data.Result.Content.ReadAsStringAsync().Result;
                    RoomFiles = JsonConvert.DeserializeObject<List<DTO.CRM.Dashboard_GetProjectFiles_Result>>(result);


                    foreach (var dir in RoomFiles)
                    {
                        var serverDirectory = new DirectoryInfo(string.Format(@"\\tardis\SPdata\new_projectfile\{0}", dir.ProjectFolderName));
                        FileInfo[] fileNames = serverDirectory.GetFiles("*.*");
                        foreach (var file in fileNames)
                        {
                            model.Attachments.Add(
                                        new AttachmentsModel
                                        {
                                            Id = Guid.NewGuid(),
                                            Name = file.Name,
                                            Path = file.FullName,
                                            Size = file.Length.ToReadableByteSizeString(),
                                            CreatedOn = file.CreationTimeUtc.ToShortDateString(),
                                            FileType = dir.FileTypeName,
                                            ReadOnly = true
                                        }
                                        );
                        }
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    //throw;
                }
            }

            if (data.IsCompleted)
            {

                data = client.GetAsync("api/documents/documents/" + room.Id);

                if (data.Result != null)
                {
                    try
                    {
                        var result = data.Result.Content.ReadAsStringAsync().Result;

                        RoomDocuments = JsonConvert.DeserializeObject<List<DTO.Shared.Document>>(result);

                        foreach (var dir in RoomDocuments)
                        {
                            var serverDirectory = new DirectoryInfo(string.Format(@"\\tardis\crm_docs\{0}", dir.FolderName));
                            FileInfo[] fileNames = serverDirectory.GetFiles("*.*");
                            if (fileNames != null)
                            {
                                foreach (var file in fileNames)
                                {
                                    if (file.Extension != ".db")
                                    {
                                        model.Attachments.Add(
                                                    new AttachmentsModel
                                                    {
                                                        Id = dir.Id,
                                                        Name = file.Name,
                                                        Path = file.FullName,
                                                        Size = file.Length.ToReadableByteSizeString(),
                                                        CreatedOn = file.CreationTimeUtc.ToShortDateString(),
                                                        FileType = dir.Type,
                                                        ReadOnly = false
                                                    }
                                                    );
                                    }
                                }
                            }
                        }


                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        //throw;
                    }
                }
            }

            return PartialView(model);
        }
        public async Task<ActionResult> SaveUploadedFile(Guid roomId, Guid parentId)
        {
            
            bool isSaved = true;
            string fileName = "";
            var client = ConstantConnectHttpClient.GetClient();

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase fileBase = Request.Files[file];
                fileName = fileBase.FileName;

                var document = new DTO.Shared.Document()
                {
                    Name = fileName,
                    RoomId = roomId,
                    OrganizationId = parentId,
                    FolderName = roomId.ToString(),
                };

                var serializedDocument = JsonConvert.SerializeObject(document);
                var data = await client.PostAsync("api/documents/newdocument/",
                    new StringContent(serializedDocument, System.Text.Encoding.Unicode, "application/json"));
                if (data.IsSuccessStatusCode)
                {
                    if (fileBase != null && fileBase.ContentLength > 0)
                    {
                        var serverDirectory = new DirectoryInfo(@"\\tardis\crm_docs\");
                        var pathString = Path.Combine(serverDirectory.ToString(), string.Format("{0}", document.RoomId));
                        var name = Path.GetFileName(fileBase.FileName);
                        bool exists = Directory.Exists(pathString);

                        if (!exists)
                            System.IO.Directory.CreateDirectory(pathString);

                        var path = string.Format("{0}\\{1}", pathString, fileBase.FileName);
                        fileBase.SaveAs(path);
                    }


                }


                //if (fileBase != null && fileBase.ContentLength > 0)
                //{
                //    var originalDirectory = new DirectoryInfo(string.Format("{0}FILESTORE\\ClientFiles", Server.MapPath(@"\")));
                //    var pathString = Path.Combine(originalDirectory.ToString(), "documents");
                //    var name = Path.GetFileName(fileBase.FileName);
                //    bool exists = Directory.Exists(pathString);

                //    if (!exists)
                //        System.IO.Directory.CreateDirectory(pathString);

                //    var path = string.Format("{0}\\{1}", pathString, fileBase.FileName);
                //    fileBase.SaveAs(path);


                //}
            }

            return Json(new { Message = fileName });
        }

        public ActionResult DeleteUploadedFile(string file)
        {
            var originalDirectory = new DirectoryInfo(string.Format("{0}FILESTORE\\ClientFiles", Server.MapPath(@"\")));
            var pathString = Path.Combine(originalDirectory.ToString(), "documents");
            string fullPath = string.Format("{0}\\{1}", pathString, file);

            if (System.IO.File.Exists(fullPath))
                System.IO.File.Delete(fullPath);


            return Json(new { Message = "Deleted" });
        }

        //public ActionResult GetAttachments(Guid? Id)
        //{
        //    if (Id == null)
        //        return Json(new { Data = "" }, JsonRequestBehavior.AllowGet);

        //    var client = ConstantConnectHttpClient.GetClient();
        //    var model = new List<DTO.CRM.Dashboard_GetProjectFiles_Result>();
        //    var data = client.GetAsync("api/documents/" + Id);

        //    if (data.Result != null)
        //    {
        //        try
        //        {
        //            var result = data.Result.Content.ReadAsStringAsync().Result;
        //            model = JsonConvert.DeserializeObject<List<DTO.CRM.Dashboard_GetProjectFiles_Result>>(result);

        //            int i = 0;
        //            var attachmentList = new List<AttachmentsModel>();
        //            foreach (var dir in model)
        //            {
        //                var serverDirectory = new DirectoryInfo(string.Format(@"\\tardis\SPdata\new_projectfile\{0}", dir.ProjectFolderName));
        //                FileInfo[] fileNames = serverDirectory.GetFiles("*.*");
        //                foreach (var file in fileNames)
        //                {
        //                    attachmentList.Add(
        //                                new AttachmentsModel
        //                                {
        //                                    Id = i,
        //                                    Name = file.Name,
        //                                    Path = file.FullName,
        //                                    Size = file.Length.ToReadableByteSizeString(),
        //                                    CreatedOn = file.CreationTimeUtc.ToShortDateString()
        //                                }
        //                                );
        //                    i++;
        //                }
        //            }
        //            if (attachmentList.Count() > 0)
        //                return Json(new { Data = attachmentList }, JsonRequestBehavior.AllowGet);

        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //            throw;
        //        }
        //    }

        //    return Json(new { Data = "" }, JsonRequestBehavior.AllowGet);
        //    //Working Local

        //    //var originalDirectory = new DirectoryInfo(string.Format("{0}FILESTORE\\ClientFiles\\documents", Server.MapPath(@"\")));
        //    //FileInfo[] fileNames = originalDirectory.GetFiles("*.*");
        //    //var attachmentList = new List<AttachmentsModel>();
        //    //int i = 0;
        //    //foreach (var item in fileNames)
        //    //{
        //    //    attachmentList.Add(
        //    //        new AttachmentsModel { Id = i, Name = item.Name, Size = item.Length.ToReadableByteSizeString(), CreatedOn = item.CreationTimeUtc.ToShortDateString()}
        //    //    );
        //    //    i++;
        //    //}

        //    //return Json(new { Data = attachmentList }, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult DownloadAttachment(string filePath, string fileName)
        {
            var serverDirectory = new DirectoryInfo(string.Format(@"tardis\SPdata\new_projectfile\"));
            //var originalDirectory = new DirectoryInfo(string.Format("{0}FILESTORE\\ClientFiles", Server.MapPath(@"\")));
            //var pathString = Path.Combine(originalDirectory.ToString(), "documents");
            //string fullPath = string.Format("{0}\\{1}", serverDirectory, file);

            //byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);
            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);


            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

        }
    }
}
