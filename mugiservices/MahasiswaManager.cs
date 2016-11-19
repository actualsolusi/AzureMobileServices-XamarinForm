using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using mugiservices.Model;

namespace mugiservices
{
    public class MahasiswaManager
    {
        static MahasiswaManager defaultInstance = new MahasiswaManager();
        MobileServiceClient client;

        //menambahkan table mobile services
        IMobileServiceTable<Mahasiswa> mahasiswaTable;

        private MahasiswaManager()
        {
            this.client = new MobileServiceClient(Constants.ApplicationURL);
            this.mahasiswaTable = client.GetTable<Mahasiswa>();
        }

        public static MahasiswaManager DefaultManager
        {
            get
            {
                return defaultInstance;
            }
            private set
            {
                defaultInstance = value;
            }
        }

        public MobileServiceClient CurrentClient
        {
            get { return client; }
        }

        public async Task<ObservableCollection<Mahasiswa>> GetMahasiswaAsync()
        {
            try
            {
                IEnumerable<Mahasiswa> items = await mahasiswaTable.ToEnumerableAsync();

                return new ObservableCollection<Mahasiswa>(items);
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                Debug.WriteLine(@"Invalid sync operation: {0}", msioe.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(@"Sync error: {0}", e.Message);
            }
            return null;
        }

        public async Task SaveTaskAsync(Mahasiswa item)
        {
            if (item.Id == null)
            {
                await mahasiswaTable.InsertAsync(item);
            }
            else
            {
                await mahasiswaTable.UpdateAsync(item);
            }
        }

    }
}
