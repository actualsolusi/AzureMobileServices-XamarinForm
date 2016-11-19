using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace mugiservices.Model
{
    public class Mahasiswa
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Nim")]
        public string Nim { get; set; }

        [JsonProperty(PropertyName = "Nama")]
        public string Nama { get; set; }

        [JsonProperty(PropertyName = "IPK")]
        public double IPK { get; set; }

        [Version]
        public string Version { get; set; }
    }
}
