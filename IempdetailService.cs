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
    public interface IempdetailService
    {
        Task<ICluster> Initialize();
        Task<List<empdetails>> GetEmployees(ICluster cluster);
        Task<empdetails> GetEmployeeBYid(ICluster cluster, int id);
        Task<empdetails> DeleteEmployees(ICluster cluster, int id);
        Task<empdetails> PutEmployeeBYid(ICluster cluster, int id, empdetails value);


    }
}
