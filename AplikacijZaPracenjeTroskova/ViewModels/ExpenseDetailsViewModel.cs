// ViewModels/ExpenseDetailsViewModel.cs
using System.Windows.Input;

[QueryProperty(nameof(Expense), "Expense")]
public class ExpenseDetailsViewModel : BaseViewModel
{
    private Expense expense;
    public Expense Expense
    {
        get => expense;
        set
        {
            expense = value;
            OnPropertyChanged();
        }
    }

    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }

    public ExpenseDetailsViewModel()
    {
        EditCommand = new Command(async () => await EditExpense());
        DeleteCommand = new Command(async () => await DeleteExpense());
    }

    private async Task EditExpense()
    {
        var parameters = new Dictionary<string, object>
        {
            { "Expense", Expense }
        };
        await Shell.Current.GoToAsync("editexpense", parameters);
    }

    private async Task DeleteExpense()
    {
        bool answer = await Shell.Current.DisplayAlert(
            "Potvrda",
            "Jeste li sigurni da želite izbrisati ovaj trošak?",
            "Da", "Ne");

        if (answer)
        {
            // Ovdje bi išao kod za brisanje iz baze
            await Shell.Current.GoToAsync("..");
        }
    }
}