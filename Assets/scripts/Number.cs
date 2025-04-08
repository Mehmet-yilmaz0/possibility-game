using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Number : MonoBehaviour
{
    public GameObject zero;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;
    public GameObject eight;
    public GameObject nine;
    public GameObject comma; 
    public GameObject Negative;
    public GameObject plus;
    public GameObject e;
    List<GameObject> list;


    // Start is called before the first frame update
    void Awake()
    {
        list = new List<GameObject>();
        list.Add(zero);
        list.Add(one);
        list.Add(two);
        list.Add(three);
        list.Add(four);
        list.Add(five);
        list.Add(six);
        list.Add(seven);
        list.Add(eight);
        list.Add(nine);
        list.Add(comma);
        list.Add(Negative);
        list.Add(plus);
        list.Add(e);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public int selectNum(string number)
    {
        foreach (GameObject i in list)
        {
            i.SetActive(false);
        }
        if (number == "zero" || number == "sýfýr" || number == "0")
        {
            zero.SetActive(true);
            return 0;
        }
        else if (number == "one" || number == "bir" || number == "1")
        {
            one.SetActive(true);
            return 1;
        }
        else if (number == "two" || number == "iki" || number == "2")
        {
            two.SetActive(true);
            return 2;
        }
        else if (number == "three" || number == "üç" || number == "3")
        {
            three.SetActive(true);
            return 3;
        }
        else if (number == "four" || number == "dört" || number == "4")
        {
            four.SetActive(true);
            return 4;
        }
        else if (number == "five" || number == "beþ" || number == "5")
        {
            five.SetActive(true);
            return 5;
        }
        else if (number == "six" || number == "altý" || number == "6")
        {
            six.SetActive(true);
            return 6;
        }
        else if (number == "seven" || number == "yedi" || number == "7")
        {
            seven.SetActive(true);
            return 7;
        }
        else if (number == "eight" || number == "sekiz" || number == "8")
        {
            eight.SetActive(true);
            return 8;
        }
        else if (number == "nine" || number == "dokuz" || number == "9")
        {
            nine.SetActive(true);
            return 9;
        }
        else if (number == "dot" || number == "comma" || number == "virgul" || number == "nokta" || number == "," || number == ".")
        {
            comma.SetActive(true);
            return 10;
        }
        else if (number == "negative" || number == "-")
        {
            Negative.SetActive(true);
            return 11;
        }
        else if(number == "plus" || number == "+")
        {
            plus.SetActive(true);
            return 12;
        }
        else if(number == "e" || number == "E")
        {
            e.SetActive(true);
            return 13;
        }
        else
        {
            return -1;
        }
    }
    public int selectNum(int number)
    {
        foreach (GameObject i in list)
        {
            i.SetActive(false);
        }
        if (number == 0)
        {
            zero.SetActive(true);
        }
        else if (number == 1)
        {
            one.SetActive(true);
        }
        else if (number == 2)
        {
            two.SetActive(true);
        }
        else if (number == 3)
        {
            three.SetActive(true);
        }
        else if (number == 4)
        {
            four.SetActive(true);
        }
        else if (number == 5)
        {
            five.SetActive(true);
        }
        else if (number == 6)
        {
            six.SetActive(true);
        }
        else if (number == 7)
        {
            seven.SetActive(true);
        }
        else if (number == 8)
        {
            eight.SetActive(true);
        }
        else if (number == 9)
        {
            nine.SetActive(true);
        }
        else
        {
            return -1;
        }
        return number;
    }
    public int WhichAmI()//rakam döndürürse sahip olduðu rakamý ifade eder 10 döndürürse virgülü.
    {
        for (int index = 0; index < list.Count; index++)
        {
            if (list[index].activeSelf)
            {
                return index;
            }
        }

        return -1;
    }
}
