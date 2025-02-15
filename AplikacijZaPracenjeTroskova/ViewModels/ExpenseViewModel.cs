// ViewModels/AddExpenseViewModel.cs
using System.Windows.Input;

public class AddExpenseViewModel : BaseViewModel
{
    private string name;
    private string description;
    private string amount;
    private string selectedCategory;

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

    public AddExpenseViewModel()
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

        var expense = new Expense
        {
            Name = Name,
            Description = Description,
            Amount = amountValue,
            Category = SelectedCategory,
            Date = DateTime.Now
        };

        // Ovdje bi išao kod za spremanje u bazu

        await Shell.Current.GoToAsync("..");
    }
}