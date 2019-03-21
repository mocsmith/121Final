using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyConnect : MonoBehaviour
{
    private Vector3 origPos;
    bool hasJoint;
    public int jointCount = 0;

    void Start()
    {
        origPos = transform.position;
    }

    void FixedUpdate()
    {
        if (gameObject.GetComponent<FixedJoint>() == null)
        {
            transform.position = origPos;
        }

        if (Input.GetKeyDown("space"))
        {
            FixedJoint fixedJoint = GetComponent<FixedJoint>();
            Destroy(fixedJoint);
            StartCoroutine(BreakJoints());
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null && !hasJoint && collision.gameObject.tag == "KeyFrag" && GameObject.Find("Canvas").GetComponent<UIScript>().totalJoints <= 2)
        {
            gameObject.AddComponent<FixedJoint>();
            gameObject.GetComponent<FixedJoint>().connectedBody = collision.rigidbody;
            hasJoint = true;
            jointCount = jointCount + 1;
            StartCoroutine(KeyPosition());
        }
    }

    public IEnumerator BreakJoints()
    {
        yield return new WaitForSeconds(0.05f);
        transform.position = origPos;
        hasJoint = false;
        jointCount = 0;
        StopCoroutine(BreakJoints());
    }

    IEnumerator KeyPosition()
    {
        yield return new WaitForSeconds(0.06f);
        if (GameObject.Find("Canvas").GetComponent<UIScript>().totalJoints == 1)
        {
            GameObject.Find("Canvas").GetComponent<UIScript>().keyPos1 = gameObject.ToString();
            StopCoroutine(KeyPosition());
        }
        else if (GameObject.Find("Canvas").GetComponent<UIScript>().totalJoints == 2)
        {
            GameObject.Find("Canvas").GetComponent<UIScript>().keyPos2 = gameObject.ToString();
            StopCoroutine(KeyPosition());
        }
        else
        {
            GameObject.Find("Canvas").GetComponent<UIScript>().keyPos3 = gameObject.ToString();
            StopCoroutine(KeyPosition());
        }
    }
}
