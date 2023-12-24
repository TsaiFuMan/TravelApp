using Newtonsoft.Json;

namespace TravelApp;

public partial class YunlinDietPage : ContentPage
{
    private string apiUrl = "https://ws.yunlin.gov.tw/001/Upload/539/opendata/15369/799/2046ea12-f965-482a-ab63-784039eeca2b.json";

    public YunlinDietPage(string title)
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
                    List<YunlinDietRoot> attractionsList = JsonConvert.DeserializeObject<List<YunlinDietRoot>>(content);
                    CvDiet.ItemsSource = attractionsList;
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
        var selectedItem = e.CurrentSelection.FirstOrDefault() as YunlinDietRoot;
        if (selectedItem == null) return;
        Navigation.PushAsync(new YunlinDietDetailPage(selectedItem));
        ((CollectionView)sender).SelectedItem = null;
    }
}

public class YunlinDietRoot
{
    [JsonProperty("����")]
    public string Area { get; set; }

    [JsonProperty("�\�U�W��")]
    public string Name { get; set; }

    [JsonProperty("�p���q��")]
    public string Phone { get; set; }

    [JsonProperty("�a�}")]
    public string Address { get; set; }

    [JsonProperty("�ѻP������")]
    public string Content { get; set; }

}