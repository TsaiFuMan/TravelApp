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
    [JsonProperty("�Ǹ�")]
    public string Id { get; set; }

    [JsonProperty("���a����")]
    public string Chain { get; set; }

    [JsonProperty("���ݽd��")]
    public string Scope { get; set; }

    [JsonProperty("���a���A")]
    public string Type { get; set; }

    [JsonProperty("�~�P�W��")]
    public string Name { get; set; }

    [JsonProperty("�����W��")]
    public string Store { get; set; }

    [JsonProperty("�ϰ�")]
    public string Area { get; set; }

    [JsonProperty("�s���q��")]
    public string Phone { get; set; }

    [JsonProperty("�p���a�}")]
    public string Address { get; set; }

    [JsonProperty("��I���")]
    public string Date { get; set; }

    [JsonProperty("�n�d����")]
    public string Discount { get; set; }

    [JsonProperty("�n�d���e")]
    public string Content { get; set; }

    [JsonProperty("�Ƶ�")]
    public string Remark { get; set; }
}