using SmartCA.Infrastructure.UI;
using SmartCA.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SmartCA.Views
{
    /// <summary>
    /// Interaction logic for ProjectInformationView.xaml
    /// </summary>
    public class ProjectInformationView : Window, IView
    {
        public ProjectInformationView()
        {
            //InitializeComponent();
            this.DataContext = new ProjectInformationViewModel(this);
        }
    }
}
