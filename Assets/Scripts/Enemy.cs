using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;

    private Transform target = null;

    private void OnEnable(){
        LookAtTarget();
    }

    public void SetTarget(Transform target){
        this.target = target;
    }

    private void Update(){
        Move();
    }
    
    private void LookAtTarget(){
        Quaternion newRotation;
        Vector3 targetDirection = target == null ? transform.position : transform.position - target.transform.position;
        newRotation = Quaternion.LookRotation(targetDirection, Vector3.forward);
        newRotation.x = 0;
        newRotation.y = 0;
        transform.rotation = newRotation;
    }

    private void Move(){
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}
