using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textTime;
    [SerializeField] private Score score;
    [SerializeField] private float StartTime = 180f; 
    private float timer;
    [SerializeField] Transform target;
    private bool stopcount = false;


    private void Start()
    {
        timer = StartTime;
    }
    
    private void Update()
    {
        if(stopcount == false)
        {
            timeCount();
        }
        else
        {

        }
    }

    private void timeCount()
    {
        textTime.transform.LookAt(new Vector3(target.position.x, textTime.transform.rotation.y, target.position.z));
        textTime.transform.forward *= -1;
        timer -= Time.deltaTime;
        textTime.text = $"Time : {(int)timer}";
        if (timer <= 0)
        {
            score.ShowScore();
            stopcount = true;
        }
    }
    public void getTime(float time)
    {
        timer += time;
    }
}
