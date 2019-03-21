using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMovement : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 origPos;

    void Start()
    {
        origPos = transform.position;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            FixedJoint fixedJoint = GetComponent<FixedJoint>();
            Destroy(fixedJoint);
            StartCoroutine(BreakJoints());
        }
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
    }

    public IEnumerator BreakJoints()
    {
        yield return new WaitForSeconds(0.05f);
        transform.position = origPos;
        StopCoroutine(BreakJoints());
    }
}
