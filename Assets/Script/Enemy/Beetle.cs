using System;
using System.Collections;
using UnityEngine;

public class Beetle : MonoBehaviour
{
    //Movement

    [Header("Setting")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float amplitude = 1f;
    [SerializeField] private float flipPos = 0.9f;
    [SerializeField] private float flipWaitTime = 1f;
    
    private float horizontalMovement;
    private Vector2 initialPos;

    private void Start() {
        initialPos = transform.position;
    }

    private void FixedUpdate() {
        horizontalMovement = Mathf.Cos(Time.time * speed) * amplitude;

        transform.position = initialPos + new Vector2(horizontalMovement, 0);

        StartCoroutine(FlipDirection());
    }

    private IEnumerator FlipDirection(){
        if(Mathf.Abs(Mathf.Cos(Time.time * speed)) > flipPos){
            transform.localScale *= new Vector2(-1, 1);
        }
        yield return new WaitForSeconds(flipWaitTime);
    }
}
