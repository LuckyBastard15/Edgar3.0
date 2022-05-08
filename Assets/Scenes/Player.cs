using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator _anim;
    private readonly int ahVelocidad = Animator.StringToHash("velocidad");
    private readonly int Jump = Animator.StringToHash("Jump");
    private readonly int Damaged = Animator.StringToHash("DAMAGED");
    [SerializeField] private Rigidbody Rb;

    
    void Start()
    {
        GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.FloorToInt(vertical) == 0)
        {
            Rb.velocity = transform.forward * 0;
        }

        if (Mathf.FloorToInt(vertical) == 1)
        {
            Rb.velocity = transform.forward * 2;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Rb.velocity = transform.forward * 4;
            _anim.SetInteger(ahVelocidad, Mathf.FloorToInt(vertical) * 2);
        }
        else
        {
            _anim.SetInteger(ahVelocidad, Mathf.FloorToInt(vertical));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _anim.SetTrigger(Jump);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _anim.CrossFade(Damaged, 0.2f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _anim.SetLayerWeight(1, 1f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _anim.SetLayerWeight(1, 0f);
        }
    }
}
