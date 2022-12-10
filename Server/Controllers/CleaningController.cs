﻿using HotelFinal.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelFinal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CleaningController : ControllerBase
    {
        private readonly HotelContext hotelContext;

        public CleaningController(HotelContext hotelContext)
        {
            this.hotelContext = hotelContext;
        }

        [HttpPost]
        public async Task RecordRoomCleaning(RoomCleaning roomCleaning)
        {
            await hotelContext.RoomCleanings.AddAsync(roomCleaning);
            await hotelContext.SaveChangesAsync();
        }

        [HttpGet("types")]
        public async Task<List<CleaningType>> GetCleaningTypesAsync()
        {
            return await hotelContext.CleaningTypes.ToListAsync();
        }

    }
}