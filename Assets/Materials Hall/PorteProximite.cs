using UnityEngine;

public class PorteProximite : Interactable
{
    public Transform porteTransform;           // L'objet à faire pivoter
    public float angleOuverture = 90f;         // Angle d'ouverture de la porte
    public float vitesseRotation = 2f;         // Vitesse de rotation
    private bool estOuverte = false;

    private Quaternion rotationInitiale;
    private Quaternion rotationOuverte;

    new void Start()
    {
        base.Start();

        if (porteTransform == null)
            porteTransform = transform;

        rotationInitiale = porteTransform.rotation;
        rotationOuverte = Quaternion.Euler(porteTransform.eulerAngles + new Vector3(0, angleOuverture, 0));
    }

    void Update()
    {
        Quaternion cible = estOuverte ? rotationOuverte : rotationInitiale;
        porteTransform.rotation = Quaternion.Lerp(porteTransform.rotation, cible, Time.deltaTime * vitesseRotation);
    }

    public override void OnInteract()
    {
        if (!FindFirstObjectByType<ProgressManager>().key)
        {
            return;
        }
        Debug.Log("OnInteract appelé sur la porte !");
        estOuverte = !estOuverte;
    }
}