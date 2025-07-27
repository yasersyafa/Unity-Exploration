using UnityEngine;

public class GameController : MonoBehaviour
{
    private InputSystem_Actions _inputActions;
    private void Awake()
    {
        _inputActions = new();
    }

    private void OnEnable()
    {
        _inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Player.Disable();
    }
}
