using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTheDice : MonoBehaviour
{
    private Vector3 originPosition = new Vector3(0f, 0f, -8f);
    private Vector3 shakePosition;
    private Vector3 targetPosition;
    private Vector3 targetRotation;
    private Quaternion originRotation;
    private Quaternion shakeRotation;
    private float shake_decay = 0.002f;
    private float shake_intensity = 0.0f;
    private bool IsThrowing = false;

    void Start()
    {
        targetPosition = transform.position;
        originPosition = transform.position;
        originRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.1f);
        if (transform.localEulerAngles.x > -135f) {
            transform.Rotate(targetRotation * 2f * Time.deltaTime);
        }
        
        if (transform.localEulerAngles.x == -135f)
        {
            targetRotation = new Vector3(135f, 0f, 0f);
        }

        if (targetRotation.x == 135f && transform.localEulerAngles.x == 0f)
        {
            targetRotation = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            targetPosition = new Vector3(0f, 5f, -8f);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RollDice();
        }

        if (transform.position.x == 0f && transform.position.y == 5f && transform.position.z == -8f)
        {
            targetPosition = new Vector3(0f, 5f, -3f);
        }

        if (shake_intensity > 0)
        {
            transform.position = shakePosition + Random.insideUnitSphere * shake_intensity;
            transform.rotation = new Quaternion(
                shakeRotation.x + Random.Range(-shake_intensity, shake_intensity) * .2f,
                shakeRotation.y + Random.Range(-shake_intensity, shake_intensity) * .2f,
                shakeRotation.z + Random.Range(-shake_intensity, shake_intensity) * .2f,
                shakeRotation.w + Random.Range(-shake_intensity, shake_intensity) * .2f
            );
            shake_intensity -= shake_decay;
        }

        if (shake_intensity == 0 && IsThrowing)
        {

        }
    }

    void Shake()
    {
        shakePosition = transform.position;
        shakeRotation = transform.rotation;
        shake_intensity = 0.5f;
    }

    void RollDice()
    {
        Shake();
        IsThrowing = true;
        targetRotation = new Vector3(-135f, 0f, 0f);
    }
}