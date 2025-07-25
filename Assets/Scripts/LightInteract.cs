using TMPro;
using UnityEngine;

public class LightInteract : Interactable
{
    public override void OnInteract()
    {
        Light light = GetComponentInChildren<Light>();
        if (light != null)
        {
            light.enabled = !light.enabled; // Toggle the light on/off
            Debug.Log("Light toggled: " + gameObject.name + " is now " + (light.enabled ? "on" : "off"));
        }
        else
        {
            Debug.LogWarning("No Light component found on " + gameObject.name);
        }
    }
}
