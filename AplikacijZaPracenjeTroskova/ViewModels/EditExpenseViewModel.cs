using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AplikacijZaPracenjeTroskova.Models;

namespace AplikacijZaPracenjeTroskova.ViewModels
{
    [QueryProperty(nameof(Expense), "Expense")]
    public class EditExpenseViewModel : BaseViewModel
    {
        private Expense expense;
        private string name;
        private string description;
        private string amount;
        private string selectedCategory;

        public Expense Expense
        {
            get => expense;
            set
            {
                expense = value;
                Name = expense.Name;
                Description = expense.Description;
                Amount = expense.Amount.ToString();
                SelectedCategory = expense.Category;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        public string Amount
        {
            get => amount;
            set
            {
                amount = value;
                OnPropertyChanged();
            }
        }

        public string SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                OnPropertyChanged();
            }
        }

        public List<string> Categories { get; } = new List<string>
        {
            "Hrana",
            "Transport",
            "Zabava",
            "Režije",
            "Ostalo"
        };

        public ICommand SaveCommand { get; }

        public EditExpenseViewModel()
        {
            SaveCommand = new Command(async () => await SaveExpense());
        }

        private async Task SaveExpense()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Amount))
            {
                await Shell.Current.DisplayAlert("Greška", "Molimo unesite naziv i iznos troška", "OK");
                return;
            }

            if (!decimal.TryParse(Amount, out decimal amountValue))
            {
                await Shell.Current.DisplayAlert("Greška", "Molimo unesite valjan iznos", "OK");
                return;
            }

            expense.Name = Name;
            expense.Description = Description;
            expense.Amount = amountValue;
            expense.Category = SelectedCategory;

            // Ovdje bi išao kod za ažuriranje u bazi

            await Shell.Current.GoToAsync("..");
        }
    }
}
