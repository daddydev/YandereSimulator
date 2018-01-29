using UnityEngine;

// Token: 0x02000136 RID: 310
public class MopScript : MonoBehaviour {

  // Token: 0x060005D3 RID: 1491 RVA: 0x0005059B File Offset: 0x0004E99B
  private void Start() {
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
    this.HeadCollider.enabled = false;
    this.UpdateBlood();
  }

  // Token: 0x060005D4 RID: 1492 RVA: 0x000505C4 File Offset: 0x0004E9C4
  private void Update() {
    if (this.PickUp.Clock.Period == 5) {
      this.PickUp.Suspicious = false;
    } else {
      this.PickUp.Suspicious = true;
    }
    if (!this.Prompt.PauseScreen.Show) {
      if (this.Yandere.PickUp == this.PickUp) {
        if (this.Prompt.HideButton[0]) {
          this.Prompt.HideButton[0] = false;
          this.Prompt.HideButton[3] = true;
          this.Yandere.Mop = this;
        }
        if (this.Yandere.Bucket == null) {
          if (this.Bleached) {
            this.Prompt.HideButton[0] = false;
            if (this.Prompt.Button[0].color.a > 0f) {
              this.Prompt.Label[0].text = "     Sweep";
              if (Input.GetButtonDown("A")) {
                this.Yandere.Mopping = true;
                this.HeadCollider.enabled = true;
              }
            }
          } else {
            this.Prompt.Label[0].text = "     Dip In Bucket First!";
            this.Prompt.HideButton[0] = false;
          }
        } else if (this.Prompt.Button[0].color.a > 0f) {
          if (this.Yandere.Bucket.Full) {
            if (!this.Yandere.Bucket.Gasoline) {
              if (this.Yandere.Bucket.Bleached) {
                if (this.Yandere.Bucket.Bloodiness < 100f) {
                  this.Prompt.Label[0].text = "     Dip";
                  if (Input.GetButtonDown("A")) {
                    this.Yandere.YandereVision = false;
                    this.Yandere.CanMove = false;
                    this.Yandere.Dipping = true;
                    this.Prompt.Hide();
                    this.Prompt.enabled = false;
                  }
                } else {
                  this.Prompt.Label[0].text = "     Water Too Bloody!";
                }
              } else {
                this.Prompt.Label[0].text = "     Add Bleach First!";
              }
            } else {
              this.Prompt.Label[0].text = "     Can't Use Gasoline!";
            }
          } else {
            this.Prompt.Label[0].text = "     Fill Bucket First!";
          }
        }
        if (this.Yandere.Mopping) {
          this.Head.LookAt(this.Head.position + Vector3.down);
          this.Head.localEulerAngles = new Vector3(this.Head.localEulerAngles.x + 90f, this.Head.localEulerAngles.y, 180f);
        } else {
          this.Rotation = Vector3.Lerp(this.Head.localEulerAngles, Vector3.zero, Time.deltaTime * 10f);
          this.Head.localEulerAngles = this.Rotation;
        }
      } else {
        this.Prompt.HideButton[0] = true;
        this.Prompt.HideButton[3] = false;
        if (this.Yandere.Mop == this) {
          this.Yandere.Mop = null;
        }
      }
      if (!this.Yandere.Mopping && this.HeadCollider.enabled) {
        this.HeadCollider.enabled = false;
      }
    }
  }

  // Token: 0x060005D5 RID: 1493 RVA: 0x00050998 File Offset: 0x0004ED98
  public void UpdateBlood() {
    if (this.Bloodiness > 100f) {
      this.Bloodiness = 100f;
      this.Sparkles.Stop();
      this.Bleached = false;
    }
    this.Blood.material.color = new Color(this.Blood.material.color.r, this.Blood.material.color.g, this.Blood.material.color.b, this.Bloodiness / 100f * 0.9f);
  }

  // Token: 0x04000DD8 RID: 3544
  public ParticleSystem Sparkles;

  // Token: 0x04000DD9 RID: 3545
  public YandereScript Yandere;

  // Token: 0x04000DDA RID: 3546
  public PromptScript Prompt;

  // Token: 0x04000DDB RID: 3547
  public PickUpScript PickUp;

  // Token: 0x04000DDC RID: 3548
  public Collider HeadCollider;

  // Token: 0x04000DDD RID: 3549
  public Vector3 Rotation;

  // Token: 0x04000DDE RID: 3550
  public Renderer Blood;

  // Token: 0x04000DDF RID: 3551
  public Transform Head;

  // Token: 0x04000DE0 RID: 3552
  public float Bloodiness;

  // Token: 0x04000DE1 RID: 3553
  public bool Bleached;
}