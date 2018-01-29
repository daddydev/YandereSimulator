using System;
using UnityEngine;

// Token: 0x020001B7 RID: 439
public class SkinnedMeshUpdater : MonoBehaviour {

  // Token: 0x060007AA RID: 1962 RVA: 0x00075E09 File Offset: 0x00074209
  public void Start() {
    GlassesCheck();
  }

  // Token: 0x060007AB RID: 1963 RVA: 0x00075E14 File Offset: 0x00074214
  public void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      UnityEngine.Object.Instantiate<GameObject>(this.TransformEffect, this.Prompt.Yandere.Hips.position, Quaternion.identity);
      this.Prompt.Yandere.CharacterAnimation.Play(this.Prompt.Yandere.IdleAnim);
      this.Prompt.Yandere.CanMove = false;
      this.Prompt.Yandere.Egg = true;
      this.BreastR.name = "RightBreast";
      this.BreastL.name = "LeftBreast";
      this.Timer = 1f;
      this.ID++;
      if (this.ID == this.Characters.Length) {
        this.ID = 1;
      }
      this.Prompt.Yandere.Hairstyle = 120 + this.ID;
      this.Prompt.Yandere.UpdateHair();
      this.GlassesCheck();
      this.UpdateSkin();
    }
    if (this.Timer > 0f) {
      this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
      if (this.Timer == 0f) {
        this.Prompt.Yandere.CanMove = true;
      }
    }
  }

  // Token: 0x060007AC RID: 1964 RVA: 0x00075F80 File Offset: 0x00074380
  public void UpdateSkin() {
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Characters[this.ID], Vector3.zero, Quaternion.identity);
    this.TempRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
    this.UpdateMeshRenderer(this.TempRenderer);
    UnityEngine.Object.Destroy(gameObject);
    this.MyRenderer.materials[0].mainTexture = this.Bodies[this.ID];
    this.MyRenderer.materials[1].mainTexture = this.Bodies[this.ID];
    this.MyRenderer.materials[2].mainTexture = this.Faces[this.ID];
  }

  // Token: 0x060007AD RID: 1965 RVA: 0x00076028 File Offset: 0x00074428
  private void UpdateMeshRenderer(SkinnedMeshRenderer newMeshRenderer) {
    SkinnedMeshRenderer myRenderer = this.Prompt.Yandere.MyRenderer;
    myRenderer.sharedMesh = newMeshRenderer.sharedMesh;
    Transform[] componentsInChildren = this.Prompt.Yandere.transform.GetComponentsInChildren<Transform>(true);
    Transform[] array = new Transform[newMeshRenderer.bones.Length];
    int boneOrder;
    for (boneOrder = 0; boneOrder < newMeshRenderer.bones.Length; boneOrder++) {
      array[boneOrder] = Array.Find<Transform>(componentsInChildren, (Transform c) => c.name == newMeshRenderer.bones[boneOrder].name);
    }
    myRenderer.bones = array;
  }

  // Token: 0x060007AE RID: 1966 RVA: 0x000760F8 File Offset: 0x000744F8
  private void GlassesCheck() {
    this.FumiGlasses.SetActive(false);
    this.NinaGlasses.SetActive(false);
    if (this.ID == 7) {
      this.FumiGlasses.SetActive(true);
    } else if (this.ID == 8) {
      this.NinaGlasses.SetActive(true);
    }
  }

  // Token: 0x040013B1 RID: 5041
  public SkinnedMeshRenderer MyRenderer;

  // Token: 0x040013B2 RID: 5042
  public GameObject TransformEffect;

  // Token: 0x040013B3 RID: 5043
  public GameObject[] Characters;

  // Token: 0x040013B4 RID: 5044
  public PromptScript Prompt;

  // Token: 0x040013B5 RID: 5045
  public GameObject BreastR;

  // Token: 0x040013B6 RID: 5046
  public GameObject BreastL;

  // Token: 0x040013B7 RID: 5047
  public GameObject FumiGlasses;

  // Token: 0x040013B8 RID: 5048
  public GameObject NinaGlasses;

  // Token: 0x040013B9 RID: 5049
  private SkinnedMeshRenderer TempRenderer;

  // Token: 0x040013BA RID: 5050
  public Texture[] Bodies;

  // Token: 0x040013BB RID: 5051
  public Texture[] Faces;

  // Token: 0x040013BC RID: 5052
  public float Timer;

  // Token: 0x040013BD RID: 5053
  public int ID;
}