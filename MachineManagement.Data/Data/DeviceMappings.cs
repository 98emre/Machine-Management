using AutoMapper;
using MachineManagement.Core.Dtos.Device;
using MachineManagement.Core.Dtos.ItemDtos;
using MachineManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineManagement.Data.Data
{
    public class DeviceMappings : Profile
    {
        public DeviceMappings()
        {

            // Device Mappings
            CreateMap<Device, DeviceDto>();
            CreateMap<DeviceDto, Device>();

            CreateMap<Device, DevicePostDto>();
            CreateMap<DevicePostDto, Device>();

            CreateMap<Device, DeviceWithoutItemDto>();
            CreateMap<DeviceWithoutItemDto, Device>();

            // Item Mappings
            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>();

            CreateMap<Item, ItemPostDto>();
            CreateMap<ItemPostDto, Item>();

            CreateMap<Item, ItemWithIdDto>();
            CreateMap<ItemWithIdDto, Device>();
        }
    }
}
