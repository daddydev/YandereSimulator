using UnityEngine;

// Token: 0x02000230 RID: 560
public class YanvaniaJukeboxScript : MonoBehaviour {

  // Token: 0x060009E4 RID: 2532 RVA: 0x000B46F0 File Offset: 0x000B2AF0
  private void Update() {
    AudioSource component = base.GetComponent<AudioSource>();
    if (component.time + Time.deltaTime > component.clip.length) {
      component.clip = ((!this.Boss) ? this.ApproachMain : this.BossMain);
      component.loop = true;
      component.Play();
    }
  }

  // Token: 0x060009E5 RID: 2533 RVA: 0x000B4750 File Offset: 0x000B2B50
  public void BossBattle() {
    AudioSource component = base.GetComponent<AudioSource>();
    component.clip = this.BossIntro;
    component.loop = false;
    component.volume = 0.25f;
    component.Play();
    this.Boss = true;
  }

  // Token: 0x04001DD7 RID: 7639
  public AudioClip BossIntro;

  // Token: 0x04001DD8 RID: 7640
  public AudioClip BossMain;

  // Token: 0x04001DD9 RID: 7641
  public AudioClip ApproachIntro;

  // Token: 0x04001DDA RID: 7642
  public AudioClip ApproachMain;

  // Token: 0x04001DDB RID: 7643
  public bool Boss;
}