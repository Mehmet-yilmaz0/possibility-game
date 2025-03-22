using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    public int Id;
    
    public GameObject character;
    public Event ForStart;
    public Vector3 Where = new Vector3(0,0,0);
    public Camera cam;

    //ýnputlar
    public List<GameObject> InputText;
    public List<float> InputValues=new List<float>();
    public int InputValueAmount;
    public GameObject SetMode;


    // Start is called before the first frame update
    void Start()
    {
        character.GetComponent<movementPlayer>().canmove = false;
        character.GetComponent<movementPlayer>().StopPlayer();
        GoTo(Where);
        if(InputValueAmount > 0)
        {
            SetMode.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
