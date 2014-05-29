/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.8
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace io.thp.psmove {

using System;
using System.Runtime.InteropServices;

public class PSMoveTracker : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal PSMoveTracker(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(PSMoveTracker obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~PSMoveTracker() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          psmoveapi_csharpPINVOKE.delete_PSMoveTracker(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public float dimming {
    set {
      psmoveapi_csharpPINVOKE.PSMoveTracker_dimming_set(swigCPtr, value);
    } 
    get {
      float ret = psmoveapi_csharpPINVOKE.PSMoveTracker_dimming_get(swigCPtr);
      return ret;
    } 
  }

  public Exposure exposure {
    set {
      psmoveapi_csharpPINVOKE.PSMoveTracker_exposure_set(swigCPtr, (int)value);
    } 
    get {
      Exposure ret = (Exposure)psmoveapi_csharpPINVOKE.PSMoveTracker_exposure_get(swigCPtr);
      return ret;
    } 
  }

  public PSMoveTracker() : this(psmoveapi_csharpPINVOKE.new_PSMoveTracker__SWIG_0(), true) {
  }

  public PSMoveTracker(int camera) : this(psmoveapi_csharpPINVOKE.new_PSMoveTracker__SWIG_1(camera), true) {
  }

  public Status enable(PSMove move) {
    Status ret = (Status)psmoveapi_csharpPINVOKE.PSMoveTracker_enable(swigCPtr, PSMove.getCPtr(move));
    return ret;
  }

  public Status enable_with_color(PSMove move, int r, int g, int b) {
    Status ret = (Status)psmoveapi_csharpPINVOKE.PSMoveTracker_enable_with_color(swigCPtr, PSMove.getCPtr(move), r, g, b);
    return ret;
  }

  public void annotate() {
    psmoveapi_csharpPINVOKE.PSMoveTracker_annotate(swigCPtr);
  }

  public void disable(PSMove move) {
    psmoveapi_csharpPINVOKE.PSMoveTracker_disable(swigCPtr, PSMove.getCPtr(move));
  }

  public void set_auto_update_leds(PSMove move, int auto_update_leds) {
    psmoveapi_csharpPINVOKE.PSMoveTracker_set_auto_update_leds(swigCPtr, PSMove.getCPtr(move), auto_update_leds);
  }

  public int get_auto_update_leds(PSMove move) {
    int ret = psmoveapi_csharpPINVOKE.PSMoveTracker_get_auto_update_leds(swigCPtr, PSMove.getCPtr(move));
    return ret;
  }

  public void get_color(PSMove move, out byte arg1, out byte arg2, out byte arg3) {
    psmoveapi_csharpPINVOKE.PSMoveTracker_get_color(swigCPtr, PSMove.getCPtr(move), out arg1, out arg2, out arg3);
  }

  public void get_camera_color(PSMove move, out byte arg1, out byte arg2, out byte arg3) {
    psmoveapi_csharpPINVOKE.PSMoveTracker_get_camera_color(swigCPtr, PSMove.getCPtr(move), out arg1, out arg2, out arg3);
  }

  public int set_camera_color(PSMove move, byte r, byte g, byte b) {
    int ret = psmoveapi_csharpPINVOKE.PSMoveTracker_set_camera_color(swigCPtr, PSMove.getCPtr(move), r, g, b);
    return ret;
  }

  public void enable_deinterlace(int enabled) {
    psmoveapi_csharpPINVOKE.PSMoveTracker_enable_deinterlace(swigCPtr, enabled);
  }

  public void set_mirror(int enabled) {
    psmoveapi_csharpPINVOKE.PSMoveTracker_set_mirror(swigCPtr, enabled);
  }

  public int get_mirror() {
    int ret = psmoveapi_csharpPINVOKE.PSMoveTracker_get_mirror(swigCPtr);
    return ret;
  }

  public Status get_status(PSMove move) {
    Status ret = (Status)psmoveapi_csharpPINVOKE.PSMoveTracker_get_status(swigCPtr, PSMove.getCPtr(move));
    return ret;
  }

  public void update_image() {
    psmoveapi_csharpPINVOKE.PSMoveTracker_update_image(swigCPtr);
  }

  public int update() {
    int ret = psmoveapi_csharpPINVOKE.PSMoveTracker_update__SWIG_0(swigCPtr);
    return ret;
  }

  public int update(PSMove move) {
    int ret = psmoveapi_csharpPINVOKE.PSMoveTracker_update__SWIG_1(swigCPtr, PSMove.getCPtr(move));
    return ret;
  }

  public PSMoveTrackerRGBImage get_image() {
    PSMoveTrackerRGBImage ret = new PSMoveTrackerRGBImage(psmoveapi_csharpPINVOKE.PSMoveTracker_get_image(swigCPtr), true);
    return ret;
  }

  public void get_position(PSMove move, out float arg1, out float arg2, out float arg3) {
    psmoveapi_csharpPINVOKE.PSMoveTracker_get_position(swigCPtr, PSMove.getCPtr(move), out arg1, out arg2, out arg3);
  }

  public void get_size(out int arg0, out int arg1) {
    psmoveapi_csharpPINVOKE.PSMoveTracker_get_size(swigCPtr, out arg0, out arg1);
  }

  public float distance_from_radius(float radius) {
    float ret = psmoveapi_csharpPINVOKE.PSMoveTracker_distance_from_radius(swigCPtr, radius);
    return ret;
  }

  public void set_distance_parameters(float height, float center, float hwhm, float shape) {
    psmoveapi_csharpPINVOKE.PSMoveTracker_set_distance_parameters(swigCPtr, height, center, hwhm, shape);
  }

}

}
