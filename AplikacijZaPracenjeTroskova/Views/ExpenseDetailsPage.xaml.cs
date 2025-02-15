using AplikacijZaPracenjeTroskova.ViewModels;

namespace AplikacijZaPracenjeTroskova.Views
{
    public partial class EditExpensePage : ContentPage
    {
        public EditExpensePage(EditExpenseViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
