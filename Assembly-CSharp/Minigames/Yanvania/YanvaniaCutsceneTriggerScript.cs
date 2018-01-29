using UnityEngine;

// Token: 0x0200022A RID: 554
public class YanvaniaCutsceneTriggerScript : MonoBehaviour {

  // Token: 0x060009CF RID: 2511 RVA: 0x000B2998 File Offset: 0x000B0D98
  private void OnTriggerEnter(Collider other) {
    if (other.gameObject.name == "YanmontChan") {
      this.BossBattleWall.SetActive(true);
      this.Yanmont.EnterCutscene = true;
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x04001D93 RID: 7571
  public YanvaniaYanmontScript Yanmont;

  // Token: 0x04001D94 RID: 7572
  public GameObject BossBattleWall;
}