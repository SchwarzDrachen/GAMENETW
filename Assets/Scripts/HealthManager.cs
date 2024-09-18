using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    //  Added health floats
    [SerializeField] private Slider enemySlider;
    /*[SerializeField] private Slider planetSlider;*/
    [SerializeField] private new Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;


    public void UpdateEnemyHealthBar(float currentValue, float maxValue)
    {
        enemySlider.value = currentValue / maxValue;
    }
    
    /*public void UpdatePlanetHealthBar(float currentValue, float maxValue)
    {
        planetSlider.value = currentValue / maxValue;
    }*/

    // Update is called once per frame
    void Update()
    {
        transform.rotation = camera.transform.rotation;
        transform.position = target.position + offset;
    }
}
