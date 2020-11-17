using Castle.Components.DictionaryAdapter;
using Couchbase;
using Couchbase.KeyValue;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using realone.Interface;
using realone.Controllers;
using realone.model;

namespace realone.service
{
    public class empdetailservice : IempdetailService
    {
        public async Task<empdetails> DeleteEmployees(ICluster cluster, int id)
        {
            var queryResult = await cluster.QueryAsync<empdetails>("SELECT id,name,empid,emailid,srccs,phonenumber,skill FROM Employeedetails where id= " + id.ToString(), new Couchbase.Query.QueryOptions());
            var bucket = await cluster.BucketAsync("Employeedetails");
            var collection = bucket.DefaultCollection();

            await collection.RemoveAsync(id.ToString());
            return null;
        }

        public async Task<empdetails> GetEmployeeBYid(ICluster cluster, int id)
        {
            empdetails employee = new empdetails();
            var queryResult = await cluster.QueryAsync<empdetails>("SELECT id,name,empid,emailid,srccs,phonenumber,skill FROM Employeedetails where id=" + id, new Couchbase.Query.QueryOptions());

            await foreach (var row in queryResult)
            {
                employee = row;
            }

            return employee;
        }

        public async Task<List<empdetails>> GetEmployees(ICluster cluster)
        {
            var queryResult = await cluster.QueryAsync<empdetails>("SELECT id,name,empid,emailid,srccs,phonenumber,skill FROM Employeedetails ", new Couchbase.Query.QueryOptions());

            List<empdetails> empList = new List<empdetails>();

            await foreach (var row in queryResult)
            {
                empList.Add(row);
            }

            return empList;
        }

        public async Task<ICluster> Initialize()
        {
            var cluster = await Cluster.ConnectAsync("couchbase://localhost", "Administrator", "Password");
            return cluster;
        }

        public async Task<empdetails> PutEmployeeBYid(ICluster cluster, int id, empdetails value)
        {
            var bucket = await cluster.BucketAsync("Employeedetails");
            var collection = bucket.DefaultCollection();
            await collection.UpsertAsync(id.ToString(), value);

            return null;

        }



    }
}

