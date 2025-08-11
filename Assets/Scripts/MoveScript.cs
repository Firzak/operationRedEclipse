using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;         // Vitesse de déplacement du personnage
    
    private GetInputScript _inputScript;
    private CharacterController _controller;  // Composant optionnel pour la collision (peut être null si non utilisé)
    private Camera _camera;

    void Start()
    {
        _camera = Camera.main;
        _inputScript = GetComponent<GetInputScript>();
        _controller = GetComponent<CharacterController>();  // Facultatif : utilise le CharacterController s'il est présent
    }

    void FixedUpdate()
    {
        // Récupère le vecteur de mouvement (Move) du nouveau Input System
        Vector2 moveInput = _inputScript ? _inputScript.MoveInput : Vector2.zero;
        float inputX = moveInput.x;   // composante gauche/droite
        float inputY = moveInput.y;   // composante avant/arrière

        Vector3 currentEuler = transform.eulerAngles;
        if (_camera) currentEuler.y = _camera.transform.eulerAngles.y;
        transform.eulerAngles = currentEuler;

        // Calcule la direction de déplacement dans le plan horizontal, en tenant compte de l'orientation du joueur (qui suit la caméra)
        Vector3 moveDir = transform.forward * inputY + transform.right * inputX;
        moveDir.y = 0f;  // on reste sur le plan horizontal

        // Applique le déplacement soit via CharacterController, soit via la position du transform
        if (_controller)
        {
            // Utilise CharacterController si présent (gère la physique de déplacement au sol automatiquement)
            _controller.SimpleMove(moveDir * moveSpeed);
        }
        else
        {
            // Déplacement simple du transform (pas de gestion de gravité ou collisions)
            transform.Translate(moveDir * (moveSpeed * Time.fixedDeltaTime), Space.World);
        }
    }
}
