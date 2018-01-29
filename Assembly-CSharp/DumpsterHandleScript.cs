﻿using UnityEngine;

// Token: 0x02000093 RID: 147
public class DumpsterHandleScript : MonoBehaviour {

  // Token: 0x06000249 RID: 585 RVA: 0x00030FE9 File Offset: 0x0002F3E9
  private void Start() {
    this.Panel.SetActive(false);
  }

  // Token: 0x0600024A RID: 586 RVA: 0x00030FF8 File Offset: 0x0002F3F8
  private void Update() {
    this.Prompt.HideButton[3] = (this.Prompt.Yandere.PickUp != null || this.Prompt.Yandere.Dragging || this.Prompt.Yandere.Carrying);
    if (this.Prompt.Circle[3].fillAmount == 0f) {
      this.Prompt.Circle[3].fillAmount = 1f;
      this.Prompt.Yandere.DumpsterGrabbing = true;
      this.Prompt.Yandere.DumpsterHandle = this;
      this.Prompt.Yandere.CanMove = false;
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[1].text = "STOP";
      this.PromptBar.Label[5].text = "PUSH / PULL";
      this.PromptBar.UpdateButtons();
      this.PromptBar.Show = true;
      this.Grabbed = true;
    }
    if (this.Grabbed) {
      this.Prompt.Yandere.transform.rotation = Quaternion.Lerp(this.Prompt.Yandere.transform.rotation, this.GrabSpot.rotation, Time.deltaTime * 10f);
      if (Vector3.Distance(this.Prompt.Yandere.transform.position, this.GrabSpot.position) > 0.1f) {
        this.Prompt.Yandere.MoveTowardsTarget(this.GrabSpot.position);
      } else {
        this.Prompt.Yandere.transform.position = this.GrabSpot.position;
      }
      if (Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("DpadX") > 0.5f) {
        base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, base.transform.parent.transform.position.z - Time.deltaTime);
      } else if (Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("DpadX") < -0.5f) {
        base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, base.transform.parent.transform.position.z + Time.deltaTime);
      }
      if (this.PullLimit < this.PushLimit) {
        if (base.transform.parent.transform.position.z < this.PullLimit) {
          base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, this.PullLimit);
        } else if (base.transform.parent.transform.position.z > this.PushLimit) {
          base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, this.PushLimit);
        }
      } else if (base.transform.parent.transform.position.z > this.PullLimit) {
        base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, this.PullLimit);
      } else if (base.transform.parent.transform.position.z < this.PushLimit) {
        base.transform.parent.transform.position = new Vector3(base.transform.parent.transform.position.x, base.transform.parent.transform.position.y, this.PushLimit);
      }
      this.Panel.SetActive(this.DumpsterLid.transform.position.z > this.DumpsterLid.DisposalSpot - 0.05f && this.DumpsterLid.transform.position.z < this.DumpsterLid.DisposalSpot + 0.05f);
      if (Input.GetButtonDown("B")) {
        this.Prompt.Yandere.DumpsterGrabbing = false;
        this.Prompt.Yandere.CanMove = true;
        this.PromptBar.ClearButtons();
        this.PromptBar.Show = false;
        this.Panel.SetActive(false);
        this.Grabbed = false;
      }
    }
  }

  // Token: 0x040007D2 RID: 2002
  public DumpsterLidScript DumpsterLid;

  // Token: 0x040007D3 RID: 2003
  public PromptBarScript PromptBar;

  // Token: 0x040007D4 RID: 2004
  public PromptScript Prompt;

  // Token: 0x040007D5 RID: 2005
  public Transform GrabSpot;

  // Token: 0x040007D6 RID: 2006
  public GameObject Panel;

  // Token: 0x040007D7 RID: 2007
  public bool Grabbed;

  // Token: 0x040007D8 RID: 2008
  public float Direction;

  // Token: 0x040007D9 RID: 2009
  public float PullLimit;

  // Token: 0x040007DA RID: 2010
  public float PushLimit;
}