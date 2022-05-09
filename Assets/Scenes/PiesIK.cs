using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiesIK : MonoBehaviour
{
    public Vector3 offsetPies;
    public bool estaActivo;
    public Animator anim;
    public float altRodilla;
    public LayerMask rayMask;

    private void OnAnimatorIK(int layerIndex)
    {
        if (!estaActivo)
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0f);
            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0f);
            return;
        }
        else
        {
            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1f);
            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1f);

            RaycastHit hit;
            Vector3 pos = anim.GetIKPosition(AvatarIKGoal.LeftFoot);
            pos.y += altRodilla;
            Debug.DrawRay(pos, Vector3.down * 0.5f, Color.green);
            if(Physics.Raycast(pos, Vector3.down,out hit , 0.5f, rayMask))
            {
                anim.SetIKPosition(AvatarIKGoal.LeftFoot, hit.point + offsetPies);

            }
            else
            {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0f);
            }

            //PieDerecho
            pos = anim.GetIKPosition(AvatarIKGoal.RightFoot);
            pos.y += altRodilla;
            Debug.DrawRay(pos, Vector3.down * 0.5f, Color.green);
            if (Physics.Raycast(pos, Vector3.down, out hit, 0.5f, rayMask))
            {
                anim.SetIKPosition(AvatarIKGoal.RightFoot, hit.point + offsetPies);

            }
            else
            {
                anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0f);
            }
        }
    }


}
