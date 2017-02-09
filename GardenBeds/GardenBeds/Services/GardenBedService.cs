using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GardenBeds.Models;
using Newtonsoft.Json;

namespace GardenBeds.Services
{
    public class GardenBedService : IGardenBedService
    {
        private List<GardenBed> _demodata;
        private Task _loader;

        public GardenBedService()
        {
            LoadDemoData();
        }

        private async void LoadDemoData()
        {
            _loader = Task.Factory.StartNew(async () =>
            {
                var assembly = typeof (GardenBedService).GetTypeInfo().Assembly;
                using (var stream = assembly.GetManifestResourceStream("GardenBeds.Resources.DemoData.json"))
                using (var streamReader = new StreamReader(stream))
                {
                    var json = await streamReader.ReadToEndAsync();
                    _demodata = Task.Factory.StartNew(() =>
                    {
                        var data = JsonConvert.DeserializeObject<List<GardenBed>>(json);
                        return data;
                    }).Result;
                }
            });
            await _loader;
        }

        public async Task<List<GardenBed>> GetGardenBeds()
        {
            await _loader;
            return _demodata;
        }

        public async Task<GardenBed> GetGardenBed(int id)
        {
            await _loader;
            return _demodata.FirstOrDefault(bed => bed.Id == id);
        }
    }
}
