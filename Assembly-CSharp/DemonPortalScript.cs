using UnityEngine;

// Token: 0x02000084 RID: 132
public class DemonPortalScript : MonoBehaviour {

  // Token: 0x06000217 RID: 535 RVA: 0x0002B47C File Offset: 0x0002987C
  private void Update() {
    if (this.Prompt.Circle[0].fillAmount == 0f) {
      this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
      this.Yandere.CanMove = false;
      UnityEngine.Object.Instantiate<GameObject>(this.DarkAura, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
      this.Timer += Time.deltaTime;
    }
    this.DemonRealmAudio.volume = Mathf.MoveTowards(this.DemonRealmAudio.volume, (this.Yandere.transform.position.y <= 1000f) ? 0f : 0.5f, Time.deltaTime * 0.1f);
    if (this.Timer > 0f) {
      if (this.Yandere.transform.position.y > 1000f) {
        this.Timer += Time.deltaTime;
        if (this.Timer > 4f) {
          this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
          if (this.Darkness.color.a == 1f) {
            this.Yandere.transform.position = new Vector3(12f, 0f, 28f);
            this.Yandere.Character.SetActive(true);
            this.Yandere.SetAnimationLayers();
            this.HeartbeatCamera.SetActive(true);
            this.FPS.SetActive(true);
            this.HUD.SetActive(true);
          }
        } else if (this.Timer > 1f) {
          this.Yandere.Character.SetActive(false);
        }
      } else {
        this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0.5f, Time.deltaTime * 0.5f);
        if (this.Jukebox.Volume == 0.5f) {
          this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
          if (this.Darkness.color.a == 0f) {
            this.Darkness.enabled = false;
            this.Yandere.CanMove = true;
            this.Clock.StopTime = false;
            this.Timer = 0f;
          }
        }
      }
    }
  }

  // Token: 0x0400073D RID: 1853
  public YandereScript Yandere;

  // Token: 0x0400073E RID: 1854
  public JukeboxScript Jukebox;

  // Token: 0x0400073F RID: 1855
  public PromptScript Prompt;

  // Token: 0x04000740 RID: 1856
  public ClockScript Clock;

  // Token: 0x04000741 RID: 1857
  public AudioSource DemonRealmAudio;

  // Token: 0x04000742 RID: 1858
  public GameObject HeartbeatCamera;

  // Token: 0x04000743 RID: 1859
  public GameObject DarkAura;

  // Token: 0x04000744 RID: 1860
  public GameObject FPS;

  // Token: 0x04000745 RID: 1861
  public GameObject HUD;

  // Token: 0x04000746 RID: 1862
  public UISprite Darkness;

  // Token: 0x04000747 RID: 1863
  public float Timer;
}