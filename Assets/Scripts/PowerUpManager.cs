using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public float extraDamage, scoreBonus;

    public bool DamageBoostActive = false, ScoreBoostActive = false;

    /*private Coroutine damageBoostTimer;
    private Coroutine scoreBoostTimer;*/

   /* private const float powerUpDuration = 10f;*/

    public void ActivatePowerUp(GameObject powerUp)
    {
        if (powerUp.CompareTag("DamageBoost") && !ScoreBoostActive)
        {
            ActivateDamageBoost();
            Debug.Log("Damage Up");
        }
        else if (powerUp.CompareTag("ScoreBoost") && !DamageBoostActive)
        {
            ActivateScoreBoost();
            Debug.Log("Score Up");
        }
    }

    public void ActivateDamageBoost()
    {
        DamageBoostActive = true;
        extraDamage = Random.Range(20f, 100f);

        /*if (damageBoostTimer != null)
        {
            StopCoroutine(damageBoostTimer);
        }*/

        /*damageBoostTimer = StartCoroutine(TimerCoroutine(powerUpDuration));*/
    }

    public void ActivateScoreBoost()
    {
        ScoreBoostActive = true;
        scoreBonus = 2f;

        /*if (scoreBoostTimer != null)
        {
            StopCoroutine(scoreBoostTimer);
        }*/

        /*scoreBoostTimer = StartCoroutine(TimerCoroutine(powerUpDuration));*/
    }

    /*private IEnumerator TimerCoroutine(float timer)
    {
        
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer -= 1f;
        }

        if (DamageBoostActive)
        {
            DeactivateDamageBoost();
        }
        else if (ScoreBoostActive)
        {
            DeactivateScoreBoost();
        }
    }*/
    public void DeactivateDamageBoost()
    {
        DamageBoostActive = false;
    }

    public void DeactivateScoreBoost()
    {
        ScoreBoostActive = false;
    }
}
