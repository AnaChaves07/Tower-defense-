using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAdManager : MonoBehaviour, IUnityAdsInitializationListener
{
    private string bannerPlacement = "Banner_Android";
    private string gameId = "5729650";
    private bool testMode = true;
   // private bool isAdShowing = false;
    void Start()
    {
        Advertisement.Initialize(gameId, testMode, this);
    }

    public void OnInitializationComplete()
    {
        StartCoroutine(BannerAdCycle());
    }

    IEnumerator BannerAdCycle()
    {
        while (true)
        {
            Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
            // Carrega o banner explicitamente
            Advertisement.Banner.Load(bannerPlacement);
            Advertisement.Banner.Show(bannerPlacement);

            yield return new WaitForSeconds(10f);
            Advertisement.Banner.Hide();
            yield return new WaitForSeconds(5f);
        }
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        //   throw new System.NotImplementedException();
    }
    // Método para bloquear o banner quando um anúncio for exibido
   // public void SetAdShowing(bool state)
    //{
      //  isAdShowing = state;
   // }
}