using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PWDataAccess;
using Microsoft.SqlServer;
using System.Data.SqlClient;


namespace PWAPIv2.Controllers
{
    [BasicAuthentication.Controllers.BasicAuthentication]
    public class PubWorksController : ApiController
    {
     

        PubWorksEntities db = new PubWorksEntities();
        public IEnumerable<csc> Get()
        {
            using (PubWorksEntities entities = new PubWorksEntities())
            {
                return entities.csc.ToList();
            }


        }
        //*********************************************************************************************************************************************************************************
        // GET api/pubworks 
        //*********************************************************************************************************************************************************************************

        public csc Get(int id)
        {

            using (PubWorksEntities entities = new PubWorksEntities())
            {
                return entities.csc.FirstOrDefault(e => e.ID == id);
            }

        }

        public csc Post(int id)
        {

            using (PubWorksEntities entities = new PubWorksEntities())
            {
                return entities.csc.FirstOrDefault(e => e.ID == id);
            }

        }
        //*********************************************************************************************************************************************************************************
        // POST api/pubworks   
        //*********************************************************************************************************************************************************************************

        public HttpResponseMessage Post(cscRez value)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    db.cscRez.Add(value);
                   
                    db.SaveChanges();

                    //POST to csc table with value.ID(new cscRez.ID)
                   

                    int result;
                    int insertedID;
                    using (SqlConnection connection = new SqlConnection("Data Source=pw-sql-2012-a1.cloudapp.net;Initial Catalog=Demo60;User ID=Demo60User;Password=edifice;"))
                    {
                        String query = "INSERT INTO dbo.csc (rezid,calldescription) VALUES (@rezid,@call); SELECT SCOPE_IDENTITY()";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            
                            command.Parameters.AddWithValue("@rezid", value.ID);
                            command.Parameters.AddWithValue("@call", value.CallDescription);
                            //command.Parameters.AddWithValue("@password", "abc");
                            //command.Parameters.AddWithValue("@email", "abc");

                            connection.Open();
                            result = command.ExecuteNonQuery();
                            insertedID = Convert.ToInt32(command.ExecuteScalar());

                            // Check Error
                            if (result < 0)
                                Console.WriteLine("Error inserting data into Database!");
                        }
                    }
               
                    return Request.CreateResponse(HttpStatusCode.OK,insertedID);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Model");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/emp/5  ******************************** PUT=UPDATE
        public cscRez Put(int id, string lastname,string name, string mobile, string email, string address, string pwd)
        {
            var obj = db.cscRez.Where(n => n.ID == id).SingleOrDefault();
            if (obj != null)
            {
                obj.Name = lastname;
                obj.FirstName = name;
                obj.PhoneCell = mobile;
                obj.Email = email;
                obj.Address = address;
                //obj.Active = pwd;
                db.SaveChanges();
                int newid = obj.ID;

            }
            return obj;
        }

       


        // DELETE api/emp/5  
        public void Delete(int id)
        {
            //var obj = db.employees.Find(id);
            //db.employees.Remove(obj);
            //db.SaveChanges();
        }
    }
}
