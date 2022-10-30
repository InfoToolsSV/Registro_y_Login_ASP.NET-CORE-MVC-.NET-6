using Microsoft.AspNetCore.Mvc;
using MVC.Data;
using MVC.Models;
using System.Data;
using System.Data.SqlClient;

namespace MVC.Controllers
{
    public class CuentaController : Controller
    {
        private readonly DbContext _contexto;

        public CuentaController(DbContext contexto)
        {
            _contexto = contexto;
        }

        public ActionResult Registrar()
        {
            return View("Registrar");
        }

        [HttpPost]
        public ActionResult Registrar(UsuarioModel u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new(_contexto.Valor))
                    {
                        using (SqlCommand cmd = new("sp_registrar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = u.Nombre;
                            cmd.Parameters.Add("@Correo", SqlDbType.VarChar).Value = u.Correo;
                            cmd.Parameters.Add("@Edad", SqlDbType.Int).Value = u.Edad;
                            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = u.Usuario;
                            cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = u.Clave;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
                return View("Registrar");
            }
            ViewData["error"] = "Error de credenciales";
            return View("Registrar");
        }


        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginModel l)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new(_contexto.Valor))
                    {
                        using (SqlCommand cmd = new("sp_login", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = l.Usuario;
                            cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = l.Clave;
                            con.Open();

                            SqlDataReader dr = cmd.ExecuteReader();

                            if (dr.Read())
                            {
                                Response.Cookies.Append("user", "Bienvenido "+l.Usuario);
                                return RedirectToAction("Index", "Home");
                            }
                            else{
                                ViewData["error"]="Error de credenciales";
                            }

                            con.Close();
                        }
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
                return View("Login");
            }
            return View("Login");
        }

        public ActionResult Logout()
        {
            Response.Cookies.Delete("user");
            return RedirectToAction("Index", "Home");
        }
    }
}