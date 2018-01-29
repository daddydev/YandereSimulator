using UnityEngine;

// Token: 0x0200022D RID: 557
public class YanvaniaIntroScript : MonoBehaviour {

  // Token: 0x060009DB RID: 2523 RVA: 0x000B3F44 File Offset: 0x000B2344
  private void Start() {
    this.BlackRight.gameObject.SetActive(true);
    this.BlackLeft.gameObject.SetActive(true);
    this.FinalStage.gameObject.SetActive(true);
    this.Heartbreak.gameObject.SetActive(true);
    this.Triangle.gameObject.SetActive(true);
    this.Triangle.transform.localScale = Vector3.zero;
    this.Heartbreak.transform.localPosition = new Vector3(1300f, this.Heartbreak.transform.localPosition.y, this.Heartbreak.transform.localPosition.z);
    this.FinalStage.transform.localPosition = new Vector3(-1300f, this.FinalStage.transform.localPosition.y, this.FinalStage.transform.localPosition.z);
  }

  // Token: 0x060009DC RID: 2524 RVA: 0x000B4050 File Offset: 0x000B2450
  private void Update() {
    this.Timer += Time.deltaTime;
    if (this.Timer > 1f && this.Timer < 3f) {
      if (!this.Jukebox.activeInHierarchy) {
        this.Jukebox.SetActive(true);
      }
      this.Triangle.transform.localScale = Vector3.Lerp(this.Triangle.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.Heartbreak.transform.localPosition = new Vector3(Mathf.Lerp(this.Heartbreak.transform.localPosition.x, 0f, Time.deltaTime * 10f), this.Heartbreak.transform.localPosition.y, this.Heartbreak.transform.localPosition.z);
      this.FinalStage.transform.localPosition = new Vector3(Mathf.Lerp(this.FinalStage.transform.localPosition.x, 0f, Time.deltaTime * 10f), this.FinalStage.transform.localPosition.y, this.FinalStage.transform.localPosition.z);
    } else if (this.Timer > 3f) {
      if (!this.Jukebox.activeInHierarchy) {
        this.Jukebox.SetActive(true);
      }
      this.Triangle.transform.localEulerAngles = new Vector3(this.Triangle.transform.localEulerAngles.x, this.Triangle.transform.localEulerAngles.y, this.Triangle.transform.localEulerAngles.z + 36f * Time.deltaTime);
      this.Triangle.color = new Color(this.Triangle.color.r, this.Triangle.color.g, this.Triangle.color.b, this.Triangle.color.a - Time.deltaTime);
      this.Heartbreak.color = new Color(this.Heartbreak.color.r, this.Heartbreak.color.g, this.Heartbreak.color.b, this.Heartbreak.color.a - Time.deltaTime);
      this.FinalStage.color = new Color(this.FinalStage.color.r, this.FinalStage.color.g, this.FinalStage.color.b, this.FinalStage.color.a - Time.deltaTime);
    }
    if (this.Timer > 4f) {
      this.Finish();
    }
    if (this.Timer > this.LeaveTime) {
      this.Position += ((this.Position != 0f) ? (this.Position * 0.1f) : Time.deltaTime);
      if (this.BlackLeft.localPosition.x > -2100f) {
        this.BlackRight.localPosition = new Vector3(this.BlackRight.localPosition.x + this.Position, this.BlackRight.localPosition.y, this.BlackRight.localPosition.z);
        this.BlackLeft.localPosition = new Vector3(this.BlackLeft.localPosition.x - this.Position, this.BlackLeft.localPosition.y, this.BlackLeft.localPosition.z);
      }
    }
    if (Input.GetKeyDown(KeyCode.Alpha1)) {
      this.Finish();
    }
  }

  // Token: 0x060009DD RID: 2525 RVA: 0x000B44D4 File Offset: 0x000B28D4
  private void Finish() {
    if (!this.Jukebox.activeInHierarchy) {
      this.Jukebox.SetActive(true);
    }
    this.ZombieSpawner.enabled = true;
    this.Yanmont.CanMove = true;
    UnityEngine.Object.Destroy(base.gameObject);
  }

  // Token: 0x04001DC6 RID: 7622
  public YanvaniaZombieSpawnerScript ZombieSpawner;

  // Token: 0x04001DC7 RID: 7623
  public YanvaniaYanmontScript Yanmont;

  // Token: 0x04001DC8 RID: 7624
  public GameObject Jukebox;

  // Token: 0x04001DC9 RID: 7625
  public Transform BlackRight;

  // Token: 0x04001DCA RID: 7626
  public Transform BlackLeft;

  // Token: 0x04001DCB RID: 7627
  public UILabel FinalStage;

  // Token: 0x04001DCC RID: 7628
  public UILabel Heartbreak;

  // Token: 0x04001DCD RID: 7629
  public UITexture Triangle;

  // Token: 0x04001DCE RID: 7630
  public float LeaveTime;

  // Token: 0x04001DCF RID: 7631
  public float Position;

  // Token: 0x04001DD0 RID: 7632
  public float Timer;
}