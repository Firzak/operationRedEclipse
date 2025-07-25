using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Hall");
        SceneManager.LoadSceneAsync("Bastien", LoadSceneMode.Additive);
    }
    
    public void QuitGame()
    {
        // Ferme l'application
        Application.Quit();
        
        // Pour l'éditeur Unity, affiche un message dans la console
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    
    public void OpenSettings()
    {
        // Logique pour ouvrir les paramètres du jeu
        Debug.Log("Ouvrir les paramètres du jeu");
    }
    
    public void OpenCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
