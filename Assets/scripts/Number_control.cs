using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberControl : MonoBehaviour
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
    List<GameObject> list;
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> list = new List<GameObject>();
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

        if (number == "zero" || number == "sýfýr")
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
        else if (number == "three" || number == "üç")
        {
            three.SetActive(true);
            return 3;
        }
        else if (number == "four" || number == "dört")
        {
            four.SetActive(true);
            return 4;
        }
        else if (number == "five" || number == "beþ")
        {
            five.SetActive(true);
            return 5;
        }
        else if (number == "six" || number == "altý")
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
        else
        {
            return -1;
        }
    }
    public int selectNum(int number)
    {
        if (number == 0)
        {
            foreach (GameObject i in list)
            {
                i.SetActive(false);
            }
            zero.SetActive(true);
        }
        else if (number == 1)
        {
            foreach (GameObject i in list)
            {
                i.SetActive(false);
            }
            one.SetActive(true);
        }
        else if (number == 2)
        {
            foreach (GameObject i in list)
            {
                i.SetActive(false);
            }
            two.SetActive(true);
        }
        else if (number == 3)
        {
            foreach (GameObject i in list)
            {
                i.SetActive(false);
            }
            three.SetActive(true);
        }
        else if (number == 4)
        {
            foreach (GameObject i in list)
            {
                i.SetActive(false);
            }
            four.SetActive(true);
        }
        else if (number == 5)
        {
            foreach (GameObject i in list)
            {
                i.SetActive(false);
            }
            five.SetActive(true);
        }
        else if (number == 6)
        {
            foreach (GameObject i in list)
            {
                i.SetActive(false);
            }
            six.SetActive(true);
        }
        else if (number == 7)
        {
            foreach (GameObject i in list)
            {
                i.SetActive(false);
            }
            seven.SetActive(true);
        }
        else if (number == 8)
        {
            foreach (GameObject i in list)
            {
                i.SetActive(false);
            }
            eight.SetActive(true);
        }
        else if (number == 9)
        {
            foreach (GameObject i in list)
            {
                i.SetActive(false);
            }
            nine.SetActive(true);
        }
        else
        {
            return -1;
        }
        return number;
    }
    public int WhichAmI()
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
