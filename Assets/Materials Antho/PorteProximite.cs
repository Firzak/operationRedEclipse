using UnityEngine;

public class PorteProximite : MonoBehaviour
{
    public Transform porteTransform;           // L'objet à faire pivoter
    public GameObject canvasInteraction;       // Le canvas "Appuyez sur E"
    public float angleOuverture = 90f;         // Angle d'ouverture de la porte
    public float vitesseRotation = 2f;         // Vitesse de rotation
    private bool estProche = false;
    private bool estOuverte = false;

    private Quaternion rotationInitiale;
    private Quaternion rotationOuverte;

    void Start()
    {
        if (porteTransform == null)
            porteTransform = transform;

        rotationInitiale = porteTransform.rotation;
        rotationOuverte = Quaternion.Euler(porteTransform.eulerAngles + new Vector3(0, angleOuverture, 0));

        if (canvasInteraction != null)
            canvasInteraction.SetActive(false);
    }

    void Update()
    {
        if (estProche)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                estOuverte = !estOuverte;
            }
        }

        Quaternion cible = estOuverte ? rotationOuverte : rotationInitiale;
        porteTransform.rotation = Quaternion.Lerp(porteTransform.rotation, cible, Time.deltaTime * vitesseRotation);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estProche = true;
            if (canvasInteraction != null)
                canvasInteraction.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            estProche = false;
            if (canvasInteraction != null)
                canvasInteraction.SetActive(false);
        }
    }
}
