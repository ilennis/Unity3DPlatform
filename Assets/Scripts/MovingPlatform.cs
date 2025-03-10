using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject waypoint1;
    public GameObject waypoint2;
    public GameObject platform;
    public float speed = 10f;
    public float delay = 1f;

    private Vector3 targetPosition;

    private bool aToB = true;
    // Start is called before the first frame update
    void Start()
    {
        platform.transform.position = waypoint1.transform.position;
        targetPosition = waypoint2.transform.position;
        StartCoroutine(MovePlatform());
    }
    IEnumerator MovePlatform()
    {
        while(true)
        {
            while((targetPosition - platform.transform.position).sqrMagnitude > 0.01f)
            {
                platform.transform.position = Vector3.MoveTowards(platform.transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }
            targetPosition = targetPosition == waypoint1.transform.position ? waypoint2.transform.position : waypoint1.transform.position;
            yield return new WaitForSeconds(delay);
        }
    }

}
