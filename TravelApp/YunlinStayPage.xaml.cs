using Newtonsoft.Json;

namespace TravelApp;

public partial class YunlinStayPage : ContentPage
{
    private string apiUrl = "https://s5.aconvert.com/convert/p3r68-cdx67/3v9u4-tqcoy.json";

    public YunlinStayPage(string title)
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
                    List<YunlinStayRoot> stayList = JsonConvert.DeserializeObject<List<YunlinStayRoot>>(content);
                    CvStay.ItemsSource = stayList;
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
}

public class YunlinStayRoot
{
    [JsonProperty("¦WºÙ")]
    public string Name { get; set; }

    [JsonProperty("¦a§}")]
    public string Address { get; set; }
}