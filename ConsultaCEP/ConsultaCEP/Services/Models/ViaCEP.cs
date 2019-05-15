// // --------------------------------------------------------------------------------------------
// //  <copyright file="ViaCEP.cs" company="Web Design Technologies, LLC">
// //      Copyright (c) Web Design Technologies, LLC.  All rights reserved.
// //  </copyright>
// // --------------------------------------------------------------------------------------------

using System;
using System.Net;
using Newtonsoft.Json;

namespace ConsultaCEP.Services.Models
{
    public class ViaCEP
    {
        private static string AddressURL = "https://viacep.com.br/ws/{0}/json/";

        public static Address SearchCEP(string CEP)
        {
            string NewAddressURL = string.Format(AddressURL, CEP);
            WebClient wc = new WebClient();
            string file = wc.DownloadString(NewAddressURL);
            Address address = JsonConvert.DeserializeObject<Address>(file);

            if (address.CEP == null) return null;

            return address;
        }
    }
}