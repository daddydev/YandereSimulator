using Pathfinding;
using UnityEngine;

// Token: 0x020000E9 RID: 233
public class GraphUpdaterScript : MonoBehaviour {

  // Token: 0x060004B6 RID: 1206 RVA: 0x0003D3D8 File Offset: 0x0003B7D8
  private void Update() {
    if (this.Frames > 0) {
      this.Graph.Scan((NavGraph)null);
      UnityEngine.Object.Destroy(this);
    }
    this.Frames++;
  }

  // Token: 0x04000A69 RID: 2665
  public AstarPath Graph;

  // Token: 0x04000A6A RID: 2666
  public int Frames;
}