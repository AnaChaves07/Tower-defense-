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
        // Carrega o an�ncio recompensado explicitamente ap�s a inicializa��o 
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
                Debug.Log("Jogador pulou o an�ncio.");
                break;

            case ShowResult.Failed:
                Debug.LogError("Falha ao mostrar o an�ncio recompensado.");
                break;
        }
    }

    private void GivePlayerReward()
    {
        int rewardAmount = 50;
        playerMoney += rewardAmount;
        rewardText.text = "Voc� ganhou " + rewardAmount + " moedas!";
        Debug.Log("Jogador recebeu " + rewardAmount + " moedas!");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        //  throw new System.NotImplementedException();
    }


}