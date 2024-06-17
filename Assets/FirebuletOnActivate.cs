using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FirebuletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spwanPoint;
    public float fireSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBullet(ActivateEventArgs arg)
    {
        GameObject spwanBullet= Instantiate(bullet);
        spwanBullet.transform.position = spwanPoint.position;
        spwanBullet.GetComponent<Rigidbody>().velocity = spwanPoint.forward * fireSpeed;
        Destroy(spwanBullet, 5);
        spwanBullet.SetActive(true);
    }
}
