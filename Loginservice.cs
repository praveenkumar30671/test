using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using realone.Interface;
using realone.model;
using Couchbase;
using Castle.Components.DictionaryAdapter;
using Couchbase.KeyValue;
using Microsoft.Extensions.Options;
using realone.Controllers;





namespace realone.service
{
    public class Loginservice : ILoginService 
    {
        public async Task<List<Logindetails>> GetLoginDetails(ICluster cluster)
        {
            var queryResult = await cluster.QueryAsync<Logindetails>("SELECT designation,id,username,pwd FROM loginDetails",  new Couchbase.Query.QueryOptions());

            List<Logindetails> empList = new List<Logindetails>();

            await foreach (var row in queryResult)
            {
                empList.Add(row);
            }

            return empList;
        }



        public async Task<ICluster> initialize()
        {
            var cluster = await Cluster.ConnectAsync("couchbase://localhost", "Administrator", "Password");
            return cluster;
        }
    }
}