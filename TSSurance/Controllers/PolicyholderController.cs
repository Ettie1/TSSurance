using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using System.Text;
using TSSurance.Models;
using TSSurance.Lib;
using TSSurance.ViewModels;

namespace TSSurance.Controllers
{
    public class PolicyholderController : Controller
    {
        private TSureDbContext db = new TSureDbContext();
        
        // GET: Policyholder
        public ActionResult Index()
        {
            return View();
        }
        private string ByteToText(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
        public ActionResult RegisterAgent()
        {
            TempData["warning"] = "Registering new agent";
            return View();
        }
        [HttpPost]
        public ActionResult RegisterAgent(RegAgent agent)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Invalid information found!!!";
                return View(agent);
            }
            TempData["success"] = $"Successfully registered {agent.FirstName} {agent.LastName}";
            agent.Salt = Security.GetSalt(128);
            agent.Password = Encoding.UTF8.GetString(Security.Hash(agent.Password, agent.Salt));
            db.Agents.Add(agent);
            db.SaveChanges();
            return View();
        }
        public ActionResult LoginAgent()
        {
            return View();
        }

        public ActionResult PolicyholderMenu()
        {
            ViewBag.Title = "Policyholders";
            ViewBag.Message = "Please select one of the available options";
            ViewBag.Details = $"Policyholder related options.\nAdded functionality that is Policyholder specific and generalized.\nReports should be available as well as exportation to word processors and spreadsheets.";
            TempData["notes"] = "Here are some friendly notes.";
            return View();
        }
        public ActionResult SearchPolicyholder()
        {
            TempData["error"] = "You will be searching";
            return View();
        }
        [HttpPost]
        public ActionResult SearchPolicyholder(string firstname, string lastname, string idno)
        {
            if(!firstname.IsEmpty()&&!lastname.IsEmpty()&&!idno.IsEmpty())
            {
                return View(db.PolicyHolders.Where(p=>p.FirstName==firstname&&p.IDNo==idno));
            }
            else if(!lastname.IsEmpty() && !idno.IsEmpty())
            {
                return View(db.PolicyHolders.Where(p => p.LastName == lastname && p.IDNo == idno));
            }
            else if(!lastname.IsEmpty())
            {
                return View(db.PolicyHolders.Where(p => p.LastName == lastname));
            }
            return View();
        }
        public ActionResult CreatePolicyholder()
        {
            ViewData["success"] = "Create a new policy holder.";
            return View();
        }
        [HttpPost]
        public ActionResult CreatePolicyholder(RegPolicyholder policyholder)
        {
            if(!ModelState.IsValid)
            {
                TempData["error"] = "Invalid values passed.";
                return View(policyholder);
            }

            db.PolicyHolders.Add(policyholder);
            db.SaveChanges();
            TempData["success"] = $"Successfully created {policyholder.Title}, {policyholder.FirstName} {policyholder.LastName}.";

            return View();
        }

        public ActionResult PolicyholderDetail(int? id)
        {
            TempData["notes"] = "Details and more";
            return View(db.PolicyHolders.Single(p=>p.PolicyHolderId==id));
        }

        public ActionResult PolicyholderDelete(int? id)
        {
            TempData["warning"] = "Deleting a policy holder.";
            return View(db.PolicyHolders.Single(p => p.PolicyHolderId == id));
        }
        public ActionResult PolicyholderEdit(int? id)
        {
            TempData["warning"] = "Editing a policy holder.";
            return View(db.PolicyHolders.Single(p => p.PolicyHolderId == id));
        }

        public ActionResult ListAllPolicyholders()
        {
            TempData["error"] = "This should not be done.";
            return View(db.PolicyHolders.ToList());
        }

        public ActionResult AddPayment(int? phId)
        {
            PolicyHolder phi = db.PolicyHolders.SingleOrDefault(ph => ph.PolicyHolderId == phId);
            PayViewModel pvm = new PayViewModel()
            {
                Policyholder = phi,
                Payment = new Payment()
                {
                    PolicyholderId = phi.PolicyHolderId,
                    PaymentDate = DateTime.Now
                }
            };
            return View(pvm);
        }

        public ActionResult AddPolicy(int? phId)
        {
            #region Temptext
            /*
            PolicyHolder phi = db.PolicyHolders.SingleOrDefault(ph => ph.PolicyHolderId == phId);
            AddPolicyViewModel apvm = new AddPolicyViewModel()
            {
                Policyholder = phi,
                Policy = new Policy
                {
                    PolicyHolderId = phi.PolicyHolderId,
                    PolicyHolder = phi

                }
            };
            */
            #endregion Temptext
            PolicyHolder policyHolder = db.PolicyHolders.SingleOrDefault(ph => ph.PolicyHolderId == phId);

            Policy pol = new Policy { PolicyHolder = policyHolder, PolicyHolderId = policyHolder.PolicyHolderId };
            return View("AddPolicy", pol);
        }
        [HttpPost]
        public ActionResult AddPolicy(Policy policy)
        {
            db.Policies.Add(policy);
            db.SaveChanges();
            return RedirectToAction(nameof(PolicyholderEdit), new { id = policy.PolicyHolder.PolicyHolderId });
        }
    }
}