using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000F0 RID: 240
public class HeartbrokenCursorScript : MonoBehaviour {

  // Token: 0x060004CF RID: 1231 RVA: 0x0003E940 File Offset: 0x0003CD40
  private void Start() {
    this.Darkness.transform.localPosition = new Vector3(this.Darkness.transform.localPosition.x, this.Darkness.transform.localPosition.y, -989f);
    this.Continue.color = new Color(this.Continue.color.r, this.Continue.color.g, this.Continue.color.b, 0f);
  }

  // Token: 0x060004D0 RID: 1232 RVA: 0x0003E9E8 File Offset: 0x0003CDE8
  private void Update() {
    base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.Lerp(base.transform.localPosition.y, 255f - (float)this.Selected * 50f, Time.deltaTime * 10f), base.transform.localPosition.z);
    if (!this.FadeOut) {
      AudioSource component = base.GetComponent<AudioSource>();
      if (this.MyLabel.color.a >= 1f) {
        if (this.InputManager.TappedDown) {
          this.Selected++;
          if (this.Selected > this.Options) {
            this.Selected = 1;
          }
          component.clip = this.MoveSound;
          component.Play();
        }
        if (this.InputManager.TappedUp) {
          this.Selected--;
          if (this.Selected < 1) {
            this.Selected = this.Options;
          }
          component.clip = this.MoveSound;
          component.Play();
        }
        this.Continue.color = new Color(this.Continue.color.r, this.Continue.color.g, this.Continue.color.b, (this.Selected == 4) ? 0f : 1f);
        if (Input.GetButtonDown("A")) {
          component.clip = this.SelectSound;
          component.Play();
          this.Nudge = true;
          if (this.Selected != 4) {
            this.FadeOut = true;
          }
        }
      }
    } else {
      this.Heartbroken.GetComponent<AudioSource>().volume -= Time.deltaTime;
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, this.Darkness.color.a + Time.deltaTime);
      if (this.Darkness.color.a >= 1f) {
        if (this.Selected == 1) {
          for (int i = 0; i < this.StudentManager.NPCsTotal; i++) {
            if (StudentGlobals.GetStudentDying(i)) {
              StudentGlobals.SetStudentDying(i, false);
            }
          }
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } else if (this.Selected == 2) {
          this.LoveSick = GameGlobals.LoveSick;
          Globals.DeleteAll();
          GameGlobals.LoveSick = this.LoveSick;
          SceneManager.LoadScene("CalendarScene");
        } else if (this.Selected == 3) {
          SceneManager.LoadScene("TitleScene");
        }
      }
    }
    if (this.Nudge) {
      base.transform.localPosition = new Vector3(base.transform.localPosition.x + Time.deltaTime * 250f, base.transform.localPosition.y, base.transform.localPosition.z);
      if (base.transform.localPosition.x > -225f) {
        base.transform.localPosition = new Vector3(-225f, base.transform.localPosition.y, base.transform.localPosition.z);
        this.Nudge = false;
      }
    } else {
      base.transform.localPosition = new Vector3(base.transform.localPosition.x - Time.deltaTime * 250f, base.transform.localPosition.y, base.transform.localPosition.z);
      if (base.transform.localPosition.x < -250f) {
        base.transform.localPosition = new Vector3(-250f, base.transform.localPosition.y, base.transform.localPosition.z);
      }
    }
  }

  // Token: 0x04000AC0 RID: 2752
  public StudentManagerScript StudentManager;

  // Token: 0x04000AC1 RID: 2753
  public InputManagerScript InputManager;

  // Token: 0x04000AC2 RID: 2754
  public HeartbrokenScript Heartbroken;

  // Token: 0x04000AC3 RID: 2755
  public UISprite Darkness;

  // Token: 0x04000AC4 RID: 2756
  public UILabel Continue;

  // Token: 0x04000AC5 RID: 2757
  public UILabel MyLabel;

  // Token: 0x04000AC6 RID: 2758
  public bool LoveSick;

  // Token: 0x04000AC7 RID: 2759
  public bool FadeOut;

  // Token: 0x04000AC8 RID: 2760
  public bool Nudge;

  // Token: 0x04000AC9 RID: 2761
  public int Selected = 1;

  // Token: 0x04000ACA RID: 2762
  public int Options = 4;

  // Token: 0x04000ACB RID: 2763
  public AudioClip SelectSound;

  // Token: 0x04000ACC RID: 2764
  public AudioClip MoveSound;
}