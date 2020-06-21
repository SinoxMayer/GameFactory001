using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    [SerializeField]private float _moveSpeed = 1f;
    [SerializeField]private float _jumpSpeed = 2f;
    
    private Rigidbody _rigidbody;

    private bool _isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();    
    }

    private void FixedUpdate()
    {
        
    }

    private void CheckInput()
    {

        if (Input.GetKey(KeyCode.D))
        {
           Move(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
 
        
    }

    private void Move(Vector3 direction)
    {
        _rigidbody.AddForce(direction * _moveSpeed,ForceMode.Acceleration);
    }

    private void Jump()
    {

        if (!_isGrounded)
        {
            return;
        }
        _rigidbody.AddForce(Vector3.up * (_jumpSpeed ),ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        _isGrounded = false;
        bool hasCollidedWithEnemy = other.collider.GetComponent<Enemy>();
        if (hasCollidedWithEnemy)
        {
            //Mathf.Infinity  ile raycast bi objeye dokunana kadar yapabilirsiniz.
            
            if (Physics.Raycast(transform.position, Vector3.down,out  RaycastHit hit , Mathf.Infinity))
            {
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                bool isOnTopOfEnemy = enemy;

                if (isOnTopOfEnemy)
                {
                    enemy.Die();
                }
                else
                {
                    Die();
                }





                //  ? işareti if gibi kullanılıyor burada null olabilir nullsa dokunma anlamında 
                //hit.collider.GetComponent<Enemy>()?.Die();
            }
            Debug.DrawRay(transform.position, Vector3.down *0.1f, Color.blue ,3f );
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
        Collectible collectible = other.GetComponent<Collectible>();
        bool isCollectible = collectible != null;
        if (isCollectible)
        {
            collectible.Collect();
        }
    }
    
    private void Die()
    {

        StartCoroutine(ChangeScene());
        //destroy kullanırsan ienumerator çalışmıyor ondan 
        //Destroy(gameObject);
        GetComponent<MeshRenderer>().enabled = false;

    }

    private IEnumerator ChangeScene()
    {
        
        yield return  new  WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
