using System;
using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using UserProject.Models;
using UserProject.Models.Dal;

namespace UserProject.Controllers
{
    public class SigninController : Controller
    {

        private readonly IHttpContextAccessor contxt;

        public SigninController(IHttpContextAccessor httpContextAccessor)
        {
            contxt = httpContextAccessor;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Itemname()
        {
            Operation o = new Operation();
            DataTable dt = o.Itnme();
            String op = "";
            op += "<option value>select</select>";
            foreach (DataRow dr in dt.Rows)
            {
                op += "<option value=" + dr["ID"] + "> " + dr["ITEM_NAME"] + "</option>";
            }
            return Json(new { success = op });
        }
        public async Task<IActionResult> price(int id)
        {
            Operation o = new Operation();
            DataTable dt = o.itemprice(id);
            DataRow dr = dt.Rows[0];
            string mp = dr["PRICE"].ToString();
            return Json(new { success = mp });
        }
      
        public async Task<IActionResult> Insert(SigninModel i)
        {
            Operation o = new Operation();
            string val = o.insert(i);
            return Json(new { success = val });
        }
        public async Task<IActionResult> Pay(SigninModel i)
        {
            Operation o = new Operation();
            string val = o.paypa(i);
            return Json(new { success = val });
        }

        public async Task<IActionResult> Chec(SigninModel obj)
        {
            Operation o = new Operation();
            DataTable dt = o.chekk(obj);
            int s;
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                s = Convert.ToInt32(dr["USERTYPE_ID"]);
                int userid = Convert.ToInt32(dr["ID"]);
                //o.lastlog(userid);
                //DataTable dt2 =  o.UShow(userid);
                //DataRow dr2 = dt2.Rows[0];
                //string lname = dr2["LNAME"].ToString();
                //string email = dr2["EMAIL"].ToString();
                //contxt.HttpContext.Session.SetString("FirstName", dr2["FNAME"].ToString());
                contxt.HttpContext.Session.SetInt32("TYPEId", s);
                contxt.HttpContext.Session.SetInt32("Id", userid);
                //contxt.HttpContext.Session.SetString("LastName", lname);
                //contxt.HttpContext.Session.SetString("Email",email);
                //contxt.HttpContext.Session.SetString("PhnNo", dr2["PHONE_NO"].ToString());
                //contxt.HttpContext.Session.SetString("Gender", dr2["GENDER"].ToString());
                return Json(new { success = true, val = s });
            }
            else
            {
                s = 0;
                return Json(new { success = false, val = s });
            }
        }
        public async Task<IActionResult> show()
        {
            Operation o = new Operation();
            DataTable ds = o.Show();
            string mp = "";
            mp += "<table class =\"table table-light\"><tr><th>SI NO</th>";
            foreach (DataColumn dc in ds.Columns)
            {
                if (dc.ColumnName == "ID")
                {
                    continue;
                }
                mp += "<th>" + dc + "</th>";
            }
            mp += "</tr>";
            int count = 1;
            foreach (DataRow dr in ds.Rows)
            {
                string id = dr["ID"].ToString();
                mp += "<tr ondblclick=Edit(" + id + ")><td>" + count++ + "</td>";

                foreach (DataColumn dc in ds.Columns)
                {
                    if (dc.ColumnName == "ID")
                    {
                        continue;
                    }
                    mp += "<td>" + dr[dc] + "</td>";
                }
            }
            mp += "</tr></table>";
            return Json(new { success = mp });

        }
        public async Task<IActionResult> showorder()
        {
            Operation o = new Operation();
            DataTable ds = o.Showordrs();
            string mp = "";
            mp += "<table class =\"table table-light\"><tr><th>SI NO</th>";
            foreach (DataColumn dc in ds.Columns)
            {
                if (dc.ColumnName == "ID")
                {
                    continue;
                }
                mp += "<th>" + dc + "</th>";
            }
            mp += "</tr>";
            int count = 1;
            foreach (DataRow dr in ds.Rows)
            {
                string id = dr["ID"].ToString();
                mp += "<tr ondblclick=Edit(" + id + ")><td>" + count++ + "</td>";

                foreach (DataColumn dc in ds.Columns)
                {
                    if (dc.ColumnName == "ID")
                    {
                        continue;
                    }
                    mp += "<td>" + dr[dc] + "</td>";
                }
            }
            mp += "</tr></table>";
            return Json(new { success = mp });

        }
        public async Task<IActionResult> showmenu()
        {
            Operation o = new Operation();
            DataTable ds = o.Showmenu();
            string mp = "";
            mp += "<table class =\"table table-light\"><tr><th>SI NO</th>";
            foreach (DataColumn dc in ds.Columns)
            {
                if (dc.ColumnName == "ID")
                {
                    continue;
                }
                mp += "<th>" + dc + "</th>";
            }
            mp += "</tr>";
            int count = 1;
            foreach (DataRow dr in ds.Rows)
            {
                string id = dr["ID"].ToString();
                contxt.HttpContext.Session.SetString("IemId", id);
                mp += "<tr ondblclick=Edit(" + id + ")><td>" + count++ + "</td>";

                foreach (DataColumn dc in ds.Columns)
                {
                    if (dc.ColumnName == "ID")
                    {
                        continue;
                    }
                    mp += "<td>" + dr[dc] + "</td>";
                }
                mp += "<td><a class='nav-link text-dark' href='/Home/Paypal'>ADD TO CART</a></td>";
              


    }
            mp += "</tr></table>";
            return Json(new { success = mp });
        }
        //public async Task<IActionResult> show()
        //{
        //    try
        //    {
        //        Operation o = new Operation();
        //        DataTable ds = o.Show();
        //        string mp = "";
        //        int a;
        //        mp += "<table class =\"table table-light\"><tr><th>SI NO</th>";
        //        foreach (DataColumn dc in ds.Columns)
        //        {
        //            if (dc.ColumnName == "ID")
        //            {
        //                continue;
        //            }
        //            if (dc.ColumnName == "TYPE_ID")
        //            {
        //                continue;
        //            }
        //            mp += "<th>" + dc + "</th>";
        //        }
        //        mp += "</tr>";
        //        int count = 1;
        //        foreach (DataRow dr in ds.Rows)
        //        {
        //            string id = dr["ID"].ToString();
        //            string typeid = dr["TYPE_ID"].ToString();
        //            mp += "<tr><td>" + count++ + "</td>";

