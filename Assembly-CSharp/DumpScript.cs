using UnityEngine;

// Token: 0x02000092 RID: 146
public class DumpScript : MonoBehaviour {

  // Token: 0x06000247 RID: 583 RVA: 0x00030F94 File Offset: 0x0002F394
  private void Update() {
    this.Timer += Time.deltaTime;
    if (this.Timer > 5f) {
      this.Incinerator.Corpses++;
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x040007CF RID: 1999
  public SkinnedMeshRenderer MyRenderer;

  // Token: 0x040007D0 RID: 2000
  public IncineratorScript Incinerator;

  // Token: 0x040007D1 RID: 2001
  public float Timer;
}