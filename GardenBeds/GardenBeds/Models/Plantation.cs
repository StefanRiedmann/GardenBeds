using Prism.Mvvm;

namespace GardenBeds.Models
{
    public class Plantation : BindableBase
    {
        private Plants _plant;
        public Plants Plant
        {
            get { return _plant; }
            set { SetProperty(ref _plant, value); }
        }
    }
}
