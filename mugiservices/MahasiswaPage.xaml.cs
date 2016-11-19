using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using mugiservices.ViewModel;

namespace mugiservices
{
    public partial class MahasiswaPage : ContentPage
    {
        private MahasiswaViewModel mhsViewModel;
        public MahasiswaPage()
        {
            InitializeComponent();
            mhsViewModel = new MahasiswaViewModel();
            this.BindingContext = mhsViewModel;
        }

        protected override void OnAppearing()
        { 
            //MahasiswaManager manager = MahasiswaManager.DefaultManager;
            //myList.ItemsSource = await manager.GetMahasiswaAsync();
        }
    }
}
