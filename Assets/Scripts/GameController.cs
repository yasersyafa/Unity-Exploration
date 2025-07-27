using Assets.Scripts.Utils;
using UnityEngine;

public class GameController : MonoSingleton<GameController>
{
    private InputSystem_Actions _inputActions;
    public override void Awake()
    {
        base.Awake();
        _inputActions = new();
    }

    public InputSystem_Actions GetInputActions() => _inputActions;

    private void OnEnable()
    {
        _inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Player.Disable();
    }
}
