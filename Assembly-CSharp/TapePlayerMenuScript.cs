using UnityEngine;

// Token: 0x020001D4 RID: 468
public class TapePlayerMenuScript : MonoBehaviour {

  // Token: 0x06000874 RID: 2164 RVA: 0x0009821C File Offset: 0x0009661C
  private void Start() {
    this.List.transform.localPosition = new Vector3(-955f, this.List.transform.localPosition.y, this.List.transform.localPosition.z);
    this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, 100f, this.TimeBar.localPosition.z);
    this.Subtitle.text = string.Empty;
    this.TapePlayerCamera.position = new Vector3(-26.15f, this.TapePlayerCamera.position.y, 5.35f);
  }

  // Token: 0x06000875 RID: 2165 RVA: 0x000982EC File Offset: 0x000966EC
  private void Update() {
    AudioSource component = base.GetComponent<AudioSource>();
    float t = Time.unscaledDeltaTime * 10f;
    if (!this.Show) {
      if (this.List.localPosition.x > -955f) {
        this.List.localPosition = new Vector3(Mathf.Lerp(this.List.localPosition.x, -956f, t), this.List.localPosition.y, this.List.localPosition.z);
        this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, Mathf.Lerp(this.TimeBar.localPosition.y, 100f, t), this.TimeBar.localPosition.z);
      } else {
        this.TimeBar.gameObject.SetActive(false);
        this.List.gameObject.SetActive(false);
      }
    } else if (this.Listening) {
      this.List.localPosition = new Vector3(Mathf.Lerp(this.List.localPosition.x, -955f, t), this.List.localPosition.y, this.List.localPosition.z);
      this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, Mathf.Lerp(this.TimeBar.localPosition.y, 0f, t), this.TimeBar.localPosition.z);
      this.TapePlayerCamera.position = new Vector3(Mathf.Lerp(this.TapePlayerCamera.position.x, -26.15f, t), this.TapePlayerCamera.position.y, Mathf.Lerp(this.TapePlayerCamera.position.z, 5.35f, t));
      if (this.Phase == 1) {
        this.TapePlayer.GetComponent<Animation>()["InsertTape"].time += 0.0555555f;
        if (this.TapePlayer.GetComponent<Animation>()["InsertTape"].time >= this.TapePlayer.GetComponent<Animation>()["InsertTape"].length) {
          this.TapePlayer.GetComponent<Animation>().Play("PressPlay");
          component.Play();
          this.PromptBar.Label[0].text = "PAUSE";
          this.PromptBar.Label[1].text = "STOP";
          this.PromptBar.Label[5].text = "REWIND / FAST FORWARD";
          this.PromptBar.UpdateButtons();
          this.Phase++;
        }
      } else if (this.Phase == 2) {
        this.Timer += 0.0166666675f;
        if (component.isPlaying) {
          if ((double)this.Timer > 0.1) {
            this.TapePlayer.GetComponent<Animation>()["PressPlay"].time += 0.0166666675f;
            if (this.TapePlayer.GetComponent<Animation>()["PressPlay"].time > this.TapePlayer.GetComponent<Animation>()["PressPlay"].length) {
              this.TapePlayer.GetComponent<Animation>()["PressPlay"].time = this.TapePlayer.GetComponent<Animation>()["PressPlay"].length;
            }
          }
        } else {
          this.TapePlayer.GetComponent<Animation>()["PressPlay"].time -= 0.0166666675f;
          if (this.TapePlayer.GetComponent<Animation>()["PressPlay"].time < 0f) {
            this.TapePlayer.GetComponent<Animation>()["PressPlay"].time = 0f;
          }
          if (Input.GetButtonDown("A")) {
            this.PromptBar.Label[0].text = "PAUSE";
            this.TapePlayer.Spin = true;
            component.time = this.ResumeTime;
            component.Play();
          }
        }
        if (this.TapePlayer.GetComponent<Animation>()["PressPlay"].time >= this.TapePlayer.GetComponent<Animation>()["PressPlay"].length) {
          this.TapePlayer.Spin = true;
          if (component.time >= component.clip.length - 1f) {
            this.TapePlayer.GetComponent<Animation>().Play("PressEject");
            this.TapePlayer.Spin = false;
            if (!component.isPlaying) {
              component.clip = this.TapeStop;
              component.Play();
            }
            this.Subtitle.text = string.Empty;
            this.Phase++;
          }
          if (Input.GetButtonDown("A") && component.isPlaying) {
            this.PromptBar.Label[0].text = "PLAY";
            this.TapePlayer.Spin = false;
            this.ResumeTime = component.time;
            component.Stop();
          }
        }
        if (Input.GetButtonDown("B")) {
          this.TapePlayer.GetComponent<Animation>().Play("PressEject");
          component.clip = this.TapeStop;
          this.TapePlayer.Spin = false;
          component.Play();
          this.PromptBar.Label[0].text = string.Empty;
          this.PromptBar.Label[1].text = string.Empty;
          this.PromptBar.Label[5].text = string.Empty;
          this.PromptBar.UpdateButtons();
          this.Subtitle.text = string.Empty;
          this.Phase++;
        }
      } else if (this.Phase == 3) {
        this.TapePlayer.GetComponent<Animation>()["PressEject"].time += 0.0166666675f;
        if (this.TapePlayer.GetComponent<Animation>()["PressEject"].time >= this.TapePlayer.GetComponent<Animation>()["PressEject"].length) {
          this.TapePlayer.GetComponent<Animation>().Play("InsertTape");
          this.TapePlayer.GetComponent<Animation>()["InsertTape"].time = this.TapePlayer.GetComponent<Animation>()["InsertTape"].length;
          this.TapePlayer.FastForward = false;
          this.Phase++;
        }
      } else if (this.Phase == 4) {
        this.TapePlayer.GetComponent<Animation>()["InsertTape"].time -= 0.0555555f;
        if (this.TapePlayer.GetComponent<Animation>()["InsertTape"].time <= 0f) {
          this.TapePlayer.Tape.SetActive(false);
          this.Jukebox.SetActive(true);
          this.Listening = false;
          this.Timer = 0f;
          this.PromptBar.Label[0].text = "PLAY";
          this.PromptBar.Label[1].text = "BACK";
          this.PromptBar.Label[4].text = "CHOOSE";
          this.PromptBar.Label[5].text = "CATEGORY";
          this.PromptBar.UpdateButtons();
        }
      }
      if (this.Phase == 2) {
        if (this.InputManager.DPadRight || Input.GetKey(KeyCode.RightArrow)) {
          this.ResumeTime += 1.66666663f;
          component.time += 1.66666663f;
          this.TapePlayer.FastForward = true;
        } else {
          this.TapePlayer.FastForward = false;
        }
        if (this.InputManager.DPadLeft || Input.GetKey(KeyCode.LeftArrow)) {
          this.ResumeTime -= 1.66666663f;
          component.time -= 1.66666663f;
          this.TapePlayer.Rewind = true;
        } else {
          this.TapePlayer.Rewind = false;
        }
        int num;
        int num2;
        if (component.isPlaying) {
          num = Mathf.FloorToInt(component.time / 60f);
          num2 = Mathf.FloorToInt(component.time - (float)num * 60f);
          this.Bar.fillAmount = component.time / component.clip.length;
        } else {
          num = Mathf.FloorToInt(this.ResumeTime / 60f);
          num2 = Mathf.FloorToInt(this.ResumeTime - (float)num * 60f);
          this.Bar.fillAmount = this.ResumeTime / component.clip.length;
        }
        this.CurrentTime = string.Format("{00:00}:{1:00}", num, num2);
        this.Label.text = this.CurrentTime + " / " + this.ClipLength;
        if (this.Category == 1) {
          if (this.Selected == 1) {
            for (int i = 0; i < this.Cues1.Length; i++) {
              if (component.time > this.Cues1[i]) {
                this.Subtitle.text = this.Subs1[i];
              }
            }
          } else if (this.Selected == 2) {
            for (int j = 0; j < this.Cues2.Length; j++) {
              if (component.time > this.Cues2[j]) {
                this.Subtitle.text = this.Subs2[j];
              }
            }
          } else if (this.Selected == 3) {
            for (int k = 0; k < this.Cues3.Length; k++) {
              if (component.time > this.Cues3[k]) {
                this.Subtitle.text = this.Subs3[k];
              }
            }
          } else if (this.Selected == 4) {
            for (int l = 0; l < this.Cues4.Length; l++) {
              if (component.time > this.Cues4[l]) {
                this.Subtitle.text = this.Subs4[l];
              }
            }
          } else if (this.Selected == 5) {
            for (int m = 0; m < this.Cues5.Length; m++) {
              if (component.time > this.Cues5[m]) {
                this.Subtitle.text = this.Subs5[m];
              }
            }
          } else if (this.Selected == 6) {
            for (int n = 0; n < this.Cues6.Length; n++) {
              if (component.time > this.Cues6[n]) {
                this.Subtitle.text = this.Subs6[n];
              }
            }
          } else if (this.Selected == 7) {
            for (int num3 = 0; num3 < this.Cues7.Length; num3++) {
              if (component.time > this.Cues7[num3]) {
                this.Subtitle.text = this.Subs7[num3];
              }
            }
          } else if (this.Selected == 8) {
            for (int num4 = 0; num4 < this.Cues8.Length; num4++) {
              if (component.time > this.Cues8[num4]) {
                this.Subtitle.text = this.Subs8[num4];
              }
            }
          } else if (this.Selected == 9) {
            for (int num5 = 0; num5 < this.Cues9.Length; num5++) {
              if (component.time > this.Cues9[num5]) {
                this.Subtitle.text = this.Subs9[num5];
              }
            }
          } else if (this.Selected == 10) {
            for (int num6 = 0; num6 < this.Cues10.Length; num6++) {
              if (component.time > this.Cues10[num6]) {
                this.Subtitle.text = this.Subs10[num6];
              }
            }
          }
        } else {
          if (this.Selected == 1) {
            for (int num7 = 0; num7 < this.BasementCues1.Length; num7++) {
              if (component.time > this.BasementCues1[num7]) {
                this.Subtitle.text = this.BasementSubs1[num7];
              }
            }
          }
          if (this.Selected == 10) {
            for (int num8 = 0; num8 < this.BasementCues10.Length; num8++) {
              if (component.time > this.BasementCues10[num8]) {
                this.Subtitle.text = this.BasementSubs10[num8];
              }
            }
          }
        }
      } else {
        this.Label.text = "00:00 / 00:00";
        this.Bar.fillAmount = 0f;
      }
    } else {
      this.TapePlayerCamera.position = new Vector3(Mathf.Lerp(this.TapePlayerCamera.position.x, -26.2125f, t), this.TapePlayerCamera.position.y, Mathf.Lerp(this.TapePlayerCamera.position.z, 5.4125f, t));
      this.List.transform.localPosition = new Vector3(Mathf.Lerp(this.List.transform.localPosition.x, 0f, t), this.List.transform.localPosition.y, this.List.transform.localPosition.z);
      this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, Mathf.Lerp(this.TimeBar.localPosition.y, 100f, t), this.TimeBar.localPosition.z);
      if (this.InputManager.TappedRight || this.InputManager.TappedLeft) {
        this.Category = ((this.Category != 1) ? 1 : 2);
        this.UpdateLabels();
      }
      if (this.InputManager.TappedUp) {
        this.Selected--;
        if (this.Selected < 1) {
          this.Selected = 10;
        }
        this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 440f - 80f * (float)this.Selected, this.Highlight.localPosition.z);
        this.CheckSelection();
      } else if (this.InputManager.TappedDown) {
        this.Selected++;
        if (this.Selected > 10) {
          this.Selected = 1;
        }
        this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 440f - 80f * (float)this.Selected, this.Highlight.localPosition.z);
        this.CheckSelection();
      } else if (Input.GetButtonDown("A")) {
        bool flag = false;
        if (this.Category == 1) {
          if (CollectibleGlobals.GetTapeCollected(this.Selected)) {
            CollectibleGlobals.SetTapeListened(this.Selected, true);
            flag = true;
          }
        } else if (CollectibleGlobals.GetBasementTapeCollected(this.Selected)) {
          CollectibleGlobals.SetBasementTapeListened(this.Selected, true);
          flag = true;
        }
        if (flag) {
          this.NewIcons[this.Selected].SetActive(false);
          this.Jukebox.SetActive(false);
          this.Listening = true;
          this.Phase = 1;
          this.PromptBar.Label[0].text = string.Empty;
          this.PromptBar.Label[1].text = string.Empty;
          this.PromptBar.Label[4].text = string.Empty;
          this.PromptBar.UpdateButtons();
          this.TapePlayer.GetComponent<Animation>().Play("InsertTape");
          this.TapePlayer.Tape.SetActive(true);
          if (this.Category == 1) {
            component.clip = this.Recordings[this.Selected];
          } else {
            component.clip = this.BasementRecordings[this.Selected];
          }
          component.time = 0f;
          this.RoundedTime = (float)Mathf.CeilToInt(component.clip.length);
          int num9 = (int)(this.RoundedTime / 60f);
          int num10 = (int)(this.RoundedTime % 60f);
          this.ClipLength = string.Format("{0:00}:{1:00}", num9, num10);
        }
      } else if (Input.GetButtonDown("B")) {
        this.TapePlayer.Yandere.HeartCamera.enabled = true;
        this.TapePlayer.Yandere.RPGCamera.enabled = true;
        this.TapePlayer.TapePlayerCamera.enabled = false;
        this.TapePlayer.NoteWindow.SetActive(true);
        this.TapePlayer.PromptBar.ClearButtons();
        this.TapePlayer.Yandere.CanMove = true;
        this.TapePlayer.PromptBar.Show = false;
        this.TapePlayer.Prompt.enabled = true;
        this.TapePlayer.Yandere.HUD.alpha = 1f;
        Time.timeScale = 1f;
        this.Show = false;
      }
    }
  }

  // Token: 0x06000876 RID: 2166 RVA: 0x000995E4 File Offset: 0x000979E4
  public void UpdateLabels() {
    int i = 0;
    while (i < this.TotalTapes) {
      i++;
      if (this.Category == 1) {
        this.HeaderLabel.text = "Mysterious Tapes";
        if (CollectibleGlobals.GetTapeCollected(i)) {
          this.TapeLabels[i].text = "Mysterious Tape " + i.ToString();
          this.NewIcons[i].SetActive(!CollectibleGlobals.GetTapeListened(i));
        } else {
          this.TapeLabels[i].text = "?????";
          this.NewIcons[i].SetActive(false);
        }
      } else {
        this.HeaderLabel.text = "Basement Tapes";
        if (CollectibleGlobals.GetBasementTapeCollected(i)) {
          this.TapeLabels[i].text = "Basement Tape " + i.ToString();
          this.NewIcons[i].SetActive(!CollectibleGlobals.GetBasementTapeListened(i));
        } else {
          this.TapeLabels[i].text = "?????";
          this.NewIcons[i].SetActive(false);
        }
      }
    }
  }

  // Token: 0x06000877 RID: 2167 RVA: 0x00099710 File Offset: 0x00097B10
  public void CheckSelection() {
    if (this.Category == 1) {
      this.TapePlayer.PromptBar.Label[0].text = ((!CollectibleGlobals.GetTapeCollected(this.Selected)) ? string.Empty : "PLAY");
      this.TapePlayer.PromptBar.UpdateButtons();
    } else {
      this.TapePlayer.PromptBar.Label[0].text = ((!CollectibleGlobals.GetBasementTapeCollected(this.Selected)) ? string.Empty : "PLAY");
      this.TapePlayer.PromptBar.UpdateButtons();
    }
  }

  // Token: 0x040018DD RID: 6365
  public InputManagerScript InputManager;

  // Token: 0x040018DE RID: 6366
  public TapePlayerScript TapePlayer;

  // Token: 0x040018DF RID: 6367
  public PromptBarScript PromptBar;

  // Token: 0x040018E0 RID: 6368
  public GameObject Jukebox;

  // Token: 0x040018E1 RID: 6369
  public Transform TapePlayerCamera;

  // Token: 0x040018E2 RID: 6370
  public Transform Highlight;

  // Token: 0x040018E3 RID: 6371
  public Transform TimeBar;

  // Token: 0x040018E4 RID: 6372
  public Transform List;

  // Token: 0x040018E5 RID: 6373
  public AudioClip[] Recordings;

  // Token: 0x040018E6 RID: 6374
  public AudioClip[] BasementRecordings;

  // Token: 0x040018E7 RID: 6375
  public UILabel[] TapeLabels;

  // Token: 0x040018E8 RID: 6376
  public GameObject[] NewIcons;

  // Token: 0x040018E9 RID: 6377
  public AudioClip TapeStop;

  // Token: 0x040018EA RID: 6378
  public string CurrentTime;

  // Token: 0x040018EB RID: 6379
  public string ClipLength;

  // Token: 0x040018EC RID: 6380
  public bool Listening;

  // Token: 0x040018ED RID: 6381
  public bool Show;

  // Token: 0x040018EE RID: 6382
  public UILabel HeaderLabel;

  // Token: 0x040018EF RID: 6383
  public UILabel Subtitle;

  // Token: 0x040018F0 RID: 6384
  public UILabel Label;

  // Token: 0x040018F1 RID: 6385
  public UISprite Bar;

  // Token: 0x040018F2 RID: 6386
  public int TotalTapes = 10;

  // Token: 0x040018F3 RID: 6387
  public int Category = 1;

  // Token: 0x040018F4 RID: 6388
  public int Selected = 1;

  // Token: 0x040018F5 RID: 6389
  public int Phase = 1;

  // Token: 0x040018F6 RID: 6390
  public float RoundedTime;

  // Token: 0x040018F7 RID: 6391
  public float ResumeTime;

  // Token: 0x040018F8 RID: 6392
  public float Timer;

  // Token: 0x040018F9 RID: 6393
  public float[] Cues1;

  // Token: 0x040018FA RID: 6394
  public float[] Cues2;

  // Token: 0x040018FB RID: 6395
  public float[] Cues3;

  // Token: 0x040018FC RID: 6396
  public float[] Cues4;

  // Token: 0x040018FD RID: 6397
  public float[] Cues5;

  // Token: 0x040018FE RID: 6398
  public float[] Cues6;

  // Token: 0x040018FF RID: 6399
  public float[] Cues7;

  // Token: 0x04001900 RID: 6400
  public float[] Cues8;

  // Token: 0x04001901 RID: 6401
  public float[] Cues9;

  // Token: 0x04001902 RID: 6402
  public float[] Cues10;

  // Token: 0x04001903 RID: 6403
  public string[] Subs1;

  // Token: 0x04001904 RID: 6404
  public string[] Subs2;

  // Token: 0x04001905 RID: 6405
  public string[] Subs3;

  // Token: 0x04001906 RID: 6406
  public string[] Subs4;

  // Token: 0x04001907 RID: 6407
  public string[] Subs5;

  // Token: 0x04001908 RID: 6408
  public string[] Subs6;

  // Token: 0x04001909 RID: 6409
  public string[] Subs7;

  // Token: 0x0400190A RID: 6410
  public string[] Subs8;

  // Token: 0x0400190B RID: 6411
  public string[] Subs9;

  // Token: 0x0400190C RID: 6412
  public string[] Subs10;

  // Token: 0x0400190D RID: 6413
  public float[] BasementCues1;

  // Token: 0x0400190E RID: 6414
  public float[] BasementCues10;

  // Token: 0x0400190F RID: 6415
  public string[] BasementSubs1;

  // Token: 0x04001910 RID: 6416
  public string[] BasementSubs10;
}