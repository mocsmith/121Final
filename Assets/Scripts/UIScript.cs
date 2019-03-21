using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    GameObject keyText;
    GameObject corText;
    GameObject incText;
    GameObject puz1;
    GameObject puz2;
    GameObject puz3;
    public float randomNo;
    public int totalJoints = 0;
    public string keyPos1;
    public string keyPos2;
    public string keyPos3;


    void Awake()
    {
        keyText = GameObject.Find("CheckKey");
        corText = GameObject.Find("CorrectText");
        incText = GameObject.Find("IncorrectText");
        puz1 = GameObject.Find("KeyPuzzle1");
        puz2 = GameObject.Find("KeyPuzzle2");
        puz3 = GameObject.Find("KeyPuzzle3");        
    }

    void Start()
    {
        puz1.SetActive(false);
        puz2.SetActive(false);
        puz3.SetActive(false);

        randomNo = Random.value;
        if (randomNo <= 0.33f)
        {
            puz1.SetActive(true);
        }
        else if (randomNo <= 0.66f)
        {
            puz2.SetActive(true);
        }
        else
        {
            puz3.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        totalJoints =   GameObject.Find("KeyFrag1").GetComponent<KeyConnect>().jointCount +
                        GameObject.Find("KeyFrag2").GetComponent<KeyConnect>().jointCount +
                        GameObject.Find("KeyFrag3").GetComponent<KeyConnect>().jointCount +
                        GameObject.Find("KeyFrag4").GetComponent<KeyConnect>().jointCount +
                        GameObject.Find("KeyFrag5").GetComponent<KeyConnect>().jointCount +
                        GameObject.Find("KeyFrag6").GetComponent<KeyConnect>().jointCount +
                        GameObject.Find("KeyFrag7").GetComponent<KeyConnect>().jointCount +
                        GameObject.Find("KeyFrag8").GetComponent<KeyConnect>().jointCount +
                        GameObject.Find("KeyFrag9").GetComponent<KeyConnect>().jointCount;

        if ( totalJoints == 3)
        {
            keyText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.T))
            {
                if (randomNo <= 0.33f)
                {
                    if (keyPos1 == "KeyFrag1 (UnityEngine.GameObject)" && keyPos2 == "KeyFrag6 (UnityEngine.GameObject)" && keyPos3 == "KeyFrag8 (UnityEngine.GameObject)")
                    {
                        StartCoroutine(CorrectText());
                    }
                    else
                    {
                        StartCoroutine(IncorrectText());
                    }
                }
                else if (randomNo <= 0.66f)
                {
                    if (keyPos1 == "KeyFrag2 (UnityEngine.GameObject)" && keyPos2 == "KeyFrag4 (UnityEngine.GameObject)" && keyPos3 == "KeyFrag7 (UnityEngine.GameObject)")
                    {
                        StartCoroutine(CorrectText());
                    }
                    else
                    {
                        StartCoroutine(IncorrectText());
                    }
                }
                else
                {
                    if (keyPos1 == "KeyFrag3 (UnityEngine.GameObject)" && keyPos2 == "KeyFrag5 (UnityEngine.GameObject)" && keyPos3 == "KeyFrag9 (UnityEngine.GameObject)")
                    {
                        StartCoroutine(CorrectText());
                    }
                    else
                    {
                        StartCoroutine(IncorrectText());
                    }
                }
            }
        }
        else
        {
            keyText.SetActive(false);
            corText.SetActive(false);
            incText.SetActive(false);
        }
    }

    IEnumerator CorrectText()
    {
        corText.SetActive(true);
        yield return new WaitForSeconds(1f);
        corText.SetActive(false);

        Destroy(GameObject.Find("KeyHandle").GetComponent<FixedJoint>());
        StartCoroutine(GameObject.Find("KeyHandle").GetComponent<HandleMovement>().BreakJoints());

        Destroy(GameObject.Find("KeyFrag1").GetComponent<FixedJoint>());
        StartCoroutine(GameObject.Find("KeyFrag1").GetComponent<KeyConnect>().BreakJoints());
        Destroy(GameObject.Find("KeyFrag2").GetComponent<FixedJoint>());
        StartCoroutine(GameObject.Find("KeyFrag2").GetComponent<KeyConnect>().BreakJoints());
        Destroy(GameObject.Find("KeyFrag3").GetComponent<FixedJoint>());
        StartCoroutine(GameObject.Find("KeyFrag3").GetComponent<KeyConnect>().BreakJoints());
        Destroy(GameObject.Find("KeyFrag4").GetComponent<FixedJoint>());
        StartCoroutine(GameObject.Find("KeyFrag4").GetComponent<KeyConnect>().BreakJoints());
        Destroy(GameObject.Find("KeyFrag5").GetComponent<FixedJoint>());
        StartCoroutine(GameObject.Find("KeyFrag5").GetComponent<KeyConnect>().BreakJoints());
        Destroy(GameObject.Find("KeyFrag6").GetComponent<FixedJoint>());
        StartCoroutine(GameObject.Find("KeyFrag6").GetComponent<KeyConnect>().BreakJoints());
        Destroy(GameObject.Find("KeyFrag7").GetComponent<FixedJoint>());
        StartCoroutine(GameObject.Find("KeyFrag7").GetComponent<KeyConnect>().BreakJoints());
        Destroy(GameObject.Find("KeyFrag8").GetComponent<FixedJoint>());
        StartCoroutine(GameObject.Find("KeyFrag8").GetComponent<KeyConnect>().BreakJoints());
        Destroy(GameObject.Find("KeyFrag9").GetComponent<FixedJoint>());
        StartCoroutine(GameObject.Find("KeyFrag9").GetComponent<KeyConnect>().BreakJoints());

        randomNo = Random.value;
        puz1.SetActive(false);
        puz2.SetActive(false);
        puz3.SetActive(false);

        if (randomNo <= 0.33f)
        {
            puz1.SetActive(true);
        }
        else if (randomNo <= 0.66f)
        {
            puz2.SetActive(true);
        }
        else
        {
            puz3.SetActive(true);
        }

        StopCoroutine(CorrectText());
    }

    IEnumerator IncorrectText()
    {
        incText.SetActive(true);
        yield return new WaitForSeconds(1f);
        incText.SetActive(false);
        StopCoroutine(IncorrectText());
    }
}
