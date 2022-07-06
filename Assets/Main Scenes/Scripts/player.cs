using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float movementSpeed;
    public Animator anim;
    private Rigidbody rb;
    private Vector3 endPosition = new Vector3(-2.5f, -1.3f, 0f);
    public GameObject _womenText;
    public GameObject _heroText;
    public bool _check;
    // Use this for initialization
    void Start()
    {
       // rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != endPosition)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, endPosition, movementSpeed * Time.deltaTime);
            _check = true;
        }
        if (transform.position == endPosition&& _check==true)
        {
            anim.SetBool("gotoIdle",true);
            StartCoroutine(Dialogue());
            _check = false;


        }
    }
    IEnumerator Dialogue()
    {
        _womenText.SetActive(true);
        yield return new WaitForSeconds(3);
        _womenText.SetActive(false);
        _heroText.SetActive(true);
        yield return new WaitForSeconds(3);
        _heroText.SetActive(false);
    }
}
