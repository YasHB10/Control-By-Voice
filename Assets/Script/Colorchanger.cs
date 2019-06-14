using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorchanger : MonoBehaviour {
    public Color colorNormal;
    public Color colorChange;
	
    // Use this for initialization
	void Start () {
        RestoreColor();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeColor() {
        gameObject.GetComponent<MeshRenderer>().material.color = colorChange;
    }

    public void RestoreColor() {
        gameObject.GetComponent<MeshRenderer>().material.color = colorNormal;
    }

    /*private void OnMouseDown()
    {
        ChangeColor();
    }

    private void OnMouseUp()
    {
        RestoreColor();
    }*/

}
