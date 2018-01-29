using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000211 RID: 529
public class WalkToSchoolManagerScript : MonoBehaviour {

  // Token: 0x06000937 RID: 2359 RVA: 0x0009F1E0 File Offset: 0x0009D5E0
  private void Start() {
    if (SchoolGlobals.SchoolAtmosphere < 0.5f || GameGlobals.LoveSick) {
      this.Darkness.color = new Color(0f, 0f, 0f, 1f);
    } else {
      this.Darkness.color = new Color(1f, 1f, 1f, 1f);
    }
    this.Window.localScale = new Vector3(0f, 0f, 0f);
    this.Yandere.Character.GetComponent<Animation>()["f02_newWalk_00"].time = UnityEngine.Random.Range(0f, this.Yandere.Character.GetComponent<Animation>()["f02_newWalk_00"].length);
    this.Yandere.WearOutdoorShoes();
    this.Senpai.WearOutdoorShoes();
    this.Rival.WearOutdoorShoes();
  }

  // Token: 0x06000938 RID: 2360 RVA: 0x0009F2DC File Offset: 0x0009D6DC
  private void Update() {
    for (int i = 1; i < 3; i++) {
      Transform transform = this.Neighborhood[i];
      transform.position = new Vector3(transform.position.x - Time.deltaTime * this.ScrollSpeed, transform.position.y, transform.position.z);
      if (transform.position.x < -160f) {
        transform.position = new Vector3(transform.position.x + 320f, transform.position.y, transform.position.z);
      }
    }
    if (!this.FadeOut) {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
      if (this.Darkness.color.a == 0f) {
        if (!this.ShowWindow) {
          if (!this.Ending) {
            this.Timer += Time.deltaTime;
            if (this.Timer > 1f) {
              this.RivalEyeRTarget = this.RivalEyeR.localEulerAngles.y;
              this.RivalEyeLTarget = this.RivalEyeL.localEulerAngles.y;
              this.SenpaiEyeRTarget = this.SenpaiEyeR.localEulerAngles.y;
              this.SenpaiEyeLTarget = this.SenpaiEyeL.localEulerAngles.y;
              this.ShowWindow = true;
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "Continue";
              this.PromptBar.Label[2].text = "Skip";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
            }
          } else {
            this.Window.localScale = Vector3.Lerp(this.Window.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
            if ((double)this.Window.localScale.x < 0.01) {
              this.Timer += Time.deltaTime;
              if (this.Timer > 1f) {
                this.FadeOut = true;
              }
            }
          }
        } else {
          this.Window.localScale = Vector3.Lerp(this.Window.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
          this.Typewriter.mLabel.color = new Color(1f, 1f, 1f, 1f);
          if (!this.Talk) {
            if ((double)this.Window.localScale.x > 0.99) {
              this.Talk = true;
              this.UpdateNameLabel();
              this.Typewriter.ResetToBeginning();
              this.Typewriter.mLabel.text = this.Lines[this.ID];
              this.Typewriter.mLabel.color = new Color(1f, 1f, 1f, 0f);
              base.GetComponent<AudioSource>().clip = this.Speech[this.ID];
              base.GetComponent<AudioSource>().Play();
            }
          } else {
            if (Input.GetButtonDown("A")) {
              if (this.ID < this.Lines.Length - 1) {
                if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length) {
                  this.Typewriter.Finish();
                } else {
                  this.ID++;
                  this.Typewriter.ResetToBeginning();
                  this.Typewriter.mLabel.text = this.Lines[this.ID];
                  this.Typewriter.mLabel.color = new Color(1f, 1f, 1f, 0f);
                  base.GetComponent<AudioSource>().clip = this.Speech[this.ID];
                  base.GetComponent<AudioSource>().Play();
                  this.UpdateNameLabel();
                }
              } else if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length) {
                this.Typewriter.Finish();
              } else {
                this.End();
              }
            }
            if (Input.GetButtonDown("X")) {
              this.End();
            }
          }
        }
      }
    } else {
      base.GetComponent<AudioSource>().volume -= Time.deltaTime;
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      if (this.Darkness.color.a == 1f && !this.Debugging) {
        SceneManager.LoadScene("LoadingScene");
      }
    }
    if (Input.GetKeyDown(KeyCode.Equals)) {
      Time.timeScale += 10f;
    }
    if (Input.GetKeyDown(KeyCode.Minus)) {
      Time.timeScale -= 10f;
    }
  }

