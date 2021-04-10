using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotSpeed = 200f;
    private float camRotX;
    private float camRotY;

    public float limitCamX = 80f;
    public float limitCamY = 80f;

    Vector3 offset;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        camRotX = Camera.main.transform.eulerAngles.x;
        camRotY = Camera.main.transform.eulerAngles.y;
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        camRotX += h * rotSpeed * Time.deltaTime;
        camRotY += v * rotSpeed * Time.deltaTime;

        camRotX = Mathf.Clamp(camRotX, -limitCamX, limitCamX);
        camRotY = Mathf.Clamp(camRotY, -limitCamY, limitCamY);

        transform.eulerAngles = new Vector3(-camRotY, camRotX);
        transform.position = target.position + offset;
    }
}
