using AplikacijZaPracenjeTroskova.Views;

namespace AplikacijZaPracenjeTroskova
{
    // AppShell.xaml.cs
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("addexpense", typeof(AddExpensePage));
            Routing.RegisterRoute("expensedetails", typeof(ExpenseDetailsPage));
            Routing.RegisterRoute("editexpense", typeof(EditExpensePage));
        }
    }
}
