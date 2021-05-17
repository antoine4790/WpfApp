using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp2
{
    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #region WPF_listes_et_controles
        public int Index { get; set; }
        public ObservableCollection<string> Valeurs { get; set; } = new ObservableCollection<string> { "Heeeeee", "Haaaaa" };


        private string _test = "Hello !";
        public string Test
        {
            get { return _test; }
            set
            {
                _test = value;
                OnPropertyChanged(nameof(Test)); // Notifie la vue que la propriété "Test" a été modifié} }
            }
        }
        public ICommand EditInput
        {
            get
            {
                return new RelayCommand(param =>
                {
                    Test = "Test";
                });
            }
        }
        public ICommand EditList
        {
            get
            {
                return new RelayCommand(param =>
                {
                    Valeurs.Add(Test);
                });
            }
        }

        public ICommand DeleteElementList
        {
            get
            {
                return new RelayCommand(
                    execute: param => Valeurs.RemoveAt(0),
                    canExecute: param => Valeurs.Count() > 0
                );
            }
        }
        public ICommand UpdateList
        {
            get
            {
                return new RelayCommand(param =>
                {
                    if (Valeurs.Contains(Test))
                        Valeurs.Remove(Test);
                    else
                        Valeurs.Add(Test);
                });
            }
        }

        public ObservableCollection<MessageViewModel> Messages { get; set; } = new ObservableCollection<MessageViewModel> { new MessageViewModel { Contenu = "Contenu 1", Date = DateTime.Now.AddDays(10), Emetteur = "Emmetteur1" } };


        public ICommand AddMessage
        {
            get
            {
                return new RelayCommand(param =>
                {
                    Messages.Add(new MessageViewModel { Contenu = "Contenu1", Emetteur = "Emetteur1", Date = DateTime.Now });
                });
            }
        }

        public ICommand ModifyMessage
        {
            get
            {
                return new RelayCommand(
                    execute: param => Messages[selectedIndex].Contenu = "Contenu_modified",
                    canExecute: param => Messages.Count() > 0
                );
            }
        }

        public ICommand DeleteFirstMessage
        {
            get
            {
                return new RelayCommand(
                    execute: param => Messages.RemoveAt(0),
                    canExecute: param => Messages.Count() > 0
                );
            }
        }

        private int selectedIndex;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                OnPropertyChanged(nameof(SelectedIndex));
            }
        }

        public ICommand DeleteSelectedMessage
        {
            get
            {
                return new RelayCommand(
                    execute: param => Messages.RemoveAt(SelectedIndex),
                    canExecute: param => Messages.Count() > 0
                );
            }
        }

        public ICommand RemoveThisMessage
        {
            get
            {
                return new RelayCommand(
                    execute: param => Messages.Remove((MessageViewModel)param)
                );
            }
        }

        public ObservableCollection<string> ListeImages { get; set; } = new ObservableCollection<string> { "/Images/image1.jpg", "/Images/image2.jpg", "/Images/image3.jpg", "image4.jpg" };
        #endregion

        #region Cas_Pratiques_MVVM

        private int _compteur;

        public int Compteur
        {
            get { return _compteur; }
            set
            {
                _compteur = value;
                OnPropertyChanged(nameof(Compteur));
            }
        }

        public ICommand Augmenter
        {
            get
            {
                return new RelayCommand(param =>
                {
                    Compteur++;
                });
            }
        }

        public ICommand Diminuer
        {
            get
            {
                return new RelayCommand(param =>
                {
                    Compteur--;
                });
            }
        }

        public ICommand Reinitialiser
        {
            get
            {
                return new RelayCommand(param =>
                {
                    Compteur = 0;
                });
            }
        }
        #endregion
    }
}
