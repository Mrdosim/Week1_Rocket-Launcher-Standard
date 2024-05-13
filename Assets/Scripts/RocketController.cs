using UnityEngine;
using UnityEngine.InputSystem;

public class RocketController : MonoBehaviour
{
    private EnergySystem _energySystem;
    private RocketMovement _rocketMovement;
    
    private bool _isMoving;
    private Vector2 _movementDirection;
    
    private void Awake()
    {
        _energySystem = GetComponent<EnergySystem>();
        _rocketMovement = GetComponent<RocketMovement>();
    }
    // TODO : OnMove 구현
    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if (input != null)
        {
            _movementDirection = new Vector2(input.x, input.y);
            Debug.Log($"Unity_Evets : {input.magnitude}");
        }
    }


    // TODO : OnBoost 구현
    private void OnBoost(InputAction.CallbackContext context)
    {
        bool isPressed = context.ReadValue<float>() > 0;
        _rocketMovement.ApplyBoost(isPressed);
    }
}