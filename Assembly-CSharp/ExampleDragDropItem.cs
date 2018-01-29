using UnityEngine;

// Token: 0x02000019 RID: 25
[AddComponentMenu("NGUI/Examples/Drag and Drop Item (Example)")]
public class ExampleDragDropItem : UIDragDropItem {

  // Token: 0x0600006D RID: 109 RVA: 0x0000A63C File Offset: 0x00008A3C
  protected override void OnDragDropRelease(GameObject surface) {
    if (surface != null) {
      ExampleDragDropSurface component = surface.GetComponent<ExampleDragDropSurface>();
      if (component != null) {
        GameObject gameObject = NGUITools.AddChild(component.gameObject, this.prefab);
        gameObject.transform.localScale = component.transform.localScale;
        Transform transform = gameObject.transform;
        transform.position = UICamera.lastWorldPosition;
        if (component.rotatePlacedObject) {
          transform.rotation = Quaternion.LookRotation(UICamera.lastHit.normal) * Quaternion.Euler(90f, 0f, 0f);
        }
        NGUITools.Destroy(base.gameObject);
        return;
      }
    }
    base.OnDragDropRelease(surface);
  }

  // Token: 0x04000135 RID: 309
  public GameObject prefab;
}