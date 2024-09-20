using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public float extraDamage, scoreBonus;

    public bool DamageBoostActive = false, ScoreBoostActive = false;

    private void Start()
    {
        extraDamage = 5f;
        scoreBonus = 1f;
    }

    public void DamageBoost()
    {
        DamageBoostActive = true;
        extraDamage = 5f;
    }
    
    public void ScoreBoost()
    {
        ScoreBoostActive = true;
        scoreBonus = 2f;
    }
}
