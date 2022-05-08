using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorIK : MonoBehaviour
{
    public Animator anim;
    public Transform ObjMirar;
    public Transform ObjMirar2;
    public Transform ManoIzq;
    private bool Ball1;
    private bool Ball2;
    private bool Tube;


    private void OnAnimatorIK(int layerIndex)
    {
        if (Ball1 == true)
        {
            anim.SetLookAtWeight(1f);
            anim.SetLookAtPosition(ObjMirar.position);
        }
        else        
        {
            anim.SetLookAtWeight(0f);
            if (Ball2 == true)
            {
                anim.SetLookAtWeight(1f);
                anim.SetLookAtPosition(ObjMirar2.position);
            }
            else
            {
                anim.SetLookAtWeight(0f);

            }
        }
        

        if (Tube == true)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
            anim.SetIKPosition(AvatarIKGoal.LeftHand, ManoIzq.position);
            anim.SetIKRotation(AvatarIKGoal.LeftHand, ManoIzq.rotation);
        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.transform.CompareTag("Ball1"))
        {
            Ball1 = true;
        }
        
        if (other.transform.CompareTag("Ball2"))
        {
            Ball2 = true;
        }
        if (other.transform.CompareTag("Tube"))
        {
            Tube = true;
        }
        

    }
    private void OnTriggerExit(Collider Other)
    {
       if(Other.transform.CompareTag("Ball1"))
        {
            Ball1 = false;
        }

        if(Other.transform.CompareTag("Ball2"))
        {
            Ball2 = false;
        }
        if (Other.transform.CompareTag("Tube"))
        {
            Tube = false;
        }
    }

}
