using System;
using UnityEngine;

/// <summary>
/// プレイヤーを制御するクラス
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("移動する速度")] private float moveSpeed;
    
    private Animator _animator;
    private Rigidbody _rigidbody;
    private bool _isMove;
    private bool _isMoveForward;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // Wキーを押している間は前に進む
        if (Input.GetKey(KeyCode.W))
        {
            // 移動アニメーション
            _animator.SetBool("IsMoveForward", true);
            
            // 移動処理
            _isMove = true;
            _isMoveForward = true;
        }
        // Wキーを離したら静止する
        else if (Input.GetKeyUp(KeyCode.W))
        {
            // 静止アニメーション
            _animator.SetBool("IsMoveForward", false);
            
            // 移動処理
            _isMove = false;
        }
        // Sキーを押している間は後ろに進む
        if (Input.GetKey(KeyCode.S))
        {
            // 移動アニメーション
            _animator.SetBool("IsMoveBackward", true);

            // 移動処理
            _isMove = true;
            _isMoveForward = false;
        }
        // Sキーを離したら静止する
        else if (Input.GetKeyUp(KeyCode.S))
        {
            // 静止アニメーション
            _animator.SetBool("IsMoveBackward", false);
            
            // 移動処理
            _isMove = false;
        }
    }

    private void FixedUpdate()
    {
        if (_isMoveForward && _isMove) 
            _rigidbody.MovePosition(_rigidbody.position + Time.deltaTime * moveSpeed/2 * transform.forward);
        
        else if (!_isMoveForward && _isMove)
        {
            _rigidbody.MovePosition(_rigidbody.position + Time.deltaTime * -moveSpeed/2 * transform.forward);
        }
    }
}