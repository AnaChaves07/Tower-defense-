using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour // Classe LevelManager: Gerencia informa��es relacionadas ao n�vel, como pontos de in�cio e caminho dos inimigos.

{
    [SerializeField] private GameObject gameOverScreen;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f; // Pausa o jogo
        gameOverScreen.SetActive(true); // Exibe a tela de Game Over
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Reinicia o tempo do jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recarrega a cena atual
    }
    public static LevelManager instance;     // Inst�ncia singleton da classe LevelManager.

    public Transform startPoint;    // Ponto de in�cio para onde os inimigos devem ser gerados.

    public Transform[] path;    // Array de pontos que definem o caminho que os inimigos devem seguir.

    public int currency; // vari�vel das Moedas 

   
    private void Start()
    {
        currency = 200; // inicia com 100 moedas
    }
    public void IncreaseCurrency(int amount) // Metodo que aumenta as Moedinhas
    {
        currency += amount; // moeda maior ou igual a quantidade
    }
    public bool SpendCurrency(int amount) // Gastar o dinheiro
    {
        if (amount <= currency) // se a quantidade � menor ou igual a moeda
        {
            currency -= amount; // moeda  menor ou igual a quantidade
            return true; // retorna verdadeiro
        }
        else
        {
            Debug.Log("Pobre voc� �"); // mostra no console a linda mensagem escrita 
            return false;    //retorna falso    
        }
    }
}
