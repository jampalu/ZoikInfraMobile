using System.ComponentModel;
using Xamarin.Forms;
using ZoikInfra.ViewModels;

namespace ZoikInfra.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}