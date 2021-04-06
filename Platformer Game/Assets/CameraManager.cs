using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 vec = transform.position;
        vec.x = player.transform.position.x;
        vec.y = player.transform.position.y;
        transform.position = vec;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CameraMove();
    }

    private void CameraMove() {
        Vector3 target = transform.position;
        target.x = player.transform.position.x;
        target.y = player.transform.position.y;
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * player.GetComponent<Player>().GetSpeed());
    }
}
