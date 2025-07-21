using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    public void SwitchWorld()
    {
        // Récupération des indices de couches
        int layerPresent = LayerMask.NameToLayer("Présent");
        int layerFutur   = LayerMask.NameToLayer("Futur");
        if (layerPresent < 0 || layerFutur < 0)
        {
            Debug.LogError("Les couches \"Présent\" ou \"Futur\" ne sont pas définies !");
            return;
        }

        GameObject presentGO = null;
        GameObject futureGO  = null;

        // Parcours de TOUTES les scènes chargées
        int sceneCount = SceneManager.sceneCount;
        for (int i = 0; i < sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (!scene.isLoaded) 
                continue;

            // Pour chaque GameObject racine de la scène
            foreach (var root in scene.GetRootGameObjects())
            {
                if      (root.layer == layerPresent) presentGO = root;
                else if (root.layer == layerFutur)   futureGO  = root;
            }
        }

        if (presentGO == null || futureGO == null)
        {
            Debug.LogWarning("Impossible de trouver les deux rigs Player en couches Présent/Futur !");
            return;
        }

        // Bascule leur état actif
        bool isPresentActive = presentGO.activeSelf;
        presentGO.SetActive(!isPresentActive);
        futureGO .SetActive( isPresentActive);
    }
}