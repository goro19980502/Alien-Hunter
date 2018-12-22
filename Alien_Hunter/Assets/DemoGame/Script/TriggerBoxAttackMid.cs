using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour {

    public Animator animator;
    public void OnTriggerStay(Collider Attack)
    {
        if (Attack.gameObject.tag == "Player")
        {
            animator.SetBool("AttackMid", true);
        }
    }

}
