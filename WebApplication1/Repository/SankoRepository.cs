using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication1.Library;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class SankoRepository
    {
        public CommonResponse InsertData(SankoModel model)
        {
            CommonResponse res = new CommonResponse();
            string sql = string.Empty;
            DataTable dbResp = null;
            try
            {
                sql = "exec sproc_sanko @flag='i'";
                sql += ",@quantity=" + Dao.FilterString(model.Quantity);
                sql += ",@category=" + Dao.FilterString(model.Category);
                sql += ",@size=" + Dao.FilterString(model.Size);
                sql += ",@amount=" + Dao.FilterString(model.Amount);
                dbResp = Dao.RunSQL(sql);
            }
            catch (Exception)
            {

                return new CommonResponse()
                {
                    code = "2",
                    message = "Exception",
                    errors = new List<Errors>()
                    {
                        new Errors()
                        {
                            error_code = "800",
                            error_message= "API Exception"
                        }
                    }
                };
            }
            if (dbResp != null)
            {
                res.code = "0";
                res.message = "success";
            }
            return res;
        }

        public CommonResponse GetAll()
        {
            CommonResponse res = new CommonResponse();
            string sql = string.Empty;
            DataTable dbResp = null;
            try
            {
                sql = "exec sproc_sanko @flag='all'";
                //sql += ",@id=" + Dao.FilterString(id);
                dbResp = Dao.RunSQL(sql);
            }
            catch (Exception ex)
            {
                return new CommonResponse()
                {
                    code = "2",
                    message = "Exception",
                    errors = new List<Errors>()
                    {
                        new Errors()
                        {
                            error_code = "800",
                            error_message= "API Exception"
                        }
                    }
                };
            }

            if (dbResp.Rows.Count == null)
            {
                return new CommonResponse()
                {
                    code = "1",
                    message = "Error",
                    errors = new List<Errors>()
                    {
                        new Errors()
                        {
                            error_code = "100",
                            error_message = "No  List Available"
                        }
                    }
                };
            }

            if (dbResp.Rows.Count > 0)
            {
                List<SankoModel> model = new List<SankoModel>();

                foreach (DataRow item in dbResp.Rows)
                {
                    SankoModel sanko = new SankoModel();
                    sanko.id = item["id"].ToString();
                    sanko.Quantity = item["quantity"].ToString();
                    sanko.Amount = item["amount"].ToString();
                    sanko.Size = item["size"].ToString();
                    sanko.Category = item["category"].ToString();
                    res.code = item["code"].ToString();
                    res.message = item["message"].ToString();
                    model.Add(sanko);
                    
                }
                //res.code = "0";
                //res.message = "success";
                res.data = model;
            };
            return res;
        }


        public CommonResponse DeleteData(SankoModel common)
        {
            CommonResponse res = new CommonResponse();
            DataTable dbResp = null;
            string sql = string.Empty;

            try
            {
                sql = "exec sproc_sanko @flag='del'";
                sql += ",@id=" + Dao.FilterString(common.id);
                dbResp = Dao.RunSQL(sql);
            }
            catch (Exception ex)
            {
                return new CommonResponse()
                {
                    code = "2",
                    message = "Exception",
                    errors = new List<Errors>()
                    {
                        new Errors()
                        {
                            error_code = "800",
                            error_message= "API Exception"
                        }
                    }
                };
            }

            if (dbResp.Rows.Count == null)
            {
                return new CommonResponse()
                {
                    code = "1",
                    message = "Error",
                    errors = new List<Errors>()
                    {
                        new Errors()
                        {
                            error_code = "100",
                            error_message = "No  List Available"
                        }
                    }
                };
            }

            if (dbResp != null)
            {
                res.code = "0";
                res.message = "success";
            }
            return res;
        }


        public CommonResponse UpdateData(SankoModel model,string id)
        {
            CommonResponse res = new CommonResponse();
            string sql = string.Empty;
            DataTable dbResp = null;
            try
            {
                sql = "exec sproc_sanko @flag='up'";
                sql += ",@id=" + Dao.FilterString(id);
                sql += ",@quantity=" + Dao.FilterString(model.Quantity);
                sql += ",@category=" + Dao.FilterString(model.Category);
                sql += ",@size=" + Dao.FilterString(model.Size);
                sql += ",@amount=" + Dao.FilterString(model.Amount);
                dbResp = Dao.RunSQL(sql);
            }
            catch (Exception)
            {

                return new CommonResponse()
                {
                    code = "2",
                    message = "Exception",
                    errors = new List<Errors>()
                    {
                        new Errors()
                        {
                            error_code = "800",
                            error_message= "API Exception"
                        }
                    }
                };
            }
            if (dbResp != null)
            {
                foreach (DataRow item in dbResp.Rows)
                {                 
                    res.code = item["code"].ToString();
                    res.message = item["message"].ToString();
                }
                //res.code = "0";
                //res.message = "success";
            }
            return res;
        }

        public CommonResponse GetById(string id)
        {
            CommonResponse res = new CommonResponse();
            string sql = string.Empty;
            DataTable dbResp = null;
            try
            {
                sql = "exec sproc_sanko @flag='details'";
                sql += ",@id=" + Dao.FilterString(id);
                dbResp = Dao.RunSQL(sql);
            }
            catch (Exception ex)
            {
                return new CommonResponse()
                {
                    code = "2",
                    message = "Exception",
                    errors = new List<Errors>()
                    {
                        new Errors()
                        {
                            error_code = "800",
                            error_message= "API Exception"
                        }
                    }
                };
            }

            if (dbResp.Rows.Count == null)
            {
                return new CommonResponse()
                {
                    code = "1",
                    message = "Error",
                    errors = new List<Errors>()
                    {
                        new Errors()
                        {
                            error_code = "100",
                            error_message = "No  List Available"
                        }
                    }
                };
            }

            if (dbResp.Rows.Count > 0)
            {
                //List<SankoModel> model = new List<SankoModel>();

                foreach (DataRow item in dbResp.Rows)
                {
                    SankoModel sanko = new SankoModel()
                    {
                        id = item["id"].ToString(),
                        Quantity = item["quantity"].ToString(),
                        Amount = item["amount"].ToString(),
                        Size = item["size"].ToString(),
                        Category = item["category"].ToString(),
                    };
                    res.data = sanko;

                    //sanko.code = item["code"].ToString();
                    //sanko.message = item["message"].ToString();
                }
                res.code = "0";
                res.message = "success";
            };
            return res;
        }

    }
}