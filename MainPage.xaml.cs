using HabitTracker.ViewModels;

namespace HabitTracker
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

       
    }
}
