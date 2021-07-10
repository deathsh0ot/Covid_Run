using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTrigger : MonoBehaviour
{
    public GameObject QuizPanel;
    public GameObject TransitionPanel;
    public bool contact = false;
    public QuizManager Q;
    // Start is called before the first frame update
    void Start()
    {
        Q=GameObject.FindGameObjectWithTag("Managers").GetComponent<QuizManager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && contact == false)
        {
            QuizPanel.SetActive(true);
            TransitionPanel.SetActive(true);
            Q.initilaze();
            contact =true;
        }
    }
    void Update()
    {

    }
}
