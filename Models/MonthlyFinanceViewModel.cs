namespace FinanceTracker.Models
{
    public class MonthlyFinanceViewModel
    {
        public int Month { get; set; } // Mois (ex: 1 pour janvier)
        public int Year { get; set; } // Année
        public decimal TotalSalary { get; set; } // Total des salaires pour le mois
        public decimal TotalExpenses { get; set; } // Total des dépenses pour le mois

        // Calcul du reste du salaire après dépenses
        public decimal RemainingSalary => TotalSalary - TotalExpenses; 

        // Si vous voulez également calculer les économies séparément
        public decimal Savings => RemainingSalary; // Calculer les économies comme le reste du salaire
    }
}
