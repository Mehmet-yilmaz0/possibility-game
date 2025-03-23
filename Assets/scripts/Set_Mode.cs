using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Set_Mode : MonoBehaviour
{
    protected float Number_Background_radius = 0.16f;
    protected float Number_start_radius = 0.16f;
    public GameObject character;
    public NumberCreat NumberCreater;
    public List<GameObject> numbers;
    public string values;
    public List<GameObject> Events;
    public GameObject Act_Event;
    public KeyCode KeyCode;
    public bool CommaIsRight = true;
    public int HowMuch;

    // Start is called before the first frame update
    void Start()
    {
        //aktif olan eventi cekiyorum   
        foreach (var active in Events)
        {
            if (active.activeSelf)
            {
                Act_Event = active;
                break;
            }
        }
        NumberCreater.Create(new Vector3(Act_Event.transform.position.x, Act_Event.transform.position.y), NumberState.start);
    }

    // Update is called once per frame
    void Update()
    {
        InputNum();

    }

    private void InputNum()
    {

        int ClickedNumber = GetNumberInput();
        if (ClickedNumber != -1)
        {
            values += ClickedNumber;
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Erase(1);
        } 
        if((Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus) || Input.GetKeyDown(KeyCode.N  )) && !numbers.Any())
        {
            Vector3 dstc;
            values += "-";
            dstc = new Vector3(Act_Event.transform.position.x + Number_start_radius, Act_Event.transform.position.y);
            numbers.Add(NumberCreater.Create(dstc, "negative"));
            ScrollCam();
        }
        if (Input.GetKeyDown(KeyCode.V) && CommaIsRight)
        {
            values += ",";
            Vector3 dstc;
            CommaIsRight = false;
            if (!numbers.Any())
            {
                dstc = new Vector3(Act_Event.transform.position.x + Number_start_radius, Act_Event.transform.position.y);
                numbers.Add(NumberCreater.Create(dstc, 0));
                ScrollCam();
                numbers.Add(NumberCreater.Create(dstc = new Vector3(dstc.x + Number_Background_radius, dstc.y, dstc.z), "comma"));
                ScrollCam();

            }
            else
            {
                dstc = new Vector3(numbers.Last().GetComponent<Transform>().position.x + Number_Background_radius, Act_Event.transform.position.y);
                numbers.Add(NumberCreater.Create(dstc, "comma"));
                ScrollCam();
                numbers.Add(NumberCreater.Create(dstc = new Vector3(dstc.x + Number_Background_radius, dstc.y, dstc.z), NumberState.left));
                ScrollCam();
            }
        }
        else if (ClickedNumber != -1)
        {

            Vector3 dstc;
            if (!numbers.Any())
            {
                dstc = new Vector3(Act_Event.transform.position.x + Number_start_radius, Act_Event.transform.position.y);
                numbers.Add(NumberCreater.Create(dstc, ClickedNumber));
                ScrollCam();
                numbers.Add(NumberCreater.Create(dstc = new Vector3(dstc.x + Number_Background_radius, dstc.y, dstc.z), NumberState.left));
                ScrollCam();
            }
            else
            {
                dstc = new Vector3(numbers.Last().GetComponent<Transform>().position.x + Number_Background_radius, Act_Event.transform.position.y);
                numbers.Add(NumberCreater.Create(dstc, ClickedNumber));
                ScrollCam();
                numbers.Add(NumberCreater.Create(dstc = new Vector3(dstc.x + Number_Background_radius, dstc.y, dstc.z), NumberState.left));
                ScrollCam();
            }

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (numbers.Any())
            {
                Act_Event.GetComponent<Event>().InputValues.Add(float.Parse(values));
                values = "";
                HowMuch++;
                ResetInput();
            }
        }

    }
    int GetNumberInput()
    {
        for (KeyCode key = KeyCode.Alpha0; key <= KeyCode.Alpha9; key++)
        {
            if (Input.GetKeyDown(key))
            {
                return key - KeyCode.Alpha0; // KeyCode'dan int'e dönüþtürme
            }
        }
        return -1; // Geçerli bir sayý girilmezse
    }

    private void ResetInput()
    {
        CommaIsRight = true;
        Camera.main.transform.position = Act_Event.transform.position;
        Camera.main.transform.position += new Vector3(0, 0, -35);
        if (Act_Event.GetComponent<Event>().InputValueAmount <= HowMuch)
        {
            NumberCreater.Create(new Vector2(numbers.Last().transform.position.x + 0.16f, numbers.Last().transform.position.y), NumberState.end);
            this.gameObject.SetActive(false); //yeterince girdiyi aldýklarýnda bitiriyor.
        }
        if (numbers.Any())
        {
            if (!(Act_Event.GetComponent<Event>().InputValueAmount <= HowMuch))
                foreach (GameObject number in numbers)
                {
                    Destroy(number);
                }
            numbers.Clear();
        }
        
    }

    void ScrollCam()
    {
        Camera.main.transform.position += new Vector3(Number_Background_radius, 0f, 0f);
    }

    public void Erase(int i = 1)
    {
        if (i >= 1)
        {
            if (numbers.Any())
            {
                for (int y = i; y >= 0; y--)
                {
                    Debug.Log("asd");
                    Camera.main.transform.position -= new Vector3(0.16f, 0, 0);
                    Destroy(numbers.Last());
                    numbers.RemoveAt(numbers.Count - 1);
                }
            }
        }
    }
}
