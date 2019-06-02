using UnityEngine;
using System.Collections;

public class SawMoveUpDown : MonoBehaviour
{


    IEnumerator Start()
    {
        var pointA = transform.position;
        var pointB = new Vector2(pointA.x ,pointA.y-3.83f);
        while(true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
            yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector2 startPos, Vector2 endPos, float time)
    {
        var i= 0.0f;
        var rate= 1.0f/time;
        while(i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector2.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}
