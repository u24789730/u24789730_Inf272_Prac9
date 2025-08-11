using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using u24789730_Inf272_Prac9.Models;

namespace u24789730_Inf272_Prac9.Controllers
{
    public class HomeController : Controller
    {
        // Global connection string visibility
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["ClubMembershipConnection"].ConnectionString;

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to the Social Club Membership Campaign!";
            return View();
        }

        // GET: InsertMember
        public ActionResult InsertMember()
        {
            return View();
        }

        // POST: InsertMember
        [HttpPost]
        public ActionResult InsertMember(Member member)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO ClubMembership (FullName, ClubName, Age, MembershipFee) VALUES (@FullName, @ClubName, @Age, @MembershipFee)";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FullName", member.FullName);
                        command.Parameters.AddWithValue("@ClubName", member.ClubName);
                        command.Parameters.AddWithValue("@Age", member.Age);
                        command.Parameters.AddWithValue("@MembershipFee", member.MembershipFee);
                        
                        command.ExecuteNonQuery();
                    }
                }
                
                ViewBag.Message = "Member successfully registered!";
                ViewBag.MessageType = "success";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
                ViewBag.MessageType = "error";
            }
            
            return View();
        }

        // GET: UpdateMember
        public ActionResult UpdateMember(int? id)
        {
            if (id == null)
            {
                return View(new Member());
            }

            Member member = new Member();
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM ClubMembership WHERE Id = @Id";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                member.Id = (int)reader["Id"];
                                member.FullName = reader["FullName"].ToString();
                                member.ClubName = reader["ClubName"].ToString();
                                member.Age = (int)reader["Age"];
                                member.MembershipFee = (decimal)reader["MembershipFee"];
                            }
                            else
                            {
                                ViewBag.Message = "Member not found.";
                                ViewBag.MessageType = "error";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
                ViewBag.MessageType = "error";
            }
            
            return View(member);
        }

        // POST: UpdateMember
        [HttpPost]
        public ActionResult UpdateMember(Member member)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE ClubMembership SET FullName = @FullName, ClubName = @ClubName, Age = @Age, MembershipFee = @MembershipFee WHERE Id = @Id";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", member.Id);
                        command.Parameters.AddWithValue("@FullName", member.FullName);
                        command.Parameters.AddWithValue("@ClubName", member.ClubName);
                        command.Parameters.AddWithValue("@Age", member.Age);
                        command.Parameters.AddWithValue("@MembershipFee", member.MembershipFee);
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        
                        if (rowsAffected > 0)
                        {
                            ViewBag.Message = "Member profile successfully updated!";
                            ViewBag.MessageType = "success";
                        }
                        else
                        {
                            ViewBag.Message = "No member found with the specified ID.";
                            ViewBag.MessageType = "error";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
                ViewBag.MessageType = "error";
            }
            
            return View(member);
        }

        // GET: Delete
        public ActionResult Delete()
        {
            return View();
        }

        // POST: Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM ClubMembership WHERE Id = @Id";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        
                        if (rowsAffected > 0)
                        {
                            ViewBag.Message = "Member successfully removed from club!";
                            ViewBag.MessageType = "success";
                        }
                        else
                        {
                            ViewBag.Message = "No member found with the specified ID.";
                            ViewBag.MessageType = "error";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: " + ex.Message;
                ViewBag.MessageType = "error";
            }
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}