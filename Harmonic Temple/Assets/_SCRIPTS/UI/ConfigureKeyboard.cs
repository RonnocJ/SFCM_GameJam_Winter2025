using UnityEngine;

public class ConfigureKeyboard : MonoBehaviour, IInputScript
{
    static public float middleKey;
    public TitleSequence titleSequence;
    private float tempMiddleKey;
    private Animator anim;

    public void AddInputs()
    {
        InputManager.root.AddListener<float>(ActionTypes.KeyUp, SetMiddleC);
    }
    void Start()
    {
        GameManager.root.currentState = GameState.Config;
        middleKey = -1;
        tempMiddleKey = -1;
        anim = GetComponent<Animator>();
    }

    void SetMiddleC(float newMiddle)
    {
        if (middleKey == -1)
        {
            if (newMiddle == tempMiddleKey)
            {
                anim.SetTrigger("toTitle");
                middleKey = newMiddle;
                titleSequence.StartCoroutine(titleSequence.PlayTitleCredits());
                GameManager.root.currentState = GameState.Title;
            }
            else
            {
                anim.SetBool("confirmConfigure", false);
                tempMiddleKey = -1;
            }

            if (tempMiddleKey == -1)
            {
                anim.SetBool("confirmConfigure", true);
                tempMiddleKey = newMiddle;
            }
        }
    }
}
