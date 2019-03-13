using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    GameObject keyText;
    GameObject incText;

    void Awake()
    {
        keyText = GameObject.Find("CheckKey");
        incText = GameObject.Find("IncorrectText");
    }

    void FixedUpdate()
    {
        if (GameObject.Find("KeyFrag").GetComponent<KeyConnect>().jointCount +
            GameObject.Find("KeyFrag1").GetComponent<KeyConnect>().jointCount +
            GameObject.Find("KeyFrag2").GetComponent<KeyConnect>().jointCount == 3)
        {
            keyText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.T))
            {
                StartCoroutine(IncorrectText());
            }
        }
        else
        {
            keyText.SetActive(false);
            incText.SetActive(false);
        }
    }

    IEnumerator IncorrectText()
    {
        incText.SetActive(true);
        yield return new WaitForSeconds(1f);
        incText.SetActive(false);
        StopCoroutine(IncorrectText());
    }
}
