using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartsClient.Data
{
    [Serializable]
    public class Part : INotifyPropertyChanged
    {
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

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
