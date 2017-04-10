using ConstantConnect.MVCClient.Helpers;
using ConstantConnect.MVCClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ConstantConnect.MVCClient.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult ChartAction()
        {
            return PartialView("TicketTrends");
        }
        //public async Task<ActionResult> TicketTrends(string start, string end)
        //{
        //    var startDate = DateTime.Parse(start);
        //    var endDate = DateTime.Parse(end);
        //    var client = ConstantConnectHttpClient.GetClient();
        //    var getData = await client.GetAsync("api/tile/ServiceTickets");

        //    if (getData.IsSuccessStatusCode)
        //    {
        //        var result = getData.Content.ReadAsStringAsync().Result;
        //        var data = JsonConvert.DeserializeObject<IEnumerable<DTO.CRM.Dashboard_ServiceTickets_Result>>(result);
        //        try
        //        {
        //            var allData = (from item in data
        //                           where item.TicketCreatedOn.Value >= startDate && item.TicketCreatedOn.Value <= endDate
        //                           group item by new { item.TicketCreatedOn.Value.Month, item.TicketCreatedOn.Value.Year } into grp
        //                           //group item by new { item.TicketCreatedOn.Value} into grp
        //                           select new
        //                           {
        //                               //Day = grp.Key.Day,
        //                               Month = grp.Key.Month,
        //                               Year = grp.Key.Year,
        //                               //Date = grp.Key,
        //                               TicketTotal = grp.Count(),
        //                           });


        //            var chart = new[]
        //            {
        //                new { label="Ticket Total",
        //                    //data = allData.Select(x=>new {x.Date, x.TicketTotal})
        //                    data = allData.OrderBy(x=>x.Year).OrderBy(x=>x.Month).Select(x=>new int[] {x.Month,x.TicketTotal})
        //                }
        //            };
        //            return Json(chart, JsonRequestBehavior.AllowGet);
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //            throw;
        //        }
        //    }
        //    return Json("", JsonRequestBehavior.AllowGet);

        //    //return Json(new[] { new[] { 0, 4 }, new[] { 1, 3 }, new[] { 2, 4 }, new[] { 3, 3 }, new[] { 4, 6 }, new[] { 5, 3 } }, JsonRequestBehavior.AllowGet);
        //}

        public dynamic TicketTrends(string startDate, string endDate, string roomId = null, string groupBy = null, string subject = null, Nullable<int> utcOffset = null)
        {
            // report start and end dates encompass the past 90 days by default, but can be set through URL variables
            var reportEnd = DateTime.UtcNow;
            var reportStart = DateTime.UtcNow.AddDays(-90);
            try
            {
                reportStart = DateTime.Parse(startDate);
                reportEnd = DateTime.Parse(endDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // optional roomid, default is null
            Nullable<System.Guid> reportRoomId = null;
            try
            {
                reportRoomId = Guid.Parse(roomId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            var client = ConstantConnectHttpClient.GetClient();
            string apiUrl = "api/chart/ServiceTicketTrends?startDate="
                + HttpUtility.UrlEncode(reportStart.ToString("yyyy-MM-dd")) + "&endDate="
                + HttpUtility.UrlEncode(reportEnd.ToString("yyyy-MM-dd"));
            if (reportRoomId != null)
            {
                apiUrl += "&roomId=" + HttpUtility.UrlEncode(reportRoomId.ToString());
            }
            // optional subject filter for Service Ticket Trends report
            if (!string.IsNullOrEmpty(subject))
            {
                apiUrl += "&subject=" + HttpUtility.UrlEncode(subject);
            }
            // optional groupBy for Service Ticket Trends report -- can be 'room', 'subject', 'day', 'month', or 'year'
            if (!string.IsNullOrEmpty(groupBy))
            {
                apiUrl += "&groupBy=" + HttpUtility.UrlEncode(groupBy);
            }
            if (utcOffset != null)
            {
                apiUrl += "&utcOffset=" + HttpUtility.UrlEncode(utcOffset.ToString());
            }
            var getData = client.GetAsync(apiUrl);

            if (getData.Result != null)
            {
                try
                {
                    return getData.Result.Content.ReadAsStringAsync().Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }


    }
}