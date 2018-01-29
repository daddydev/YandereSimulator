using UnityEngine;

// Token: 0x02000159 RID: 345
public class PickpocketMinigameScript : MonoBehaviour {

  // Token: 0x0600065F RID: 1631 RVA: 0x0005BF84 File Offset: 0x0005A384
  private void Start() {
    base.transform.localScale = Vector3.zero;
    this.ButtonPrompts[1].enabled = false;
    this.ButtonPrompts[2].enabled = false;
    this.ButtonPrompts[3].enabled = false;
    this.ButtonPrompts[4].enabled = false;
    this.Circle.enabled = false;
    this.BG.enabled = false;
  }

  // Token: 0x06000660 RID: 1632 RVA: 0x0005BFF4 File Offset: 0x0005A3F4
  private void Update() {
    if (this.Show) {
      if (this.PickpocketSpot != null) {
        this.Yandere.MoveTowardsTarget(this.PickpocketSpot.position);
        this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.PickpocketSpot.rotation, Time.deltaTime * 10f);
      }
      base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.Timer += Time.deltaTime;
      if (this.Timer > 1f) {
        if (this.ButtonID == 0) {
          this.ChooseButton();
          this.Timer = 0f;
        } else {
          this.Failure = true;
          this.End();
        }
      } else if (this.ButtonID > 0) {
        this.Circle.fillAmount = 1f - this.Timer / 1f;
        if ((Input.GetButtonDown("A") && this.CurrentButton != "A") || (Input.GetButtonDown("B") && this.CurrentButton != "B") || (Input.GetButtonDown("X") && this.CurrentButton != "X") || (Input.GetButtonDown("Y") && this.CurrentButton != "Y")) {
          this.Failure = true;
          this.End();
        } else if (Input.GetButtonDown(this.CurrentButton)) {
          this.ButtonPrompts[this.ButtonID].enabled = false;
          this.Circle.enabled = false;
          this.BG.enabled = false;
          this.ButtonID = 0;
          this.Timer = 0f;
          this.Progress++;
          if (this.Progress == 5) {
            this.Yandere.CanMove = true;
            this.Success = true;
            this.End();
          }
        }
      }
    } else if (base.transform.localScale.x > 0.1f) {
      base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if (base.transform.localScale.x < 0.1f) {
        base.transform.localScale = Vector3.zero;
      }
    }
  }

  // Token: 0x06000661 RID: 1633 RVA: 0x0005C2D4 File Offset: 0x0005A6D4
  private void ChooseButton() {
    this.ButtonPrompts[1].enabled = false;
    this.ButtonPrompts[2].enabled = false;
    this.ButtonPrompts[3].enabled = false;
    this.ButtonPrompts[4].enabled = false;
    int buttonID = this.ButtonID;
    while (this.ButtonID == buttonID) {
      this.ButtonID = UnityEngine.Random.Range(1, 5);
    }
    if (this.ButtonID == 1) {
      this.CurrentButton = "A";
    } else if (this.ButtonID == 2) {
      this.CurrentButton = "B";
    } else if (this.ButtonID == 3) {
      this.CurrentButton = "X";
    } else if (this.ButtonID == 4) {
      this.CurrentButton = "Y";
    }
    this.ButtonPrompts[this.ButtonID].enabled = true;
    this.Circle.enabled = true;
    this.BG.enabled = true;
  }

  // Token: 0x06000662 RID: 1634 RVA: 0x0005C3D4 File Offset: 0x0005A7D4
  public void End() {
    this.ButtonPrompts[1].enabled = false;
    this.ButtonPrompts[2].enabled = false;
    this.ButtonPrompts[3].enabled = false;
    this.ButtonPrompts[4].enabled = false;
    this.Circle.enabled = false;
    this.BG.enabled = false;
    if (this.Failure) {
      this.Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
      this.Yandere.Caught = true;
    } else {
      this.Yandere.Pickpocketing = false;
    }
    if (this.NotNurse) {
      this.Yandere.CanMove = true;
      this.NotNurse = false;
    }
    this.Progress = 0;
    this.ButtonID = 0;
    this.Show = false;
    this.Timer = 0f;
  }

  // Token: 0x04000F7F RID: 3967
  public Transform PickpocketSpot;

  // Token: 0x04000F80 RID: 3968
  public UISprite[] ButtonPrompts;

  // Token: 0x04000F81 RID: 3969
  public UISprite Circle;

  // Token: 0x04000F82 RID: 3970
  public UISprite BG;

  // Token: 0x04000F83 RID: 3971
  public YandereScript Yandere;

  // Token: 0x04000F84 RID: 3972
  public string CurrentButton = string.Empty;

  // Token: 0x04000F85 RID: 3973
  public bool NotNurse;

  // Token: 0x04000F86 RID: 3974
  public bool Failure;

  // Token: 0x04000F87 RID: 3975
  public bool Success;

  // Token: 0x04000F88 RID: 3976
  public bool Show;

  // Token: 0x04000F89 RID: 3977
  public int ButtonID;

  // Token: 0x04000F8A RID: 3978
  public int Progress;

  // Token: 0x04000F8B RID: 3979
  public int ID;

  // Token: 0x04000F8C RID: 3980
  public float Timer;
}