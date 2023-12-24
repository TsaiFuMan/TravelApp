namespace TravelApp;

public partial class YunlinDietDetailPage : ContentPage
{
	public YunlinDietDetailPage(YunlinDietRoot selectedItem)
	{
		InitializeComponent();
        lblName.Text = $"{selectedItem.Name}";
        lblAddress.Text = $"�a�}�G{selectedItem.Address}";
        lblPhone.Text = $"�q�ܡG{selectedItem.Phone}";
        lblContent.Text = $"�n�d�G{selectedItem.Content}";

        Title = selectedItem.Name;
    }
}