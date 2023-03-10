using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DistanceGrab : XRBaseControllerInteractor
{
    #region member variables

    List<XRBaseInteractable> m_ValidTargets = new List<XRBaseInteractable>();
    XRBaseInteractable m_CurrentNearestObject;

    //settings
    public float m_grabbingThreshold = .8f;
    //public GameObject m_cursor;
    public Transform m_fwdVector;
    private List<XRBaseInteractable> m_grabbableItems;
    private SphereCollider m_coll;

    #endregion

   /* private new void Start()
    {
        m_cursor = Instantiate(m_cursor);
        m_cursor.SetActive(false);
    }*/
   private new void Start()
    {
        if (!m_coll)
            m_coll = gameObject.AddComponent<SphereCollider>();
        m_coll.radius = .1f;
        m_coll.isTrigger = true;
    }
    private new void Update()
    {
        //create a collider and make it a trigger
        /*if (!m_coll)
            m_coll = gameObject.AddComponent<SphereCollider>();
        m_coll.radius = .1f;
        m_coll.isTrigger = true;*/

        //deal with the cursor
        //m_cursor = Instantiate(m_cursor);
       // m_cursor.SetActive(false);

        //get a list of all the objects we could grab and cache them
        m_grabbableItems = FindObjectsOfType<XRBaseInteractable>().ToList();
    }

    //protected override List<XRBaseInteractable> ValidTargets { get { return m_ValidTargets; } }

    public override void ProcessInteractor(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractor(updatePhase);

        GetValidTargets(m_ValidTargets);
    }

    public override void GetValidTargets(List<XRBaseInteractable> validTargets)
    {
        validTargets.Clear();

        //find the best grabbable object by using a min algorithm and the dot product
        float bestGuess = 0;
        XRBaseInteractable selectable = null;
        foreach (XRBaseInteractable obj in m_grabbableItems)
        {
            Vector3 dir = (obj.transform.position - m_fwdVector.position).normalized;
            float currentGuess = Vector3.Dot(m_fwdVector.forward, dir);

            if (currentGuess > m_grabbingThreshold && currentGuess > bestGuess)
            {
                bestGuess = currentGuess;
                selectable = obj;
                m_CurrentNearestObject = selectable;
                //translate the center of the collider into world space (as it is in local space relative to the GameObject)
                m_coll.center = transform.InverseTransformPoint(selectable.transform.position);

                validTargets.Add(selectable);
            }
        }

        //if we found something, let's move our cursor to the selectable object
        if (selectable)
        {
           // m_cursor.SetActive(true);
           // m_cursor.transform.position = selectable.transform.position;
        }
        else //if not, let's disable the cursor
        {
          //  m_coll.center = Vector3.zero;
          //  m_cursor.SetActive(false);
        }
    }

    //tell the XRInteractionManager that we have an object that we can select for when the grab input is activated
    public override bool CanSelect(XRBaseInteractable interactable)
    {
        bool selectActivated = m_CurrentNearestObject == interactable || base.CanSelect(interactable);
        return selectActivated && (selectTarget == null || selectTarget == interactable);
    }
}
