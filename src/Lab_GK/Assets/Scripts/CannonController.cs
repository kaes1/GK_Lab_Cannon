using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{

    //Available cameras.
    public GameObject[] Cameras;
    private int activeCameraIndex = 0;

    //Cannonball prefab to shoot.
    public GameObject CannonballPrefab;
    //
    public float ShotPower = 8.0f;

    //Delay between shots in seconds.
    private double ShootingDelay = 0.8;
    private double ShotCooldown = 0.0;


    private Transform ShootingPoint;
    private Transform RotatePoint;
    private GameObject Barrel;

    // Start is called before the first frame update
    void Start()
    {
        ShootingPoint = GameObject.Find("ShootingPoint").transform;
        RotatePoint = GameObject.Find("RotatePoint").transform;
        Barrel = GameObject.Find("Barrel");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //rotate up
            MoveBarrelUp();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            //rotate down
            MoveBarrelDown();
        }

        if (Input.GetKey(KeyCode.A))
            TurnLeft();
        else if (Input.GetKey(KeyCode.D))
            TurnRight();


        if (Input.GetKey(KeyCode.Space))
        {
            //shoot
            ShootCannonball();
        }



        ShotCooldown -= Time.deltaTime;


        if (Input.GetKey(KeyCode.Alpha1) && activeCameraIndex != 0 && Cameras.Length > 1)
        {
            Cameras[activeCameraIndex].SetActive(false);
            activeCameraIndex = 0;
            Cameras[activeCameraIndex].SetActive(true);
        }
        else if (Input.GetKey(KeyCode.Alpha2) && activeCameraIndex != 1 && Cameras.Length > 1)
        {
            Cameras[activeCameraIndex].SetActive(false);
            activeCameraIndex = 1;
            Cameras[activeCameraIndex].SetActive(true);
        }

    }

    private void TurnLeft()
    {
        this.transform.RotateAround(this.transform.position, Vector3.up, -30 * Time.deltaTime);
    }
    private void TurnRight()
    {
        this.transform.RotateAround(this.transform.position, Vector3.up, 30 * Time.deltaTime);
    }

    private void MoveBarrelUp()
    {
        Barrel.transform.RotateAround(RotatePoint.position, Vector3.forward, 30 * Time.deltaTime);
    }

    private void MoveBarrelDown()
    {
        Barrel.transform.RotateAround(RotatePoint.position, Vector3.forward, -30 * Time.deltaTime);
    }

    private void ShootCannonball()
    {
        if (ShotCooldown < 0.0)
        {
            GameObject newCannonball = Instantiate(CannonballPrefab, ShootingPoint.position, Quaternion.identity);
            Vector3 forceVector = ShootingPoint.position - Barrel.transform.position;
            newCannonball.GetComponent<Rigidbody>().AddForce(forceVector * ShotPower, ForceMode.Impulse);
            ShotCooldown = ShootingDelay;
        }
    }
}
