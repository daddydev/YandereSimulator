using UnityEngine;

// Token: 0x02000051 RID: 81
public class BucketPourScript : MonoBehaviour {

  // Token: 0x06000127 RID: 295 RVA: 0x0001237D File Offset: 0x0001077D
  private void Start() {
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    base.enabled = false;
  }

  // Token: 0x06000128 RID: 296 RVA: 0x000123B4 File Offset: 0x000107B4
  private void Update() {
    if (this.Yandere.PickUp != null) {
      if (this.Yandere.PickUp.Bucket != null) {
        if (this.Yandere.PickUp.Bucket.Full) {
          if (!this.Prompt.enabled) {
            this.Prompt.Label[0].text = "     Pour";
            this.Prompt.enabled = true;
          }
        } else if (this.Yandere.PickUp.Bucket.Dumbbells == 5) {
          if (!this.Prompt.enabled) {
            this.Prompt.Label[0].text = "     Drop";
            this.Prompt.enabled = true;
          }
        } else if (this.Prompt.enabled) {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
        }
      } else if (this.Prompt.enabled) {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    } else if (this.Prompt.enabled) {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
    if (this.Prompt.Circle[0] != null && this.Prompt.Circle[0].fillAmount == 0f) {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (this.Prompt.Label[0].text == "     Pour") {
        this.Yandere.Stool = base.transform;
        this.Yandere.CanMove = false;
        this.Yandere.Pouring = true;
        this.Yandere.PourDistance = this.PourDistance;
        this.Yandere.PourHeight = this.PourHeight;
        this.Yandere.PourTime = this.PourTime;
      } else {
        this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_bucketDrop_00");
        this.Yandere.MyController.radius = 0f;
        this.Yandere.BucketDropping = true;
        this.Yandere.DropSpot = base.transform;
        this.Yandere.CanMove = false;
      }
    }
    if (this.Yandere.Pouring) {
      if (this.PourHeight == "Low" && Input.GetButtonDown("B")) {
        this.SplashCamera.Show = true;
        this.SplashCamera.MyCamera.enabled = true;
        this.SplashCamera.transform.position = new Vector3(2.875f, 0.8f, -35.625f);
        this.SplashCamera.transform.eulerAngles = new Vector3(0f, 45f, 0f);
      }
    } else if (this.Yandere.BucketDropping && Input.GetButtonDown("B")) {
      this.SplashCamera.Show = true;
      this.SplashCamera.MyCamera.enabled = true;
      this.SplashCamera.transform.position = new Vector3(2.875f, 0.8f, -35.625f);
      this.SplashCamera.transform.eulerAngles = new Vector3(0f, 45f, 0f);
    }
  }

  // Token: 0x040003A2 RID: 930
  public SplashCameraScript SplashCamera;

  // Token: 0x040003A3 RID: 931
  public YandereScript Yandere;

  // Token: 0x040003A4 RID: 932
  public PromptScript Prompt;

  // Token: 0x040003A5 RID: 933
  public string PourHeight = string.Empty;

  // Token: 0x040003A6 RID: 934
  public float PourDistance;

  // Token: 0x040003A7 RID: 935
  public float PourTime;
}