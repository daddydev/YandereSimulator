using UnityEngine;

// Token: 0x02000033 RID: 51
public class HatredScript : MonoBehaviour {

  // Token: 0x060000BB RID: 187 RVA: 0x0000CCE7 File Offset: 0x0000B0E7
  private void Start() {
    this.Character.SetActive(false);
  }

  // Token: 0x040002B5 RID: 693
  public DepthOfFieldScatter DepthOfField;

  // Token: 0x040002B6 RID: 694
  public HomeDarknessScript HomeDarkness;

  // Token: 0x040002B7 RID: 695
  public HomeCameraScript HomeCamera;

  // Token: 0x040002B8 RID: 696
  public GrayscaleEffect Grayscale;

  // Token: 0x040002B9 RID: 697
  public Bloom Bloom;

  // Token: 0x040002BA RID: 698
  public GameObject CrackPanel;

  // Token: 0x040002BB RID: 699
  public AudioSource Voiceover;

  // Token: 0x040002BC RID: 700
  public GameObject SenpaiPhoto;

  // Token: 0x040002BD RID: 701
  public GameObject RivalPhotos;

  // Token: 0x040002BE RID: 702
  public GameObject Character;

  // Token: 0x040002BF RID: 703
  public GameObject Panties;

  // Token: 0x040002C0 RID: 704
  public GameObject Yandere;

  // Token: 0x040002C1 RID: 705
  public GameObject Shrine;

  // Token: 0x040002C2 RID: 706
  public Transform AntennaeR;

  // Token: 0x040002C3 RID: 707
  public Transform AntennaeL;

  // Token: 0x040002C4 RID: 708
  public Transform Corkboard;

  // Token: 0x040002C5 RID: 709
  public UISprite CrackDarkness;

  // Token: 0x040002C6 RID: 710
  public UISprite Darkness;

  // Token: 0x040002C7 RID: 711
  public UITexture Crack;

  // Token: 0x040002C8 RID: 712
  public UITexture Logo;

  // Token: 0x040002C9 RID: 713
  public bool Begin;

  // Token: 0x040002CA RID: 714
  public float Timer;

  // Token: 0x040002CB RID: 715
  public int Phase;

  // Token: 0x040002CC RID: 716
  public Texture[] CrackTexture;
}