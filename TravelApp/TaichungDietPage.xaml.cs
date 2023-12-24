using Newtonsoft.Json;

namespace TravelApp;

public partial class TaichungDietPage : ContentPage
{
    private string apiUrl = "https://datacenter.taichung.gov.tw/swagger/OpenData/72b2e32b-74e4-4000-b920-7457c54565be";

    public TaichungDietPage(string title)
	{
		InitializeComponent();
        Title = title;
        FetchAndDisplayData();
    }
    private async void FetchAndDisplayData()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<TaichungDietRoot> dietList = JsonConvert.DeserializeObject<List<TaichungDietRoot>>(content);
                    CvDiet.ItemsSource = dietList;
                }
                else
                {
                    DisplayAlert("Error", "Failed to retrieve data from the server", "OK");
                }
            }
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }

    private void CvDiet_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as TaichungDietRoot;
        if (selectedItem == null) return;
        Navigation.PushAsync(new TaichungDietDetailPage(selectedItem));
        ((CollectionView)sender).SelectedItem = null;
    }
}

public class TaichungDietRoot
{
    [JsonProperty("序號")]
    public string Id { get; set; }

    [JsonProperty("店家類型")]
    public string Chain { get; set; }

    [JsonProperty("隸屬範圍")]
    public string Scope { get; set; }

    [JsonProperty("店家型態")]
    public string Type { get; set; }

    [JsonProperty("品牌名稱")]
    public string Name { get; set; }

    [JsonProperty("門市名稱")]
    public string Store { get; set; }

    [JsonProperty("區域")]
    public string Area { get; set; }

    [JsonProperty("連絡電話")]
    public string Phone { get; set; }

    [JsonProperty("聯絡地址")]
    public string Address { get; set; }

    [JsonProperty("實施日期")]
    public string Date { get; set; }

    [JsonProperty("好康類型")]
    public string Discount { get; set; }

    [JsonProperty("好康內容")]
    public string Content { get; set; }

    [JsonProperty("備註")]
    public string Remark { get; set; }
}