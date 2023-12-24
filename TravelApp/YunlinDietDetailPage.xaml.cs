namespace TravelApp;

public partial class YunlinDietDetailPage : ContentPage
{
	public YunlinDietDetailPage(YunlinDietRoot selectedItem)
	{
		InitializeComponent();
        lblName.Text = $"{selectedItem.Name}";
        lblAddress.Text = $"地址：{selectedItem.Address}";
        lblPhone.Text = $"電話：{selectedItem.Phone}";
        lblContent.Text = $"好康：{selectedItem.Content}";

        Title = selectedItem.Name;
    }
}