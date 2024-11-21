using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsInitializationListener
{
    private string interstitialPlacement = "Interstitial_Android";
    private string gameId = "5729650";
    private bool testMode = true;

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
        //Advertisement.Show(interstitialPlacement, new ShowOptions { resultCallback = HandleAdResult });
        Advertisement.Show(interstitialPlacement, new ShowOptions());
    }

    // Método para lidar com os resultados do intersticial
    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("O jogador assistiu ao anúncio.");
                break;
            case ShowResult.Skipped:
                Debug.Log("O jogador pulou o anúncio.");
                break;
            case ShowResult.Failed:
                Debug.LogError("Falha ao mostrar o anúncio.");
                break;
        }
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        //  throw new System.NotImplementedException();
    }
}
