using Newtonsoft.Json;

namespace TravelApp;

public partial class TaichungStayPage : ContentPage
{
    private string apiUrl = "https://datacenter.taichung.gov.tw/swagger/OpenData/4801148d-6d06-469c-abab-8c2578b89c56";

    public TaichungStayPage(string title)
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
                    List<TaichungStayRoot> stayList = JsonConvert.DeserializeObject<List<TaichungStayRoot>>(content);
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

public class TaichungStayRoot
{
    [JsonProperty("編號")]
    public string Id { get; set; }

    [JsonProperty("旅館登記證編號")]
    public string Number { get; set; }

    [JsonProperty("中文名稱")]
    public string Name { get; set; }

    [JsonProperty("郵遞區號")]
    public string Posttal { get; set; }

    [JsonProperty("地址")]
    public string Address { get; set; }

    [JsonProperty("合計總房間數")]
    public string Quantity { get; set; }
}