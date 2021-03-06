﻿using UnityEngine;

// Token: 0x02000166 RID: 358
public class PromoCameraScript : MonoBehaviour {

  // Token: 0x060006A1 RID: 1697 RVA: 0x00064520 File Offset: 0x00062920
  private void Start() {
    base.transform.eulerAngles = this.StartRotations[this.ID];
    base.transform.position = this.StartPositions[this.ID];
    this.PromoCharacter.gameObject.SetActive(false);
    this.PromoBlack.material.color = new Color(this.PromoBlack.material.color.r, this.PromoBlack.material.color.g, this.PromoBlack.material.color.b, 0f);
    this.Noose.material.color = new Color(this.Noose.material.color.r, this.Noose.material.color.g, this.Noose.material.color.b, 0f);
    this.Rope.material.color = new Color(this.Rope.material.color.r, this.Rope.material.color.g, this.Rope.material.color.b, 0f);
  }

  // Token: 0x060006A2 RID: 1698 RVA: 0x000646AC File Offset: 0x00062AAC
  private void Update() {
    if (Input.GetKeyDown(KeyCode.Space) && this.ID < 3) {
      this.ID++;
      this.UpdatePosition();
    }
    if (this.ID == 0) {
      base.transform.Translate(Vector3.back * (Time.deltaTime * 0.01f));
    } else if (this.ID == 1) {
      base.transform.Translate(Vector3.back * (Time.deltaTime * 0.01f));
    } else if (this.ID == 2) {
      base.transform.Translate(Vector3.forward * (Time.deltaTime * 0.01f));
      this.PromoCharacter.gameObject.SetActive(true);
    } else if (this.ID == 1 || this.ID == 3) {
      base.transform.Translate(Vector3.back * (Time.deltaTime * 0.1f));
    }
    this.Timer += Time.deltaTime;
    if (this.Timer > 20f) {
      this.Noose.material.color = new Color(this.Noose.material.color.r, this.Noose.material.color.g, this.Noose.material.color.b, this.Noose.material.color.a + Time.deltaTime * 0.2f);
      this.Rope.material.color = new Color(this.Rope.material.color.r, this.Rope.material.color.g, this.Rope.material.color.b, this.Rope.material.color.a + Time.deltaTime * 0.2f);
    } else if (this.Timer > 15f) {
      this.PromoBlack.material.color = new Color(this.PromoBlack.material.color.r, this.PromoBlack.material.color.g, this.PromoBlack.material.color.b, this.PromoBlack.material.color.a + Time.deltaTime * 0.2f);
    }
    if (this.Timer > 10f) {
      this.Drills.LookAt(this.Drills.position - Vector3.right);
      if (this.ID == 2) {
        this.ID = 3;
        this.UpdatePosition();
      }
    } else if (this.Timer > 5f) {
      this.PromoCharacter.EyeShrink += Time.deltaTime * 0.1f;
      if (this.ID == 1) {
        this.ID = 2;
        this.UpdatePosition();
      }
    }
  }

  // Token: 0x060006A3 RID: 1699 RVA: 0x00064A18 File Offset: 0x00062E18
  private void UpdatePosition() {
    base.transform.position = this.StartPositions[this.ID];
    base.transform.eulerAngles = this.StartRotations[this.ID];
    if (this.ID == 2) {
      this.MyCamera.farClipPlane = 3f;
      this.Timer = 5f;
    }
    if (this.ID == 3) {
      this.MyCamera.farClipPlane = 5f;
      this.Timer = 10f;
    }
  }

  // Token: 0x04001085 RID: 4229
  public PortraitChanScript PromoCharacter;

  // Token: 0x04001086 RID: 4230
  public Vector3[] StartPositions;

  // Token: 0x04001087 RID: 4231
  public Vector3[] StartRotations;

  // Token: 0x04001088 RID: 4232
  public Renderer PromoBlack;

  // Token: 0x04001089 RID: 4233
  public Renderer Noose;

  // Token: 0x0400108A RID: 4234
  public Renderer Rope;

  // Token: 0x0400108B RID: 4235
  public Camera MyCamera;

  // Token: 0x0400108C RID: 4236
  public Transform Drills;

  // Token: 0x0400108D RID: 4237
  public float Timer;

  // Token: 0x0400108E RID: 4238
  public int ID;
}