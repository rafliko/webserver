using PartsClient.Data;
using PartsClient.ViewModels;

namespace PartsClient.Pages;

[QueryProperty("PartToDisplay", "part")]
public partial class AddPartPage : ContentPage
{
	AddPartViewModel viewModel;
	public AddPartPage()
	{
		InitializeComponent();

		viewModel = new AddPartViewModel();
		BindingContext = viewModel;
    }

	Part _partToDisplay;
    public Part PartToDisplay {
		get => _partToDisplay;
		set
        {
			if (_partToDisplay == value)
				return;

			_partToDisplay = value;

			viewModel.CarID = _partToDisplay.CarID;
			viewModel.Marka = _partToDisplay.Marka;
            viewModel.Model = _partToDisplay.Model;
            viewModel.Rocznik = _partToDisplay.Rocznik;
			viewModel.Cena = _partToDisplay.Cena;
        }
	}
}
