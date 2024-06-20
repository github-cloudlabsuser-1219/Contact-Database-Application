using CRUD_application_2.Models;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            // Implement the Index method here
           return View(userlist);
        }
 
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Implement the details method here
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
 
        // GET: User/Create
        public ActionResult Create()
        {
            //Implement the Create method here
            
                return View();
            
        }
 
        // POST: User/Create
        [HttpPost]

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrizeves the user from the userlist based on the provided ID and passes it to the Edit view.
            // Find the user in the userlist by the provided id
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return HttpNotFound (404 error)
            if (user == null)
            {
                return HttpNotFound();
            }

            // If a user is found, pass the user to the Edit view
            return View(user);

        }
 
        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.

            // Find the user in the userlist by the provided id
            var userToedit = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return HttpNotFound (404 error)
            if (userToedit == null)
            {
                return HttpNotFound();
            }

            // Update the user's information with the data received from the form submission
            // Assuming User model includes common properties like Name, Email, etc.
            // Update these properties as necessary based on your User model
            userToedit.Name = user.Name;
            userToedit.Email = user.Email;
            // Continue updating other fields as necessary

            // Redirect to the Index action to show the updated list of users
            return RedirectToAction("Index");


        }
 
        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here
            // Find the user in the userlist by the provided id
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If no user is found, return HttpNotFound (404 error)
            if (user == null)
            {
                return HttpNotFound();
            }

            // If a user is found, pass the user to the Delete view
            return View(user);
        }
 
        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Implement the Delete method (POST) here
            var user = userlist.FirstOrDefault(u => u.Id == id);

            // If a user is found, remove the user from the list
            if (user != null)
            {
                userlist.Remove(user);
            }

            // Redirect to the Index action to show the updated list of users
            return RedirectToAction("Index");
        }
    }
}
