using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public float extraDamage;
    public float scoreBonus;

    public bool DamageBoostActive = false;

    public void DamageBoost()
    {
        DamageBoostActive = true;
        extraDamage = 50f;
    }
}
