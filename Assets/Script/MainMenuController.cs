using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioMixer auidoMixer;
    [SerializeField] Text textRate;

    [SerializeField] GameObject optionMenu;
    [SerializeField] GameObject mainMenu;

    void Awake()
    {
        textRate.text = "80";
    }
    public void quitApplication()
    {
        Application.Quit();
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void changeVolumn(float amount)
    {
        auidoMixer.SetFloat("MasterVolume", amount);
        float changeVolumn = amount + 80;
        Debug.Log("MasterVolume" + changeVolumn);
        textRate.text = changeVolumn.ToString();

    }

    public void showOptionMenu()
    {
        mainMenu.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void quitOptionMenu()
    {
        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
