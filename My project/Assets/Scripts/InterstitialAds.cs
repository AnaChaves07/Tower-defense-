using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsInitializationListener
{
    private string interstitialPlacement = "Interstitial_Android";
    private string gameId = "5729650";
    private bool testMode = true;
    private bool isAdShowing = false;
    private int interstitialCounter = 0;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode, this);
    }


    public void OnInitializationComplete()
    {
        Advertisement.Load(interstitialPlacement);
    }

    public void ShowInterstitialAd()
    {
        if (!isAdShowing)
        {
            isAdShowing = true;
            Advertisement.Show(interstitialPlacement, new ShowOptions());
            // ShowOptions options = new ShowOptions();
            // options.resultCallback = HandleAdResult; 
            // Advertisement.Show(interstitialPlacement, options);
        }
     
    }

    // M�todo para lidar com os resultados do intersticial
    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("O jogador assistiu ao an�ncio.");
                break;
            case ShowResult.Skipped:
                Debug.Log("O jogador pulou o an�ncio.");
                break;
            case ShowResult.Failed:
                Debug.LogError("Falha ao mostrar o an�ncio.");
                break;
        }
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        //  throw new System.NotImplementedException();
    }
}
