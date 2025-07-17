using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform target;      // Cible à suivre (le transform du joueur)
    [SerializeField] private float distance = 5f;   // Distance caméra-joueur (modifiable dans l’inspector)
    [SerializeField] private float rotationSpeed = 150f; // Vitesse de rotation de la caméra (sensibilité)
    [SerializeField] private float minPitch = -20f; // Angle de pitch minimum (en degrés, regard vers le haut)
    [SerializeField] private float maxPitch = 80f;  // Angle de pitch maximum (en degrés, regard vers le bas)

    private float yaw;   // Angle de rotation horizontale (autour de Y)
    private float pitch; // Angle de rotation verticale (autour de X)

    private GetInputScript inputScript;

    void Start()
    {
        // Initialisation des angles à la rotation actuelle de la caméra
        Vector3 angles = transform.eulerAngles;
        pitch = angles.x;
        yaw = angles.y;
        // Recherche du script d'entrée (présent sur le même objet que le joueur)
        if (target != null) 
            inputScript = target.GetComponent<GetInputScript>();
    }

    void LateUpdate()
    {
        if (target == null || inputScript == null) return;

        // Récupère l'input de regard (Look) du joueur
        Vector2 lookInput = inputScript.LookInput;
        float lookX = lookInput.x;
        float lookY = lookInput.y;

        // Calcul des nouveaux angles de rotation de la caméra
        yaw   += lookX * rotationSpeed * Time.deltaTime;   // incrémente l'angle horizontal en fonction de l'entrée X
        pitch -= lookY * rotationSpeed * Time.deltaTime;   // décrémente l'angle vertical en fonction de l'entrée Y (on inverse pour que Y positif = regarder vers le haut)
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);    // limite l'angle vertical entre minPitch et maxPitch

        // Application de la rotation orbitale autour du joueur
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 offset = new Vector3(0f, 0f, -distance);
        // Positionne la caméra à la distance voulue autour de la cible selon les angles calculés
        transform.position = target.position + rotation * offset;
        // Oriente la caméra pour qu'elle regarde la cible (le joueur)
        transform.LookAt(target.position);
    }
}
