using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text coinText;
    public Text LlavesText;
    public Text goldKeyText;
    public Text normalKeyText;

    int coins;

    int normalKeys;
    int goldKeys;

    public void AddCoins()
    {
        coins++;
        Debug.Log("Coins: " + coins);

        coinText.text = "Coins: " + coins;
    }

    public void AddKey(int id)
    {
        if (id == 1)
        {
            normalKeys++;
            normalKeyText.text = "Normal Key: " + normalKeys;
        }
        else if (id == 2)
        {
            goldKeys++;
            goldKeyText.text = "Golden Keys: " + goldKeys;
        }
        else
            Debug.LogWarning("No existe la llave con id: " + id);
    }
    public void ConsumeKey(int id)
    {
        if (id == 1)
        {
            normalKeys--;
            normalKeyText.text = "Normal Keys: " + normalKeys;
        }
        else if (id == 2)
        {
            goldKeys--;
            goldKeyText.text = "Golden Keys: " + goldKeys;
        }
    }

    public bool HasKey(int id)
    {
        int count = 0;

        if (id == 1)
            count = normalKeys;
        else if (id == 2)
            count = goldKeys;

        if (count > 0)
            return true;
        else
            return false;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameWin()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}