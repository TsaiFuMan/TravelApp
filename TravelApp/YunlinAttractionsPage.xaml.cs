using Newtonsoft.Json;

namespace TravelApp;

public partial class YunlinAttractionsPage : ContentPage
{
    private string apiUrl = "https://ws.yunlin.gov.tw/001/Upload/539/opendata/15369/1380/38781b5c-8ef3-4311-a8ea-2d6e5953891e.json";

    public YunlinAttractionsPage(string title)
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
                    List<YunlinAttractionsRoot> attractionsList = JsonConvert.DeserializeObject<List<YunlinAttractionsRoot>>(content);
                    List<YunlinAttractionsRoot> filteredAttractionsList = attractionsList.Skip(3).ToList();
                    CvAttractions.ItemsSource = filteredAttractionsList;
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
        var selectedItem = e.CurrentSelection.FirstOrDefault() as YunlinAttractionsRoot;
        if (selectedItem == null) return;
        Navigation.PushAsync(new YunlinAttractionsDetailPage(selectedItem));
        ((CollectionView)sender).SelectedItem = null;
    }
}

public class YunlinAttractionsRoot
{
    [JsonProperty("Äæ¦ì¦WºÙ")]
    public string id { get; set; }

    [JsonProperty("CName")]
    public string CName { get; set; }

    [JsonProperty("EName")]
    public string EName { get; set; }

    [JsonProperty("CToldescribe")]
    public string CToldescribe { get; set; }

    [JsonProperty("EToldescribe")]
    public string EToldescribe { get; set; }

    [JsonProperty("CoastalActivities")]
    public string CoastalActivities { get; set; }

    [JsonProperty("Amenities")]
    public string Amenities { get; set; }

    [JsonProperty("Px")]
    public string Px { get; set; }

    [JsonProperty("Py")]
    public string Py { get; set; }

    [JsonProperty("Tel")]
    public string Tel { get; set; }

    [JsonProperty("CAdd")]
    public string CAdd { get; set; }

    [JsonProperty("EAdd")]
    public string EAdd { get; set; }

    [JsonProperty("Opentime")]
    public string Opentime { get; set; }

    [JsonProperty("OpenremarkC")]
    public string OpenremarkC { get; set; }

    [JsonProperty("OpenremarkE")]
    public string OpenremarkE { get; set; }

    [JsonProperty("Picture1")]
    public string Picture1 { get; set; }

    [JsonProperty("Picdescribe1C")]
    public string Picdescribe1C { get; set; }

    [JsonProperty("Picdescribe1E")]
    public string Picdescribe1E { get; set; }

    [JsonProperty("Picture2")]
    public string Picture2 { get; set; }

    [JsonProperty("Picdescribe2C")]
    public string Picdescribe2C { get; set; }

    [JsonProperty("Picdescribe2E")]
    public string Picdescribe2E { get; set; }

    [JsonProperty("Website")]
    public string Website { get; set; }

    [JsonProperty("Ticketinfo")]
    public string Ticketinfo { get; set; }

    [JsonProperty("Remarks")]
    public string Remarks { get; set; }

    [JsonProperty("Facebook")]
    public string Facebook { get; set; }

    [JsonProperty("Twitter")]
    public string Twitter { get; set; }

    [JsonProperty("Video")]
    public string Video { get; set; }

    [JsonProperty("MapLink")]
    public string MapLink { get; set; }

    [JsonProperty("Changtime")]
    public string Changtime { get; set; }

}