namespace TravelApp;

public partial class TaichungDietDetailPage : ContentPage
{
	public TaichungDietDetailPage(TaichungDietRoot selectedItem)
	{
		InitializeComponent();
        lblNameAndDiscount.Text = $"{selectedItem.Name} ( {selectedItem.Discount} )";
        lblTypeAndChain.Text = $"{selectedItem.Type}，{selectedItem.Chain}";
        lblAddress.Text = $"地址：{selectedItem.Address}";
        lblPhone.Text = $"電話：{selectedItem.Phone}";
        lblContent.Text = $"好康：{selectedItem.Content}";
        lblRemark.Text = $"備註：{selectedItem.Remark}";

        Title = selectedItem.Name;
    }
}