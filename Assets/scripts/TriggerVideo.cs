using UnityEngine;
using UnityEngine.Video;
public class TriggerVideo : MonoBehaviour
{
    public GameObject VideoPanel;
    public GameObject Canvas;
    public GameObject B1;
    public GameObject B2;
    public GameObject B3;
    public GameObject S1;
    public GameObject S2;
    public VideoPlayer Video;
    public AudioSource theme;
    private bool contact = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && contact == false)
        {
            print("WORking....................");
            Canvas.SetActive(false);
            VideoPanel.SetActive(true);
            theme.Pause();
            B1.SetActive(true);
            B2.SetActive(true);
            B3.SetActive(true);
            S1.SetActive(true);
            S2.SetActive(true);
            Video.Play();

            contact = true;
        }
    }
}
