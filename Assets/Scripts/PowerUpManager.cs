using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public float extraDamage;
    public float scoreBonus;

    public bool isActive;

    public void DamageBoost()
    {
        isActive = true;
        extraDamage = 50f;
    }
}
