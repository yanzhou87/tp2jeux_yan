

using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    private static ScoreManager _instance;
    public GameObject text;

    public static ScoreManager Instance { get { return _instance; } }

    private int score = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            SceneManager.LoadScene("MenuScene");
       
        if (score == 4) 
        {
            Instantiate(text, new Vector3(0f, 0f, 0f), transform.rotation);
           
        }

    }

    public void AddScore(int inc = 1)
    {
        score += inc;
        Debug.Log($"Score: {score} (+{inc})"); // Equivalent a Debug.Log("Score: " + score + "(+" + inc + ")");
    }

    //TODO Arreter la partie quand il n'y a plus d'asteroides.
}
