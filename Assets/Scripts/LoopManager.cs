using UnityEngine;
using UnityEngine.SceneManagement;

public class LoopManager : MonoBehaviour
{
    float time = 0;
    float timeLimit = 1f; // Durée de la boucle en minutes
    
    [SerializeField] GameObject explosionPrefab; // Préfabriqué de l'explosion

    void Update()
    {
        // Incrémente le temps écoulé
        time += Time.deltaTime;

        // Vérifie si le temps écoulé dépasse la limite
        if (time >= timeLimit * 60f) // Convertit les minutes
        {
            // Réinitialise le temps écoulé
            time = 0;

            EndLoop();
        }
    }
    
    void EndLoop()
    {
        Instantiate(explosionPrefab, Vector3.zero, Quaternion.identity);
        
        Invoke("StartLoop", 5f);
    }

    void StartLoop()
    {
        // Charger les 2 scènes présent et futur
        SceneManager.LoadScene("Mounir");
        SceneManager.LoadSceneAsync("Mounir 1", LoadSceneMode.Additive);
    }
}
