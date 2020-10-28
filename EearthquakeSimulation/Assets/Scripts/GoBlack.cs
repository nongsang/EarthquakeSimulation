using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoBlack : MonoBehaviour
{
	public GameObject Player;
    SpriteRenderer goBlack;
	public SpriteRenderer die;
    private float fade = 1.0f;
    public float time = 6.0f;

    bool black = false;

    private void Awake()
    {
		System.GC.Collect();
		goBlack = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if (black)
            Black();
    }

    void Black()
    {
        time -= 1.0f * Time.deltaTime;
		if (time > 2.0f && time < 5.5f)
			goBlack.color = new Color(0, 0, 0, fade);
		else if (time <= 2.0f)
		{
			fade -= 1.0f * Time.deltaTime;
			goBlack.color = new Color(0, 0, 0, fade);
		}
		else if (time <= 0.0f)
			time = 0.0f;
    }

	void Die()
	{
		goBlack.color = new Color(0, 0, 0, 1);
		Player.GetComponent<CharacterController>().enabled = false;
		Invoke("ShowDie", 1);
	}

    void Switch()
    {
        black = true;
    }

	void ShowDie()
	{
		die.enabled = true;
	}
}