        //            foreach (DataColumn dc in ds.Columns)
        //            {
        //                if (dc.ColumnName == "ID")
        //                {
        //                    continue;
        //                }
        //                if (dc.ColumnName == "TYPE_ID")
        //                {
        //                    continue;
        //                }
        //                mp += "<td>" + dr[dc] + "</td>";
        //            }
        //            //a=Convert.ToInt32(dr["TYPE_ID"]);
        //            if (Convert.ToInt32(dr["TYPE_ID"]) == 4)
        //            {
        //                mp += "<td><button class='btn btn-primary' type='button' value='UNBLOCK' onclick='Unblockusr(" + id + ")'>UNBLOCK</button></td>";
        //            }
        //            else if (Convert.ToInt32(dr["TYPE_ID"]) == 1)
        //            {
        //                mp += "<td></td>";
        //            }
        //            else
        //            {
        //                mp += "<td><button class='btn btn-primary' type='button' value='BLOCK' onclick='Blockusr(" + id + ")'>BLOCK</button></td>";
        //            }


        //        }
        //        mp += "</tr></table>";
        //        return Json(new { success = mp });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        //public async Task<IActionResult> Update(SigninModel i)
        //{
        //    Operation o = new Operation();
        //    int val = o.updated(i);
        //    return Json(new { success = val });
        //}
        //public async Task<IActionResult> selebyid(int id)
        //{
        //    Operation o = new Operation();
        //    DataTable ds = o.SelecTDet(id);
        //    DataRow dr = ds.Rows[0];
        //    return Json(new { fname = dr["FNAME"], lname = dr["LNAME"], email = dr["EMAIL"], phno = dr["PHONE_NO"], gender = dr["GENDER"].ToString(), id = dr["ID"] });
        //}
        //public async Task<IActionResult> blocked(int id)
        //{
        //    try
        //    {
        //       Operation o = new Operation();
        //       string val = o.blokk(id);
        //      return Json(new { success = val });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //} 
        //public async Task<IActionResult> Deleted(int id)
        //{
        //    try
        //    {
        //       Operation o = new Operation();
        //       string val = o.Delete(id);
        //      return Json(new { success = val });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}
        public async Task<IActionResult> addcart(int id)
        {
            try
            {
                Operation o = new Operation();
                string val = o.addtocart(id);
                return Json(new { success = val });
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //public async Task<IActionResult> showUser()
        //{
        //    try
        //    {
        //        Operation o = new Operation();
        //        DataTable ds = o.Showusr();
        //        string mp = "";
        //        int a;
        //        mp += "<table class =\"table table-light\"><tr><th>SI NO</th>";
        //        foreach (DataColumn dc in ds.Columns)
        //        {
        //            if (dc.ColumnName == "ID")
        //            {
        //                continue;
        //            }
        //            if (dc.ColumnName == "TYPE_ID")
        //            {
        //                continue;
        //            }
        //            mp += "<th>" + dc + "</th>";
        //        }
        //        mp += "</tr>";
        //        int count = 1;
        //        foreach (DataRow dr in ds.Rows)
        //        {
        //            string id = dr["ID"].ToString();
        //            string typeid = dr["TYPE_ID"].ToString();
        //            mp += "<tr><td>" + count++ + "</td>";

        //            foreach (DataColumn dc in ds.Columns)
        //            {
        //                if (dc.ColumnName == "ID")
        //                {
        //                    continue;
        //                }
        //                if (dc.ColumnName == "TYPE_ID")
        //                {
        //                    continue;
        //                }
        //                mp += "<td>" + dr[dc] + "</td>";
        //            }
        //            if (Convert.ToInt32(dr["TYPE_ID"]) == 4)
        //            {
        //                mp += "<td><button class='btn btn-primary' type='button' value='UNBLOCK' onclick='Unblockusr(" + id + ")'>UNBLOCK</button></td><td><button class='btn btn-primary' type='button' value='DELETE' onclick='Delete(" + id + ")'>DELETE</button></td>";
        //            }
        //            else if (Convert.ToInt32(dr["TYPE_ID"]) == 3)
        //            {
        //                mp += "<td></td>";
        //            }
        //            else
        //            {
        //                mp += "<td><button class='btn btn-primary' type='button' value='BLOCK' onclick='Blockusr(" + id + ")'>BLOCK</button></td><td><button class='btn btn-primary' type='button' value='DELETE' onclick='Delete(" + id + ")'>DELETE</button></td>";
        //            }

        //        }
        //        mp += "</tr></table>";
        //        return Json(new { success = mp });
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}
        //public async Task<IActionResult> btnLogout_Click()
        //{
        //    contxt.HttpContext.Session.RemoveAll();
        //    Session.Abandon();

        //    Response.Redirect("LoginPage.aspx");
        //}



    }
}
