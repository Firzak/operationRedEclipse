using UnityEngine;
using UnityEngine.InputSystem;

public class GetInputScript : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction;  // Référence à l'action "Move" (Vector2) du nouveau Input System
    [SerializeField] private InputActionReference lookAction;  // Référence à l'action "Look" (Vector2) du nouveau Input System

    public Vector2 MoveInput { get; private set; }  // Valeur courante de l'input de déplacement
    public Vector2 LookInput { get; private set; }  // Valeur courante de l'input de regard

    private void OnEnable()
    {
        // Active les actions d'input lorsque cet objet est activé
        if (moveAction != null) moveAction.action.Enable();
        if (lookAction != null) lookAction.action.Enable();
    }

    private void OnDisable()
    {
        // Désactive les actions d'input pour éviter les fuites ou lectures indésirables
        if (moveAction != null) moveAction.action.Disable();
        if (lookAction != null) lookAction.action.Disable();
    }

    void Update()
    {
        // Lit les valeurs actuelles des actions d'input à chaque frame
        MoveInput = moveAction != null ? moveAction.action.ReadValue<Vector2>() : Vector2.zero;
        LookInput = lookAction != null ? lookAction.action.ReadValue<Vector2>() : Vector2.zero;
    }
}