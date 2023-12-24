namespace TravelApp;

public partial class TravelNextPage : ContentPage
{
    private string categoryName;

    public TravelNextPage(string categoryName)
    {
        InitializeComponent();
        this.categoryName = categoryName;
        DisplayNextResult();
        Title = categoryName;
    }

    private void DisplayNextResult()
    {
        TravelData traveldata = new TravelData();
        switch (categoryName)
        {
            case "Miaoli":
                CvName.ItemsSource = traveldata.Miaoli;
                break;
            case "Taichung":
                CvName.ItemsSource = traveldata.Taichung;
                break;
            case "Changhua":
                CvName.ItemsSource = traveldata.Changhua;
                break;
            case "Nantou":
                CvName.ItemsSource = traveldata.Nantou;
                break;
            case "Yunlin":
                CvName.ItemsSource = traveldata.Yunlin;
                break;
            default:
                break;
        }
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        ImageButton button = (ImageButton)sender;
        string subCategory = button.CommandParameter.ToString();

        switch (subCategory)
        {
            case "Attractions":
                switch (categoryName)
                {
                    case "Miaoli":
                        Navigation.PushAsync(new TaichungAttractionsPage($"{categoryName} / 春翴"));
                        break;
                    case "Taichung":
                        Navigation.PushAsync(new TaichungAttractionsPage($"{categoryName} / 春翴"));
                        break;
                    case "Changhua":
                        Navigation.PushAsync(new TaichungAttractionsPage($"{categoryName} / 春翴"));
                        break;
                    case "Nantou":
                        Navigation.PushAsync(new TaichungAttractionsPage($"{categoryName} / 春翴"));
                        break;
                    case "Yunlin":
                        Navigation.PushAsync(new YunlinAttractionsPage($"{categoryName} / 春翴"));
                        break;
                    default:
                        break;
                }
                break;
            case "Diet":
                switch (categoryName)
                {
                    case "Miaoli":
                        Navigation.PushAsync(new TaichungDietPage($"{categoryName} / 都"));
                        break;
                    case "Taichung":
                        Navigation.PushAsync(new TaichungDietPage($"{categoryName} / 都"));
                        break;
                    case "Changhua":
                        Navigation.PushAsync(new TaichungDietPage($"{categoryName} / 都"));
                        break;
                    case "Nantou":
                        Navigation.PushAsync(new TaichungDietPage($"{categoryName} / 都"));
                        break;
                    case "Yunlin":
                        Navigation.PushAsync(new YunlinDietPage($"{categoryName} / 都"));
                        break;
                    default:
                        break;
                }
                break;
            case "Stay":
                switch (categoryName)
                {
                    case "Miaoli":
                        Navigation.PushAsync(new TaichungStayPage($"{categoryName} / 盝"));
                        break;
                    case "Taichung":
                        Navigation.PushAsync(new TaichungStayPage($"{categoryName} / 盝"));
                        break;
                    case "Changhua":
                        Navigation.PushAsync(new TaichungStayPage($"{categoryName} / 盝"));
                        break;
                    case "Nantou":
                        Navigation.PushAsync(new TaichungStayPage($"{categoryName} / 盝"));
                        break;
                    case "Yunlin":
                        Navigation.PushAsync(new YunlinStayPage($"{categoryName} / 盝"));
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }
}