﻿using UnityEngine;

// Token: 0x0200015A RID: 346
public class PickpocketScript : MonoBehaviour {

  // Token: 0x06000664 RID: 1636 RVA: 0x0005C4BC File Offset: 0x0005A8BC
  private void Start() {
    if (this.Student.StudentID != this.Student.StudentManager.NurseID) {
      this.Prompt.transform.parent.gameObject.SetActive(false);
      base.enabled = false;
    } else {
      this.PickpocketMinigame = this.Student.StudentManager.PickpocketMinigame;
      this.ID = 2;
    }
  }

  // Token: 0x06000665 RID: 1637 RVA: 0x0005C530 File Offset: 0x0005A930
  private void Update() {
    if (this.Prompt.transform.parent != null) {
      if (this.Student.Routine) {
        if (this.Student.DistanceToDestination > 0.5f) {
          if (this.Prompt.enabled) {
            this.Prompt.Hide();
            this.Prompt.enabled = false;
            this.PickpocketPanel.enabled = false;
          }
        } else {
          this.PickpocketPanel.enabled = true;
          if (this.Student.Yandere.PickUp == null && this.Student.Yandere.Pursuer == null) {
            this.Prompt.enabled = true;
          } else {
            this.Prompt.enabled = false;
            this.Prompt.Hide();
          }
          this.Timer += Time.deltaTime;
          this.TimeBar.fillAmount = 1f - this.Timer / this.Student.CharacterAnimation[this.Student.PatrolAnim].length;
          if (this.Timer > this.Student.CharacterAnimation[this.Student.PatrolAnim].length) {
            if (this.Student.Yandere.Pickpocketing && this.PickpocketMinigame.ID == this.ID) {
              this.PickpocketMinigame.End();
              this.Punish();
            }
            this.Timer = 0f;
          }
        }
      } else if (this.Prompt.enabled) {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.PickpocketPanel.enabled = false;
        if (this.Student.Yandere.Pickpocketing && this.PickpocketMinigame.ID == this.ID) {
          this.PickpocketMinigame.End();
          this.Punish();
        }
      }
      if (this.Prompt.Circle[0].fillAmount == 0f) {
        this.PickpocketMinigame.PickpocketSpot = this.PickpocketSpot;
        this.PickpocketMinigame.Show = true;
        this.PickpocketMinigame.ID = this.ID;
        this.Student.Yandere.CharacterAnimation.CrossFade("f02_pickpocketing_00");
        this.Student.Yandere.Pickpocketing = true;
        this.Student.Yandere.EmptyHands();
        this.Student.Yandere.CanMove = false;
      }
      if (this.PickpocketMinigame != null && this.PickpocketMinigame.ID == this.ID) {
        if (this.PickpocketMinigame.Success) {
          this.PickpocketMinigame.Success = false;
          this.PickpocketMinigame.ID = 0;
          this.Succeed();
          this.Prompt.gameObject.SetActive(false);
          this.Key.SetActive(false);
        }
        if (this.PickpocketMinigame.Failure) {
          this.PickpocketMinigame.Failure = false;
          this.PickpocketMinigame.ID = 0;
          this.Punish();
        }
      }
      if (!this.Student.Alive) {
        base.transform.position = new Vector3(this.Student.transform.position.x, this.Student.transform.position.y + 1f, this.Student.transform.position.z);
        this.Prompt.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        this.Prompt.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        this.Prompt.gameObject.GetComponent<Rigidbody>().useGravity = true;
        this.Prompt.enabled = true;
        base.transform.parent = null;
      }
    } else if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Succeed();
      this.Prompt.Hide();
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x06000666 RID: 1638 RVA: 0x0005C98C File Offset: 0x0005AD8C
  private void Punish() {
    GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.Student.Yandere.transform.position + Vector3.up, Quaternion.identity);
    gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
    this.Student.Witnessed = StudentWitnessType.Theft;
    this.Student.Concern = 5;
    this.Student.SenpaiNoticed();
    this.Student.CameraEffects.MurderWitnessed();
    this.Timer = 0f;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.PickpocketPanel.enabled = false;
  }

  // Token: 0x06000667 RID: 1639 RVA: 0x0005CA38 File Offset: 0x0005AE38
  private void Succeed() {
    if (this.ID == 1) {
      this.Student.StudentManager.ShedDoor.Prompt.Label[0].text = "     Open";
      this.Student.StudentManager.ShedDoor.Locked = false;
      this.Student.ClubManager.Padlock.SetActive(false);
      this.Student.Yandere.Inventory.ShedKey = true;
    } else {
      this.Student.StudentManager.CabinetDoor.Prompt.Label[0].text = "     Open";
      this.Student.StudentManager.CabinetDoor.Locked = false;
      this.Student.Yandere.Inventory.CabinetKey = true;
    }
  }

  // Token: 0x04000F8D RID: 3981
  public PickpocketMinigameScript PickpocketMinigame;

  // Token: 0x04000F8E RID: 3982
  public StudentScript Student;

  // Token: 0x04000F8F RID: 3983
  public PromptScript Prompt;

  // Token: 0x04000F90 RID: 3984
  public UIPanel PickpocketPanel;

  // Token: 0x04000F91 RID: 3985
  public UISprite TimeBar;

  // Token: 0x04000F92 RID: 3986
  public Transform PickpocketSpot;

  // Token: 0x04000F93 RID: 3987
  public GameObject AlarmDisc;

  // Token: 0x04000F94 RID: 3988
  public GameObject Key;

  // Token: 0x04000F95 RID: 3989
  public float Timer;

  // Token: 0x04000F96 RID: 3990
  public int ID = 1;

  // Token: 0x04000F97 RID: 3991
  public bool Test;
}