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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace toDoWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowSchedule_Click(object sender, RoutedEventArgs e)
        {
            ShowAct showAct = new ShowAct();
            showAct.Show();
        }

        private void AddActivity_Click(object sender, RoutedEventArgs e)
        {
            AddAct add = new AddAct();
            add.Show();
        }

        private void RemoveActivity_Click(object sender, RoutedEventArgs e)
        {
            Remove remove = new Remove();
            remove.Show();
        }

        private void UpdateAct_Click(object sender, RoutedEventArgs e)
        {
            UpdateAct update = new UpdateAct();
            update.Show();
        }
    }
}
