using GardenBeds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GardenBeds.Services
{
    public interface IGardenBedsService
    {
        Task<List<GardenBed>> GetGardenBeds();
        Task<GardenBed> GetGardenBed(int id);
    }
}
