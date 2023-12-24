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
    [JsonProperty("�s��")]
    public string Id { get; set; }

    [JsonProperty("���]�n�O�ҽs��")]
    public string Number { get; set; }

    [JsonProperty("����W��")]
    public string Name { get; set; }

    [JsonProperty("�l���ϸ�")]
    public string Posttal { get; set; }

    [JsonProperty("�a�}")]
    public string Address { get; set; }

    [JsonProperty("�X�p�`�ж���")]
    public string Quantity { get; set; }
}