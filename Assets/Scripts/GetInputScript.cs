using UnityEngine;
using UnityEngine.InputSystem;

public class GetInputScript : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference lookAction;
    [SerializeField] private InputActionReference switchAction;
    [SerializeField] private InputActionReference interactAction;
    
    public Vector2 MoveInput { get; private set; }  // Valeur courante de l'input de déplacement
    public Vector2 LookInput { get; private set; }  // Valeur courante de l'input de regard
    public InputActionReference SwitchAction => switchAction; // Action de changement de monde
    public InputActionReference InteractAction => interactAction; // Action d'interaction

    private void OnEnable()
    {
        // Active les actions d'input lorsque cet objet est activé
        if (moveAction != null) moveAction.action.Enable();
        if (lookAction != null) lookAction.action.Enable();
        if (switchAction != null) switchAction.action.Enable();
        if (interactAction != null) interactAction.action.Enable();
    }

    void Update()
    {
        // Lit les valeurs actuelles des actions d'input à chaque frame
        MoveInput = moveAction != null ? moveAction.action.ReadValue<Vector2>() : Vector2.zero;
        LookInput = lookAction != null ? lookAction.action.ReadValue<Vector2>() : Vector2.zero;
        // Vérifie si l'action de changement de monde est déclenchée
        if (switchAction && switchAction.action.triggered)
        {
            // Appelle la méthode pour changer de monde
            FindFirstObjectByType<WorldManager>().SwitchWorld();
        }
        // Vérifie si l'action d'interaction est déclenchée
        if (interactAction && interactAction.action.triggered)
        {
            // Appelle la méthode d'interaction
            GetComponent<InteractionManager>().Interact();
        }
    }
}