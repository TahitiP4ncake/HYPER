using UnityEngine;


public enum AnimationState
{
    Left,
    Right,
    Front,
    Back,
    Bonus,
    Malus
}

public class PlayerVisuals : MonoBehaviour {

    public Color32 color1;
    public Color32 color2;
    public Color32 color3;
    public Color32 color4;

    [Space]

    public GameObject playerController;

    public GameObject trail1;

    public ParticleSystem jet;

    [Space]

    Vector3 velocity = Vector3.zero;
    public float smoothTime;
    public float turnSpeed;

    [Space]
    public bool gameOn = true;

    public Animator anim;

	// Use this for initialization
	void Start () {
        JetOff();
       // SetColor(4);
    }

    public void JetOn()
    {
        
            jet.Play();
        
    }
    public void JetOff()
    {
        jet.Stop();
    }

    public void SetPlayer(GameObject _playerController, int _playerIndex)
    {
        playerController = _playerController;
        SetColor(_playerIndex);
    }

    public void PlayAnimation(AnimationState _animationState)
    {
        anim.SetTrigger(_animationState.ToString());
    }

    public void SetColor(int _playerIndex)
    {
        switch(_playerIndex)
        {
            case 0:
        
                    GetComponentInChildren<Renderer>().material.SetColor("_Player_Color", color1);
                    trail1.GetComponent<TrailRenderer>().material.SetColor("_Color", color1);
                    jet.startColor = color1;
                  
                    break;
        
            case 1:
                
                    GetComponentInChildren<Renderer>().material.SetColor("_Player_Color", color2);
                    trail1.GetComponent<TrailRenderer>().material.SetColor("_Color", color2);
                    jet.startColor = color2;

                break;
                
            case 2:
                
                    GetComponentInChildren<Renderer>().material.SetColor("_Player_Color", color3);
                    trail1.GetComponent<TrailRenderer>().material.SetColor("_Color", color3);
                jet.startColor = color3;
                break;
                
            case 3:
                
                    GetComponentInChildren<Renderer>().material.SetColor("_Player_Color", color4);
                    trail1.GetComponent<TrailRenderer>().material.SetColor("_Color", color4);
                jet.startColor = color4;
                break;
                
        }
    }

    void FixedUpdate()
    {
        if (gameOn)
        {
            /*
            transform.position = Vector3.SmoothDamp(transform.position, playerController.transform.position, ref velocity, smoothTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, playerController.transform.rotation, Time.deltaTime * turnSpeed);
            */
            transform.position = playerController.transform.position;
            transform.rotation = playerController.transform.rotation;
        }
    }
}