  // Token: 0x06000939 RID: 2361 RVA: 0x0009F8F8 File Offset: 0x0009DCF8
  private void LateUpdate() {
    if (this.Talk) {
      if (!this.Ending) {
        this.RivalNeckTarget = Mathf.Lerp(this.RivalNeckTarget, 15f, Time.deltaTime * 3.6f);
        this.RivalHeadTarget = Mathf.Lerp(this.RivalHeadTarget, 15f, Time.deltaTime * 3.6f);
        this.RivalEyeRTarget = Mathf.Lerp(this.RivalEyeRTarget, 95f, Time.deltaTime * 3.6f);
        this.RivalEyeLTarget = Mathf.Lerp(this.RivalEyeLTarget, 275f, Time.deltaTime * 3.6f);
        this.SenpaiNeckTarget = Mathf.Lerp(this.SenpaiNeckTarget, -15f, Time.deltaTime * 3.6f);
        this.SenpaiHeadTarget = Mathf.Lerp(this.SenpaiHeadTarget, -15f, Time.deltaTime * 3.6f);
        this.SenpaiEyeRTarget = Mathf.Lerp(this.SenpaiEyeRTarget, 85f, Time.deltaTime * 3.6f);
        this.SenpaiEyeLTarget = Mathf.Lerp(this.SenpaiEyeLTarget, 265f, Time.deltaTime * 3.6f);
        this.YandereNeckTarget = Mathf.Lerp(this.YandereNeckTarget, 7.5f, Time.deltaTime * 3.6f);
        this.YandereHeadTarget = Mathf.Lerp(this.YandereHeadTarget, 7.5f, Time.deltaTime * 3.6f);
      } else {
        this.RivalNeckTarget = Mathf.Lerp(this.RivalNeckTarget, 0f, Time.deltaTime * 3.6f);
        this.RivalHeadTarget = Mathf.Lerp(this.RivalHeadTarget, 0f, Time.deltaTime * 3.6f);
        this.RivalEyeRTarget = Mathf.Lerp(this.RivalEyeRTarget, 90f, Time.deltaTime * 3.6f);
        this.RivalEyeLTarget = Mathf.Lerp(this.RivalEyeLTarget, 270f, Time.deltaTime * 3.6f);
        this.SenpaiNeckTarget = Mathf.Lerp(this.SenpaiNeckTarget, 0f, Time.deltaTime * 3.6f);
        this.SenpaiHeadTarget = Mathf.Lerp(this.SenpaiHeadTarget, 0f, Time.deltaTime * 3.6f);
        this.SenpaiEyeRTarget = Mathf.Lerp(this.SenpaiEyeRTarget, 90f, Time.deltaTime * 3.6f);
        this.SenpaiEyeLTarget = Mathf.Lerp(this.SenpaiEyeLTarget, 270f, Time.deltaTime * 3.6f);
        this.YandereNeckTarget = Mathf.Lerp(this.YandereNeckTarget, 0f, Time.deltaTime * 3.6f);
        this.YandereHeadTarget = Mathf.Lerp(this.YandereHeadTarget, 0f, Time.deltaTime * 3.6f);
      }
      this.RivalNeck.localEulerAngles = new Vector3(this.RivalNeck.localEulerAngles.x, this.RivalNeckTarget, this.RivalNeck.localEulerAngles.z);
      this.RivalHead.localEulerAngles = new Vector3(this.RivalHead.localEulerAngles.x, this.RivalHeadTarget, this.RivalHead.localEulerAngles.z);
      this.RivalEyeR.localEulerAngles = new Vector3(this.RivalEyeR.localEulerAngles.x, this.RivalEyeRTarget, this.RivalEyeR.localEulerAngles.z);
      this.RivalEyeL.localEulerAngles = new Vector3(this.RivalEyeL.localEulerAngles.x, this.RivalEyeLTarget, this.RivalEyeL.localEulerAngles.z);
      this.SenpaiNeck.localEulerAngles = new Vector3(this.SenpaiNeck.localEulerAngles.x, this.SenpaiNeckTarget, this.SenpaiNeck.localEulerAngles.z);
      this.SenpaiHead.localEulerAngles = new Vector3(this.SenpaiHead.localEulerAngles.x, this.SenpaiHeadTarget, this.SenpaiHead.localEulerAngles.z);
      this.SenpaiEyeR.localEulerAngles = new Vector3(this.SenpaiEyeR.localEulerAngles.x, this.SenpaiEyeRTarget, this.SenpaiEyeR.localEulerAngles.z);
      this.SenpaiEyeL.localEulerAngles = new Vector3(this.SenpaiEyeL.localEulerAngles.x, this.SenpaiEyeLTarget, this.SenpaiEyeL.localEulerAngles.z);
      this.YandereNeck.localEulerAngles = new Vector3(this.YandereNeck.localEulerAngles.x, this.YandereNeckTarget, this.YandereNeck.localEulerAngles.z);
      this.YandereHead.localEulerAngles = new Vector3(this.YandereHead.localEulerAngles.x, this.YandereHeadTarget, this.YandereHead.localEulerAngles.z);
      if (base.GetComponent<AudioSource>().isPlaying) {
        this.MouthTimer += Time.deltaTime;
        if (this.MouthTimer > this.TimerLimit) {
          this.MouthTarget = UnityEngine.Random.Range(40f, 40f + this.MouthExtent);
          this.MouthTimer = 0f;
        }
        if (this.Speakers[this.ID]) {
          this.RivalJaw.localEulerAngles = new Vector3(this.RivalJaw.localEulerAngles.x, this.RivalJaw.localEulerAngles.y, Mathf.Lerp(this.RivalJaw.localEulerAngles.z, this.MouthTarget, Time.deltaTime * this.TalkSpeed));
          this.RivalLipL.localPosition = new Vector3(this.RivalLipL.localPosition.x, Mathf.Lerp(this.RivalLipL.localPosition.y, 0.02632812f + this.MouthTarget * this.LipStrength, Time.deltaTime * this.TalkSpeed), this.RivalLipL.localPosition.z);
          this.RivalLipR.localPosition = new Vector3(this.RivalLipR.localPosition.x, Mathf.Lerp(this.RivalLipR.localPosition.y, 0.02632812f + this.MouthTarget * this.LipStrength, Time.deltaTime * this.TalkSpeed), this.RivalLipR.localPosition.z);
        } else {
          this.SenpaiJaw.localEulerAngles = new Vector3(this.SenpaiJaw.localEulerAngles.x, this.SenpaiJaw.localEulerAngles.y, Mathf.Lerp(this.SenpaiJaw.localEulerAngles.z, this.MouthTarget, Time.deltaTime * this.TalkSpeed));
          this.SenpaiLipL.localPosition = new Vector3(this.SenpaiLipL.localPosition.x, Mathf.Lerp(this.SenpaiLipL.localPosition.y, 0.02632812f + this.MouthTarget * this.LipStrength, Time.deltaTime * this.TalkSpeed), this.SenpaiLipL.localPosition.z);
          this.SenpaiLipR.localPosition = new Vector3(this.SenpaiLipR.localPosition.x, Mathf.Lerp(this.SenpaiLipR.localPosition.y, 0.02632812f + this.MouthTarget * this.LipStrength, Time.deltaTime * this.TalkSpeed), this.SenpaiLipR.localPosition.z);
        }
      }
    }
  }

