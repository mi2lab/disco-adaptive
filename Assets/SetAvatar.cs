using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetAvatar : MonoBehaviour
{
    public Button saveBtn;
    public Button spawnBtn;
    public Vector3 position;
    public bool active = false;
    private bool isDragging = false;
    private float downwardOffset = 0.9f; // Adjust this value to control how much lower the object spawns
    // private float initializedOffset = -1.2f; // The height from the floor to the avatar

    [SerializeField]
    private List<Vector3> avatarPositions;
    private List<Quaternion> avatarRots;
    private List<GameObject> activatedAvatars = new List<GameObject>();
    private int avatarNum = -1;

    void Start()
    {
        avatarPositions = new();
        avatarRots = new();

    }
    void Update()
    {
        // if (active)
        // {
        //     MoveAvatar();
        //     RotateAvatar();
        // }
    }
    public void activateAvatar()
    {
        if (active)
        {
            this.gameObject.SetActive(false);
            activatedAvatars.RemoveAt(avatarNum);
            avatarPositions.RemoveAt(avatarNum);
            avatarRots.RemoveAt(avatarNum);
            avatarNum = -1;
            active = false;

        }
        else
        {
            this.gameObject.SetActive(true);
            avatarNum = activatedAvatars.Count;
            activatedAvatars.Add(this.gameObject);
            avatarPositions.Add(this.gameObject.transform.position);
            avatarRots.Add(this.gameObject.transform.rotation);
            active = true;
        }
        return;
    }

    public void setPosition()
    {
        Debug.Log("Save button Clicked");
        position = this.gameObject.transform.position;

    }
    private void MoveAvatar()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            Vector3 controllerPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            Quaternion controllerRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
            Vector3 forwardOffset = controllerRotation * Vector3.forward * 0.05f;
            Vector3 newPosition = controllerPosition + forwardOffset;
            newPosition.y -= downwardOffset;
            // if (currentAvatarIndex == 3) // for the first avatar, enable y modify.
            // {
            //     initializedOffset = newPosition.y;
            // }
            // if (currentAvatarIndex > 3)
            // {
            //     newPosition.y = initializedOffset; // set the y axis (height from floor) fixed for avatars.
            // }
            this.gameObject.transform.position = newPosition;
        }
        else
        {
            isDragging = false;
            avatarPositions.Add(this.gameObject.transform.position); // Here add the position
            avatarRots.Add(this.gameObject.transform.rotation);
        }
    }
    private void RotateAvatar()
    {
        if (isDragging && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.LTouch))
        {
            float rotationSpeed = 200f;
            float yRotation = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch).x * rotationSpeed * Time.deltaTime;
            this.gameObject.transform.Rotate(0, yRotation, 0, Space.World);
        }
    }

    public void print()
    {
        Debug.Log("button clicked");
    }


}
