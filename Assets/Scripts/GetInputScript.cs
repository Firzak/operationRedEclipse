using UnityEngine;
using UnityEngine.InputSystem;

public class GetInputScript : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference lookAction;
    [SerializeField] private InputActionReference switchAction;
    
    public Vector2 MoveInput { get; private set; }  // Valeur courante de l'input de déplacement
    public Vector2 LookInput { get; private set; }  // Valeur courante de l'input de regard
    public InputActionReference SwitchAction => switchAction; // Action de changement de monde

    private void OnEnable()
    {
        // Active les actions d'input lorsque cet objet est activé
        if (moveAction != null) moveAction.action.Enable();
        if (lookAction != null) lookAction.action.Enable();
        if (switchAction != null) switchAction.action.Enable();
    }

//    private void OnDisable()
//    {
//        // Désactive les actions d'input pour éviter les fuites ou lectures indésirables
//        if (moveAction != null) moveAction.action.Disable();
//        if (lookAction != null) lookAction.action.Disable();
//        if (switchAction != null) switchAction.action.Disable();
//    }

    void Update()
    {
        // Lit les valeurs actuelles des actions d'input à chaque frame
        MoveInput = moveAction != null ? moveAction.action.ReadValue<Vector2>() : Vector2.zero;
        LookInput = lookAction != null ? lookAction.action.ReadValue<Vector2>() : Vector2.zero;
        // Vérifie si l'action de changement de monde est déclenchée
        if (switchAction != null && switchAction.action.triggered)
        {
            // Appelle la méthode pour changer de monde
            FindFirstObjectByType<WorldManager>().SwitchWorld();
        }
    }
}