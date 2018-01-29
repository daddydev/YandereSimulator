using UnityEngine;

// Token: 0x0200014C RID: 332
public class ParticleDeathScript : MonoBehaviour {

  // Token: 0x0600061E RID: 1566 RVA: 0x00056370 File Offset: 0x00054770
  private void LateUpdate() {
    if (this.Particles.isPlaying && this.Particles.particleCount == 0) {
      UnityEngine.Object.Destroy(base.gameObject);
    }
  }

  // Token: 0x04000EB3 RID: 3763
  public ParticleSystem Particles;
}