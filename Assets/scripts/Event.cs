using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Event : MonoBehaviour
{
    public int Id;
    public GameObject character;
    public Event ForStart;
    public Camera cam;
    bool control = false;
    public GameObject process;

    //ýnputlar
    public bool IsInfinity=true;
    public List<string> InputStrings;
    public List<string> BackupInputStrings;
    public List<double> InputValues=new List<double>();
    private int ValuesCheck;
    public int InputValueAmount;
    public GameObject SetMode;
    public TextMeshPro _tmp_Input;
    public Vector3 WhereToSet = new Vector3(0,0,0);
    public bool InputFinish=false;

    //getsler
    public bool IsGoGet = false;
    public bool AnyGets=true;
    public Vector3 WhereToGet = new Vector3(0,0,-1);
    public GameObject GetMode;
    public List<string> GetValues;

    // Start is called before the first frame update
    void Start()
    {
        character.GetComponent<movementPlayer>().canmove = false;
        character.GetComponent<movementPlayer>().StopPlayer();
        _tmp_Input.text = InputStrings.Last();
        if(InputValueAmount != 0 ) GoTo(WhereToSet);
        process.gameObject.SetActive(true);
        if (InputValueAmount > 0 || IsInfinity)
        {
            SetMode.SetActive(true);
        }
        else
        {
            GetMode.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        EventManage();
    }

    public void EventManage()
    {
        
        //string degistirme kodu
        if (_tmp_Input.gameObject.activeSelf)
        {
            if (InputValues.Count > ValuesCheck)
            {
                nextString();
                ValuesCheck = InputValues.Count;
            }
        }
        //getmode'a goturen kod
        if(GetMode.activeSelf && InputValueAmount == 0 && !IsGoGet) 
        {
            GoTo(WhereToGet);
            IsGoGet = true;
        }
        if (GetMode.activeSelf && Input.GetKeyUp(KeyCode.Space))
        {
            GoTo(WhereToGet);
            IsGoGet= true;
        }
        //yeterince input alindi mi bakan kod ve buna gore getmode'u aktif ediyo veya eventi bitiriyor. her turlu ise setmode false oluyor.
        if (InputValueAmount <= InputValues.Count && InputFinish && !process.activeSelf)
        {
            if (!GetMode.activeSelf)
            {
                if (AnyGets)
                {
                    GetMode.SetActive(true);
                }
                else
                {
                    FinishEvent();
                }
                SetMode.SetActive(false);
            }
        }
    }

    public void GoTo(Vector3 _where)
    {
        cam.transform.position = _where;
    }

    public void nextString()
    {
        if(InputStrings.Count != 1)
        InputStrings.RemoveAt(InputStrings.Count - 1);
        if (InputStrings.Any())
            _tmp_Input.text = InputStrings.Last();
    }
    public List<string> GetProcess(List<double> InputValues)
    {
        return new List<string>();
    }
    public void FinishEvent()
    {
        character.GetComponent<movementPlayer>().canmove = true;
        this.gameObject.SetActive(false);
    }

    public void ResetSetValue()
    {
        InputValues.Clear();
        SetMode.SetActive(true);
        ValuesCheck = InputValues.Count;
        InputFinish = false;
        InputStrings.Clear();
        foreach(var i in BackupInputStrings)
        {
            InputStrings.Add(i);
        }
        _tmp_Input.text = InputStrings.Last();
        SetMode.GetComponent<Set_Mode>().HowMuch = 0;
    }
}
