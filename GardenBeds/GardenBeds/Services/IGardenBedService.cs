using GardenBeds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenBeds.Services
{
    public interface IGardenBedService
    {
        Task<List<GardenBed>> GetGardenBeds();
        Task<GardenBed> GetGardenBed(int id);
    }
}
