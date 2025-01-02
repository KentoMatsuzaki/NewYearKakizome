using UnityEngine;

/// <summary>
/// プレイヤーを制御するクラス
/// </summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("移動する速度")] private float moveSpeed;
    
    private Animator _animator;
    private Rigidbody _rigidbody;
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
            _rigidbody.MovePosition(_rigidbody.position + Time.deltaTime * moveSpeed * transform.forward);
        }
        // Wキーを離したら静止する
        else if (Input.GetKeyUp(KeyCode.W))
        {
            // 静止アニメーション
            _animator.SetBool("IsMoveForward", false);
        }
        // Sキーを押している間は後ろに進む
        if (Input.GetKey(KeyCode.S))
        {
            // 移動アニメーション
            _animator.SetBool("IsMoveBackward", true);

            // 移動処理
            _rigidbody.MovePosition(_rigidbody.position + Time.deltaTime * -moveSpeed/2 * transform.forward);
        }
        // Sキーを離したら静止する
        else if (Input.GetKeyUp(KeyCode.S))
        {
            // 静止アニメーション
            _animator.SetBool("IsMoveBackward", false);
        }
    }
}