using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounceWithRigid : MonoBehaviour
{
    Rigidbody Rigid;
    public float jumpPadPower = 8;
    // Start is called before the first frame update
    void Start()
    {
        Rigid = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Jump Pad"))
        {
            Rigid.AddForce(Vector3.up * jumpPadPower, ForceMode.Impulse);
        }
    }
    public void removeContraint()
    {
        Rigid.constraints = RigidbodyConstraints.None;
    }
}
