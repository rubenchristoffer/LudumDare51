using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueArrow : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
    }

    // Update is called once per frame
    void Update()
    {
        PointToTarget(target);
        
    }
    void PointToTarget(Transform target)
    {
        float angle = Vector2.Angle(transform.position, target.position);
        Vector2 relative = target.position - transform.position;
        angle = Mathf.Atan2(relative.y, relative.x) * 180 / Mathf.PI;
        
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angle);
    }
}
