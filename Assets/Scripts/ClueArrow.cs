using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueArrow : MonoBehaviour
{

    void Update()
    {
        PointToTarget(TileSet.escapeTileCenterCoordinates);
    }
    void PointToTarget(Vector3 target)
    {
        float angle = Vector2.Angle(transform.position, target);
        Vector2 relative = target - transform.position;
        angle = Mathf.Atan2(relative.y, relative.x) * 180 / Mathf.PI;
        
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, angle);
    }
}
