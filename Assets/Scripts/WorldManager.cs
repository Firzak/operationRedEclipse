using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [Header("Références à assigner en Inspector")]
    [Tooltip("Le GameObject du Player (root de ton rig)")]
    [SerializeField] private GameObject player;

    [Tooltip("La caméra qui affiche le monde Présent")]
    [SerializeField] private GameObject cameraPresent;
    [Tooltip("La caméra qui affiche le monde Futur")]
    [SerializeField] private GameObject cameraFutur;

    public void SwitchWorld()
    {
        // 1) Vérification des layers
        int layerPresent = LayerMask.NameToLayer("Présent");
        int layerFutur   = LayerMask.NameToLayer("Futur");
        if (layerPresent < 0 || layerFutur < 0)
        {
            Debug.LogError("Les layers \"Présent\" ou \"Futur\" n'existent pas !");
            return;
        }

        // 2) Détermine la nouvelle layer du player
        int current = player.layer;
        int next    = (current == layerPresent) ? layerFutur : layerPresent;

        // 3) Applique la nouvelle layer au player et à tous ses enfants
        SetLayerRecursively(player, next);

        // 4) Active / désactive les cameras en fonction de la nouvelle layer
        bool isNowPresent = (next == layerPresent);
        cameraPresent.SetActive(isNowPresent);
        cameraFutur .SetActive(!isNowPresent);
    }

    // Utile pour propager la layer à tout le rig (mesh, colliders, etc.)
    private void SetLayerRecursively(GameObject go, int newLayer)
    {
        go.layer = newLayer;
        foreach (Transform child in go.transform)
            SetLayerRecursively(child.gameObject, newLayer);
    }
}