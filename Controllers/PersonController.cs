using ASAP.Dto;
using ASAP.Models;
using ASAP.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PersonController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.Person.GetAllAsync();
            if (result == null)
            {
                return StatusCode(204);
            }
            return StatusCode(200, result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(PersonDto model)
        {
            var person = _mapper.Map<Person>(model);
            var result = await _unitOfWork.Person.AddAsync(person);
            if (result == null)
            {
                return StatusCode(203);
            }
            return StatusCode(201, result);
        }

        [HttpPost("Update")]
        public IActionResult Update(PersonDto model)
        {
            var person = _mapper.Map<Person>(model);
            var result = _unitOfWork.Person.Update(person);
            if (result == null)
            {
                return StatusCode(203);
            }
            return StatusCode(201, result);
        }


        [HttpPost("Delete")]
        public IActionResult Delete(Person model)
        {
            _unitOfWork.Person.Delete(model);

            return StatusCode(201);
        }
    }
}
