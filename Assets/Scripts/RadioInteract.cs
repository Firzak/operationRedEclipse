using UnityEngine;

public class RadioInteract : Interactable
{
    public override void OnInteract()
    {
        AudioSource audio = GetComponentInChildren<AudioSource>();
        if (audio.volume > 0f)
        {
            audio.volume = 0f; // Mute the audio source
        }
        else
        {
            audio.volume = 0.3f; // Unmute the audio source
        }
    }
}
