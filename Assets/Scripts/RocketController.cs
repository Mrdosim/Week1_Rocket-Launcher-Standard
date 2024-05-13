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
    // private void OnMove...


    // TODO : OnBoost 구현
    // private void OnBoost...
    private void OnBoost(InputValue value)
    {
        _rocketMovement.ApplyBoost(value.isPressed);
    }
}