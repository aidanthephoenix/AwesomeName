using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class musicbutton : MonoBehaviour
{

    public Sprite sprite1;
    public GameObject img;
    public Button button;
    private void Start() {
        button.onClick.AddListener(delegate{ChangeImg();});
    }

    private void ChangeImg(){
        img.GetComponent<Image>().sprite=sprite1;
    }
}