  // Token: 0x0600093A RID: 2362 RVA: 0x000A0113 File Offset: 0x0009E513
  public void UpdateNameLabel() {
    if (this.Speakers[this.ID]) {
      this.NameLabel.text = "Osana-chan";
    } else {
      this.NameLabel.text = "Senpai-kun";
    }
  }

  // Token: 0x0600093B RID: 2363 RVA: 0x000A014C File Offset: 0x0009E54C
  public void End() {
    this.PromptBar.Show = false;
    this.ShowWindow = false;
    this.Ending = true;
    this.Timer = 0f;
  }

  // Token: 0x04001A24 RID: 6692
  public PromptBarScript PromptBar;

  // Token: 0x04001A25 RID: 6693
  public CosmeticScript Yandere;

  // Token: 0x04001A26 RID: 6694
  public CosmeticScript Senpai;

  // Token: 0x04001A27 RID: 6695
  public CosmeticScript Rival;

  // Token: 0x04001A28 RID: 6696
  public UISprite Darkness;

  // Token: 0x04001A29 RID: 6697
  public Transform[] Neighborhood;

  // Token: 0x04001A2A RID: 6698
  public Transform Window;

  // Token: 0x04001A2B RID: 6699
  public Transform RivalNeck;

  // Token: 0x04001A2C RID: 6700
  public Transform RivalHead;

