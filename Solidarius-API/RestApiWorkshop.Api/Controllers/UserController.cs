using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolidariusAPI.Api.Data;
using SolidariusAPI.Api.Enum;
using SolidariusAPI.Api.Models;
using SolidariusAPI.Api.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidariusAPI.Api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IDatabase context;
        private readonly IMapper mapper;
        public UserController(IDatabase context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("user-page")]
        public IActionResult CheckSession()
        {
            var sessionOn = HttpContext.Session.GetInt32("UserId") != null &&
                            HttpContext.Session.GetInt32("UserId") != 0 &&
                            HttpContext.Session.GetInt32("UserType") != null &&
                            HttpContext.Session.GetInt32("UserType") != 0;
            if (!sessionOn)
            {
                return NoContent();
            }

            var userId = HttpContext.Session.GetInt32("UserId").Value;
            var userType = (UserType)HttpContext.Session.GetInt32("UserType").Value;

            IModel user = null;
            IDto dto = null;
            switch (userType)
            {
                case UserType.Beneficiario:
                    user = context.Beneficiario.Find(userId);
                    dto = mapper.Map<BeneficiarioDto>(user);
                    break;
                case UserType.Doador:
                    user = context.Doador.Find(userId);
                    dto = mapper.Map<DoadorDto>(user);
                    break;
                case UserType.Mediador:
                    user = context.Mediador.Find(userId);
                    dto = mapper.Map<MediadorDto>(user);
                    break;
            }

            return Ok(new { obj = dto, userType = userType });
        }

        [HttpGet("login")]
        public IActionResult Login(string email, string pass)
        {
            var userId = context.Usuario
                            .Where(w => w.Email == email)
                            .Where(w => w.Senha == pass)
                            .Select(s => s.Id)
                            .FirstOrDefault();
            if (userId == 0)
            {
                return NoContent();
            }
            HttpContext.Session.SetInt32("UserId", userId);

            var beneficiario = context.Beneficiario.Where(w => w.Id == userId);
            if (beneficiario.Any())
            {
                HttpContext.Session.SetInt32("UserType", (int)UserType.Beneficiario);
            }
            var doador = context.Doador.Where(w => w.Id == userId);
            if (doador.Any())
            {
                HttpContext.Session.SetInt32("UserType", (int)UserType.Doador);
            }
            var mediador = context.Mediador.Where(w => w.Id == userId);
            if (mediador.Any())
            {
                HttpContext.Session.SetInt32("UserType", (int)UserType.Mediador);
            }
            return Ok();

            //var query = context.Query(
            //    @"
            //        select u.UsuarioId, 
            //               b.BeneficiadoId, 
            //               m.MediadorId, 
            //               d.DoadorId 
            //        from 
            //            usuario as u 
            //            left join beneficiario as b on u.UsuarioId = b.UsuarioId 
            //            left join doador as d on u.UsuarioId = d.UsuarioId 
            //            left join mediador as m on u.UsuarioId = m.UsuarioId 
            //        where u.UsuarioId = :userId");
            //query.SetInt32("userId", userId);
        }
    }
}
