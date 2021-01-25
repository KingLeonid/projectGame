using System.Collections;
using UnityEngine;

public class ClickTrack : MonoBehaviour
{
    public float Speed = 2;
    public float Amplitude = 5;
    public Vector3 Target = new Vector3(20, 0, 20);

    Vector3 point;

    void Update()
    {

        StartCoroutine(Move());
    }
    public float distance = 10f;

    IEnumerator Move()
    {
        point = gameObject.transform.position;

        while (true)
        {
            point = Vector3.MoveTowards(point, Target, Time.deltaTime * Speed);
            transform.position = point + transform.right * Mathf.Sin(Time.time) * Amplitude;
            yield return null;
        }
    }

}



