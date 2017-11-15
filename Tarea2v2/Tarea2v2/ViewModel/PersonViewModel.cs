using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Tarea2v2.Model;
using Xamarin.Forms;

namespace Tarea2v2.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        public PersonViewModel() {
            AgregarPersonaCommand = new Command(AgregarPersona);
            FiltrarPersonaCommand = new Command(FiltrarPersona);
        }

        private ObservableCollection<Person> _lstPersonList = new ObservableCollection<Person>();
        private ObservableCollection<Person> _lstPersonListOriginal = new ObservableCollection<Person>();

        public ObservableCollection<Person> lstPersonList
        {
            get
            {
                //if (FiltroEntry != null)
                //{
                //    return new ObservableCollection<Person>(_lstPersonList.Where(p => p.Nombre == FiltroEntry).ToList());
                //}
                //else
                //{
                    return _lstPersonList;
               // }
            }

            set
            {
                _lstPersonList = value;
                OnPropertyChanged("lstPersonList");
            }

        }

        #region AgregarPersona
        private string _AgregarPersonaEntry { get; set; }

        public string AgregarPersonaEntry
        { get { return _AgregarPersonaEntry; }
             set {
                _AgregarPersonaEntry = value;
                OnPropertyChanged("AgregarPersonaEntry");
            }
        }

        public ICommand AgregarPersonaCommand { get; set; }

        private void AgregarPersona()
        {
            lstPersonList.Add(new Person(){ Nombre= AgregarPersonaEntry });
        }
        #endregion

        #region Filtro

        private string _FiltroEntry { get; set; }

        public string FiltroEntry
        {
            get { return _FiltroEntry; }
            set
            {
                _FiltroEntry = value;
                OnPropertyChanged("FiltroEntry");
            }
        }


        public ICommand FiltrarPersonaCommand { get; set; }

        private void FiltrarPersona()
        {
            //lstPersonList.Clear();
            if (FiltroEntry != null && FiltroEntry!= String.Empty)
            {
                _lstPersonListOriginal = _lstPersonList;
                lstPersonList = new ObservableCollection<Person>(_lstPersonList.Where(p => p.Nombre.Contains(FiltroEntry)).ToList());
            }
            else
            {
                lstPersonList = _lstPersonListOriginal;
            }

        }
        #endregion

        #region NotifyProperty
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
