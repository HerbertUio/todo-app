using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using uab.server.Business;
using uab.server.Entities;
using uab.server.Entities.Entities;
using uab.server.webapp.Models;

namespace uab.server.webapp.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        private readonly UsuarioBusiness usuarioBusiness;
        public UsuarioController()
        {
            usuarioBusiness = new UsuarioBusiness();
        }

        [HttpPost]
        [Route("getAll")]
        public IHttpActionResult RetornarTodoApp()
        {
            var result = new List<Usuario>();
            for (int i = 1; i < 1000; i++)
            {
                var usuario = usuarioBusiness.GetById(i);
                if (usuario != null)
                    result.Add(usuario);
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("save")]
        public IHttpActionResult SaveMethod([FromBody] LiteUsuarioModel entity)
        {
            var usuario = usuarioBusiness.GetById(entity.Id) ?? new Usuario();
            usuario.Nombre = entity.Nombre;
            usuario.Apellido = entity.Apellido;
            usuario.FechaNacimiento = entity.FechaNacimiento;
            usuario.Sexo = (entity.Sexo.id==0) ? SexoEnum.Femenino : SexoEnum.Masculino;
            usuarioBusiness.SaveOrUpdate(usuario);
            return Ok();
        }
        [HttpPost]
        [Route("delete")]
        public IHttpActionResult DeleteNethod([FromBody] LiteUsuarioModel id)
        {
            usuarioBusiness.DeleteById(id.Id);
            return Ok();
            
        }

        //[HttpPost]
        //[Route("save")]
        //public IHttpActionResult Save(Usuario dato)
        //{
        //    if(dato.Id == 0)
        //    {
        //        dato.FechaNacimiento = DateTime.Now;
        //    }
        //    dato.FechaNacimiento = DateTime.Now;
        //    var result = usuarioBusiness.SaveOrUpdate(dato);
        //    return Ok(result);
        //}

        ////[HttpPost]
        ////[Route("update")]
        ////public IHttpActionResult Update(Usuario dato)
        ////{
        ////    var result = usuarioBusiness.SaveOrUpdate(dato);
        ////    return Ok(result);
            

        //}
        //[HttpPost]
        //[Route("delete")]
        //public IHttpActionResult Delete(int entityId)
        //{
        //    todoAppBusiness.DeleteById(entityId);
        //    return Ok("Se elimino corretamente!!!");
        //}

        //[HttpPost]
        //[Route("serachbydescription")]
        //public IHttpActionResult SearchByDescrition(string description)
        //{
        //    var resultado = todoAppBusiness.SearchByDescription(description);
        //    var sexousuario = resultado.FirstOrDefault().Usuario.Sexo.ToString(); 
        //    return Ok(resultado);
        //}

        //// GET: api/TodoApp
        //public IHttpActionResult Get()
        //{
        //    var resultado = todoAppBusiness.GetById(1008);
        //    return Ok(resultado);
        //}

        //// GET: api/TodoApp/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/TodoApp
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/TodoApp/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/TodoApp/5
        //public void Delete(int id)
        //{
        //}
    }
}
