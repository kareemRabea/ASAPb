using ASAP.Dto;
using ASAP.Models;
using ASAP.UnitOfWork;
using AutoMapper;
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
    public class AddressController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AddressController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _unitOfWork.Address.GetAllAsync();
            if (result == null)
            {
                return StatusCode(204);
            }
            return StatusCode(200, result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddressDto model)
        {
            var Address = _mapper.Map<Address>(model);
            var result = await _unitOfWork.Address.AddAsync(Address);
            if (result == null)
            {
                return StatusCode(203);
            }
            return StatusCode(201, result);
        }

        [HttpPost("Update")]
        public IActionResult Update(AddressDto model)
        {
            var Address = _mapper.Map<Address>(model);
            var result = _unitOfWork.Address.Update(Address);
            if (result == null)
            {
                return StatusCode(203);
            }
            return StatusCode(201, result);
        }


        [HttpPost("Delete")]
        public IActionResult Delete(Address model)
        {
            _unitOfWork.Address.Delete(model);

            return StatusCode(201);
        }
    }
}
