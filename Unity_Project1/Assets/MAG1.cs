using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MAG1 : MonoBehaviour
{
    public Animator MAG;
    public TextMeshProUGUI text;
    public string[] replics = new string[5];
    public GameObject cristal1;
    public GameObject cristal2;
    public float Answer_time = 2;
    private bool answer_end = false;
    private void Start()
    {
        cristal1.SetActive(false);
        cristal2.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            MAG.SetBool("New Bool", true);
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        for (int i = 0; i < replics.Length; i++)
        {
            
            text.text = replics[i];
            if (i == 3)
            {
                StartCoroutine(Choice());

            }
            if (i == 4) {
                cristal1.SetActive(true);
            }
            yield return new WaitForSeconds(2);
        }
    }
    IEnumerator Choice() {
        while (answer_end == false)
        {
            if (Input.GetKey(KeyCode.Alpha2))
            {
                answer_end = true;
            }
            if (Input.GetKey(KeyCode.Alpha1))
            {
                SceneManager.LoadScene(3);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}

