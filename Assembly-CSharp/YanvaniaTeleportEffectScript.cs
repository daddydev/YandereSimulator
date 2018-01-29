using UnityEngine;

// Token: 0x02000232 RID: 562
public class YanvaniaTeleportEffectScript : MonoBehaviour {

  // Token: 0x060009E9 RID: 2537 RVA: 0x000B4844 File Offset: 0x000B2C44
  private void Start() {
    this.FirstBeam.material.color = new Color(this.FirstBeam.material.color.r, this.FirstBeam.material.color.g, this.FirstBeam.material.color.b, 0f);
    this.SecondBeam.material.color = new Color(this.SecondBeam.material.color.r, this.SecondBeam.material.color.g, this.SecondBeam.material.color.b, 0f);
    this.FirstBeam.transform.localScale = new Vector3(0f, this.FirstBeam.transform.localScale.y, 0f);
    this.SecondBeamParent.transform.localScale = new Vector3(this.SecondBeamParent.transform.localScale.x, 0f, this.SecondBeamParent.transform.localScale.z);
  }

  // Token: 0x060009EA RID: 2538 RVA: 0x000B499B File Offset: 0x000B2D9B
  private void Update() {
  }

  // Token: 0x04001DDD RID: 7645
  public YanvaniaDraculaScript Dracula;

  // Token: 0x04001DDE RID: 7646
  public Transform SecondBeamParent;

  // Token: 0x04001DDF RID: 7647
  public Renderer SecondBeam;

  // Token: 0x04001DE0 RID: 7648
  public Renderer FirstBeam;

  // Token: 0x04001DE1 RID: 7649
  public bool InformedDracula;

  // Token: 0x04001DE2 RID: 7650
  public float Timer;
}