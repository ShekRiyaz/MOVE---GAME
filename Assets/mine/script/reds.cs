using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reds : MonoBehaviour
{
    public AudioSource goodred;
    public AudioSource badred;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<fallingDown>(out fallingDown item))
        {
            if (item.alignment == alignment.good)
            {
                goodred.Play();
            }
            if (item.alignment == alignment.bad)
            {
                badred.Play();  
            }
        }
    }
}
