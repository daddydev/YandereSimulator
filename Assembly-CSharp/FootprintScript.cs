using UnityEngine;

// Token: 0x020000C0 RID: 192
public class FootprintScript : MonoBehaviour {

  // Token: 0x060002E1 RID: 737 RVA: 0x00036F94 File Offset: 0x00035394
  private void Start() {
    if (this.Yandere.Schoolwear == 0 || this.Yandere.Schoolwear == 2 || (this.Yandere.ClubAttire && ClubGlobals.Club == ClubType.MartialArts)) {
      base.GetComponent<Renderer>().material.mainTexture = this.Footprint;
    }
    UnityEngine.Object.Destroy(this);
  }

  // Token: 0x0400092A RID: 2346
  public YandereScript Yandere;

  // Token: 0x0400092B RID: 2347
  public Texture Footprint;
}