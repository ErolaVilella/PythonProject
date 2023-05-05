using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject ClientInfo;
    [SerializeField] GameObject PauseInfo;
    
    
    public static string PreviousScene;

    /// <summary>
    /// Guarda la escena actual y carga la escena que recibe por parametro.
    /// </summary>
    /// <param name="name">Nombre de la escena a cargar.</param>
    /// 

    public void CargarEscena(string name)
    {
        // Carga la escena necesaria (solo al hacer clic en botones "Jugar", "Salir". También en botón "Volver a Jugar" de la escena "Win".
        PreviousScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadSceneAsync(name);
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

    public void TancarClientRequest()
    {
        ClientInfo.SetActive(false);
    }

    public void ObrirClientRequest()
    {
        ClientInfo.SetActive(true);
    }

    public void ObrirPausa()
    {
        PauseInfo.SetActive(true);
    }

    public void TancarPausa()
    {
        PauseInfo.SetActive(false);
    }
}
