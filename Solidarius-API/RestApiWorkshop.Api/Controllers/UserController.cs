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
    public class UserCredential
    {
        public string email { get; set; }
        public string pass { get; set; }
    }
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
        public IActionResult CheckSession(int userId, int userTypeInt)
        {
            var userType = (UserType)userTypeInt;
            //var userId_test = HttpContext.Session.GetInt32("UserId");
            //var userType_test = HttpContext.Session.GetInt32("UserType");
            //var sessionOn = userId_test != null &&
            //                userId_test != 0 &&
            //                userType_test != null &&
            //                userType_test != 0;
            //if (!sessionOn)
            //{
            //    return NoContent();
            //}

            //var userId = HttpContext.Session.GetInt32("UserId").Value;
            //var userType = (UserType)HttpContext.Session.GetInt32("UserType").Value;

            IModel user = null;
            switch (userType)
            {
                case UserType.Beneficiario:
                    user = context.Beneficiario.Find(userId);
                    var beneficiarioDto = mapper.Map<BeneficiarioDto>(user);
                    return Ok(new { obj = beneficiarioDto, userType = userType });
                    // break;
                case UserType.Doador:
                    user = context.Doador.Find(userId);
                    var doadorDto = mapper.Map<DoadorDto>(user);
                    return Ok(new { obj = doadorDto, userType = userType });
                    // break;
                case UserType.Mediador:
                    user = context.Mediador.Find(userId);
                    var mediadorDto = mapper.Map<MediadorDto>(user);
                    return Ok(new { obj = mediadorDto, userType = userType });
                    // break;
            }
            return NotFound();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]UserCredential user)
        {
            var email = user.email;
            var pass = user.pass;
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
            int? userType = null;

            var beneficiario = context.Beneficiario.Where(w => w.Id == userId);
            if (beneficiario.Any())
            {
                userType = (int)UserType.Beneficiario;
            }
            var doador = context.Doador.Where(w => w.Id == userId);
            if (doador.Any())
            {
                userType = (int)UserType.Doador;
            }
            var mediador = context.Mediador.Where(w => w.Id == userId);
            if (mediador.Any())
            {
                userType = (int)UserType.Mediador;
            }
            HttpContext.Session.SetInt32("UserType", userType.Value);
            return Ok(new { userId, userType });

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
