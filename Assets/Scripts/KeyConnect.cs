using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyConnect : MonoBehaviour
{
    public int KeyNumber;
    private Vector3 origPos;
    private Vector3 screenPoint;
    private Vector3 offset;
    bool hasJoint;
    public int jointCount = 0;

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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null && !hasJoint && collision.gameObject.tag == "KeyFrag")
        {
            gameObject.AddComponent<FixedJoint>();
            gameObject.GetComponent<FixedJoint>().connectedBody = collision.rigidbody;
            hasJoint = true;
            jointCount = jointCount + 1;
        }
    }

    IEnumerator BreakJoints()
    {
        yield return new WaitForSeconds(0.05f);
        transform.position = origPos;
        hasJoint = false;
        jointCount = 0;
        StopCoroutine(BreakJoints());
    }
}
