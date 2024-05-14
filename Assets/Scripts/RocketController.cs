using UnityEngine;
using UnityEngine.InputSystem;

public class RocketController : MonoBehaviour
{
    private EnergySystem _energySystem;
    private RocketMovement _rocketMovement;

    private bool _isMoving;
    private Vector2 _movementDirection = Vector2.zero;
    private bool _isBoosted;

    private void Awake()
    {
        _energySystem = GetComponent<EnergySystem>();
        _rocketMovement = GetComponent<RocketMovement>();
    }
    private void FixedUpdate()
    {
        if (_energySystem.Fuel > 0)
        {
            float energyCost = _isBoosted ? 3f : 1f;
            if (_energySystem.UseEnergy(energyCost * Time.fixedDeltaTime))
            {
                _rocketMovement.ApplyMovement(_movementDirection);
            }
            else
            {
                _rocketMovement.ApplyMovement(Vector2.zero);
            }
        }
    }
    // TODO : OnMove 구현
    public void OnMove(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                _movementDirection = context.ReadValue<Vector2>().normalized;
                break;
            case InputActionPhase.Canceled:
                _movementDirection = Vector2.zero;
                break;
        }
    }

    // TODO : OnBoost 구현
    public void OnBoost(InputAction.CallbackContext context)
    {
        _isBoosted = context.phase == InputActionPhase.Performed;
        _rocketMovement.ApplyBoost(_isBoosted);
    }
}