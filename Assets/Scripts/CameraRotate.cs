using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotate : MonoBehaviour
{
    [Header("Suivi du joueur")]
    [SerializeField] private Transform target;        

    [Header("Réglages Orbite")]
    [SerializeField] private float distance = 5f;     
    [SerializeField] private float rotationSpeed = 150f;
    [SerializeField] private float minPitch = -10f;   
    [SerializeField] private float maxPitch = 60f;    

    private float yaw;   
    private float pitch; 

    private GetInputScript inputScript;

    // À chaque enable (Start + après switch de WorldManager),
    // on reprend yaw/pitch depuis la rotation courante
    void OnEnable()
    {
        Vector3 angles = transform.eulerAngles;
        yaw   = angles.y;
        pitch = (angles.x > 180f ? angles.x - 360f : angles.x);

        if (target != null)
            inputScript = target.GetComponent<GetInputScript>();
    }

    void Start() => OnEnable();

    void LateUpdate()
    {
        if (target == null || inputScript == null) 
            return;

        // Lecture de l'input Look
        Vector2 look = inputScript.LookInput;
        yaw   += look.x * rotationSpeed * Time.deltaTime;
        pitch -= look.y * rotationSpeed * Time.deltaTime;
        pitch  = Mathf.Clamp(pitch, minPitch, maxPitch);

        // Calcul de la rotation orbitale et de la position
        Quaternion rot = Quaternion.Euler(pitch, yaw, 0f);

        // **Mise à jour** de la position ET de la rotation
        transform.SetPositionAndRotation(transform.position, rot);
    }
}