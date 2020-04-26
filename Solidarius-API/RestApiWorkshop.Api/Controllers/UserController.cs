using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolidariusAPI.Api.Data;
using SolidariusAPI.Api.Enum;
using SolidariusAPI.Api.Models;
using SolidariusAPI.Api.TransferObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
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

        [HttpPost("images")]
        public IActionResult UserImage([FromForm]int userId)
        {
            string PathDB = "../../DB/Images";

            if (HttpContext.Request.Form.Files == null)
            {
                return NoContent();
            }

            var files = HttpContext.Request.Form.Files;
            if (files.Count != 1)
            {
                return BadRequest();
            }
            var file = files[0];
            if (file.Length < 0)
            {
                return NoContent();
            }


            //Getting FileName
            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

            //Assigning Unique Filename (Guid)
            var uniqueFileName = Convert.ToString(Guid.NewGuid());

            //Getting file Extension
            var FileExtension = Path.GetExtension(fileName);

            // concating  FileName + FileExtension
            var newFileName = uniqueFileName + FileExtension;

            // Combines two strings into a path.
            fileName = PathDB + $@"\{ newFileName}";

            // if you want to store path of folder in database
            PathDB = "Images/" + newFileName;

            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            if (userId != 0)
            {
                var user = context.Usuario.Find(userId);
                user.FotoUsuario = PathDB;
                context.Update(user);
            } else
            {
                return Ok(new { path = PathDB});
            }

            return Ok();
        }
        [HttpGet("image/{userId}")]
        public async Task<IActionResult> Get([FromRoute]int userId)
        {
            string PathDB = "../../DB/";
            var user = context.Usuario.Find(userId);
            var image = System.IO.File.OpenRead(PathDB + user.FotoUsuario);
            return File(image, "image/jpeg");
        }
    }
}
