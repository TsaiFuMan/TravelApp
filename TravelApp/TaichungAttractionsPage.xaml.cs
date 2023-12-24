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
    [JsonProperty("�s��")]
    public string Id { get; set; }

    [JsonProperty("�W��")]
    public string Name { get; set; }

    [JsonProperty("²������")]
    public string Introduction { get; set; }

    [JsonProperty("�m��")]
    public string Township { get; set; }

    [JsonProperty("�a�}")]
    public string Address { get; set; }

    [JsonProperty("�q��")]
    public string Phone { get; set; }

    [JsonProperty("�n��")]
    public string Latitude { get; set; }

    [JsonProperty("�g��")]
    public string Longitude { get; set; }

    [JsonProperty("����/���O")]
    public string Tickets { get; set; }

    [JsonProperty("�ȹC�m�{")]
    public string Exhort { get; set; }

    [JsonProperty("�樮��T")]
    public string Driving { get; set; }

    [JsonProperty("�j���B��")]
    public string Transportation { get; set; }

    [JsonProperty("������T")]
    public string Parking { get; set; }

}