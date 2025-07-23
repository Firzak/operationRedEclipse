using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform target;      // le joueur
    [SerializeField] private float rotationSpeed = 150f;
    [SerializeField] private float minPitch = -10f; // regarde vers le bas max
    [SerializeField] private float maxPitch =  60f; // regarde vers le haut max

    private float yaw;   // rotation horizontale
    private float pitch; // rotation verticale

    private GetInputScript inputScript;

    void Start()
    {
        // Récupère inputScript sur le joueur
        if (target != null)
            inputScript = target.GetComponent<GetInputScript>();

        // initialise yaw/pitch en convertissant correctement les EulerAngles
        Vector3 angles = transform.eulerAngles;
        yaw   = angles.y;
        pitch = angles.x > 180f ? angles.x - 360f : angles.x;
    }

    void LateUpdate()
    {
        if (target == null || inputScript == null) return;

        Vector2 look = inputScript.LookInput;
        yaw   += look.x * rotationSpeed * Time.deltaTime;
        pitch -= look.y * rotationSpeed * Time.deltaTime;

        // **CLAMP** du pitch pour ne pas dépasser sol/plafond
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // construit la rotation finale à partir du yaw/pitch
        Quaternion rot = Quaternion.Euler(pitch, yaw, 0f);

        // calcule la position : derrière le joueur à la bonne distance
        // Vector3 pos = target.position + rot * Vector3.back * distance;

        // applique *ensemble* position + rotation
        transform.SetPositionAndRotation(transform.position, rot);
    }
}
