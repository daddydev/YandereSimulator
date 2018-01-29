using System;
using System.Collections;
using UnityEngine;

// Token: 0x020001F6 RID: 502
public static class GameObjectUtils {

  // Token: 0x060008FD RID: 2301 RVA: 0x0009E958 File Offset: 0x0009CD58
  public static void SetLayerRecursively(GameObject obj, int newLayer) {
    obj.layer = newLayer;
    IEnumerator enumerator = obj.transform.GetEnumerator();
    try {
      while (enumerator.MoveNext()) {
        object obj2 = enumerator.Current;
        Transform transform = (Transform)obj2;
        GameObjectUtils.SetLayerRecursively(transform.gameObject, newLayer);
      }
    } finally {
      IDisposable disposable;
      if ((disposable = (enumerator as IDisposable)) != null) {
        disposable.Dispose();
      }
    }
  }

  // Token: 0x060008FE RID: 2302 RVA: 0x0009E9CC File Offset: 0x0009CDCC
  public static void SetTagRecursively(GameObject obj, string newTag) {
    obj.tag = newTag;
    IEnumerator enumerator = obj.transform.GetEnumerator();
    try {
      while (enumerator.MoveNext()) {
        object obj2 = enumerator.Current;
        Transform transform = (Transform)obj2;
        GameObjectUtils.SetTagRecursively(transform.gameObject, newTag);
      }
    } finally {
      IDisposable disposable;
      if ((disposable = (enumerator as IDisposable)) != null) {
        disposable.Dispose();
      }
    }
  }
}