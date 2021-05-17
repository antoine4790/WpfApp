using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class MessageViewModel : INotifyPropertyChanged
    {
        private string _contenu;

        public string Contenu
        {
            get { return _contenu; }
            set 
            { 
                _contenu = value;
                OnPropertyChanged("Contenu");
            }
        }

        private string _emetteur;

        public string Emetteur
        {
            get { return _emetteur; }
            set 
            { 
                _emetteur = value;
                OnPropertyChanged("Emetteur");
            }
        }

        private DateTime _date;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public DateTime Date
        {
            get { return _date; }
            set 
            { 
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        public override string ToString()
        {
            return $"{Contenu} {Emetteur} {Date}"; 
        }

    }
}
