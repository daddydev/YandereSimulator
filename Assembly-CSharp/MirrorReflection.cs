using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000131 RID: 305
[ExecuteInEditMode]
public class MirrorReflection : MonoBehaviour {

  // Token: 0x060005C2 RID: 1474 RVA: 0x0004FA4C File Offset: 0x0004DE4C
  public void OnWillRenderObject() {
    Renderer component = base.GetComponent<Renderer>();
    if (!base.enabled || !component || !component.sharedMaterial || !component.enabled) {
      return;
    }
    Camera current = Camera.current;
    if (!current) {
      return;
    }
    if (MirrorReflection.s_InsideRendering) {
      return;
    }
    MirrorReflection.s_InsideRendering = true;
    Camera camera;
    this.CreateMirrorObjects(current, out camera);
    Vector3 position = base.transform.position;
    Vector3 up = base.transform.up;
    int pixelLightCount = QualitySettings.pixelLightCount;
    if (this.m_DisablePixelLights) {
      QualitySettings.pixelLightCount = 0;
    }
    this.UpdateCameraModes(current, camera);
    float w = -Vector3.Dot(up, position) - this.m_ClipPlaneOffset;
    Vector4 plane = new Vector4(up.x, up.y, up.z, w);
    Matrix4x4 zero = Matrix4x4.zero;
    MirrorReflection.CalculateReflectionMatrix(ref zero, plane);
    Vector3 position2 = current.transform.position;
    Vector3 position3 = zero.MultiplyPoint(position2);
    camera.worldToCameraMatrix = current.worldToCameraMatrix * zero;
    Vector4 clipPlane = this.CameraSpacePlane(camera, position, up, 1f);
    Matrix4x4 projectionMatrix = current.CalculateObliqueMatrix(clipPlane);
    camera.projectionMatrix = projectionMatrix;
    camera.cullingMask = (-17 & this.m_ReflectLayers.value);
    camera.targetTexture = this.m_ReflectionTexture;
    GL.invertCulling = true;
    camera.transform.position = position3;
    Vector3 eulerAngles = current.transform.eulerAngles;
    camera.transform.eulerAngles = new Vector3(0f, eulerAngles.y, eulerAngles.z);
    camera.Render();
    camera.transform.position = position2;
    GL.invertCulling = false;
    Material[] sharedMaterials = component.sharedMaterials;
    foreach (Material material in sharedMaterials) {
      if (material.HasProperty("_ReflectionTex")) {
        material.SetTexture("_ReflectionTex", this.m_ReflectionTexture);
      }
    }
    if (this.m_DisablePixelLights) {
      QualitySettings.pixelLightCount = pixelLightCount;
    }
    MirrorReflection.s_InsideRendering = false;
  }

  // Token: 0x060005C3 RID: 1475 RVA: 0x0004FC68 File Offset: 0x0004E068
  private void OnDisable() {
    if (this.m_ReflectionTexture) {
      UnityEngine.Object.DestroyImmediate(this.m_ReflectionTexture);
      this.m_ReflectionTexture = null;
    }
    IDictionaryEnumerator enumerator = this.m_ReflectionCameras.GetEnumerator();
    try {
      while (enumerator.MoveNext()) {
        object obj = enumerator.Current;
        UnityEngine.Object.DestroyImmediate(((Camera)((DictionaryEntry)obj).Value).gameObject);
      }
    } finally {
      IDisposable disposable;
      if ((disposable = (enumerator as IDisposable)) != null) {
        disposable.Dispose();
      }
    }
    this.m_ReflectionCameras.Clear();
  }

  // Token: 0x060005C4 RID: 1476 RVA: 0x0004FD0C File Offset: 0x0004E10C
  private void UpdateCameraModes(Camera src, Camera dest) {
    if (dest == null) {
      return;
    }
    dest.clearFlags = src.clearFlags;
    dest.backgroundColor = src.backgroundColor;
    if (src.clearFlags == CameraClearFlags.Skybox) {
      Skybox skybox = src.GetComponent(typeof(Skybox)) as Skybox;
      Skybox skybox2 = dest.GetComponent(typeof(Skybox)) as Skybox;
      if (!skybox || !skybox.material) {
        skybox2.enabled = false;
      } else {
        skybox2.enabled = true;
        skybox2.material = skybox.material;
      }
    }
    dest.farClipPlane = src.farClipPlane;
    dest.nearClipPlane = src.nearClipPlane;
    dest.orthographic = src.orthographic;
    dest.fieldOfView = src.fieldOfView;
    dest.aspect = src.aspect;
    dest.orthographicSize = src.orthographicSize;
  }

