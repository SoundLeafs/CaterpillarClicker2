using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

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

    //Sprites
    public Image click01;
  /*
    public Sprite click02;
    public Sprite click03;
    public Sprite click04;
    public Sprite click05;
    public Sprite click06;
    public Sprite click07;
    public Sprite click08;
    public Sprite click09;
  Decided to use array instead because easier
  */

    //change sprites to an array
    public Sprite[] clickImagesArray;

    public Image worm01;
    public Sprite worm02;
    public Sprite worm03;
    public Sprite worm04;
    public Sprite worm05;
    public Sprite worm06;
    public Sprite worm07;
    public Sprite worm08;
    public Sprite worm09;

    public Image actImage;
    public Sprite[] actImagesArray;
    public GameObject actVisible;


    public void ChangeAct(int i)
    {
        //Change our sprite taking input int from the button we click on
        actImage.sprite = actImagesArray[i];
        //show our image
        actVisible.SetActive(true);
    } 

    public void HideAct()
    {
        //hide our Image
        actVisible.SetActive(false);
    }


    //Show Items

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



    //skills booleans
    public bool skills1Active = false;
    public bool skills2Active = false;
    public bool skills3Active = false;


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

    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private GameObject canvas;

    //Will display button which when clicked shows ending
    public static bool endingButton = false;
    [SerializeField] GameObject _endingButton;
   

    #region Show Auto

    //This method/function will show text at position of object it is attached to  (Gaamemanager)
    void ShowAuto(string text)
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, canvas.transform);
            prefab.GetComponentInChildren<Text>().text = text;
        }
    }

    #endregion


    #endregion
    // Start is called before the first frame update

    void Start()
    {
        #region variables initialise
        actVisible.SetActive(false);

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

        _endingButton.SetActive(false);

        
        #endregion
    }

    void Update()
    {
        foodResourcet.text = "Food Consumed = " + foodResource;
        totalFoodConsumedt.text = "Total Food Consumed = "+ totalFoodConsumed;
        autoEatPerSecondt.text = "Auto Eat Per Second = " + autoEatRate;
        timePassedt.text = timePassed + " Seconds of Chaos";

        //DEBUG CODE REMOVE BEFORE SHIPPING
        if (Input.GetKeyDown(KeyCode.X))
        {
            foodResource += 100000;
            totalFoodConsumed += 100000;

        }
        //REMOVE THIS ABOVE

        //Disable skills if time up
        if (skills1Active && ClickerCalculator.skills1ActiveTime <1)
        {
            skills1Active= false;
            Debug.Log("skills1Disabled");
        }

        //Disable skills if time up
        if (skills2Active && ClickerCalculator.skills2ActiveTime < 1)
        {
            skills2Active = false;
            Debug.Log("skills2Disabled");
        }
        //Disable skills if time up
        if (skills3Active && ClickerCalculator.skills3ActiveTime < 1)
        {
            skills3Active = false;
            Debug.Log("skills3Disabled");
        }



        #region Unlock Shop Items and MonsterSize / Stages
        //Show items when total food Consumed reaches a high enough level,
        switch (totalFoodConsumed)
        {
            case > 300000:
                _endingButton.SetActive(true);
                     break;

            case > 250000:
          
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
                _skills1.SetActive(true);
                _skills2.SetActive(true);
                _skills3.SetActive(true);

                MonsterSize.monsterSize = 8;
                click01.sprite = clickImagesArray[25];
                worm01.sprite = worm09;
                break;


            case > 235000:
                click01.sprite = clickImagesArray[24];
                break;

            case > 220000:
                click01.sprite = clickImagesArray[23];
                break;

            case > 200000:
           
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
                _skills1.SetActive(true);
                _skills2.SetActive(true);
                _skills3.SetActive(true);


                MonsterSize.monsterSize = 8;
                click01.sprite = clickImagesArray[22];
                worm01.sprite = worm08;
                break;


            case > 160000:
                click01.sprite = clickImagesArray[21];
                break;

            case > 130000:
                click01.sprite = clickImagesArray[20];
                break;

            case > 100000:
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
                _skills1.SetActive(true);
                _skills2.SetActive(true);
                _skills3.SetActive(true);


                MonsterSize.monsterSize = 7;
                click01.sprite = clickImagesArray[19];
                worm01.sprite = worm07;
            

                break;

            case > 85000:
                click01.sprite = clickImagesArray[18];
                break;

            case > 70000:
                click01.sprite = clickImagesArray[17];
                break;

            case > 50000:
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
                _skills1.SetActive(true);
                _skills2.SetActive(true);
                _skills3.SetActive(true);


                MonsterSize.monsterSize = 6;
                click01.sprite = clickImagesArray[16];
                worm01.sprite = worm06;
           

                break;

            case > 40000:
                click01.sprite = clickImagesArray[15];
                break;

            case > 25000:
                click01.sprite = clickImagesArray[14];
                break;

            case > 10000:
                _showitem5.SetActive(true);
                _showitem4.SetActive(true);
                _showitem3.SetActive(true);
                _showitem2.SetActive(true);
                _stage2.SetActive(true);
                _stage3.SetActive(true);
                _stage4.SetActive(true);
                _stage5.SetActive(true);
                _skills1.SetActive(true);
                _skills2.SetActive(true);
                _skills3.SetActive(true);

                MonsterSize.monsterSize = 5;
                click01.sprite = clickImagesArray[13];
                worm01.sprite = worm05;
              

                break;

            case > 8500:
                click01.sprite = clickImagesArray[12];
                break;

            case > 7000:
                click01.sprite = clickImagesArray[11];
                break;


            case > 5000:
                _showitem4.SetActive(true);
                _showitem3.SetActive(true);
                _showitem2.SetActive(true);
                _stage2.SetActive(true);
                _stage3.SetActive(true);
                _stage4.SetActive(true);
                _skills1.SetActive(true);
                _skills2.SetActive(true);


                MonsterSize.monsterSize = 4;
               click01.sprite = clickImagesArray[10];
                worm01.sprite = worm04;
                break;

            case > 3500:
                click01.sprite = clickImagesArray[9];
                break;

            case > 2000:
                click01.sprite = clickImagesArray[8];
                break;

            case > 500:
                _showitem3.SetActive(true);
                _showitem2.SetActive(true);
                _stage2.SetActive(true);
                _stage3.SetActive(true);
                _skills1.SetActive(true);


                MonsterSize.monsterSize = 3;
                click01.sprite = clickImagesArray[7];
                worm01.sprite = worm03;

                break;

            case > 400:
                click01.sprite = clickImagesArray[6];
                break;

            case > 200:
                click01.sprite = clickImagesArray[5];
                break;


               
            case > 99:
                _showitem2.SetActive(true);
                _stage2.SetActive(true);
                MonsterSize.monsterSize = 2;
                click01.sprite = clickImagesArray[4];
                worm01.sprite = worm02;
                break;

            case > 50:
                click01.sprite = clickImagesArray[3];
                break;

            case > 25:
                click01.sprite = clickImagesArray[2];
                break;

        }
        #endregion



        // If the next update is reached
        if (Time.time >= nextUpdate)
        {
        
            // Change the next update (current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            // Call your fonction
            UpdateEverySecond();
        }

     

        void UpdateEverySecond()
        {
            timePassed++;
            ClickerCalculator.skills1Cooldown--;
            ClickerCalculator.skills1ActiveTime--;
            Debug.Log(ClickerCalculator.skills1Cooldown);
            ClickerCalculator.skills2Cooldown--;
            ClickerCalculator.skills2ActiveTime--;
            Debug.Log(ClickerCalculator.skills2Cooldown);
            ClickerCalculator.skills3Cooldown--;
            ClickerCalculator.skills3ActiveTime--;
            Debug.Log(ClickerCalculator.skills3Cooldown);
            //every second will add x to the foodResource.

            if (autoEatRate > 0)
                //if we have auto, otherwise will keep showing zero which is annoying
            {
                if (skills2Active)
                {
                    ShowAuto(GameManager.autoEatRate.ToString());
                    foodResource += autoEatRate*3;
                    totalFoodConsumed += autoEatRate*3;
                }
                else
                {
                    ShowAuto(GameManager.autoEatRate.ToString());
                    foodResource += autoEatRate;
                    totalFoodConsumed += autoEatRate;
                } 
                   
                
            }

            

        }

    }


}


