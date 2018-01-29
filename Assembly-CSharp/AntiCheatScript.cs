using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000030 RID: 48
public class AntiCheatScript : MonoBehaviour {

  // Token: 0x060000B0 RID: 176 RVA: 0x0000C338 File Offset: 0x0000A738
  private void Update() {
    if (this.Check && !base.GetComponent<AudioSource>().isPlaying) {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
  }

  // Token: 0x060000B1 RID: 177 RVA: 0x0000C372 File Offset: 0x0000A772
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.name == "YandereChan") {
      this.Jukebox.SetActive(false);
      this.Check = true;
      base.GetComponent<AudioSource>().Play();
    }
  }

  // Token: 0x040002A3 RID: 675
  public GameObject Jukebox;

  // Token: 0x040002A4 RID: 676
  public bool Check;
}