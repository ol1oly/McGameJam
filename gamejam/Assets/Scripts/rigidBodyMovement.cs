using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RigidBodyMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float baseSpeed = 5f;
    public float currentSpeed;

    Coroutine adjustSpeedCoroutine;

    void Start()
    {
        currentSpeed = baseSpeed * 0.2f;
        StartAdjust(baseSpeed, 0.1f);


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<SlowZone>(out SlowZone sz))
        {
            Debug.Log("there is a slow zone");
            StartAdjust(baseSpeed * sz.speedChange, sz.timeToChange);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<SlowZone>(out SlowZone sz))
        {
            StartAdjust(baseSpeed, sz.timeToChange);
        }
    }

    void StartAdjust(float targetSpeed, float time)
    {
        if (adjustSpeedCoroutine != null)
            StopCoroutine(adjustSpeedCoroutine);

        adjustSpeedCoroutine = StartCoroutine(AdjustSpeed(targetSpeed, time));
    }

    IEnumerator AdjustSpeed(float targetSpeed, float duration)
    {
        float startSpeed = currentSpeed;
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            currentSpeed = Mathf.Lerp(startSpeed, targetSpeed, t / duration);
            rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);
            yield return null;
        }

        currentSpeed = targetSpeed;
        rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);
    }
}
