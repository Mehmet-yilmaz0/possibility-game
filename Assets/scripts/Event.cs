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
    public Vector3 WhereToSet = new Vector3(0,0,0);
    public Camera cam;
    public List<string> InputStrings;
    public TextMeshPro _tmp;

    //ýnputlar
    public List<GameObject> InputText;
    public List<float> InputValues=new List<float>();
    private int ValuesCheck;
    public int InputValueAmount;
    public GameObject SetMode;

    // Start is called before the first frame update
    void Start()
    {
        character.GetComponent<movementPlayer>().canmove = false;
        character.GetComponent<movementPlayer>().StopPlayer();
        _tmp.text = InputStrings.Last();
        GoTo(WhereToSet);
        if(InputValueAmount > 0)
        {
            SetMode.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(InputValues.Count > ValuesCheck)
        {
            nextString();
            ValuesCheck = InputValues.Count;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
        }
    }

    public void GoTo(Vector3 _where)
    {
        cam.transform.position = _where;
    }

    public void nextString()
    {
        InputStrings.RemoveAt(InputStrings.Count - 1);
        if(InputStrings.Any())
            _tmp.text = InputStrings.Last();
    }
}
