using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject ClientInfo;
    [SerializeField] GameObject PauseInfo;

    public bool time;
    public Timer timer;


    public static string PreviousScene;

    /// <summary>
    /// Guarda la escena actual y carga la escena que recibe por parametro.
    /// </summary>
    /// <param name="name">Nombre de la escena a cargar.</param>
    /// 

    IEnumerator NextLevelAfterWait(string name)
    {
        yield return new WaitForSeconds(2.0f);

        print("carrega");

        PreviousScene = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(name);
        SceneManager.LoadSceneAsync(name);
    }


    public void CargarEscena(string name)
    {
        // Carga la escena necesaria (solo al hacer clic en botones "Jugar", "Salir". También en botón "Volver a Jugar" de la escena "Win".
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadSceneAsync(name);
    }


    public void CargarEscenaMenus(string name)
    {
        StartCoroutine(NextLevelAfterWait(name));
    }

    /// <summary>
    /// Carga la escena anterior.
    /// </summary>
    public void CargarEscenaAnterior()
    {
        // Se usa en el botón "Volver a Jugar" de la escena "Game Over".
        // En caso de perder en la escena del Level1 y pulsar el botón, se cargará la escena del Level1.
        // En caso de perder en la escena del Level2 y pulsar el botón, se cargará la escena del Level2.
        SceneManager.LoadSceneAsync(PreviousScene);
    }

    public void CloseClientRequest()
    {
        ClientInfo.SetActive(false);
        if(timer.GetComponent<Timer>().isPaused)
        {
            timer.GetComponent<Timer>().StartTimer();
        }
    }

    public void OpenClientRequest()
    {
        ClientInfo.SetActive(true);
    }

    public void ObrirPausa()
    {
        timer.GetComponent<Timer>().pauseTimer();
        PauseInfo.SetActive(true);
    }

    public void TancarPausa()
    {
        timer.GetComponent<Timer>().StartTimer();
        PauseInfo.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
}
