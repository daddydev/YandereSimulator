using UnityEngine;

// Token: 0x02000094 RID: 148
public class DumpsterLidScript : MonoBehaviour {

  // Token: 0x0600024C RID: 588 RVA: 0x00031616 File Offset: 0x0002FA16
  private void Start() {
    this.FallChecker.SetActive(false);
    this.Prompt.HideButton[3] = true;
  }

  // Token: 0x0600024D RID: 589 RVA: 0x00031634 File Offset: 0x0002FA34
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Open) {
        this.Prompt.Label[0].text = "     Close";
        this.Open = true;
      } else {
        this.Prompt.Label[0].text = "     Open";
        this.Open = false;
      }
    }
    if (!this.Open) {
      this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
      this.Prompt.HideButton[3] = true;
    } else {
      this.Rotation = Mathf.Lerp(this.Rotation, -115f, Time.deltaTime * 10f);
      if (this.Corpse != null) {
        if (this.Prompt.Yandere.PickUp != null) {
          this.Prompt.HideButton[3] = !this.Prompt.Yandere.PickUp.Garbage;
        } else {
          this.Prompt.HideButton[3] = true;
        }
      } else {
        this.Prompt.HideButton[3] = true;
      }
      if (this.Prompt.Circle[3].fillAmount == 0f) {
        UnityEngine.Object.Destroy(this.Prompt.Yandere.PickUp.gameObject);
        this.Prompt.Circle[3].fillAmount = 1f;
        this.Prompt.HideButton[3] = false;
        this.Fill = true;
      }
      if (base.transform.position.z > this.DisposalSpot - 0.05f && base.transform.position.z < this.DisposalSpot + 0.05f) {
        this.FallChecker.SetActive(this.Prompt.Yandere.RoofPush);
      } else {
        this.FallChecker.SetActive(false);
      }
    }
    this.Hinge.localEulerAngles = new Vector3(this.Rotation, 0f, 0f);
    if (this.Fill) {
      this.GarbageDebris.localPosition = new Vector3(this.GarbageDebris.localPosition.x, Mathf.Lerp(this.GarbageDebris.localPosition.y, 1f, Time.deltaTime * 10f), this.GarbageDebris.localPosition.z);
      if (this.GarbageDebris.localPosition.y > 0.99f) {
        this.Prompt.Yandere.Police.SuicideScene = false;
        this.Prompt.Yandere.Police.Suicide = false;
        this.Prompt.Yandere.Police.HiddenCorpses--;
        this.Prompt.Yandere.Police.Corpses--;
        this.Prompt.Yandere.NearBodies--;
        this.GarbageDebris.localPosition = new Vector3(this.GarbageDebris.localPosition.x, 1f, this.GarbageDebris.localPosition.z);
        UnityEngine.Object.Destroy(this.Corpse);
        this.Fill = false;
      }
    }
  }

  // Token: 0x040007DB RID: 2011
  public StudentScript Victim;

  // Token: 0x040007DC RID: 2012
  public Transform GarbageDebris;

  // Token: 0x040007DD RID: 2013
  public Transform Hinge;

  // Token: 0x040007DE RID: 2014
  public GameObject FallChecker;

  // Token: 0x040007DF RID: 2015
  public GameObject Corpse;

  // Token: 0x040007E0 RID: 2016
  public PromptScript Prompt;

  // Token: 0x040007E1 RID: 2017
  public float DisposalSpot;

  // Token: 0x040007E2 RID: 2018
  public float Rotation;

  // Token: 0x040007E3 RID: 2019
  public bool Fill;

  // Token: 0x040007E4 RID: 2020
  public bool Open;
}