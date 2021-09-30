using System.Windows;
using System.Windows.Controls;
using DSCSJsonEditor.Core.Models;
using DSCSJsonEditor.WPF.ViewModels;

namespace DSCSJsonEditor.WPF.Views
{
    /// <summary>
    /// Interaction logic for NavigationView.xaml
    /// </summary>
    public partial class NavigationView : UserControl
    {
        public NavigationView()
        {
            InitializeComponent();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.BindSelectedStep(e.NewValue);
            this.BindSelectedStepContainer(e.NewValue);
        }

        private void BindSelectedStepContainer(object obj)
        {
            // TODO: Access the ViewModel safely, without the cast
            if (obj is IStepContainer step)
            {
                ((NavigationViewModel)this.DataContext).SelectedStepContainer = step;
            }
            else
            {
                ((NavigationViewModel)this.DataContext).SelectedStepContainer = null;
            }
        }

        private void BindSelectedStep(object obj)
        {
            // TODO: Access the ViewModel safely, without the cast
            if (obj is Step step)
            {
                ((NavigationViewModel)this.DataContext).SelectedStep = step;
            }
            else
            {
                ((NavigationViewModel)this.DataContext).SelectedStep = null;
            }
        }
    }
}
