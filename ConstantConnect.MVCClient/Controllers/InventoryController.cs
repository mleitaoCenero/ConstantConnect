using ConstantConnect.DTO.CRM;
using ConstantConnect.MVCClient.Helpers;
using ConstantConnect.MVCClient.Models;
using Marvin.JsonPatch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConstantConnect.MVCClient.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        public async Task<ActionResult> InventoryIndex()
        {
            var client = ConstantConnectHttpClient.GetClient();
            var model = new InventoryModel();

            //var activeRoomData = await client.GetAsync("api/tile/ActiveRooms").ConfigureAwait(false);
            var activeRoomData = await client.GetAsync("api/room");

            if (activeRoomData.IsSuccessStatusCode)
            {
                var result = await activeRoomData.Content.ReadAsStringAsync();
                //var data = JsonConvert.DeserializeObject<List<DTO.ConstantConnect.Dashboard_ActiveRooms_Result>>(result);
                var data = JsonConvert.DeserializeObject<List<DTO.Shared.Room>>(result);
                model.ClientRooms = data;
            }
            return View(model);
        }


        //public dynamic InventoryTable(Guid? Id)
        //{
        //    var client = ConstantConnectHttpClient.GetClient();
        //    var getData = client.GetAsync("api/new_clientrooms/" + Id+ "/New_clientequipment");

        //    try
        //    {
        //        if (getData.Result != null)
        //        {
        //            var result = getData.Result.Content.ReadAsStringAsync().Result;
        //            var data = JsonConvert.DeserializeObject<IEnumerable<DTO.CRM.New_clientequipment>>(result);

        //            return Json(new
        //            {
        //                data = data.Select(x => new {
        //                    id = x.New_clientequipmentId.ToString(), 
        //                    modelnumber = x.New_ModelNumber == null ? "NA" : x.New_ModelNumber,
        //                    serialnumber = x.New_SerialNumber == null ? "NA" : x.New_SerialNumber,
        //                    function = x.New_EquipmentFunctionIdName == null ? "NA" : x.New_EquipmentFunctionIdName,
        //                    type = x.New_EquipmentType == null ? "NA" : x.New_EquipmentType
        //                    })

        //            }, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        //throw;
        //    }

        //    return Json("", JsonRequestBehavior.AllowGet);
        //}

        public ActionResult InventoryTable(Guid? Id)
        {
            var client = ConstantConnectHttpClient.GetClient();
            var getData = client.GetAsync("api/new_clientrooms/" + Id + "/New_clientequipment");

            try
            {
                if (getData.Result != null)
                {
                    var result = getData.Result.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<IEnumerable<DTO.CRM.New_clientequipment>>(result);
                    return PartialView(data);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //throw;
            }

            return PartialView();
        }

        public ActionResult ModalAction(Guid Id, string Name)
        {
            var model = new Modal()
            {
                Id = Id,
                Name = Name
            };

            return PartialView("ModalContent", model);
        }

        [HttpGet]
        public ActionResult Edit(Guid? Id)
        {
            if (Id == null)
                return View();

            var model = new InventoryDetailsModel();
            var client = ConstantConnectHttpClient.GetClient();
            var data = client.GetAsync("api/new_clientequipment/" + Id);

            if (data.Result != null)
            {
                try
                {
                    var result = data.Result.Content.ReadAsStringAsync().Result;
                    model.Equipment = JsonConvert.DeserializeObject<DTO.CRM.New_clientequipment>(result);
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }

            if (data.IsCompleted)
            {
                data = client.GetAsync("api/room");

                if (data.Result != null)
                {
                    try
                    {
                        var result = data.Result.Content.ReadAsStringAsync().Result;
                        model.ClientRooms = JsonConvert.DeserializeObject<List<DTO.Shared.Room>>(result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }
                }
            }

            if (data.IsCompleted)
            {
                data = client.GetAsync("api/new_manufacturer");

                if (data.Result != null)
                {
                    try
                    {
                        var result = data.Result.Content.ReadAsStringAsync().Result;
                        model.Manufacturers = JsonConvert.DeserializeObject<List<DTO.CRM.New_manufacturer>>(result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }
                }
            }

            if (data.IsCompleted)
            {
                data = client.GetAsync("api/new_clientequipmentfunction");

                if (data.Result != null)
                {
                    try
                    {
                        var result = data.Result.Content.ReadAsStringAsync().Result;
                        model.FunctionTypes = JsonConvert.DeserializeObject<List<DTO.CRM.New_clientequipmentfunction>>(result);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }
                }
            }
            if (model != null)
            {
                if(model.Equipment.New_CCCDeviceID != null)
                    return PartialView("ProactiveEdit", model);
                else
                    return PartialView("ReactiveEdit", model);
            }
                

            return PartialView();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid Id, InventoryDetailsModel entity)
        {
            try
            {
                var client = ConstantConnectHttpClient.GetClient();

                var patchDocument = new JsonPatchDocument<DTO.CRM.New_clientequipment>();
                
                patchDocument.Replace(e => e.New_ModelNumber, entity.Equipment.New_ModelNumber);
                patchDocument.Replace(e => e.New_SerialNumber, entity.Equipment.New_SerialNumber);
                //patchDocument.Replace(e => e.New_EquipmentStatusId, entity.Equipment.New_EquipmentStatusId);
                patchDocument.Replace(e => e.New_AssetID, entity.Equipment.New_AssetID);
                patchDocument.Replace(e => e.New_PartNumber, entity.Equipment.New_PartNumber);
                patchDocument.Replace(e => e.New_ClientRoomEquipmentId, entity.Equipment.New_ClientRoomEquipmentId);
                patchDocument.Replace(e => e.New_ManufacturerId, entity.Equipment.New_ManufacturerId);
                patchDocument.Replace(e => e.New_EquipmentFunctionId, entity.Equipment.New_EquipmentFunctionId);
                //patchDocument.Replace(e => e.New_Barcode, entity.Equipment.New_Barcode);
                //patchDocument.Replace(e => e.New_BENAssetNumber, entity.Equipment.New_BENAssetNumber);
                //patchDocument.Replace(e => e.New_Loanable, entity.Equipment.New_Loanable);
                //patchDocument.Replace(e => e.New_LoanContactName, entity.Equipment.New_LoanContactName);
                //patchDocument.Replace(e => e.New_LoanContactInfo, entity.Equipment.New_LoanContactInfo);
                //patchDocument.Replace(e => e.New_WCITTag, entity.Equipment.New_WCITTag);
                patchDocument.Replace(e => e.New_EquipmentNotes, entity.Equipment.New_EquipmentNotes);

                var serialize = JsonConvert.SerializeObject(patchDocument);

                var response = client.PatchAsync("api/patch_new_clientequipment/" + Id,
                    new StringContent(serialize,
                    System.Text.Encoding.Unicode, "application/json")).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = new
                    {
                        Message = "Device successfully",
                        Strong = "Updated",
                        AlertType = "success"
                    };
                    return Json(content, JsonRequestBehavior.AllowGet);
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    var content = new
                    {
                        Message = "Device did not",
                        Strong = "Update",
                        AlertType = "info"
                    };

                    return Json(content, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var content = new
                    {
                        Message = "Device update",
                        Strong = "Failed",
                        AlertType = "warning"
                    };

                    return Json(content, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                var content = new
                {
                    Message = "Device update",
                    Strong = "Failed",
                    AlertType = "warning"
                };

                return Json(content, JsonRequestBehavior.AllowGet);
            }

        }
    }
}