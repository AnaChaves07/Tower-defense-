using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class RewardedAd : MonoBehaviour, IUnityAdsInitializationListener
{
    private string rewardedPlacement = "Rewarded_Android";
    private string gameId = "5729650";
    private bool testMode = true;

    public Text rewardText;
    private int playerMoney = 0;

    void Start()
    {
        // Inicializa o Unity Ads com o listener
        Advertisement.Initialize(gameId, testMode, this);
    }


    public void OnInitializationComplete()
    {
        // Carrega o anúncio recompensado explicitamente após a inicialização 
        Advertisement.Load(rewardedPlacement);
    }


    private void HandleRewardedAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                GivePlayerReward();
                break;

            case ShowResult.Skipped:
                Debug.Log("Jogador pulou o anúncio.");
                break;

            case ShowResult.Failed:
                Debug.LogError("Falha ao mostrar o anúncio recompensado.");
                break;
        }
    }

    private void GivePlayerReward()
    {
        int rewardAmount = 50;
        playerMoney += rewardAmount;
        rewardText.text = "Você ganhou " + rewardAmount + " moedas!";
        Debug.Log("Jogador recebeu " + rewardAmount + " moedas!");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        //  throw new System.NotImplementedException();
    }


}