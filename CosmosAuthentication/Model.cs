using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosAuthentication
{
    public class CosmosToken
    {
        public string Endpoint { get; set; }
        public string Key { get; set; }
    }

    public class SuperCodeContext
    {
        public static readonly string SuperCode
            = nameof(SuperCode).ToLower();
    }
}
