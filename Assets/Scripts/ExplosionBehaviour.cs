using System;
using UnityEngine;

public class ExplosionBehaviour : MonoBehaviour
{
    [SerializeField] private float explosionRadius = 5f; // Rayon de l'explosion*
    [SerializeField] private float timer = 1f; // Intervalle de temps entre les explosions
    
    private void Awake()
    {
        // Appelée une fois au démarrage
        InvokeRepeating(nameof(PlayExplosionSound), 0f, timer); // Joue le son toutes les secondes
    }

    private void FixedUpdate()
    {
        // Aggrandi le rayon de l'explosion
        explosionRadius += Time.fixedDeltaTime * 2f; // Augmente le rayon de l'explosion
        transform.localScale = Vector3.one * explosionRadius; // Met à jour l'échelle de l'explosion
    }
    
    private void PlayExplosionSound()
    {
        AudioSource originalSource = GetComponent<AudioSource>();
        if (originalSource != null && originalSource.clip != null)
        {
            AudioSource newSource = gameObject.AddComponent<AudioSource>();
            newSource.clip = originalSource.clip;
            newSource.Play();
            Destroy(newSource, newSource.clip.length);
        }
        else
        {
            Debug.LogWarning("Aucun AudioSource ou clip trouvé sur l'objet ExplosionBehaviour !");
        }
    }
}
