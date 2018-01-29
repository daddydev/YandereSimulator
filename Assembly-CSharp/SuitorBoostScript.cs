using UnityEngine;

// Token: 0x020001D1 RID: 465
public class SuitorBoostScript : MonoBehaviour {

  // Token: 0x06000868 RID: 2152 RVA: 0x00093ADC File Offset: 0x00091EDC
  private void Update() {
    if (this.Yandere.Followers > 0) {
      if (this.Yandere.Follower.StudentID == 13) {
        this.Prompt.enabled = true;
      }
    } else if (this.Prompt.enabled) {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
      this.Yandere.Follower.CharacterAnimation.CrossFade(this.Yandere.Follower.IdleAnim);
      this.Yandere.Follower.Pathfinding.canSearch = false;
      this.Yandere.Follower.Pathfinding.canMove = false;
      this.Yandere.Follower.enabled = false;
      this.Yandere.RPGCamera.enabled = false;
      this.Darkness.enabled = true;
      this.Yandere.CanMove = false;
      this.Boosting = true;
      this.FadeOut = true;
    }
    if (this.Boosting) {
      if (this.FadeOut) {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
        if (this.Darkness.color.a == 1f) {
          this.Timer += Time.deltaTime;
          if (this.Timer > 1f) {
            if (this.Phase == 1) {
              Camera.main.transform.position = new Vector3(-26f, 5.3f, 17.5f);
              Camera.main.transform.eulerAngles = new Vector3(15f, 180f, 0f);
              this.Yandere.Follower.Character.transform.localScale = new Vector3(1f, 1f, 1f);
              this.YandereChair.transform.localPosition = new Vector3(this.YandereChair.transform.localPosition.x, this.YandereChair.transform.localPosition.y, -0.6f);
              this.SuitorChair.transform.localPosition = new Vector3(this.SuitorChair.transform.localPosition.x, this.SuitorChair.transform.localPosition.y, -0.6f);
              this.Yandere.Character.GetComponent<Animation>().Play("f02_sit_01");
              this.Yandere.Follower.Character.GetComponent<Animation>().Play("sit_01");
              this.Yandere.transform.eulerAngles = Vector3.zero;
              this.Yandere.Follower.transform.eulerAngles = Vector3.zero;
              this.Yandere.transform.position = this.YandereSitSpot.position;
              this.Yandere.Follower.transform.position = this.SuitorSitSpot.position;
            } else {
              this.Yandere.FixCamera();
              this.Yandere.Follower.Character.transform.localScale = new Vector3(0.94f, 0.94f, 0.94f);
              this.YandereChair.transform.localPosition = new Vector3(this.YandereChair.transform.localPosition.x, this.YandereChair.transform.localPosition.y, -0.333333343f);
              this.SuitorChair.transform.localPosition = new Vector3(this.SuitorChair.transform.localPosition.x, this.SuitorChair.transform.localPosition.y, -0.333333343f);
              this.Yandere.Character.GetComponent<Animation>().Play(this.Yandere.IdleAnim);
              this.Yandere.Follower.Character.GetComponent<Animation>().Play(this.Yandere.Follower.IdleAnim);
              this.Yandere.transform.position = this.YandereSpot.position;
              this.Yandere.Follower.transform.position = this.SuitorSpot.position;
            }
            this.PromptBar.ClearButtons();
            this.FadeOut = false;
            this.Phase++;
          }
        }
      } else {
        this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
        if (this.Darkness.color.a == 0f) {
          if (this.Phase == 2) {
            this.TextBox.gameObject.SetActive(true);
            this.TextBox.localScale = Vector3.Lerp(this.TextBox.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
            if (this.TextBox.localScale.x > 0.9f) {
              if (!this.PromptBar.Show) {
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[0].text = "Continue";
                this.PromptBar.UpdateButtons();
                this.PromptBar.Show = true;
              }
              if (Input.GetButtonDown("A")) {
                this.PromptBar.Show = false;
                this.Phase++;
              }
            }
          } else if (this.Phase == 3) {
            if (this.TextBox.localScale.x > 0.1f) {
              this.TextBox.localScale = Vector3.Lerp(this.TextBox.localScale, Vector3.zero, Time.deltaTime * 10f);
            } else {
              this.TextBox.gameObject.SetActive(false);
              this.FadeOut = true;
              this.Phase++;
            }
          } else if (this.Phase == 5) {
            DatingGlobals.SetSuitorTrait(2, DatingGlobals.GetSuitorTrait(2) + 1);
            this.Yandere.RPGCamera.enabled = true;
            this.Darkness.enabled = false;
            this.Yandere.CanMove = true;
            this.Boosting = false;
            this.Yandere.Follower.Pathfinding.canSearch = true;
            this.Yandere.Follower.Pathfinding.canMove = true;
            this.Yandere.Follower.enabled = true;
            this.Prompt.Hide();
            this.Prompt.enabled = false;
            base.enabled = false;
          }
        }
      }
    }
  }

  // Token: 0x06000869 RID: 2153 RVA: 0x000942C4 File Offset: 0x000926C4
  private void LateUpdate() {
    if (this.Boosting && this.Phase > 1 && this.Phase < 5) {
      this.Yandere.Head.LookAt(this.LookTarget);
      this.Yandere.Follower.Head.LookAt(this.LookTarget);
    }
  }

  // Token: 0x040018AF RID: 6319
  public PromptBarScript PromptBar;

  // Token: 0x040018B0 RID: 6320
  public YandereScript Yandere;

  // Token: 0x040018B1 RID: 6321
  public PromptScript Prompt;

  // Token: 0x040018B2 RID: 6322
  public UISprite Darkness;

  // Token: 0x040018B3 RID: 6323
  public Transform YandereSitSpot;

  // Token: 0x040018B4 RID: 6324
  public Transform SuitorSitSpot;

  // Token: 0x040018B5 RID: 6325
  public Transform YandereChair;

  // Token: 0x040018B6 RID: 6326
  public Transform SuitorChair;

  // Token: 0x040018B7 RID: 6327
  public Transform YandereSpot;

  // Token: 0x040018B8 RID: 6328
  public Transform SuitorSpot;

  // Token: 0x040018B9 RID: 6329
  public Transform LookTarget;

  // Token: 0x040018BA RID: 6330
  public Transform TextBox;

  // Token: 0x040018BB RID: 6331
  public bool Boosting;

  // Token: 0x040018BC RID: 6332
  public bool FadeOut;

  // Token: 0x040018BD RID: 6333
  public float Timer;

  // Token: 0x040018BE RID: 6334
  public int Phase = 1;
}