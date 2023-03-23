using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//need this to use math functions
using System;
using System.Runtime.CompilerServices;

public class ClickerCalculator : MonoBehaviour
{
    public int itemNo;
    public int item1Level;
    public int item2Level;
    public int item3Level;
    public int item4level;
    public int item5level;
    public int item6Level;
    public int item7Level;
    public int item8Level;
    public int item9Level;
    public Text textItem1;
    public Text textItem2;
    public Text textItem3;
    public Text textItem4;
    public Text textItem5;
    public Text textItem6;
    public Text textItem7;
    public Text textItem8;
    public Text textItem9;

    //Show Levels of items
    public Text item1LVtxt;
    public Text item2LVtxt;
    public Text item3LVtxt;
    public Text item4LVtxt;
    public Text item5LVtxt;
    public Text item6LVtxt;
    public Text item7LVtxt;

    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3, sfx4, sfx5, sfx6;
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private GameObject canvas;

    public static bool showItemBox1 = false;
    [SerializeField] GameObject _showItemBox1;

    public static bool showItemBox2 = false;
    [SerializeField] GameObject _showItemBox2;

    public static bool showItemBox3 = false;
    [SerializeField] GameObject _showItemBox3;

    public static bool showItemBox4 = false;
    [SerializeField] GameObject _showItemBox4;

    public static bool showItemBox5 = false;
    [SerializeField] GameObject _showItemBox5;

    public static bool showItemBox6 = false;
    [SerializeField] GameObject _showItemBox6;

    public static bool showItemBox7 = false;
    [SerializeField] GameObject _showItemBox7;

    public static bool showItemBox8 = false;
    [SerializeField] GameObject _showItemBox8;

    public static bool showItemBox9 = false;
    [SerializeField] GameObject _showItemBox9;

    //Item level description

    public static bool showItemLV1Box = false;
    [SerializeField] GameObject _showItemLv1Box;

    public static bool showItemLV2Box = false;
    [SerializeField] GameObject _showItemLv2Box;
    
    public static bool showItemLV3Box = false;
    [SerializeField] GameObject _showItemLv3Box;

    public static bool showItemLV4Box = false;
    [SerializeField] GameObject _showItemLv4Box;

    public static bool showItemLV5Box = false;
    [SerializeField] GameObject _showItemLv5Box;

    public static bool showItemLV6Box = false;
    [SerializeField] GameObject _showItemLv6Box;

    public static bool showItemLV7Box = false;
    [SerializeField] GameObject _showItemLv7Box;





    //Skills Bool
    public static bool skills1Active;
    public static bool skills1Bought;
    public static int skills1Cooldown;
    public static int skills1ActiveTime;

    public static bool skills2Active;
    public static bool skills2Bought;
    public static int skills2Cooldown;
    public static int skills2ActiveTime;

    public static bool skills3Active;
    public static bool skills3Bought;
    public static int skills3Cooldown;
    public static int skills3ActiveTime;


    //Hide TextBox when not in use

