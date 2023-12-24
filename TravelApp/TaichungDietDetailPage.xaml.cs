namespace TravelApp;

public partial class TaichungDietDetailPage : ContentPage
{
	public TaichungDietDetailPage(TaichungDietRoot selectedItem)
	{
		InitializeComponent();
        lblNameAndDiscount.Text = $"{selectedItem.Name} ( {selectedItem.Discount} )";
        lblTypeAndChain.Text = $"{selectedItem.Type}�A{selectedItem.Chain}";
        lblAddress.Text = $"�a�}�G{selectedItem.Address}";
        lblPhone.Text = $"�q�ܡG{selectedItem.Phone}";
        lblContent.Text = $"�n�d�G{selectedItem.Content}";
        lblRemark.Text = $"�Ƶ��G{selectedItem.Remark}";

        Title = selectedItem.Name;
    }
}