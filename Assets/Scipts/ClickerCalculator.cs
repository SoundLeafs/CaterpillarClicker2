using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickerCalculator : MonoBehaviour
{
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

    //create an array with all variables for items, eg array is 9X3 so nine arrays with three objects each, will contain (Item name, price, value of mulriplier)
    //Nevermind I need them to all be int, so just price and value 9,2
    public int[] itemPriceArray = new int[9]; 



    private void Start()
    {
        item1Level= 0;
        item2Level= 0;
        item3Level= 0;
        item4level= 0;
        item51evel= 0;
        item6Level= 0;
        item7Level= 0;
        item8Level= 0;
        item9Level =0;    

    }

    public void Eating()
        //this is code applied when we click the apple
    {
        if (GameManager.doubleHead == true)

        {
            GameManager.foodResource += 2* GameManager.eatRate;
            //if we have double head then all clicks are worth double
            GameManager.totalFoodConsumed += 2 * GameManager.eatRate;
            //update the total food consumed
            

        }   
       
        else if(GameManager.tripleHead == true) 
        {
            GameManager.foodResource += 3 * GameManager.eatRate;
            //if we have triple head then all clicks are worth triple
            GameManager.totalFoodConsumed += 3 * GameManager.eatRate;
            //update the total food consumed
            
        }

        else
        {
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
                if (GameManager.foodResource > 9)
                {
                    GameManager.foodResource -= 10;
                    GameManager.eatRate += 1;
                    src.clip = sfx1;
                    src.Play();
                    item1Level++;
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
              
                break;
                
            case 2:
                if (GameManager.foodResource > 999)
                {
                    GameManager.foodResource -= 1000;
                    GameManager.eatRate +=50;
                    src.clip = sfx1;
                    src.Play();
                    item2Level++;
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 3:
                if (GameManager.foodResource > 4999)
                {
                    GameManager.foodResource -= 5000;
                    GameManager.autoEatRate += 20;
                    src.clip = sfx1;
                    src.Play();
                    item3Level++;
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 4:
                if (GameManager.foodResource > 9999)
                {
                    GameManager.foodResource -= 10000;
                    GameManager.eatRate += 25000;
                    src.clip = sfx1;
                    src.Play();
                    item4level++;
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 5:
                if (GameManager.foodResource > 9)
                {
                    GameManager.foodResource -= 10;
                    GameManager.eatRate += 2;
                    src.clip = sfx1;
                    src.Play();
                    item51evel++;
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 6:
                if (GameManager.foodResource > 9)
                {
                    GameManager.foodResource -= 10;
                    GameManager.eatRate += 2;
                    src.clip = sfx1;
                    src.Play();
                    item6Level++;
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 7:
                if (GameManager.foodResource > 9)
                {
                    GameManager.foodResource -= 10;
                    GameManager.eatRate += 2;
                    src.clip = sfx1;
                    src.Play();
                    item7Level++;
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 8:
                if (GameManager.foodResource > 9)
                {
                    GameManager.foodResource -= 10;
                    GameManager.eatRate += 2;
                    src.clip = sfx1;
                    src.Play();
                    item8Level++;
                }
                else
                {
                    src.clip = sfx2;
                    src.Play();
                }
                break;

            case 9:
                if (GameManager.foodResource > 9)
                {
                    GameManager.foodResource -= 10;
                    GameManager.eatRate += 22;
                    src.clip = sfx1;
                    src.Play();
                    item9Level++;
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
                textItem1.text = "Cost = 10";
                textItem1.text = "Gain + 1 Food Per Click";
                break;

            case 2:
                textItem2.text = "Cost = 10";
                textItem2.text = "Gain + 1 Food Per Click";
                break;

            case 3:
                textItem3.text = "Cost = 10";
                textItem3.text = "Gain + 1 Food Per Click";
                break;

            case 4:
               textItem4.text = "Cost = 10";
                textItem4.text = "Gain + 1 Food Per Click";
                break;

            case 5:
                textItem5.text = "Cost = 10";
               textItem5.text = "Gain + 1 Food Per Click";
                break;

            case 6:
                textItem6.text = "Cost = 10";
                textItem6.text = "Gain + 1 Food Per Click";
                break;

            case 7:
                textItem7.text = "Cost = 10";
                textItem7.text = "Gain + 1 Food Per Click";
                break;

            case 8:
                textItem8.text = "Cost = 10";
                textItem8.text = "Gain + 1 Food Per Click";
                break;

            case 9:
                textItem9.text = "Cost = 10";
                textItem9.text = "Gain + 1 Food Per Click";
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
