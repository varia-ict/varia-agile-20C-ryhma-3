using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    Animator anim;
    public bool playedAnimation;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            playedAnimation = true;
        }
            Death();
    }

    private void Death()
    {
        anim.SetBool("isDead", true);
    }
}
