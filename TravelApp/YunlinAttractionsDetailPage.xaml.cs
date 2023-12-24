namespace TravelApp;

public partial class YunlinAttractionsDetailPage : ContentPage
{
	public YunlinAttractionsDetailPage(YunlinAttractionsRoot selectedItem)
	{
		InitializeComponent();
        Picture1.Source = new FileImageSource { File = selectedItem.Picture1 };
        lblCName.Text = $"{selectedItem.CName}";
        lblCToldescribe.Text = $"{selectedItem.CToldescribe}";
        lblCAdd.Text = $"地址：{selectedItem.CAdd}";
        lblTel.Text = $"電話：{selectedItem.Tel}";
        lblTicketinfo.Text = $"收費：{selectedItem.Ticketinfo}";
        lblOpentime.Text = $"開放時間：{selectedItem.Opentime}";
        lblRemarks.Text = $"備註：{selectedItem.Remarks}";

        Title = selectedItem.CName;
    }
}