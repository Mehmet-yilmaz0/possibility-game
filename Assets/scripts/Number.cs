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
        if (number == "zero" || number == "s�f�r")
        {
            zero.SetActive(true);
            return 0;
        }
        else if (number == "one" || number == "bir")
        {
            one.SetActive(true);
            return 1;
        }
        else if (number == "two" || number == "iki")
        {
            two.SetActive(true);
            return 2;
        }
        else if (number == "three" || number == "��")
        {
            three.SetActive(true);
            return 3;
        }
        else if (number == "four" || number == "d�rt")
        {
            four.SetActive(true);
            return 4;
        }
        else if (number == "five" || number == "be�")
        {
            five.SetActive(true);
            return 5;
        }
        else if (number == "six" || number == "alt�")
        {
            six.SetActive(true);
            return 6;
        }
        else if (number == "seven" || number == "yedi")
        {
            seven.SetActive(true);
            return 7;
        }
        else if (number == "eight" || number == "sekiz")
        {
            eight.SetActive(true);
            return 8;
        }
        else if (number == "nine" || number == "dokuz")
        {
            nine.SetActive(true);
            return 9;
        }
        else if (number == "dot" || number == "comma" || number == "virgul" || number == "nokta")
        {
            comma.SetActive(true);
            return 0;
        }
        else if (number == "negative" || number == "-")
        {
            Negative.SetActive(true);
            return 0;
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
    public int WhichAmI()//rakam d�nd�r�rse sahip oldu�u rakam� ifade eder 10 d�nd�r�rse virg�l�.
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
