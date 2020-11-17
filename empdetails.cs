using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Couchbase;
using realone.model;
using realone.Interface;


namespace realone.model
{
    public class empdetails

    { 
        
        public int id { get; set; }
        public string name { get; set; }
        public int empid { get; set; }
        public string srccs { get; set; }
        public string emailid { get; set; }    
        public string phonenumber { get; set; }
        public string skill { get; set; }
        

       
    }

}