    #region Show Clicks
    public void ShowClicks(string text)
        //This Method will turn clicks into floating text
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, canvas.transform);
            prefab.GetComponentInChildren<Text>().text = text;
        }
    }
    #endregion


    //create an array with all variables for items, eg array is 9X3 so nine arrays with three objects each, will contain (Item name, price, value of mulriplier)
    //Nevermind I need them to all be int, so just price and value 9,2
    //this array is public so can be edit in ItemPriceArray Under Game
    public int[] itemPriceArray = new int[9]; 

    //Create array with variables for ClickGain
    public int[] itemEatRate = new int[9];

    //Create array with variables for AutoClickGain
    public int[] itemAutoRate= new int[9];


    private void Start()
    {
        item1Level= 1;
        item2Level= 1;
        item3Level= 1;
        item4level= 1;
        item5level= 1;
        item6Level= 1;
        item7Level= 1;
        item8Level= 1;
        item9Level =1;    
        itemNo= 0;

       
        
        
    }

    

    #region Skills Methods
    public void Skill1Activate()
        //triple click, all clicks worth triple
    {
        //Check if we have purchased skill, if yes then go to next line, else purchase or play bad sounds
        if (skills1Bought)
        {
            //if cooldown is 0 then we can use 
            if (skills1Cooldown <=0)
            {
                skills1Active= true;
                //set cooldown to 30 seconds
                skills1Cooldown= 30;
                skills1ActiveTime= 10;
            }   
        }

        else
        {
            //if we dont have it and click and we have >5000 then we buy it
            if (GameManager.foodResource >= 5000)
            {
                GameManager.foodResource -= 5000;
                skills1Bought = true;
                src.clip = sfx1;
                src.Play();
               
              
            }
            else
            {
                src.clip = sfx2;
                src.Play();
            }
        }
       

    }

    public void Skill2Activate()
    {
        //Check if we have purchased skill, if yes then go to next line, else purchase or play bad sounds
        if (skills2Bought)
        {
            //if cooldown is 0 then we can use 
            if (skills2Cooldown <= 0)
            {
                skills2Active = true;
                //set cooldown to 60 seconds
                skills2Cooldown = 60;
                skills2ActiveTime= 15;
            }
        }

        else
        {
            //if we dont have it and click and we have >5000 then we buy it
            if (GameManager.foodResource >= 10000)
            {
                GameManager.foodResource -= 10000;
                skills2Bought = true;
                src.clip = sfx1;
                src.Play();
               
               
            }
            else
            {
                src.clip = sfx2;
                src.Play();
            }
        }
    }
    
    public void Skill3Activate()
    {
        //Check if we have purchased skill, if yes then go to next line, else purchase or play bad sounds
        if (skills3Bought)
        {
            //if cooldown is 0 then we can use 
            if (skills3Cooldown <= 0)
            {
                skills3Active = true;
                //set cooldown to 90 seconds
                skills3Cooldown = 90;
                skills3ActiveTime= 15;
            }
        }

        else
        {
            //if we dont have it and click and we have >5000 then we buy it
            if (GameManager.foodResource >= 20000)
            {
                GameManager.foodResource -= 20000;
                skills3Bought = true;
                src.clip = sfx1;
                src.Play();


            }
            else
            {
                src.clip = sfx2;
                src.Play();
            }
        }
    }

    #endregion

    public void Eating()
        //this is code applied when we click the apple
    {
        
       

        if (GameManager.doubleHead == true)

        {
            if (skills1Active)
            {
                //we run 3 times if skills1active
                for (int i = 0; i < 3; i++)
                {
                    ShowClicks((2 * GameManager.eatRate).ToString());
                    GameManager.foodResource += 2 * GameManager.eatRate;
                    //if we have double head then all clicks are worth double
                    GameManager.totalFoodConsumed += 2 * GameManager.eatRate;
                    //update the total food consumed
                    
                }

            }
            else
            {
                ShowClicks((2 * GameManager.eatRate).ToString());
                GameManager.foodResource += 2 * GameManager.eatRate;
                //if we have double head then all clicks are worth double
                GameManager.totalFoodConsumed += 2 * GameManager.eatRate;
                //update the total food consumed
            }



        }   
       
        else if(GameManager.tripleHead == true) 
        {
            if (skills1Active)
            {
                //run 3 times
                for (int i = 0; i < 3; i++)
                {
                    ShowClicks((3 * GameManager.eatRate).ToString());
                    GameManager.foodResource += 3 * GameManager.eatRate;
                    //if we have triple head then all clicks are worth triple
                    GameManager.totalFoodConsumed += 3 * GameManager.eatRate;
                    //update the total food consumed
                }
            }
            else
            {
                ShowClicks((3 * GameManager.eatRate).ToString());
                GameManager.foodResource += 3 * GameManager.eatRate;
                //if we have triple head then all clicks are worth triple
                GameManager.totalFoodConsumed += 3 * GameManager.eatRate;
                //update the total food consumed
            }


        }

        else
        {
            if (skills1Active) 
            {
                for (int i = 0; i < 3; i++)
                {
                    ShowClicks(GameManager.eatRate.ToString());
                    GameManager.foodResource += GameManager.eatRate;
                    //if we have neither of these then all clicks are worth 1 x whatever other additons we have earned
                    GameManager.totalFoodConsumed += GameManager.eatRate;
                    //update the total food consumed
                }
            }
            else
            {
                ShowClicks(GameManager.eatRate.ToString());
                GameManager.foodResource += GameManager.eatRate;
                //if we have neither of these then all clicks are worth 1 x whatever other additons we have earned
                GameManager.totalFoodConsumed += GameManager.eatRate;
                //update the total food consumed
            }


        }

    }

    public void Shopping(int num)
        //this is the code we run when clicking on a Item to buy
    {
        switch (num)
        {
            case 1:
                int foodCost = Convert.ToInt32(Math.Pow(itemPriceArray[0], item1Level));
                if (GameManager.foodResource >= foodCost)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.eatRate += itemEatRate[0];
                    GameManager.autoEatRate += itemAutoRate[0];
                    src.clip = sfx1;
                    src.Play();
                    item1Level++;
                    Debug.Log(itemPriceArray[1]);
                    MouseOver(1);
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
              
                break;
                
            case 2:
                foodCost = itemPriceArray[1] * item2Level;
                if ((GameManager.foodResource >= foodCost) && GameManager.doubleHead == false)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.doubleHead= true;
                    src.clip = sfx1;
                    src.Play();
                    MouseOver(2);
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 3:
                foodCost = itemPriceArray[2] * item3Level;
                if (GameManager.foodResource >= foodCost)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.eatRate += itemEatRate[0];
                    GameManager.autoEatRate += itemAutoRate[2]; 
                    src.clip = sfx1;
                    src.Play();
                    item3Level++;
                    MouseOver(3);
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 4:
                foodCost = itemPriceArray[3] * item4level;
                if (GameManager.foodResource >= foodCost)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.eatRate +=  itemEatRate[3];
                    GameManager.autoEatRate += itemAutoRate[3];
                    src.clip = sfx1;
                    src.Play();
                    item4level++;
                    MouseOver(4);
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 5:
                foodCost = itemPriceArray[4] * item5level;
                if (GameManager.foodResource >= foodCost)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.eatRate +=  itemEatRate[4];
                    GameManager.autoEatRate += itemAutoRate[4];
                    src.clip = sfx1;
                    src.Play();
                    item5level++;
                    MouseOver(5);
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 6:
                foodCost = itemPriceArray[5] * item6Level;
                if (GameManager.foodResource >= foodCost)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.eatRate += itemEatRate[5];
                    GameManager.autoEatRate +=  itemAutoRate[5]; 
                    src.clip = sfx1;
                    src.Play();
                    item6Level++;
                    MouseOver(6);
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 7:
                foodCost = itemPriceArray[6] * item7Level;
                if (GameManager.foodResource >= foodCost && GameManager.tripleHead == false)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.tripleHead= true;
                    src.clip = sfx4;
                    src.Play();
                    MouseOver(7);
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 8:
                foodCost = itemPriceArray[7] * item8Level;
                if (GameManager.foodResource >= foodCost)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.eatRate +=  itemEatRate[7];
                    GameManager.autoEatRate += itemAutoRate[7];
                    src.clip = sfx1;
                    src.Play();
                    item8Level++;
                    MouseOver(8);
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 9:
                foodCost = itemPriceArray[8] * item9Level;
                if (GameManager.foodResource >= foodCost)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.eatRate += itemEatRate[8];
                    GameManager.autoEatRate +=  itemAutoRate[8]; 
                    src.clip = sfx1;
                    src.Play();
                    item9Level++;
                    MouseOver(9);
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;
        }
    }
    public void MouseOver(int num)
    //this is the code we run when clicking on a Item to buy
    {
        switch (num)
        {
            case 1:
                //Math Pow will multiple the first number (10) by the next number after comma (item1level)
                _showItemBox1.SetActive(true);
                textItem1.text = "Cost = "+ Math.Pow(itemPriceArray[0],item1Level) + "\n Gain + 1 Food Per Click";
                
                break;

            case 2:
                if (GameManager.doubleHead == false)
                    //if we dont have double head display price, if we do then dont
                {
                    _showItemBox2.SetActive(true);
                    textItem2.text = "Cost = " + itemPriceArray[1] * item2Level + "\n All Clicks worth Double";
                    break;
                }
                break;

            case 3:
                _showItemBox3.SetActive(true);
                textItem3.text = "Cost = " + itemPriceArray[2] * item3Level + "\n Gain + 75 Auto Eat";
                break;

            case 4:
                _showItemBox4.SetActive(true);
                textItem4.text = "Cost = " + itemPriceArray[3] * item4level + "\n Gain + 1250 Food Per Click";
                break;

            case 5:
                _showItemBox5.SetActive(true);
                textItem5.text = "Cost = " + itemPriceArray[4] * item5level + "\n Gain + 3000 Food Per Click";
                break;

            case 6:
                _showItemBox6.SetActive(true);
                textItem6.text = "Cost = " + itemPriceArray[5] * item6Level + "\n Gain + 350 Auto Eat";
                break;

            case 7:
                if (GameManager.tripleHead == false)
                    //if we dont have triple head
                {
                    _showItemBox7.SetActive(true);
                    textItem7.text = "Cost = " + itemPriceArray[6] * item7Level + "\n All Clicks worth TRIPLE";
                    break;
                }
               
                break;

            case 8:
                _showItemBox8.SetActive(true);
                textItem8.text = "Cost = " + itemPriceArray[7] * item8Level + "\n Gain + 15000 Food Per Click";
                break;

            case 9:
                _showItemBox9.SetActive(true);
                textItem9.text = "Cost = " + itemPriceArray[8] * item9Level+ "\n Gain + 10000 Food Per Click";
                break;
        }
    }

   

    public void MouseAway(int num)
    //this is the code we run when clicking on a Item to buy
    {
        switch (num)
        {
            case 1:
                item1LVtxt.text = "Bite \n Lv" + item1Level;
                _showItemLv1Box.SetActive(true);
                _showItemBox1.SetActive(false);
                break;

            case 2:
                item2LVtxt.text = "Twin Head \n Lv" + item2Level;
                _showItemLv2Box.SetActive(true);
                _showItemBox2.SetActive(false);
                break;
                

            case 3:
                item3LVtxt.text = "InsectArmy \n Lv" + item3Level;
                _showItemLv3Box.SetActive(true);
                _showItemBox3.SetActive(false);
                break;

            case 4:
                item4LVtxt.text = "Blackhole Stomach \n Lv" + item4level;
                _showItemLv4Box.SetActive(true);
                _showItemBox4.SetActive(false);
                break;

            case 5:
                item5LVtxt.text = "Human Army \n Lv" + item5level;
                _showItemLv5Box.SetActive(true);
                _showItemBox5.SetActive(false);
                break;

            case 6:
                item6LVtxt.text = "Grabby Hands \n Lv" + item6Level;
                _showItemLv6Box.SetActive(true);
                _showItemBox6.SetActive(false);
                break;;

            case 7:
                item7LVtxt.text = "Cerberus \n Lv" + item7Level;
                _showItemLv7Box.SetActive(true);
                _showItemBox7.SetActive(false);
                break;

            case 8:
                textItem8.text = "Item8 \n Lv" + item8Level;
                _showItemBox8.SetActive(false);
                _showItemBox8.SetActive(false);
                break;

            case 9:
                textItem9.text = "Item9 \n Lv" + item9Level;
                _showItemBox9.SetActive(false);
                _showItemBox9.SetActive(false);
                break;
        }
    }
}
