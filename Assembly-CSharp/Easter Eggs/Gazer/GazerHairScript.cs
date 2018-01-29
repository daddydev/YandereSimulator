using UnityEngine;

// Token: 0x020000CA RID: 202
public class GazerHairScript : MonoBehaviour {

  // Token: 0x06000303 RID: 771 RVA: 0x00039984 File Offset: 0x00037D84
  private void Update() {
    this.ID = 0;
    while (this.ID < this.Weight.Length) {
      this.Weight[this.ID] = Mathf.MoveTowards(this.Weight[this.ID], this.TargetWeight[this.ID], Time.deltaTime * 100f);
      if (this.Weight[this.ID] == this.TargetWeight[this.ID]) {
        this.TargetWeight[this.ID] = UnityEngine.Random.Range(0f, 100f);
      }
      this.MyMesh.SetBlendShapeWeight(this.ID, this.Weight[this.ID]);
      this.ID++;
    }
  }

  // Token: 0x0400099C RID: 2460
  public SkinnedMeshRenderer MyMesh;

  // Token: 0x0400099D RID: 2461
  public float[] TargetWeight;

  // Token: 0x0400099E RID: 2462
  public float[] Weight;

  // Token: 0x0400099F RID: 2463
  public int ID;
}