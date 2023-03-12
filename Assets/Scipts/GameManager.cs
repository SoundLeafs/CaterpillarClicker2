using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region variables
    public static int foodResource;
    public static int eatRate;
    public static int autoEatRate;
    public static bool doubleHead;
    public static bool tripleHead;
    public Text foodResourcet;
    public Text totalFoodConsumedt;
    public Text autoEatPerSecondt;
    public Text timePassedt;
    public static int totalFoodConsumed;
    public static int timePassed;
    //Next update in seconds
    private int nextUpdate = 1;
  


    public static bool showItem2 = false;
    [SerializeField] GameObject _showitem2;
    public static bool showItem3 = false;
    [SerializeField] GameObject _showitem3;
    public static bool showItem4 = false;
    [SerializeField] GameObject _showitem4;
    public static bool showItem5 = false;
    [SerializeField] GameObject _showitem5;
    public static bool showItem6 = false;
    [SerializeField] GameObject _showitem6;
    public static bool showItem7 = false;
    [SerializeField] GameObject _showitem7;
    public static bool showItem8 = false;
    [SerializeField] GameObject _showitem8;
    public static bool showItem9 = false;
    [SerializeField] GameObject _showitem9;

    public static bool stage2 = false;
    [SerializeField] GameObject _stage2;
    public static bool stage3 = false;
    [SerializeField] GameObject _stage3;
    public static bool stage4 = false;
    [SerializeField] GameObject _stage4;
    public static bool stage5 = false;
    [SerializeField] GameObject _stage5;
    public static bool stage6 = false;
    [SerializeField] GameObject _stage6;
    public static bool stage7 = false;
    [SerializeField] GameObject _stage7;
    public static bool stage8 = false;
    [SerializeField] GameObject _stage8;
    public static bool stage9 = false;
    [SerializeField] GameObject _stage9;

    public static bool skills1 = false;
    [SerializeField] GameObject _skills1;
    public static bool skills2 = false;
    [SerializeField] GameObject _skills2;
    public static bool skills3 = false;
    [SerializeField] GameObject _skills3;




    #endregion
    // Start is called before the first frame update

    void Start()
    {
        #region variables initialise

        foodResource = 0;
        eatRate = 1;
        autoEatRate = 0;
        doubleHead = false;
        tripleHead = false;
        totalFoodConsumed= 0;
        timePassed = 0;
        _showitem2.SetActive(false);
        _showitem3.SetActive(false);
        _showitem4.SetActive(false);
        _showitem5.SetActive(false);
        _showitem6.SetActive(false);
        _showitem7.SetActive(false);
        _showitem8.SetActive(false);
        _showitem9.SetActive(false);

        _stage2.SetActive(false);
        _stage3.SetActive(false);
        _stage4.SetActive(false);
        _stage5.SetActive(false);
        _stage6.SetActive(false);
        _stage7.SetActive(false);
        _stage8.SetActive(false);
        _stage9.SetActive(false);

        _skills1.SetActive(false);
        _skills2.SetActive(false);
        _skills3.SetActive(false);
        #endregion
    }

    void Update()
    {
        foodResourcet.text = "Food Consumed = " + foodResource;
        totalFoodConsumedt.text = "Total Food Consumed = "+ totalFoodConsumed;
        autoEatPerSecondt.text = "Auto Eat Per Second = " + autoEatRate;
        timePassedt.text = timePassed + " Seconds of Chaos";

        #region Unlock Shop Items
        //Show items when total food Consumed reaches a high enough level,
        switch (totalFoodConsumed)
        {
            case > 9999999:
               _showitem9.SetActive(true);
                _showitem8.SetActive(true);
                _showitem7.SetActive(true);
                _showitem6.SetActive(true);
                _showitem5.SetActive(true);
                _showitem4.SetActive(true);
                _showitem3.SetActive(true);
                _showitem2.SetActive(true);
                _stage2.SetActive(true);
                _stage3.SetActive(true);
                _stage4.SetActive(true);
                _stage5.SetActive(true);
                _stage6.SetActive(true);
                _stage7.SetActive(true);
                _stage8.SetActive(true);
                _stage9.SetActive(true);

                break;
            case > 999999:
                _showitem8.SetActive(true);
                _showitem7.SetActive(true);
                _showitem6.SetActive(true);
                _showitem5.SetActive(true);
                _showitem4.SetActive(true);
                _showitem3.SetActive(true);
                _showitem2.SetActive(true);
                _stage2.SetActive(true);  
                _stage3.SetActive(true);
                _stage4.SetActive(true);
                _stage5.SetActive(true);
                _stage6.SetActive(true);
                _stage7.SetActive(true);
                _stage8.SetActive(true);
               
                break;
            case > 99999:
                _showitem7.SetActive(true);
                _showitem6.SetActive(true);
                _showitem5.SetActive(true);
                _showitem4.SetActive(true);
                _showitem3.SetActive(true);
                _showitem2.SetActive(true);
                _stage2.SetActive(true);
                _stage3.SetActive(true);
                _stage4.SetActive(true);
                _stage5.SetActive(true);
                _stage6.SetActive(true);
                _stage7.SetActive(true);
              
                break;
            case > 9999:
                _showitem6.SetActive(true);
                _showitem5.SetActive(true);
                _showitem4.SetActive(true);
                _showitem3.SetActive(true);
                _showitem2.SetActive(true);
                _stage2.SetActive(true);
                _stage3.SetActive(true);
                _stage4.SetActive(true);
                _stage5.SetActive(true);
                _stage6.SetActive(true);
             
                break;
            case > 999:
                _showitem5.SetActive(true);
                _showitem4.SetActive(true);
                _showitem3.SetActive(true);
                _showitem2.SetActive(true);
                _stage2.SetActive(true);
                _stage3.SetActive(true);
                _stage4.SetActive(true);
                _stage5.SetActive(true);
         
                break;
            case > 99:
                _showitem4.SetActive(true);
                _showitem3.SetActive(true);
                _showitem2.SetActive(true);
                _stage2.SetActive(true);
                _stage3.SetActive(true);
                _stage4.SetActive(true);
   
                break;
            case > 50:
                _showitem3.SetActive(true);
                _showitem2.SetActive(true);
                _stage2.SetActive(true);
                _stage3.SetActive(true);
              
                break;
            case > 49:
                _showitem2.SetActive(true);
                _stage2.SetActive(true);
 
                break;

        }
        #endregion



        // If the next update is reached
        if (Time.time >= nextUpdate)
        {
            Debug.Log(Time.time + ">=" + nextUpdate);
            // Change the next update (current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            // Call your fonction
            UpdateEverySecond();
        }
        void UpdateEverySecond()
        {
            foodResource += autoEatRate;
            timePassed++;
            //every second will add x to the foodResource.
        }

    }


}


