using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITime : MonoBehaviour
{
    public Text timeText;
    private float timer = 0f;
    private bool isPlaying = true;
    // Start is called before the first frame update
    public void OffTimer() {
        isPlaying = false;
    }
    void Start()
    {
        timeText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying)
        {
            timer += Time.deltaTime;
            timeText.text = "버틴 시간 : " + (Mathf.Floor(timer * 100) / 100) + "초";
        }
    }
}
