using UnityEngine;

// Token: 0x0200023C RID: 572
public class YouTubeScript : MonoBehaviour {

  // Token: 0x06000A13 RID: 2579 RVA: 0x000B978B File Offset: 0x000B7B8B
  private void Update() {
    this.Timer += Time.deltaTime;
    if (this.Timer > 1f) {
      base.GetComponent<AudioSource>().Play();
      UnityEngine.Object.Destroy(this);
    }
  }

  // Token: 0x04001EA8 RID: 7848
  public float Timer;
}