using PartsClient.Data;
using PartsClient.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PartsClient.ViewModels
{
    public class AddPartViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand DoneEditingCommand { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        string _carId;
        public string CarID
        {
            get => _carId;
            set
            {
                if (_carId == value)
                    return;

                _carId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CarID)));
            }
        }

        string _marka;
        public string Marka
        {
            get => _marka;
            set
            {
                if (_marka == value)
                    return;

                _marka = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Marka)));
            }
        }

        string _model;
        public string Model
        {
            get => _model;
            set
            {
                if (_model == value)
                    return;

                _model = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Model)));
            }
        }

        string _rocznik;
        public string Rocznik
        {
            get => _rocznik;
            set
            {
                if (_rocznik == value)
                    return;

                _rocznik = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Rocznik)));
            }
        }

        string _cena;
        public string Cena
        {
            get => _cena;
            set
            {
                if (_cena == value)
                    return;

                _cena = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Cena)));
            }
        }

        //private PartsManager partsManager = new PartsManager();

        public AddPartViewModel()
        {            
            DoneEditingCommand = new Command(async () => await DoneEditing());
            SaveCommand = new Command(async () => await SaveData());
            DeleteCommand = new Command(async () => await DeletePart());
        }        

        private async Task SaveData()
        {
            if (string.IsNullOrWhiteSpace(CarID))
                await InsertPart();
            else
                await UpdatePart();
        }

        private async Task InsertPart()
        {
            await PartsManager.Add(Marka, Model, Rocznik, Cena);

            MessagingCenter.Send(this, "refresh");

            await Shell.Current.GoToAsync("..");
        }

        private async Task UpdatePart()
        {
            Part partToSave = new()
            {
                CarID = CarID,
                Marka = Marka,
                Rocznik = Rocznik,
                Cena = Cena,
                Model = Model
            };

            await PartsManager.Update(partToSave);

            MessagingCenter.Send(this, "refresh");

            await Shell.Current.GoToAsync("..");
        }

        private async Task DeletePart()
        {
            if (string.IsNullOrWhiteSpace(CarID))
                return;

            await PartsManager.Delete(CarID);

            MessagingCenter.Send(this, "refresh");

            await Shell.Current.GoToAsync("..");
        }

        private async Task DoneEditing()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
