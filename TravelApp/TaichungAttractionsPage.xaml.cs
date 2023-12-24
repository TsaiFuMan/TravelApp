using Newtonsoft.Json;

namespace TravelApp;

public partial class TaichungAttractionsPage : ContentPage
{
    private string apiUrl = "https://datacenter.taichung.gov.tw/swagger/OpenData/f9bc650f-531f-4fe8-9d6b-85451f8a8149";

    public TaichungAttractionsPage(string title)
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
                    List<TaichungAttractionsRoot> attractionsList = JsonConvert.DeserializeObject<List<TaichungAttractionsRoot>>(content);
                    CvAttractions.ItemsSource = attractionsList;
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

    private void CvAttractions_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as TaichungAttractionsRoot;
        if (selectedItem == null) return;
        Navigation.PushAsync(new TaichungAttractionsDetailPage(selectedItem));
        ((CollectionView)sender).SelectedItem = null;
    }
}

public class TaichungAttractionsRoot
{
    [JsonProperty("編號")]
    public string Id { get; set; }

    [JsonProperty("名稱")]
    public string Name { get; set; }

    [JsonProperty("簡介說明")]
    public string Introduction { get; set; }

    [JsonProperty("鄉鎮")]
    public string Township { get; set; }

    [JsonProperty("地址")]
    public string Address { get; set; }

    [JsonProperty("電話")]
    public string Phone { get; set; }

    [JsonProperty("緯度")]
    public string Latitude { get; set; }

    [JsonProperty("經度")]
    public string Longitude { get; set; }

    [JsonProperty("門票/收費")]
    public string Tickets { get; set; }

    [JsonProperty("旅遊叮嚀")]
    public string Exhort { get; set; }

    [JsonProperty("行車資訊")]
    public string Driving { get; set; }

    [JsonProperty("大眾運輸")]
    public string Transportation { get; set; }

    [JsonProperty("停車資訊")]
    public string Parking { get; set; }

}