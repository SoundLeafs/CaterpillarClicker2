using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSize : MonoBehaviour
{

    //adjust the size of monster
    public static int monsterSize;
    public Vector3 originalSize;

    // Start is called before the first frame update
    void Start()
    {
        //set the size of monster to that of parent
        originalSize = transform.localScale;
        monsterSize = 1;
        //size will either increase with total ammount of food eaten or unlocking acts
    }

    // Update is called once per frame
    void Update()
    {
        //Adjust size of Monster
        transform.localScale = originalSize * (monsterSize)/2;
    }
}
