using Pathfinding;
using UnityEngine;

// Token: 0x02000242 RID: 578
public class PathfindingTestScript : MonoBehaviour {

  // Token: 0x06000A22 RID: 2594 RVA: 0x000BA2D8 File Offset: 0x000B86D8
  private void Update() {
    if (Input.GetKeyDown("left")) {
      this.bytes = AstarPath.active.astarData.SerializeGraphs();
    }
    if (Input.GetKeyDown("right")) {
      AstarPath.active.astarData.DeserializeGraphs(this.bytes);
      AstarPath.active.Scan((NavGraph)null);
    }
  }

  // Token: 0x04001EBC RID: 7868
  private byte[] bytes;
}