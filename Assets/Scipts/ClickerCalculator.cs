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
    public int item51evel;
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
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3;
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] private GameObject canvas;
    

    //create an array with all variables for items, eg array is 9X3 so nine arrays with three objects each, will contain (Item name, price, value of mulriplier)
    //Nevermind I need them to all be int, so just price and value 9,2
    //this array is public so can be edit in ItemPriceArray Under Game
    public int[] itemPriceArray = new int[9]; 



    private void Start()
    {
        item1Level= 1;
        item2Level= 1;
        item3Level= 1;
        item4level= 1;
        item51evel= 1;
        item6Level= 1;
        item7Level= 1;
        item8Level= 1;
        item9Level =1;    
        itemNo= 0;
        
    }

    #region Show Clicks
    void ShowClicks(string text)
        //This Method will turn clicks into floating text
    {
        if (floatingTextPrefab)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, canvas.transform);
            prefab.GetComponentInChildren<Text>().text = text;
        }
    }
    #endregion

    public void Eating()
        //this is code applied when we click the apple
    {
        if (GameManager.doubleHead == true)

        {
            ShowClicks((2*GameManager.eatRate).ToString());
            GameManager.foodResource += 2* GameManager.eatRate;
            //if we have double head then all clicks are worth double
            GameManager.totalFoodConsumed += 2 * GameManager.eatRate;
            //update the total food consumed
            

        }   
       
        else if(GameManager.tripleHead == true) 
        {
            ShowClicks((3 * GameManager.eatRate).ToString());
            GameManager.foodResource += 3 * GameManager.eatRate;
            //if we have triple head then all clicks are worth triple
            GameManager.totalFoodConsumed += 3 * GameManager.eatRate;
            //update the total food consumed
            
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
                    GameManager.eatRate += 1;
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
                if (GameManager.foodResource >= foodCost)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.eatRate +=6;
                    src.clip = sfx1;
                    src.Play();
                    item2Level++;
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
                    GameManager.autoEatRate += 35;
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
                    GameManager.eatRate += 1250;
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
                foodCost = itemPriceArray[4] * item51evel;
                if (GameManager.foodResource >= foodCost)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.eatRate += 3000;
                    src.clip = sfx1;
                    src.Play();
                    item51evel++;
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
                    GameManager.autoEatRate += 350;
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
                if (GameManager.foodResource >= foodCost)
                {
                    GameManager.foodResource -= foodCost;
                    GameManager.eatRate += 365;
                    GameManager.autoEatRate += 250;
                    src.clip = sfx1;
                    src.Play();
                    item7Level++;
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
                    GameManager.eatRate += 15000;
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
                    GameManager.autoEatRate += 10000;
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
                textItem1.text = "Cost = "+ Math.Pow(itemPriceArray[0],item1Level) + "\n Gain + 1 Food Per Click";
                
                break;

            case 2:
                textItem2.text = "Cost = " + itemPriceArray[1] * item2Level + "\n Gain + 65 Food Per Click";
                break;

            case 3:
                textItem3.text = "Cost = " + itemPriceArray[2] * item3Level + "\n Gain + 75 Auto Eat";
                break;

            case 4:
                textItem4.text = "Cost = " + itemPriceArray[3] * item4level + "\n Gain + 1250 Food Per Click";
                break;

            case 5:
                textItem5.text = "Cost = " + itemPriceArray[4] * item51evel + "\n Gain + 3000 Food Per Click";
                break;

            case 6:
                textItem6.text = "Cost = " + itemPriceArray[5] * item6Level + "\n Gain + 350 Auto Eat";
                break;

            case 7:
                textItem7.text = "Cost = " + itemPriceArray[6] * item7Level + "\n Gain + 36 Food Per Click & 250 Auto";
                break;

            case 8:
                textItem8.text = "Cost = " + itemPriceArray[7] * item8Level + "\n Gain + 15000 Food Per Click";
                break;

            case 9:
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
                textItem1.text = "Item1 \n Lv" + item1Level;
                break;

            case 2:
                textItem2.text = "Item2 \n Lv" + item2Level;
                
                break;
                

            case 3:
                textItem3.text = "Item3 \n Lv" + item3Level;
                
                break;

            case 4:
                textItem4.text = "Item4 \n Lv" + item4level;
                
                break;

            case 5:
                textItem5.text = "Item5 \n Lv" + item51evel;
              
                break;

            case 6:
                textItem6.text = "Item6 \n Lv" + item6Level;
                
                break;

            case 7:
                textItem7.text = "Item7 \n Lv" + item7Level;
                
                break;

            case 8:
                textItem8.text = "Item8 \n Lv" + item8Level;
                
                break;

            case 9:
                textItem9.text = "Item9 \n Lv" + item9Level;
                
                break;
        }
    }
}
