using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class RiggedAccessoryAttacher : MonoBehaviour {

  // Token: 0x0600001B RID: 27 RVA: 0x000088D8 File Offset: 0x00006CD8
  private void Start() {
    if (this.PantyID == 99) {
      this.PantyID = PlayerGlobals.PantiesEquipped;
    }
    if (this.Gentle) {
      this.accessory = GameObject.Find("GentleEyes");
      this.accessoryMaterials = this.defaultMaterials;
    } else {
      if (this.ID == 26) {
        this.accessory = GameObject.Find("OkaBlazer");
        this.accessoryMaterials = this.okaMaterials;
      }
      if (this.ID == 100) {
        this.accessory = this.Panties[this.PantyID];
        this.accessoryMaterials[0] = this.PantyMaterials[this.PantyID];
      }
    }
    this.AddLimb(this.accessory, this.root, this.accessoryMaterials);
  }

  // Token: 0x0600001C RID: 28 RVA: 0x000089A0 File Offset: 0x00006DA0
  private void Update() {
    if (this.ID == 100 && Input.GetKeyDown("p")) {
      this.PantyID++;
      if (this.PantyID > 11) {
        this.PantyID = 0;
      }
      UnityEngine.Object.Destroy(this.newRenderer);
      this.Start();
    }
  }

  // Token: 0x0600001D RID: 29 RVA: 0x000089FC File Offset: 0x00006DFC
  private void AddLimb(GameObject bonedObj, GameObject rootObj, Material[] bonedObjMaterials = null) {
    SkinnedMeshRenderer[] componentsInChildren = bonedObj.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
    foreach (SkinnedMeshRenderer thisRenderer in componentsInChildren) {
      this.ProcessBonedObject(thisRenderer, rootObj, bonedObjMaterials);
    }
  }

  // Token: 0x0600001E RID: 30 RVA: 0x00008A38 File Offset: 0x00006E38
  private void ProcessBonedObject(SkinnedMeshRenderer thisRenderer, GameObject rootObj, Material[] thisRendererMaterials = null) {
    GameObject gameObject = new GameObject(thisRenderer.gameObject.name);
    gameObject.transform.parent = rootObj.transform;
    gameObject.layer = rootObj.layer;
    gameObject.AddComponent<SkinnedMeshRenderer>();
    this.newRenderer = gameObject.GetComponent<SkinnedMeshRenderer>();
    Transform[] array = new Transform[thisRenderer.bones.Length];
    for (int i = 0; i < thisRenderer.bones.Length; i++) {
      array[i] = this.FindChildByName(thisRenderer.bones[i].name, rootObj.transform);
    }
    this.newRenderer.bones = array;
    this.newRenderer.sharedMesh = thisRenderer.sharedMesh;
    if (thisRendererMaterials == null) {
      this.newRenderer.materials = thisRenderer.sharedMaterials;
    } else {
      this.newRenderer.materials = thisRendererMaterials;
    }
  }

  // Token: 0x0600001F RID: 31 RVA: 0x00008B10 File Offset: 0x00006F10
  private Transform FindChildByName(string thisName, Transform thisGameObj) {
    if (thisGameObj.name == thisName) {
      return thisGameObj.transform;
    }
    IEnumerator enumerator = thisGameObj.GetEnumerator();
    try {
      while (enumerator.MoveNext()) {
        object obj = enumerator.Current;
        Transform thisGameObj2 = (Transform)obj;
        Transform transform = this.FindChildByName(thisName, thisGameObj2);
        if (transform) {
          return transform;
        }
      }
    } finally {
      IDisposable disposable;
      if ((disposable = (enumerator as IDisposable)) != null) {
        disposable.Dispose();
      }
    }
    return null;
  }

  // Token: 0x040000BD RID: 189
  public GameObject root;

  // Token: 0x040000BE RID: 190
  public GameObject accessory;

  // Token: 0x040000BF RID: 191
  public Material[] accessoryMaterials;

  // Token: 0x040000C0 RID: 192
  public Material[] okaMaterials;

  // Token: 0x040000C1 RID: 193
  public Material[] ribaruMaterials;

  // Token: 0x040000C2 RID: 194
  public Material[] defaultMaterials;

  // Token: 0x040000C3 RID: 195
  public GameObject[] Panties;

  // Token: 0x040000C4 RID: 196
  public Material[] PantyMaterials;

  // Token: 0x040000C5 RID: 197
  public SkinnedMeshRenderer newRenderer;

  // Token: 0x040000C6 RID: 198
  public bool Gentle;

  // Token: 0x040000C7 RID: 199
  public int PantyID;

  // Token: 0x040000C8 RID: 200
  public int ID;
}