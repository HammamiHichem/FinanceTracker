using Microsoft.AspNetCore.Mvc;
using FinanceTracker.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context; // Injection du contexte de la base de données
        }

        public IActionResult Index()
        {
            ViewBag.Salaries = _context.Salaries.ToList(); // Récupérer les salaires de la base de données
            ViewBag.Expenses = _context.Expenses.ToList(); // Récupérer les dépenses de la base de données
            ViewBag.Savings = _context.Savings.ToList(); // Récupérer les économies de la base de données
            return View();
        }

        [HttpPost]
        public IActionResult AddSalary(Salary salary)
        {
            if (ModelState.IsValid)
            {
                _context.Salaries.Add(salary);
                _context.SaveChanges(); // Enregistrer les modifications dans la base de données
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult AddExpense(Expense expense)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expense); // Ajouter à la base de données
                _context.SaveChanges(); // Enregistrer les modifications
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult AddSavings(Savings savings)
        {
            if (ModelState.IsValid)
            {
                _context.Savings.Add(savings); // Ajouter à la base de données
                _context.SaveChanges(); // Enregistrer les modifications
                return RedirectToAction(nameof(Index));
            }
            return View("Index");
        }

        // Nouvelle action pour afficher le suivi financier mensuel
     public IActionResult MonthlyOverview()
{
    var monthlyData = _context.Salaries
        .GroupBy(salary => new { Year = salary.Date.Year, Month = salary.Date.Month }) // Group by year and month
        .Select(salaryGroup => new MonthlyFinanceViewModel
        {
            Year = salaryGroup.Key.Year,
            Month = salaryGroup.Key.Month,
            TotalSalary = salaryGroup.Sum(s => s.Amount), // Total salary for the month
            TotalExpenses = _context.Expenses
                .Where(e => e.Date.Year == salaryGroup.Key.Year && e.Date.Month == salaryGroup.Key.Month)
                .Sum(e => (decimal?)e.Amount) ?? 0, // Total expenses for the month
        })
        .ToList(); // Ensure it's converted to a list

    return View(monthlyData); // Pass the data to the view
}


}
}