using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateApple : MonoBehaviour
{
    // Start is called before the first frame update

    public static Animation apple;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            apple.Play();
        }
    }
}
