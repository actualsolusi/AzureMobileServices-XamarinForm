using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using mugiservices.Model;

using mugiservices;
using System.Collections.ObjectModel;
using System.Threading;

namespace mugiservices.ViewModel
{
    public class MahasiswaViewModel : BindableObject
    {
        private MahasiswaManager manager;
        private ObservableCollection<Mahasiswa> lstItems;
        public ObservableCollection<Mahasiswa> ListItems
        {
            get { return lstItems; }
            set { lstItems = value; OnPropertyChanged("ListItems"); }
        }

        public MahasiswaViewModel()
        {
            manager = MahasiswaManager.DefaultManager;
            GetData();
        }

        private async void SeedData()
        {
            //var newMhs = new Mahasiswa { Nim = "22002321", Nama = "Erick Kurniawan", IPK = 3.5 };
            var newMhs = new Mahasiswa { Nim = "22002322", Nama = "Jovan Kurniawan", IPK = 3.7 };
            await manager.SaveTaskAsync(newMhs);
        }

        public async void GetData()
        {
            ListItems = await manager.GetMahasiswaAsync();
        }  

    }
}
