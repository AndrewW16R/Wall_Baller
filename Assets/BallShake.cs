using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShake : MonoBehaviour
{

    public float duration = 1f;
    public AnimationCurve curve01; //sets intensity of shake over time
    public AnimationCurve curve02;

    public float heavySwingHitStopThreshold; // set this value to the lowest amount of hitstop power from all of the heavy swings

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateShake01()
    {
        StartCoroutine(Shaking01());
    }

    public void ActivateShake02()
    {
        StartCoroutine(Shaking02());
    }

    IEnumerator Shaking01()
    {
        Vector3 startPosition = transform.position; //saves starting position
        float elapsedTime = 0f; //sets elapsed time to zero

        while (elapsedTime < duration)
        {
            //Debug.Log(elapsedTime);
            elapsedTime += Time.deltaTime;

            float strength = curve01.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;

    }

    IEnumerator Shaking02()
    {
        Vector3 startPosition = transform.position; //saves starting position
        float elapsedTime = 0f; //sets elapsed time to zero

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve02.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    
    }
}
