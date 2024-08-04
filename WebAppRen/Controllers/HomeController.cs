using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAppRen.Models;
using WebAppRen.Data;


namespace WebAppRen.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDBContext _context;

        public HomeController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult One()
        {
            return View();
        }

        public IActionResult Thousand()
        {
            return View();
        }

        public IActionResult Custom()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetLatestId()
        {
            var latestId = _context.tblT_Personal.OrderByDescending(p => p.Id).Select(p => p.Id).FirstOrDefault();
            if (latestId < 1)
                latestId = 0;
            return Json(new { latestId });
        }

        [HttpGet]
        public IActionResult GetGender()
        {
            var gender = _context.tblM_gender.ToList();
            return Json(gender);
        }

        [HttpGet]
        public IActionResult GetHobi()
        {
            var hobi = _context.tblM_Hobi.ToList();
            return Json(hobi);
        }

        [HttpPost]
        public IActionResult SubmitData([FromBody] List<Personal> personalList)
        {
            try {
                var dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Nama", typeof(string));
                dataTable.Columns.Add("IdGender", typeof(int));
                dataTable.Columns.Add("IdHobi", typeof(string));
                dataTable.Columns.Add("Umur", typeof(int));

                foreach (var item in personalList)
                {
                    dataTable.Rows.Add(item.Id, item.Nama, item.IdGender, item.IdHobi, item.Umur);
                }

                var umurData = personalList
                .GroupBy(p => p.Umur)
                .Select(g => new { Umur = g.Key, Total = g.Count() })
                .ToList();

                var umurDataTable = new DataTable();
                umurDataTable.Columns.Add("Umur", typeof(int));
                umurDataTable.Columns.Add("Total", typeof(int));

                foreach (var item in umurData)
                {
                    umurDataTable.Rows.Add(item.Umur, item.Total);
                }

                using (var connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("InsertPersonalData", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        var parameter = command.Parameters.AddWithValue("@PersonalData", dataTable);
                        parameter.SqlDbType = SqlDbType.Structured;
                        parameter.TypeName = "dbo.PersonalServer";

                        var umurParam = command.Parameters.AddWithValue("@UmurData", umurDataTable);
                        umurParam.SqlDbType = SqlDbType.Structured;
                        umurParam.TypeName = "dbo.UmurServer";

                        command.ExecuteNonQuery();
                    }
                }

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
