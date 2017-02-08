using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace GardenBeds.Models
{
    public class GardenBed : BindableBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private int _size;
        public int Size
        {
            get { return _size; }
            set { SetProperty(ref _size, value); }
        }

        private ObservableCollection<Plantation> _plantation;
        public ObservableCollection<Plantation> Plantations
        {
            get { return _plantation; }
            set { SetProperty(ref _plantation, value); }
        }
         
    }
}