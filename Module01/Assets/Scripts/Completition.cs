using UnityEngine;
using UnityEngine.SceneManagement;
public class Completition : MonoBehaviour
{
    [SerializeField] private GameObject thomasLamp;
    [SerializeField] private GameObject claireLamp;
    [SerializeField] private GameObject johnLamp;
    
    void Awake()
    {
        Debug.Log("You must enter each exit with the correct player");
    }

    // Update is called once per frame
    void Update()
    {
        if(claireLamp.activeSelf && thomasLamp.activeSelf && johnLamp.activeSelf)
        {
            if(SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            }
        }
    }
}
