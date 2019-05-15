﻿// // --------------------------------------------------------------------------------------------
// //  <copyright file="Address.cs" company="Web Design Technologies, LLC">
// //      Copyright (c) Web Design Technologies, LLC.  All rights reserved.
// //  </copyright>
// // --------------------------------------------------------------------------------------------

namespace ConsultaCEP.Services.Models
{
    public class Address
    {
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string Unidade { get; set; }
        public string IBGE { get; set; }
        public string GIA { get; set; }
    }
}