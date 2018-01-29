using UnityEngine;

// Token: 0x02000120 RID: 288
public class LaptopScript : MonoBehaviour {

  // Token: 0x06000592 RID: 1426 RVA: 0x0004C6A4 File Offset: 0x0004AAA4
  private void Start() {
    if (SchoolGlobals.SCP) {
      this.LaptopScreen.localScale = Vector3.zero;
      this.LaptopCamera.enabled = false;
      this.SCP.SetActive(false);
      base.enabled = false;
    } else {
      Animation component = this.SCP.GetComponent<Animation>();
      component["f02_scp_00"].speed = 0f;
      component["f02_scp_00"].time = 0f;
      this.MyAudio = base.GetComponent<AudioSource>();
    }
  }

  // Token: 0x06000593 RID: 1427 RVA: 0x0004C734 File Offset: 0x0004AB34
  private void Update() {
    if (this.FirstFrame == 2) {
      this.LaptopCamera.enabled = false;
    }
    this.FirstFrame++;
    if (!this.Off) {
      Animation component = this.SCP.GetComponent<Animation>();
      if (!this.React) {
        if (this.Yandere.transform.position.x > base.transform.position.x + 1f && Vector3.Distance(this.Yandere.transform.position, new Vector3(base.transform.position.x, 4f, base.transform.position.z)) < 2f && this.Yandere.Followers == 0) {
          this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
          component["f02_scp_00"].time = 0f;
          this.LaptopCamera.enabled = true;
          component.Play();
          this.Hair.enabled = true;
          this.Jukebox.Dip = 0.5f;
          this.MyAudio.Play();
          this.React = true;
        }
      } else {
        this.MyAudio.pitch = Time.timeScale;
        this.MyAudio.volume = 1f;
        if (this.Yandere.transform.position.y > base.transform.position.y + 3f || this.Yandere.transform.position.y < base.transform.position.y - 3f) {
          this.MyAudio.volume = 0f;
        }
        for (int i = 0; i < this.Cues.Length; i++) {
          if (this.MyAudio.time > this.Cues[i]) {
            this.EventSubtitle.text = this.Subs[i];
          }
        }
        if (this.MyAudio.time >= this.MyAudio.clip.length - 1f || this.MyAudio.time == 0f) {
          component["f02_scp_00"].speed = 1f;
          this.Timer += Time.deltaTime;
        } else {
          component["f02_scp_00"].time = this.MyAudio.time;
        }
        if (this.Timer > 1f || Vector3.Distance(this.Yandere.transform.position, new Vector3(base.transform.position.x, 4f, base.transform.position.z)) > 5f) {
          this.TurnOff();
        }
      }
      if (this.Yandere.StudentManager.Clock.HourTime > 16f) {
        this.TurnOff();
      }
    } else if (this.LaptopScreen.localScale.x > 0.1f) {
      this.LaptopScreen.localScale = Vector3.Lerp(this.LaptopScreen.localScale, Vector3.zero, Time.deltaTime * 10f);
    } else if (base.enabled) {
      this.LaptopScreen.localScale = Vector3.zero;
      this.Hair.enabled = false;
      base.enabled = false;
    }
  }

  // Token: 0x06000594 RID: 1428 RVA: 0x0004CB18 File Offset: 0x0004AF18
  private void TurnOff() {
    this.MyAudio.clip = this.ShutDown;
    this.MyAudio.Play();
    this.EventSubtitle.text = string.Empty;
    SchoolGlobals.SCP = true;
    this.LaptopCamera.enabled = false;
    this.Jukebox.Dip = 1f;
    this.React = false;
    this.Off = true;
  }

  // Token: 0x04000D3C RID: 3388
  public Camera LaptopCamera;

  // Token: 0x04000D3D RID: 3389
  public JukeboxScript Jukebox;

  // Token: 0x04000D3E RID: 3390
  public YandereScript Yandere;

  // Token: 0x04000D3F RID: 3391
  public AudioSource MyAudio;

  // Token: 0x04000D40 RID: 3392
  public DynamicBone Hair;

  // Token: 0x04000D41 RID: 3393
  public Transform LaptopScreen;

  // Token: 0x04000D42 RID: 3394
  public AudioClip ShutDown;

  // Token: 0x04000D43 RID: 3395
  public GameObject SCP;

  // Token: 0x04000D44 RID: 3396
  public bool React;

  // Token: 0x04000D45 RID: 3397
  public bool Off;

  // Token: 0x04000D46 RID: 3398
  public float[] Cues;

  // Token: 0x04000D47 RID: 3399
  public string[] Subs;

  // Token: 0x04000D48 RID: 3400
  public int FirstFrame;

  // Token: 0x04000D49 RID: 3401
  public float Timer;

  // Token: 0x04000D4A RID: 3402
  public UILabel EventSubtitle;
}