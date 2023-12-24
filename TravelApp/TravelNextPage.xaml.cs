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
                        Navigation.PushAsync(new TaichungAttractionsPage($"{categoryName} / ���I"));
                        break;
                    case "Taichung":
                        Navigation.PushAsync(new TaichungAttractionsPage($"{categoryName} / ���I"));
                        break;
                    case "Changhua":
                        Navigation.PushAsync(new TaichungAttractionsPage($"{categoryName} / ���I"));
                        break;
                    case "Nantou":
                        Navigation.PushAsync(new TaichungAttractionsPage($"{categoryName} / ���I"));
                        break;
                    case "Yunlin":
                        Navigation.PushAsync(new YunlinAttractionsPage($"{categoryName} / ���I"));
                        break;
                    default:
                        break;
                }
                break;
            case "Diet":
                switch (categoryName)
                {
                    case "Miaoli":
                        Navigation.PushAsync(new TaichungDietPage($"{categoryName} / ����"));
                        break;
                    case "Taichung":
                        Navigation.PushAsync(new TaichungDietPage($"{categoryName} / ����"));
                        break;
                    case "Changhua":
                        Navigation.PushAsync(new TaichungDietPage($"{categoryName} / ����"));
                        break;
                    case "Nantou":
                        Navigation.PushAsync(new TaichungDietPage($"{categoryName} / ����"));
                        break;
                    case "Yunlin":
                        Navigation.PushAsync(new YunlinDietPage($"{categoryName} / ����"));
                        break;
                    default:
                        break;
                }
                break;
            case "Stay":
                switch (categoryName)
                {
                    case "Miaoli":
                        Navigation.PushAsync(new TaichungStayPage($"{categoryName} / ��J"));
                        break;
                    case "Taichung":
                        Navigation.PushAsync(new TaichungStayPage($"{categoryName} / ��J"));
                        break;
                    case "Changhua":
                        Navigation.PushAsync(new TaichungStayPage($"{categoryName} / ��J"));
                        break;
                    case "Nantou":
                        Navigation.PushAsync(new TaichungStayPage($"{categoryName} / ��J"));
                        break;
                    case "Yunlin":
                        Navigation.PushAsync(new YunlinStayPage($"{categoryName} / ��J"));
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