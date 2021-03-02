using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdMobScript : MonoBehaviour
{

    string App_ID = "ca-app-pub-8694778749014953~9902601750";
#if UNITY_ANDROID
    string Banner_ID = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
    string Banner_ID = "ca-app-pub-3940256099942544/6300978111";
#endif

    string Interstitial_ID = "ca-app-pub-3940256099942544/1033173712";
    string Interstitial_Video_ID = "ca-app-pub-3940256099942544/8691691433";

    private BannerView bannerView;
    private InterstitialAd interstitial;
    private InterstitialAd interstitialVid;

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(App_ID);
    }

    public void RequestBanner()
    {

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(Banner_ID, AdSize.Banner, AdPosition.Bottom);
    }

    public void ShowBannerAd()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
    }

    //FOR EVENTS AND DELEGATES FOR ADS
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
}
