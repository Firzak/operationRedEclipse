using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenInteract : Interactable
{
    [SerializeField] private GameObject screenCanvas; // Le canvas du Minitel
    [SerializeField] private TextMeshProUGUI text; // Le texte à afficher sur le Minitel
    [SerializeField] private TextAsset textShowing;
    
    public override void OnInteract()
    {
        if (screenCanvas.activeSelf)
        {
            FindFirstObjectByType<GetInputScript>().Enable();
            screenCanvas.SetActive(false);
        }
        else
        {
            FindFirstObjectByType<GetInputScript>().Disable();
            screenCanvas.SetActive(true);
            text.text = textShowing.ToString();
        }
    }
}
