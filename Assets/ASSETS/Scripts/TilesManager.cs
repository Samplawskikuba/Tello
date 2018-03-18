using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TilesManager : MonoBehaviour
{
    System.Random rng= new System.Random();
    public Image inGameImg;
    public Image inGameImg2;
    public List<Texture> tilesBackup;
    public List<Texture> tiles;
    Sprite[] sprites;
    Sprite[] spritesNext;
    int actualSprite=0;
    int actualSpriteNext=0;
   
    List<string> foldername = new List<string>() { "Basic"};
    private void OnEnable()
    {
        tilesBackup = new List<Texture>(tiles);
        GetNew();
       
    }

    private void GetNew()
    {
        int i = Random.Range(0, tiles.Count - 1);
        sprites = Resources.LoadAll<Sprite>("GAME/SpritesSheets/"+foldername[rng.Next(0,foldername.Count-1)]+"/" + tiles[i].name);
        tiles.RemoveAt(i);
        if (tiles.Count == 0)
            tiles = new List<Texture>(tilesBackup);

        i = Random.Range(0, tiles.Count - 1);
        spritesNext = Resources.LoadAll<Sprite>("GAME/SpritesSheets/" + foldername[rng.Next(0, foldername.Count - 1)] + "/" + tiles[i].name);
        tiles.RemoveAt(i);
        if (tiles.Count == 0)
            tiles = new List<Texture>( tilesBackup);

        actualSprite = 0;
        actualSpriteNext = 0;
        StartCoroutine(ImgAnim(inGameImg,sprites,actualSprite));
        StartCoroutine(ImgAnim(inGameImg2,spritesNext,actualSpriteNext));
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            StopAllCoroutines();
            GetNew();
            
            
        }
    }
    IEnumerator ImgAnim(Image img,Sprite[] sprites,int actualSprite)
    {
        img.sprite = sprites[actualSprite];
        yield return new WaitForSeconds(0.1f);
        if (actualSprite == sprites.Length - 1)
            actualSprite = 0;
        else
            actualSprite++;
        StartCoroutine(ImgAnim(img,sprites,actualSprite));

    }
    
}
