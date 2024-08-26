using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpWalk()
    {
        _animator.SetBool("UpWalk", true);
        _animator.SetBool("DownWalk", false);
        _animator.SetBool("LeftWalk", false);
        _animator.SetBool("RightWalk", false);

    }
    public void LeftWalk()
    {
        _animator.SetBool("UpWalk", false);
        _animator.SetBool("DownWalk", false);
        _animator.SetBool("LeftWalk", true);
        _animator.SetBool("RightWalk", false);

    }
    public void RightWalk()
    {
        _animator.SetBool("UpWalk", false);
        _animator.SetBool("DownWalk", false);
        _animator.SetBool("LeftWalk", false);
        _animator.SetBool("RightWalk", true);

    }
    public void DownWalk()
    {
        _animator.SetBool("UpWalk", false);
        _animator.SetBool("DownWalk", true);
        _animator.SetBool("LeftWalk", false);
        _animator.SetBool("RightWalk", false);

    }
    public void Idle()
    {
        _animator.SetBool("UpWalk", false);
        _animator.SetBool("DownWalk", false);
        _animator.SetBool("LeftWalk", false);
        _animator.SetBool("RightWalk", false);

    }
}
