using Couchbase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using realone.model;
using realone.Interface;
using realone.Controllers;


namespace realone.Interface
{
    public interface ILoginService
    {
        Task<ICluster> initialize();
           
        Task<List<Logindetails>> GetLoginDetails(ICluster cluster);
    }




}

