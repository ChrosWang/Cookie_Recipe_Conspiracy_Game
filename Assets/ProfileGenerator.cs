using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileGenerator : MonoBehaviour
{
    public Sprite[] hair_f;
    public Sprite[] hair_b;
    public Sprite[] eyes;
    public Sprite[] nose;
    public Sprite[] mouth;
    public Sprite[] face;
    public Sprite[] cloth;
    public Sprite[] eyebr;

    public Image Hair_f;
    public Image Hair_b;
    public Image Eyes;
    public Image Nose;
    public Image Mouth;
    public Image Face;
    public Image Cloth;
    public Image Bg;
    public Image Eyebr;


    public Button RandomButton;
    private void Start()
    {
        RandomRoll();
        RandomButton.onClick.AddListener(() => RandomRoll());
    }

    public void RandomRoll()
    {
        Generateface();
        Generateeyes();
        Generatenose();
        Generatemouth();
        Generatehair();
        Generatecloth();
        Generatebr();
        //Generateface();

    }

    public void ChangeColor(Image image1, Image image2)
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        //LeanTween.color(image1.gameObject, new Color(r, g, b),0);
        //LeanTween.color(image2.gameObject, new Color(r, g, b), 0);
        image1.color = new Color(r,g,b);
        image2.color = new Color(r, g, b);
    }

    public void ChangeFaceColor(Image image1)
    {
        Color c1 = new Color(0.9339623f, 0.6819687f, 0.6819687f);
        Color color2 = new Color(0.4811321f, 0.410324f, 0.410324f);
        Color c3 = new Color(0.9056604f, 0.8441141f, 0.5673193f);
        Color c4 = new Color(1f, 1f, 1f);

        Color[] race = { c1, color2, c3, c4};

        image1.color = race[Random.Range(0, 4)];
}
    public void Generateface()
    {
        int index = Random.Range(0, face.Length);
        Debug.Log("Random generated "+ index);
        Face.sprite = face[index];
        ChangeFaceColor(Face);
    }

    public void Generatehair()
    {
        int index = Random.Range(0, hair_f.Length);
        Hair_f.sprite = hair_f[index];
        Hair_b.sprite = hair_b[index];
        ChangeColor(Hair_f, Hair_b);
    }

    public void Generateeyes()
    {
        int index = Random.Range(0, eyes.Length);
        Eyes.sprite = eyes[index];
    }
    public void Generatebr()
    {
        int index = Random.Range(0, eyebr.Length);
        Eyebr.sprite = eyebr[index];
    }
    public void Generatenose()
    {
        int index = Random.Range(0, nose.Length);
        Nose.sprite = nose[index];
    }
    public void Generatemouth()
    {
        int index = Random.Range(0, mouth.Length);
        Mouth.sprite = mouth[index];
    }
    public void Generatecloth()
    {
        int index = Random.Range(0, cloth.Length);
        Cloth.sprite = cloth[index];
        ChangeColor(Cloth, Cloth);
        ChangeColor(Bg,Bg);
    }

}
