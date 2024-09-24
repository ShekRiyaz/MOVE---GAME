using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwipeMove : MonoBehaviour
{
    public AudioSource bgm2;
    public AudioSource outbgm;

    public AudioSource goodbgm;
    public AudioSource badbgm;
        
    private Vector2 startTouchPosition, endTouchPosition;

    private Touch touch;
    public int points;
    public GameObject gameOver_panel;

    [SerializeField] private float maxHeight, minHeight, minWidth, maxWidth;
    public Sprite deathFace;
    private IEnumerator goCoroutine;
    private bool coroutineAllowed;
    [SerializeField,Range(0.2f,100f)]private float speed = 4f;
    
    private void Start()
    {
        Time.timeScale = 1F;
        coroutineAllowed = true;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        }
        
        if (touch.phase == TouchPhase.Began)
        {
            startTouchPosition = touch.position;
        }

        if (Input.touchCount > 0 && touch.phase == TouchPhase.Ended && coroutineAllowed)
        { 
            endTouchPosition = touch.position;

            if ((endTouchPosition.y > startTouchPosition.y)
                && (Mathf.Abs(touch.deltaPosition.y) > Mathf.Abs(touch.deltaPosition.x)))
            {
                goCoroutine = Go(new Vector3(0f, 0.25f, 0f));
                StartCoroutine(goCoroutine);
            }

            else if ((endTouchPosition.y < startTouchPosition.y)
                && (Mathf.Abs(touch.deltaPosition.y) > Mathf.Abs(touch.deltaPosition.x))) 
            {
                goCoroutine = Go(new Vector3(0f, -0.25f, 0f)); 
                StartCoroutine(goCoroutine);
            }

            else if ((endTouchPosition.x < startTouchPosition.x)
                && (Mathf.Abs(touch.deltaPosition.x) > Mathf.Abs(touch.deltaPosition.y)))
            {
                goCoroutine = Go(new Vector3(-0.25f, 0f, 0f));
                StartCoroutine(goCoroutine);
            }

            else if ((endTouchPosition.x > startTouchPosition.x)
                && (Mathf.Abs(touch.deltaPosition.x) > Mathf.Abs(touch.deltaPosition.y)))
            {
                goCoroutine = Go(new Vector3(0.25f, 0f, 0f));
                StartCoroutine(goCoroutine);
            }
        }
    }

    private IEnumerator Go(Vector3 direction)
    {
        coroutineAllowed = false;
        direction *= speed;


        for (int i = 0; i <= 2; i++)
        {
            transform.localScale = new Vector2(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f);
            transform.Translate(direction);
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i <= 2; i++)
        {
            transform.localScale = new Vector2(transform.localScale.x + 0.2f, transform.localScale.y + 0.2f);
            transform.Translate(direction);
            yield return new WaitForSeconds(0.01f);
        }

        transform.Translate(direction);

        if (transform.position.x < minWidth) { transform.position = new Vector3(minWidth, transform.position.y, transform.position.z); }
        if (transform.position.x > maxWidth) { transform.position = new Vector3(maxWidth, transform.position.y, transform.position.z); }
        if (transform.position.y < minHeight) { transform.position = new Vector3(transform.position.x, minHeight, transform.position.z); }
        if (transform.position.y > maxHeight) { transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z); }

        coroutineAllowed = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent<fallingDown>(out fallingDown item))
        {
            if (item.alignment == alignment.good)
            {
                goodbgm.Play();
                points += 1;
                Destroy(collision.gameObject);    
            } 
            if (item.alignment == alignment.bad)
            { 
                badbgm.Play();
                bgm2.Pause();
                
                GetComponent<SpriteRenderer>().sprite = deathFace;
                Time.timeScale = 0f;
                transform.localScale = Vector3.one * 2;
                gameOver_panel.SetActive(true);
                
            }
        }
    }


    public void restart_but()
    {
        
        SceneManager.LoadScene(1);
    }
    public void exit()
    { 
        Application.Quit();
    }
}
