using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

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

    public void CargarEscena(string name)
    {
        // Carga la escena necesaria (solo al hacer clic en botones "Jugar", "Salir". Tambi�n en bot�n "Volver a Jugar" de la escena "Win".
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadSceneAsync(name);
    }

    /// <summary>
    /// Carga la escena anterior.
    /// </summary>
    public void CargarEscenaAnterior()
    {
        // Se usa en el bot�n "Volver a Jugar" de la escena "Game Over".
        // En caso de perder en la escena del Level1 y pulsar el bot�n, se cargar� la escena del Level1.
        // En caso de perder en la escena del Level2 y pulsar el bot�n, se cargar� la escena del Level2.
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
}
