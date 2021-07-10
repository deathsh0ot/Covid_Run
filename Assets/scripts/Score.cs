using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public BoiHealth boi;
    public Text score;
    // Update is called once per frame
    void Update()
    {
        score.text = boi.NumberOfMasks.ToString() + " x";
    }
}
