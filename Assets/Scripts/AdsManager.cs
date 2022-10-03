using UnityEngine.Events;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;


public class AdsManager : MonoBehaviour
{

    UIManager UIManager;
   
    //"ca-app-pub-3940256099942544/1033173712"; //test Interestial
    private string interstitialAdUnitID = "ca-app-pub-9715704859390980/4155251014"; // real
  
    //"ca-app-pub-3940256099942544/5224354917"; //test Video Ad
    private string rewardedAdUnitID = "ca-app-pub-9715704859390980/4318215154"; //real

    private InterstitialAd interstitial;
    private RewardedAd rewardedAd;

    public bool canUserWatchVideo = true;
    public bool userEearnReward = false;


    void Start() {

        UIManager = GetComponent<UIManager>();

        //Initialize Goodle Ads SDK
        MobileAds.Initialize(initStatus => { });

        RequestInterstitial();
        RequestVideoAd();
    }


    public void RequestInterstitial() {
        
        //Initialize, Create and Fill request
        this.interstitial = new InterstitialAd(interstitialAdUnitID);                                                                             
        AdRequest request = new AdRequest.Builder().Build();     
        this.interstitial.LoadAd(request);
    }


    public void ShowInterstitalAd() {
        //Initialize Interstital Handlers
        this.interstitial.OnAdClosed += HandleInterstitialOnAdClosed;

        //Show AD
        if (this.interstitial.IsLoaded()) {
            this.interstitial.Show();
        }
        else {
            SceneManager.LoadScene("World 1 - Level Select");
        }   
    }


    public void RequestVideoAd() {

        this.rewardedAd = new RewardedAd(rewardedAdUnitID);                     
        AdRequest request = new AdRequest.Builder().Build();            
        this.rewardedAd.LoadAd(request);

        //Initialize Video handlers
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
    }


    public void ShowVideoAd() {  
        
        if (this.rewardedAd.IsLoaded()) {
            this.rewardedAd.Show();
        }
        else {
            SceneManager.LoadScene("Sample Lvl");
        }
    }




    //***HANDLERS***

    //INTERESTIAL
    public void HandleInterstitialOnAdClosed(object sender, EventArgs args) {
        interstitial.Destroy();
        RequestInterstitial();
        SceneManager.LoadScene("World 1 - Level Select");


    }



    //User watches the whole video and closes the ad
    public void HandleUserEarnedReward(object sender, Reward args) {
        
        userEearnReward = true;
        canUserWatchVideo = false;
               
        
        UIManager.videoButton.interactable = false;
        UIManager.resumePlay();

       


    }


    //User closes the ad without watching the whole video
    public void HandleRewardedAdClosed(object sender, EventArgs args) {

        if(userEearnReward == false) {
            canUserWatchVideo = true;
        }

    }
   
}

