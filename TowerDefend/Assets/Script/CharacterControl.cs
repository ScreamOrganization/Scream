using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour {

    public float speed;
	private GameObject WinMenu;
	private GameObject FailMenu;
	private GameObject map;
	void Start () {
		
		GameObject menu = GameObject.Find("GameCanvas");
		WinMenu = menu.transform.Find("Win").gameObject;
		FailMenu = menu.transform.Find("Fail").gameObject;
		//map = GameObject.Find("MapManager");
	}
	
	void Update () {
        MoveControl();
		if (MapManager.turretCount == 0)
		{
			WinMenu.gameObject.SetActive(true);
		}
	}

    void MoveControl()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h != 0)
        {
            //transform.localScale = new Vector3(Mathf.Sign(h)*-1, 1, 1);
            transform.position += new Vector3(Time.deltaTime * speed * Mathf.Sign(h), 0, 0);
        } 
        if (v != 0)
        {
            
            transform.position += new Vector3(0, Time.deltaTime * speed * Mathf.Sign(v), 0);
        }
    }

	void OnDestroy()
	{
		if(FailMenu!=null)
		{
			FailMenu.gameObject.SetActive(true);
		}	
	}

}
