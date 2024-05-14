using System;
using UnityEngine;

public class EnergySystem : MonoBehaviour
{
    public event Action<float> OnEnergyChanged;
    public float MaxFuel { get; private set; } = 10f;
    public float Fuel { get; private set; } = 10f;
    
    public bool UseEnergy(float amount)
    {
        if (Fuel < amount)
        {
            if (Fuel > 0)
            {
                Fuel = 0;  // 에너지를 강제로 0으로 설정
                OnEnergyChanged?.Invoke(Fuel / MaxFuel);  // 에너지 변경 이벤트 발생
            }
            return false;
        }

        Fuel -= amount;
        OnEnergyChanged?.Invoke(Fuel / MaxFuel);  // 에너지 사용 후 변경 사항 반영
        return true;
    }
}