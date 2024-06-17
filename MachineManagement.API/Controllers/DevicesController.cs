using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MachineManagement.Core.Entities;
using MachineManagement.Core.Repositories;
using AutoMapper;
using MachineManagement.Core.Dtos.Device;

namespace MachineManagement.API.Controllers
{
    [Route("api/devices")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DevicesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDevice()
        {
            var devices = await _unitOfWork.DeviceRepository.GetAllAsync();

            if(!devices.Any() ||  devices == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<DeviceWithoutItemDto>>(devices));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDevice(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            var device = await _unitOfWork.DeviceRepository.GetAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DeviceWithoutItemDto>(device));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice(int id, DevicePostDto devicePostDto)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            if (! await DeviceExists(id))
            {
                return BadRequest($"Device with Id {id} not found");
            }

            var device = _mapper.Map<Device>(devicePostDto);
            device.Id = id;

            try
            {
                _unitOfWork.DeviceRepository.Update(device);
                await _unitOfWork.CompleteAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DeviceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<DevicePostDto>> PostDevice(DevicePostDto devicePostDto)
        {
            var device = _mapper.Map<Device>(devicePostDto);

            try
            {
                _unitOfWork.DeviceRepository.Add(device);
                await _unitOfWork.CompleteAsync();
            }

            catch(Exception)
            {
                return StatusCode(500, "An error occured while posting the device");
            }

            var returnDevice = _mapper.Map<DeviceDto>(device);

            return CreatedAtAction("GetDevice", new { id = returnDevice.Id }, returnDevice);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            var device = await _unitOfWork.DeviceRepository.GetAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            try
            {
                _unitOfWork.DeviceRepository.Remove(device);
                await _unitOfWork.CompleteAsync();
            }

            catch (Exception)
            {
                return StatusCode(500, "An error occured whilte deleting the game.");
            }

            return NoContent();
        }

        private async Task<bool> DeviceExists(int id) => await _unitOfWork.DeviceRepository.AnyAsync(id);

    }
}
