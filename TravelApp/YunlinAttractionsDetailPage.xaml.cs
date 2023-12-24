namespace TravelApp;

public partial class YunlinAttractionsDetailPage : ContentPage
{
	public YunlinAttractionsDetailPage(YunlinAttractionsRoot selectedItem)
	{
		InitializeComponent();
        Picture1.Source = new FileImageSource { File = selectedItem.Picture1 };
        lblCName.Text = $"{selectedItem.CName}";
        lblCToldescribe.Text = $"{selectedItem.CToldescribe}";
        lblCAdd.Text = $"�a�}�G{selectedItem.CAdd}";
        lblTel.Text = $"�q�ܡG{selectedItem.Tel}";
        lblTicketinfo.Text = $"���O�G{selectedItem.Ticketinfo}";
        lblOpentime.Text = $"�}��ɶ��G{selectedItem.Opentime}";
        lblRemarks.Text = $"�Ƶ��G{selectedItem.Remarks}";

        Title = selectedItem.CName;
    }
}