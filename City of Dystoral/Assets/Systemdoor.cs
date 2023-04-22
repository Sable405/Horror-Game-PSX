using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Systemdoor : MonoBehaviour
{
  public bool DoorOpen = false;
 
    public float doorOpenAngel = 95f;
    public float doorCloseAngel = 90f;
    public float OpenSmooth = 5.0f;
    public float CloseSmooth = 6.0f;
 
    public float angularx = 0f;
    public float angularz = 0f;
 
    //SOUND
//    public AudioClip sonido;
 //   public AudioClip sonido2;
   // private AudioSource sound;
 
    private bool reproducido;
    private bool reproducido2;
 
    //ACCESS
    public Transform PlayerCamera;
    public GameObject door;
    public float MaxDistance = 3f;
 
    void Start()
    {
      //  sound = GetComponent<AudioSource>();
    }
 
 
    void Update()
    {
 
        RaycastHit doorhit;
 
        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {
            if (doorhit.collider.gameObject.name == door.name)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    DoorOpen = !DoorOpen;
                    if (!reproducido)
                    {
                    //    sound.PlayOneShot(sonido);
                        reproducido = true;
                        reproducido2 = false;
 
 
                    }
 
                    else if (!reproducido2)
                    {
                     //   sound.PlayOneShot(sonido2);
                        reproducido2 = true;
                        reproducido = false;
 
 
                    }
 
                }
            }
        }
 
                if (DoorOpen)
                {
 
                    Quaternion targetRotation = Quaternion.Euler(angularx, doorOpenAngel, angularz);
                    transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, OpenSmooth * Time.deltaTime);
 
                }
 
                else
                {
 
                    Quaternion targetRotation2 = Quaternion.Euler(angularx, doorCloseAngel, angularz);
                    transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, CloseSmooth * Time.deltaTime);
 
                }
         
     
    }
}
