using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Doma = LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Numerics;
using System;

namespace LibeyTechnicalTestAPI.Controllers.LibeyUser
{
    [ApiController]
    [Route("[controller]")]
    public class LibeyUserController : Controller
    {
        private readonly ILibeyUserAggregate _aggregate;
        public LibeyUserController(ILibeyUserAggregate aggregate)
        {
            _aggregate = aggregate;
        }
        [HttpGet]
        [Route("{documentNumber}")]
        public IActionResult FindResponse(string documentNumber)
        {
            var row = _aggregate.FindResponse(documentNumber);
            return Ok(row);
        }
        [HttpPost]
        public IActionResult Create(UserUpdateorCreateCommand command)
        {
            _aggregate.Create(command);
            return Ok(true);
        }

        [HttpPut]
        public IActionResult Update(UserUpdateorCreateCommand command)
        {
            _aggregate.Update(command);
            return Ok(true);
        }

        [HttpDelete]
        [Route("{documentNumber}")]
        public IActionResult Delete(string documentNumber)
        {
            var row = _aggregate.FindResponse(documentNumber).ToList().First();
            if (!row.Active)
            {
                return NoContent();
            }
            var EliminarDato = new UserUpdateorCreateCommand() 
            {
                DocumentNumber = row.DocumentNumber,
                DocumentTypeId =  row.DocumentTypeId,
                Name = row.Name,
                FathersLastName = row.FathersLastName,
                MothersLastName = row.MothersLastName,
                Address = row.Address,
                UbigeoCode = row.UbigeoCode,
                Phone = row.Phone,
                Email = row.Email,
            };

            this._aggregate.Delete(EliminarDato);
            return Ok(true);
        }
    }
}