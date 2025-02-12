using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UIElements;


public class NewBehaviourScript : MonoBehaviour
{
    public UnityEngine.UI.Button activeButton;
    public UnityEngine.UI.Button saveButton;
    public Vector3 position;
    public bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        // if button clicked:
        // check which avatar the button is for
        // set active to true

    }

    void activateAvatar()
    {
        if (active)
        {
            this.gameObject.SetActive(false);
            active = false;
        }
        else
        {
            this.gameObject.SetActive(true);
            active = true;
        }
        return;
    }

    void setPosition()
    {
        Debug.Log("Save button Clicked");
        position = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        activeButton.onClick.AddListener(this.activateAvatar);

        // dragging avatars;

        // if save button is clicked:
        // store position in position vector

        saveButton.onClick.AddListener(this.setPosition);
    }
}