  // Token: 0x060005C5 RID: 1477 RVA: 0x0004FDF8 File Offset: 0x0004E1F8
  private void CreateMirrorObjects(Camera currentCamera, out Camera reflectionCamera) {
    reflectionCamera = null;
    if (!this.m_ReflectionTexture || this.m_OldReflectionTextureSize != this.m_TextureSize) {
      if (this.m_ReflectionTexture) {
        UnityEngine.Object.DestroyImmediate(this.m_ReflectionTexture);
      }
      this.m_ReflectionTexture = new RenderTexture(this.m_TextureSize, this.m_TextureSize, 16);
      this.m_ReflectionTexture.name = "__MirrorReflection" + base.GetInstanceID();
      this.m_ReflectionTexture.isPowerOfTwo = true;
      this.m_ReflectionTexture.hideFlags = HideFlags.DontSave;
      this.m_OldReflectionTextureSize = this.m_TextureSize;
    }
    reflectionCamera = (this.m_ReflectionCameras[currentCamera] as Camera);
    if (!reflectionCamera) {
      GameObject gameObject = new GameObject(string.Concat(new object[]
      {
        "Mirror Refl Camera id",
        base.GetInstanceID(),
        " for ",
        currentCamera.GetInstanceID()
      }), new Type[]
      {
        typeof(Camera),
        typeof(Skybox)
      });
      reflectionCamera = gameObject.GetComponent<Camera>();
      reflectionCamera.enabled = false;
      reflectionCamera.transform.position = base.transform.position;
      reflectionCamera.transform.rotation = base.transform.rotation;
      reflectionCamera.gameObject.AddComponent<FlareLayer>();
      gameObject.hideFlags = HideFlags.HideAndDontSave;
      this.m_ReflectionCameras[currentCamera] = reflectionCamera;
    }
  }

  // Token: 0x060005C6 RID: 1478 RVA: 0x0004FF7F File Offset: 0x0004E37F
  private static float sgn(float a) {
    if (a > 0f) {
      return 1f;
    }
    if (a < 0f) {
      return -1f;
    }
    return 0f;
  }

  // Token: 0x060005C7 RID: 1479 RVA: 0x0004FFA8 File Offset: 0x0004E3A8
  private Vector4 CameraSpacePlane(Camera cam, Vector3 pos, Vector3 normal, float sideSign) {
    Vector3 v = pos + normal * this.m_ClipPlaneOffset;
    Matrix4x4 worldToCameraMatrix = cam.worldToCameraMatrix;
    Vector3 lhs = worldToCameraMatrix.MultiplyPoint(v);
    Vector3 rhs = worldToCameraMatrix.MultiplyVector(normal).normalized * sideSign;
    return new Vector4(rhs.x, rhs.y, rhs.z, -Vector3.Dot(lhs, rhs));
  }

  // Token: 0x060005C8 RID: 1480 RVA: 0x00050014 File Offset: 0x0004E414
  private static void CalculateReflectionMatrix(ref Matrix4x4 reflectionMat, Vector4 plane) {
    reflectionMat.m00 = 1f - 2f * plane[0] * plane[0];
    reflectionMat.m01 = -2f * plane[0] * plane[1];
    reflectionMat.m02 = -2f * plane[0] * plane[2];
    reflectionMat.m03 = -2f * plane[3] * plane[0];
    reflectionMat.m10 = -2f * plane[1] * plane[0];
    reflectionMat.m11 = 1f - 2f * plane[1] * plane[1];
    reflectionMat.m12 = -2f * plane[1] * plane[2];
    reflectionMat.m13 = -2f * plane[3] * plane[1];
    reflectionMat.m20 = -2f * plane[2] * plane[0];
    reflectionMat.m21 = -2f * plane[2] * plane[1];
    reflectionMat.m22 = 1f - 2f * plane[2] * plane[2];
    reflectionMat.m23 = -2f * plane[3] * plane[2];
    reflectionMat.m30 = 0f;
    reflectionMat.m31 = 0f;
    reflectionMat.m32 = 0f;
    reflectionMat.m33 = 1f;
  }

  // Token: 0x04000DC6 RID: 3526
  public bool m_DisablePixelLights = true;

  // Token: 0x04000DC7 RID: 3527
  public int m_TextureSize = 256;

  // Token: 0x04000DC8 RID: 3528
  public float m_ClipPlaneOffset = 0.07f;

  // Token: 0x04000DC9 RID: 3529
  public LayerMask m_ReflectLayers = -1;

  // Token: 0x04000DCA RID: 3530
  private Hashtable m_ReflectionCameras = new Hashtable();

  // Token: 0x04000DCB RID: 3531
  private RenderTexture m_ReflectionTexture;

  // Token: 0x04000DCC RID: 3532
  private int m_OldReflectionTextureSize;

  // Token: 0x04000DCD RID: 3533
  private static bool s_InsideRendering;
}