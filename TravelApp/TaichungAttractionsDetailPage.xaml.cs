namespace TravelApp;

public partial class TaichungAttractionsDetailPage : ContentPage
{
	public TaichungAttractionsDetailPage(TaichungAttractionsRoot selectedItem)
	{
		InitializeComponent();
        lblName.Text = $"{selectedItem.Name}";
        lblIntroduction.Text = $"{selectedItem.Introduction}";
        lblTownshipAndAddress.Text = $"地址：{selectedItem.Township}{selectedItem.Address}";
        lblPhone.Text = $"電話：{selectedItem.Phone}";
        lblTickets.Text = $"收費：{selectedItem.Tickets}";

        Title = selectedItem.Name;
    }
}