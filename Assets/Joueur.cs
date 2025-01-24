using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Joueur : MonoBehaviour
{
    private Rigidbody2D _rb;

    public float ForceSaut = 7;

    private bool _toucheSol = false;

    private Animator _animator;

    private int _argent = 0;

    internal float vitessePoids = 1F;

    public TextMeshProUGUI TextArgent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame g
    void Update()
    {
        float mouvement = Input.GetAxisRaw("Horizontal");

        _rb.linearVelocity = new Vector2(mouvement * 2 * vitessePoids, _rb.linearVelocityY);

        if (Input.GetButtonDown("Jump") && _toucheSol)
        {
            _rb.AddForce(new Vector2(0, (float)(ForceSaut * 26.5)));
        }

        _animator.SetBool("deplacement", mouvement != 0);

        // si le joueur se deplace a droite ou gauche
        if (mouvement != 0)
        {
            Vector3 localScale = transform.localScale;
            localScale.x = mouvement > 0 ? 1f : -1f;
            transform.localScale = localScale;
        }
        ;
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {

        if (collider.gameObject.CompareTag("Sol"))
        {
            _toucheSol = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collider)
    {

        if (collider.gameObject.CompareTag("Sol"))
        {
            _toucheSol = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Argent") || collider.gameObject.CompareTag("Argent-big"))
        {
            if (collider.gameObject.CompareTag("Argent-big"))
            {
                _argent += 10;
            }
            _argent += 5;
            TextArgent.text = _argent + " " + "$";

            Destroy(collider.gameObject);

        }
    }
}
