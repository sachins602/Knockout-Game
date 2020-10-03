using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
    public static AdManager instance;

    string App_ID = "ca-app-pub-7955784199678642~8593247290";
    string Banner_AD_ID = "ca-app-pub-3940256099942544/6300978111";
    string Interstitial_AD_ID = "ca-app-pub-3940256099942544/1033173712";
    string Video_AD_ID = "ca-app-pub-3940256099942544/5224354917";
   // string NativeAdvanced_AD_ID = "ca-app-pub-3940256099942544/2247696110";

    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardedAd rewardedAd;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame updat
    void Start()
    {
        MobileAds.Initialize(App_ID);
        RequestInterstitial();
        
    }

    public void RequestBanner()
    {

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(Banner_AD_ID, AdSize.Banner, AdPosition.Bottom);

        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;

    }
    public void ShowBannerAd()
    {
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
        this.bannerView.Show();
    }
    public void HideBannerAd()
    {
       
        this.bannerView.Destroy();
    }

    public void RequestInterstitial()
    {


        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(Interstitial_AD_ID);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        AdRequest request = new AdRequest.Builder().Build();
        this.interstitial.LoadAd(request);
    }

    public void ShowInterstitialAd()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else
        {
            Debug.Log("AD not Loaded");
        }
    }

    public void RequestRewardAd()
    {
        this.rewardedAd = new RewardedAd(Video_AD_ID);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
    }

    public void ShowRewardAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
    }

    // FOR EVENTS AND DELEGATES FOR ADS
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


    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
        RequestRewardAd();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }
}
