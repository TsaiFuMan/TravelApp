namespace TravelApp;

public partial class TaichungAttractionsDetailPage : ContentPage
{
	public TaichungAttractionsDetailPage(TaichungAttractionsRoot selectedItem)
	{
		InitializeComponent();
        lblName.Text = $"{selectedItem.Name}";
        lblIntroduction.Text = $"{selectedItem.Introduction}";
        lblTownshipAndAddress.Text = $"�a�}�G{selectedItem.Township}{selectedItem.Address}";
        lblPhone.Text = $"�q�ܡG{selectedItem.Phone}";
        lblTickets.Text = $"���O�G{selectedItem.Tickets}";

        Title = selectedItem.Name;
    }
}