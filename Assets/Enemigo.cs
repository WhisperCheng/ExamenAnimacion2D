using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    Animator animator;
    public bool tocando;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 origen = transform.position;
        Vector3 direccion = transform.right;

        RaycastHit2D hit = Physics2D.Raycast(origen, direccion, Mathf.Infinity);

        if (hit.collider != null)
        {
            tocando = true;
        }
        else
        {
            tocando= false;
        }
        animator.SetBool("Detectado", tocando);
    }
}
