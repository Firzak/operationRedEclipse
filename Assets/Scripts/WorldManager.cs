using UnityEngine;

public class WorldManager : MonoBehaviour
{
    [Header("Références à assigner en Inspector")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cameraPresent;
    [SerializeField] private GameObject cameraFutur;

    public void SwitchWorld()
    {
        int layerPresent = LayerMask.NameToLayer("Présent");
        int layerFutur   = LayerMask.NameToLayer("Futur");
        if (layerPresent < 0 || layerFutur < 0)
        {
            Debug.LogError("Les layers \"Présent\" ou \"Futur\" n'existent pas !");
            return;
        }

        int current = player.layer;
        int next    = (current == layerPresent) ? layerFutur : layerPresent;
        SetLayerRecursively(player, next);

        bool isNowPresent = (next == layerPresent);
        
        GameObject futurCanvas = GameObject.FindGameObjectWithTag("FuturCanvas");
        futurCanvas.GetComponent<Canvas>().enabled = !isNowPresent;

        // Synchronisation position/rotation
        GameObject camToActivate   = isNowPresent ? cameraPresent : cameraFutur;
        GameObject camToDeactivate = isNowPresent ? cameraFutur   : cameraPresent;

        camToActivate.transform.position = camToDeactivate.transform.position;
        camToActivate.transform.rotation = camToDeactivate.transform.rotation;

        cameraPresent.SetActive(isNowPresent);
        cameraFutur .SetActive(!isNowPresent);
    }

    private void SetLayerRecursively(GameObject go, int newLayer)
    {
        go.layer = newLayer;
        foreach (Transform child in go.transform)
            SetLayerRecursively(child.gameObject, newLayer);
    }
}