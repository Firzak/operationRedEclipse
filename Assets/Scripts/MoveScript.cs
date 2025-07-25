using UnityEngine;
using UnityEngine.InputSystem;

public class MoveScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;         // Vitesse de déplacement du personnage
    
    private GetInputScript inputScript;
    private CharacterController controller;  // Composant optionnel pour la collision (peut être null si non utilisé)

    void Start()
    {
        inputScript = GetComponent<GetInputScript>();
        controller = GetComponent<CharacterController>();  // Facultatif : utilise le CharacterController s'il est présent
    }

    void Update()
    {
        // Récupère le vecteur de mouvement (Move) du nouveau Input System
        Vector2 moveInput = inputScript != null ? inputScript.MoveInput : Vector2.zero;
        float inputX = moveInput.x;   // composante gauche/droite
        float inputY = moveInput.y;   // composante avant/arrière

        Vector3 currentEuler = transform.eulerAngles;
        currentEuler.y = Camera.main.transform.eulerAngles.y;
        transform.eulerAngles = currentEuler;

        // Calcule la direction de déplacement dans le plan horizontal, en tenant compte de l'orientation du joueur (qui suit la caméra)
        Vector3 moveDir = transform.forward * inputY + transform.right * inputX;
        moveDir.y = 0f;  // on reste sur le plan horizontal

        // Applique le déplacement soit via CharacterController, soit via la position du transform
        if (controller != null)
        {
            // Utilise CharacterController si présent (gère la physique de déplacement au sol automatiquement)
            controller.SimpleMove(moveDir * moveSpeed);
        }
        else
        {
            // Déplacement simple du transform (pas de gestion de gravité ou collisions)
            transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
