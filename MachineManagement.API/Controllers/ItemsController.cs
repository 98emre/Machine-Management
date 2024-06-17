using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MachineManagement.Data.Data;
using MachineManagement.Core.Entities;
using MachineManagement.Data.Repositories;
using AutoMapper;
using MachineManagement.Core.Repositories;
using MachineManagement.Core.Dtos.ItemDtos;

namespace MachineManagement.API.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly MachineManagementAPIContext _context;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ItemsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _unitOfWork.ItemRepository.GetAllAsync();

            if(!items.Any() || items == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ItemDto>>(items));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var item = await _unitOfWork.ItemRepository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ItemDto>(item));
        }

        [HttpGet("device/{id}")]
        public async Task<IActionResult> GetDeviceItems(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var items = await _unitOfWork.ItemRepository.GetDeviceItemsAsync(id);

            if (!items.Any() || items == null)
            {
                items = new List<Item>();
            }

            return Ok(_mapper.Map<IEnumerable<ItemDto>>(items));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, ItemPostDto itemPostDto)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var item = _mapper.Map<Item>(itemPostDto);
            item.Id = id;

            if (!await ItemExists(item.Id))
            {
                return BadRequest($"Item with Id {item.Id} not found");
            }

            if (!await DeviceExists(item.DeviceId))
            {
                return BadRequest($"Device with Id {item.DeviceId} not found");
            }

            try
            {
                _unitOfWork.ItemRepository.Update(item);
                await _unitOfWork.CompleteAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (! await ItemExists(id))
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
        public async Task<ActionResult<ItemDto>> PostItem(ItemPostDto itemPostDto)
        {
            var item = _mapper.Map<Item>(itemPostDto);

            if (!(await DeviceExists(item.DeviceId)))
            {
                return BadRequest($"Device with Id {item.DeviceId} not found");
            }

            try
            {
                _unitOfWork.ItemRepository.Add(item);
                await _unitOfWork.CompleteAsync();
            }

            catch (Exception)
            {
                return StatusCode(500, "An error occured while posting the game");
            }

            var returnItem = _mapper.Map<ItemDto>(item);

            return CreatedAtAction("GetItem", new { id = returnItem.Id }, returnItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }

            var item = await _unitOfWork.ItemRepository.GetAsync(id);
            
            if (item == null)
            {
                return NotFound();
            }

            try
            {
                _unitOfWork.ItemRepository.Remove(item);
                await _unitOfWork.CompleteAsync();
            }

            catch(Exception)
            {
                return StatusCode(500, "An error occured whilte deleting the item");
            }

            return NoContent();
        }

        private Task<bool> ItemExists(int id) => _unitOfWork.ItemRepository.AnyAsync(id);

        private async Task<bool> DeviceExists(int id) => await _unitOfWork.DeviceRepository.AnyAsync(id);
    }
}