  // Token: 0x04001A2D RID: 6701
  public Transform RivalEyeR;

  // Token: 0x04001A2E RID: 6702
  public Transform RivalEyeL;

  // Token: 0x04001A2F RID: 6703
  public Transform RivalJaw;

  // Token: 0x04001A30 RID: 6704
  public Transform RivalLipL;

  // Token: 0x04001A31 RID: 6705
  public Transform RivalLipR;

  // Token: 0x04001A32 RID: 6706
  public Transform SenpaiNeck;

  // Token: 0x04001A33 RID: 6707
  public Transform SenpaiHead;

  // Token: 0x04001A34 RID: 6708
  public Transform SenpaiEyeR;

  // Token: 0x04001A35 RID: 6709
  public Transform SenpaiEyeL;

  // Token: 0x04001A36 RID: 6710
  public Transform SenpaiJaw;

  // Token: 0x04001A37 RID: 6711
  public Transform SenpaiLipL;

  // Token: 0x04001A38 RID: 6712
  public Transform SenpaiLipR;

  // Token: 0x04001A39 RID: 6713
  public Transform YandereNeck;

  // Token: 0x04001A3A RID: 6714
  public Transform YandereHead;

  // Token: 0x04001A3B RID: 6715
  public Transform YandereEyeR;

  // Token: 0x04001A3C RID: 6716
  public Transform YandereEyeL;

  // Token: 0x04001A3D RID: 6717
  public float ScrollSpeed = 1f;

  // Token: 0x04001A3E RID: 6718
  public float LipStrength = 0.0001f;

  // Token: 0x04001A3F RID: 6719
  public float TimerLimit = 0.1f;

  // Token: 0x04001A40 RID: 6720
  public float TalkSpeed = 10f;

  // Token: 0x04001A41 RID: 6721
  public float Timer;

  // Token: 0x04001A42 RID: 6722
  public float MouthExtent = 5f;

  // Token: 0x04001A43 RID: 6723
  public float MouthTarget;

  // Token: 0x04001A44 RID: 6724
  public float MouthTimer;

  // Token: 0x04001A45 RID: 6725
  public float RivalNeckTarget;

  // Token: 0x04001A46 RID: 6726
  public float RivalHeadTarget;

  // Token: 0x04001A47 RID: 6727
  public float RivalEyeRTarget;

  // Token: 0x04001A48 RID: 6728
  public float RivalEyeLTarget;

  // Token: 0x04001A49 RID: 6729
  public float SenpaiNeckTarget;

  // Token: 0x04001A4A RID: 6730
  public float SenpaiHeadTarget;

  // Token: 0x04001A4B RID: 6731
  public float SenpaiEyeRTarget;

  // Token: 0x04001A4C RID: 6732
  public float SenpaiEyeLTarget;

  // Token: 0x04001A4D RID: 6733
  public float YandereNeckTarget;

  // Token: 0x04001A4E RID: 6734
  public float YandereHeadTarget;

  // Token: 0x04001A4F RID: 6735
  public bool ShowWindow;

  // Token: 0x04001A50 RID: 6736
  public bool Debugging;

  // Token: 0x04001A51 RID: 6737
  public bool FadeOut;

  // Token: 0x04001A52 RID: 6738
  public bool Ending;

  // Token: 0x04001A53 RID: 6739
  public bool Talk;

  // Token: 0x04001A54 RID: 6740
  public TypewriterEffect Typewriter;

  // Token: 0x04001A55 RID: 6741
  public UILabel NameLabel;

  // Token: 0x04001A56 RID: 6742
  public AudioClip[] Speech;

  // Token: 0x04001A57 RID: 6743
  public string[] Lines;

  // Token: 0x04001A58 RID: 6744
  public bool[] Speakers;

  // Token: 0x04001A59 RID: 6745
  public int ID;
}