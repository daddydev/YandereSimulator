using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000078 RID: 120
public class CreditsScript : MonoBehaviour {

  // Token: 0x1700001D RID: 29
  // (get) Token: 0x060001C2 RID: 450 RVA: 0x000234F8 File Offset: 0x000218F8
  private bool ShouldStopCredits {
    get {
      return this.ID == this.JSON.Credits.Length;
    }
  }

  // Token: 0x060001C3 RID: 451 RVA: 0x0002350F File Offset: 0x0002190F
  private GameObject SpawnLabel(int size) {
    return UnityEngine.Object.Instantiate<GameObject>((size != 1) ? this.BigCreditsLabel : this.SmallCreditsLabel, this.SpawnPoint.position, Quaternion.identity);
  }

  // Token: 0x060001C4 RID: 452 RVA: 0x00023540 File Offset: 0x00021940
  private void Update() {
    AudioSource component = base.GetComponent<AudioSource>();
    if (!this.Begin) {
      this.Timer += Time.deltaTime;
      if (this.Timer > 1f) {
        this.Begin = true;
        component.Play();
        this.Timer = 0f;
      }
    } else {
      if (!this.ShouldStopCredits) {
        if (this.Timer == 0f) {
          CreditJson creditJson = this.JSON.Credits[this.ID];
          GameObject gameObject = this.SpawnLabel(creditJson.Size);
          this.TimerLimit = (float)creditJson.Size * this.SpeedUpFactor;
          gameObject.transform.parent = this.Panel;
          gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
          gameObject.GetComponent<UILabel>().text = creditJson.Name;
          this.ID++;
        }
        this.Timer += Time.deltaTime;
        if (this.Timer >= this.TimerLimit) {
          this.Timer = 0f;
        }
      }
      if (Input.GetButtonDown("B") || !component.isPlaying) {
        this.FadeOut = true;
      }
    }
    if (this.FadeOut) {
      this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
      component.volume -= Time.deltaTime;
      if (this.Darkness.color.a == 1f) {
        SceneManager.LoadScene("TitleScene");
      }
    }
    bool keyDown = Input.GetKeyDown(KeyCode.Minus);
    bool keyDown2 = Input.GetKeyDown(KeyCode.Equals);
    if (keyDown) {
      Time.timeScale -= 1f;
    } else if (keyDown2) {
      Time.timeScale += 1f;
    }
    if (keyDown || keyDown2) {
      component.pitch = Time.timeScale;
    }
  }

  // Token: 0x0400060B RID: 1547
  [SerializeField]
  private JsonScript JSON;

  // Token: 0x0400060C RID: 1548
  [SerializeField]
  private Transform SpawnPoint;

  // Token: 0x0400060D RID: 1549
  [SerializeField]
  private Transform Panel;

  // Token: 0x0400060E RID: 1550
  [SerializeField]
  private GameObject SmallCreditsLabel;

  // Token: 0x0400060F RID: 1551
  [SerializeField]
  private GameObject BigCreditsLabel;

  // Token: 0x04000610 RID: 1552
  [SerializeField]
  private UISprite Darkness;

  // Token: 0x04000611 RID: 1553
  [SerializeField]
  private int ID;

  // Token: 0x04000612 RID: 1554
  [SerializeField]
  private float SpeedUpFactor;

  // Token: 0x04000613 RID: 1555
  [SerializeField]
  private float TimerLimit;

  // Token: 0x04000614 RID: 1556
  [SerializeField]
  private float FadeTimer;

  // Token: 0x04000615 RID: 1557
  [SerializeField]
  private float Timer;

  // Token: 0x04000616 RID: 1558
  [SerializeField]
  private bool FadeOut;

  // Token: 0x04000617 RID: 1559
  [SerializeField]
  private bool Begin;

  // Token: 0x04000618 RID: 1560
  private const int SmallTextSize = 1;

  // Token: 0x04000619 RID: 1561
  private const int BigTextSize = 2;
}