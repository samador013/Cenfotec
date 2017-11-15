using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea2v2.ViewModel;
using Xamarin.Forms;

namespace Tarea2v2
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BindingContext = new PersonViewModel();
		}
	}
}
