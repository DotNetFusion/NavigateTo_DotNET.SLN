
using Microsoft.AspNetCore.Components;
using Plugin.MauiMTAdmob;
using Plugin.MauiMTAdmob.Controls;
using Plugin.MauiMTAdmob.Extra;
using System.Diagnostics;

namespace NavigateTo;

public partial class MainPage : ContentPage
{
    private bool _shouldSetEvents = true;
    public int count = 0;
    public string countrycode = string.Empty;
    public string mobilenumber = string.Empty;
    public string msg = string.Empty;
    

    [Inject]
    public NavigationManager NavigationManager { get; set; }
    public MainPage()
    {
        InitializeComponent(); 
    }
    private void LoadBanner(object sender, EventArgs e)
    {
        myAds.LoadAd();
        
    }
    private void MyAds_AdsClicked(object sender, EventArgs e)
    { 
        Debug.WriteLine("MyAds_AdsClicked");
    }
    private void MyAds_AdVClosed(object sender, EventArgs e)
    { 
        Debug.WriteLine("MyAds_AdVClosed");
    }
    private void MyAds_AdFailedToLoad(object sender, MTEventArgs e)
    { 
        Debug.WriteLine($"MyAds_AdFailedToLoad: {e.ErrorCode} - {e.ErrorMessage}");
    }
    private void MyAds_AdVImpression(object sender, EventArgs e)
    {  
        Debug.WriteLine("MyAds_AdVImpression");
    }

    private void MyAds_AdLoaded(object sender, EventArgs e)
    { 
        Debug.WriteLine("MyAds_AdLoaded");
    }
    private void MyAds_AdVOpened(object sender, EventArgs e)
    { 
        Debug.WriteLine("MyAds_AdVOpened");
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        try
        {
            mobilenumber = mobileNumber.Text;
            msg =    message.Text!=null ? message.Text :"";
            Launcher.OpenAsync(string.Format("https://api.whatsapp.com/send/?phone={0} {1}&text={2}&type=phone_number&app_absent=0",countrycode, mobilenumber.ToString(), msg.ToString()));
            mobileNumber.Text = string.Empty;
            message.Text = string.Empty;
        }
        catch(Exception ex) 
        { }



    }
    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            var temp = picker.Items[selectedIndex];
            countrycode = GetSubstringByString("(", ")", temp);

        }
    }
    public string GetSubstringByString(string a, string b, string c)
    {
        return c.Substring((c.IndexOf(a) + a.Length), (c.IndexOf(b) - c.IndexOf(a) - a.Length));
    }
} 

