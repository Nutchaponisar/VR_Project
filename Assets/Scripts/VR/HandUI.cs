using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class HandUI : MonoBehaviour
{
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject hp_bar;
    private DistanceGrab _grabable;
    void Start()
    {
         _grabable = GetComponentInChildren<DistanceGrab>();
    }

   
    void Update()
    {
        var rotation = transform.rotation.eulerAngles;

        Debug.Log(rotation);
        var xrange_hud = rotation.x > -30f && rotation.x < 30f || rotation.x > 345f && rotation.x < 360f;
        var zrange_hud = rotation.z > 75f && rotation.z < 110f;

        //Debug.Log(xrange_hud);
        //Debug.Log(zrange_hud);
        var xrange_hpbar = rotation.x > 335 && rotation.x < 360 || rotation.x > 0 && rotation.x < 15;
        var zrange_hpbar = rotation.z > 260 && rotation.z < 290;

        Debug.Log(xrange_hpbar);
        Debug.Log(zrange_hpbar);

        if (xrange_hud && zrange_hud && !_grabable.selectTarget) 
        {
            hud.SetActive(true);
        }
        else
        {
            hud.SetActive(false);
        }


        if(xrange_hpbar && zrange_hpbar)
        {
            hp_bar.SetActive(true);
        }
        else
        {
            hp_bar.SetActive(false);
        }
    }
}
