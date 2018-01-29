using UnityEngine;

// Token: 0x02000176 RID: 374
public class ReputationScript : MonoBehaviour {

  // Token: 0x060006E7 RID: 1767 RVA: 0x0006A923 File Offset: 0x00068D23
  private void Start() {
    if (MissionModeGlobals.MissionMode) {
      this.MissionMode = true;
    }
    this.Reputation = PlayerGlobals.Reputation;
    this.Bully();
  }

  // Token: 0x060006E8 RID: 1768 RVA: 0x0006A948 File Offset: 0x00068D48
  private void Update() {
    if (this.Phase == 1) {
      if (this.Clock.PresentTime / 60f > 8.5f) {
        this.Phase++;
      }
    } else if (this.Phase == 2) {
      if (this.Clock.PresentTime / 60f > 13.5f) {
        this.Phase++;
      }
    } else if (this.Phase == 3 && this.Clock.PresentTime / 60f > 18f) {
      this.Phase++;
    }
    if (this.CheckedRep < this.Phase) {
      this.UpdateRep();
      if (this.Reputation <= -100f) {
        this.Portal.EndDay();
      }
    }
    if (!this.MissionMode) {
      this.CurrentRepMarker.localPosition = new Vector3(Mathf.Lerp(this.CurrentRepMarker.localPosition.x, -830f + this.Reputation * 1.5f, Time.deltaTime * 10f), this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
      this.PendingRepMarker.localPosition = new Vector3(Mathf.Lerp(this.PendingRepMarker.localPosition.x, this.CurrentRepMarker.transform.localPosition.x + this.PendingRep * 1.5f, Time.deltaTime * 10f), this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
    } else {
      this.PendingRepMarker.localPosition = new Vector3(Mathf.Lerp(this.PendingRepMarker.localPosition.x, -980f + this.PendingRep * -3f, Time.deltaTime * 10f), this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
    }
    if (this.CurrentRepMarker.localPosition.x < -980f) {
      this.CurrentRepMarker.localPosition = new Vector3(-980f, this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
    }
    if (this.PendingRepMarker.localPosition.x < -980f) {
      this.PendingRepMarker.localPosition = new Vector3(-980f, this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
    }
    if (this.CurrentRepMarker.localPosition.x > -680f) {
      this.CurrentRepMarker.localPosition = new Vector3(-680f, this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
    }
    if (this.PendingRepMarker.localPosition.x > -680f) {
      this.PendingRepMarker.localPosition = new Vector3(-680f, this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
    }
    if (!this.MissionMode) {
      if (this.PendingRep > 0f) {
        this.PendingRepLabel.text = "+" + this.PendingRep.ToString();
      } else if (this.PendingRep < 0f) {
        this.PendingRepLabel.text = this.PendingRep.ToString();
      } else {
        this.PendingRepLabel.text = string.Empty;
      }
    } else if (this.PendingRep < 0f) {
      this.PendingRepLabel.text = (-this.PendingRep).ToString();
    } else {
      this.PendingRepLabel.text = string.Empty;
    }
  }

  // Token: 0x060006E9 RID: 1769 RVA: 0x0006ADD8 File Offset: 0x000691D8
  private void Bully() {
    int studentReputation = StudentGlobals.GetStudentReputation(7);
    this.FlowerVase.SetActive(false);
    this.Grafitti.SetActive(false);
    if (!StudentGlobals.GetStudentDead(7)) {
      if ((float)studentReputation < -33.33333f && (float)studentReputation > -66.66666f) {
        this.FlowerVase.SetActive(true);
      } else if ((float)studentReputation < -66.66666f) {
        this.Grafitti.SetActive(true);
      }
    } else {
      this.FlowerVase.SetActive(true);
    }
  }

  // Token: 0x060006EA RID: 1770 RVA: 0x0006AE61 File Offset: 0x00069261
  public void UpdateRep() {
    this.Reputation += this.PendingRep;
    this.PendingRep = 0f;
    this.CheckedRep++;
    this.StudentManager.WipePendingRep();
  }

  // Token: 0x0400115B RID: 4443
  public StudentManagerScript StudentManager;

  // Token: 0x0400115C RID: 4444
  public PortalScript Portal;

  // Token: 0x0400115D RID: 4445
  public Transform CurrentRepMarker;

  // Token: 0x0400115E RID: 4446
  public Transform PendingRepMarker;

  // Token: 0x0400115F RID: 4447
  public UILabel PendingRepLabel;

  // Token: 0x04001160 RID: 4448
  public ClockScript Clock;

  // Token: 0x04001161 RID: 4449
  public float Reputation;

  // Token: 0x04001162 RID: 4450
  public float PendingRep;

  // Token: 0x04001163 RID: 4451
  public int CheckedRep = 1;

  // Token: 0x04001164 RID: 4452
  public int Phase;

  // Token: 0x04001165 RID: 4453
  public bool MissionMode;

  // Token: 0x04001166 RID: 4454
  public GameObject FlowerVase;

  // Token: 0x04001167 RID: 4455
  public GameObject Grafitti;
}