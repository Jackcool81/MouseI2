using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDialogue : MonoBehaviour
{
    public GameObject panel;
    public GameObject buttons;
    public PlayerMovement player;
    //Without reference variable
    public GameObject QuestLogScript;
    public GameObject PlayerMovementScript;
    public int questID = 0;
    public string questString;
    public string acceptString;
    public string rejectString;
    public GameObject teleporter; 

    public Text panelText;

    private bool isDone;

    private void Start()
    {
        panel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" ) { 
            if (isDone == false)
            {
                print("hello");
                PlayerMovementScript.GetComponent<CharacterController2D>().canMove = false;
                PlayerMovementScript.GetComponent<CharacterController2D>().m_Rigidbody2D.velocity = new Vector2(0, 0);
                PlayerMovementScript.GetComponent<PlayerMovement>().animator.SetFloat("Speed", 0);
                panelText.text = questString;
                panel.SetActive(true);
                isDone = true;
            }
        }
        
    }

    public void AcceptQuest()
    {
        panelText.text = acceptString;
        buttons.SetActive(false);
        QuestLogScript.GetComponent<QuestLog>().UpdateQuest(questID);
        questID++;
        teleporter.GetComponent<Teleport>().canTele = true;
        StartCoroutine(ExitQuest());
    }

    public void RejectQuest()
    {
        panelText.text = rejectString;
        buttons.SetActive(false);
        StartCoroutine(ExitQuest());
    }

    private IEnumerator ExitQuest()
    {
        // Wait until left click is pressed
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        panel.SetActive(false);
        PlayerMovementScript.GetComponent<CharacterController2D>().canMove = true;

    }
}
