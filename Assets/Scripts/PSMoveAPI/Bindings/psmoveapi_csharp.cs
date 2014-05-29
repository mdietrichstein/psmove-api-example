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

public class psmoveapi_csharp {
  public static PSMove_Bool psmove_init(PSMove_Version version) {
    PSMove_Bool ret = (PSMove_Bool)psmoveapi_csharpPINVOKE.psmove_init((int)version);
    return ret;
  }

  public static void psmove_set_remote_config(RemoteConfig config) {
    psmoveapi_csharpPINVOKE.psmove_set_remote_config((int)config);
  }

  public static int psmove_count_connected() {
    int ret = psmoveapi_csharpPINVOKE.psmove_count_connected();
    return ret;
  }

  public static PSMove psmove_connect() {
    IntPtr cPtr = psmoveapi_csharpPINVOKE.psmove_connect();
    PSMove ret = (cPtr == IntPtr.Zero) ? null : new PSMove(cPtr, false);
    return ret;
  }

  public static PSMove psmove_connect_by_id(int id) {
    IntPtr cPtr = psmoveapi_csharpPINVOKE.psmove_connect_by_id(id);
    PSMove ret = (cPtr == IntPtr.Zero) ? null : new PSMove(cPtr, false);
    return ret;
  }

  public static ConnectionType psmove_connection_type(PSMove move) {
    ConnectionType ret = (ConnectionType)psmoveapi_csharpPINVOKE.psmove_connection_type(PSMove.getCPtr(move));
    return ret;
  }

  public static PSMove_Bool psmove_is_remote(PSMove move) {
    PSMove_Bool ret = (PSMove_Bool)psmoveapi_csharpPINVOKE.psmove_is_remote(PSMove.getCPtr(move));
    return ret;
  }

  public static string psmove_get_serial(PSMove move) {
    string ret = psmoveapi_csharpPINVOKE.psmove_get_serial(PSMove.getCPtr(move));
    return ret;
  }

  public static PSMove_Bool psmove_pair(PSMove move) {
    PSMove_Bool ret = (PSMove_Bool)psmoveapi_csharpPINVOKE.psmove_pair(PSMove.getCPtr(move));
    return ret;
  }

  public static PSMove_Bool psmove_pair_custom(PSMove move, string btaddr_string) {
    PSMove_Bool ret = (PSMove_Bool)psmoveapi_csharpPINVOKE.psmove_pair_custom(PSMove.getCPtr(move), btaddr_string);
    return ret;
  }

  public static void psmove_set_rate_limiting(PSMove move, PSMove_Bool enabled) {
    psmoveapi_csharpPINVOKE.psmove_set_rate_limiting(PSMove.getCPtr(move), (int)enabled);
  }

  public static void psmove_set_leds(PSMove move, byte r, byte g, byte b) {
    psmoveapi_csharpPINVOKE.psmove_set_leds(PSMove.getCPtr(move), r, g, b);
  }

  public static void psmove_set_rumble(PSMove move, byte rumble) {
    psmoveapi_csharpPINVOKE.psmove_set_rumble(PSMove.getCPtr(move), rumble);
  }

  public static PSMove_Update_Result psmove_update_leds(PSMove move) {
    PSMove_Update_Result ret = (PSMove_Update_Result)psmoveapi_csharpPINVOKE.psmove_update_leds(PSMove.getCPtr(move));
    return ret;
  }

  public static int psmove_poll(PSMove move) {
    int ret = psmoveapi_csharpPINVOKE.psmove_poll(PSMove.getCPtr(move));
    return ret;
  }

  public static uint psmove_get_buttons(PSMove move) {
    uint ret = psmoveapi_csharpPINVOKE.psmove_get_buttons(PSMove.getCPtr(move));
    return ret;
  }

  public static void psmove_get_button_events(PSMove move, SWIGTYPE_p_unsigned_int pressed, SWIGTYPE_p_unsigned_int released) {
    psmoveapi_csharpPINVOKE.psmove_get_button_events(PSMove.getCPtr(move), SWIGTYPE_p_unsigned_int.getCPtr(pressed), SWIGTYPE_p_unsigned_int.getCPtr(released));
  }

  public static BatteryLevel psmove_get_battery(PSMove move) {
    BatteryLevel ret = (BatteryLevel)psmoveapi_csharpPINVOKE.psmove_get_battery(PSMove.getCPtr(move));
    return ret;
  }

  public static int psmove_get_temperature(PSMove move) {
    int ret = psmoveapi_csharpPINVOKE.psmove_get_temperature(PSMove.getCPtr(move));
    return ret;
  }

  public static float psmove_get_temperature_in_celsius(PSMove move) {
    float ret = psmoveapi_csharpPINVOKE.psmove_get_temperature_in_celsius(PSMove.getCPtr(move));
    return ret;
  }

  public static byte psmove_get_trigger(PSMove move) {
    byte ret = psmoveapi_csharpPINVOKE.psmove_get_trigger(PSMove.getCPtr(move));
    return ret;
  }

  public static void psmove_get_accelerometer(PSMove move, SWIGTYPE_p_int ax, SWIGTYPE_p_int ay, SWIGTYPE_p_int az) {
    psmoveapi_csharpPINVOKE.psmove_get_accelerometer(PSMove.getCPtr(move), SWIGTYPE_p_int.getCPtr(ax), SWIGTYPE_p_int.getCPtr(ay), SWIGTYPE_p_int.getCPtr(az));
  }

  public static void psmove_get_gyroscope(PSMove move, SWIGTYPE_p_int gx, SWIGTYPE_p_int gy, SWIGTYPE_p_int gz) {
    psmoveapi_csharpPINVOKE.psmove_get_gyroscope(PSMove.getCPtr(move), SWIGTYPE_p_int.getCPtr(gx), SWIGTYPE_p_int.getCPtr(gy), SWIGTYPE_p_int.getCPtr(gz));
  }

  public static void psmove_get_magnetometer(PSMove move, SWIGTYPE_p_int mx, SWIGTYPE_p_int my, SWIGTYPE_p_int mz) {
    psmoveapi_csharpPINVOKE.psmove_get_magnetometer(PSMove.getCPtr(move), SWIGTYPE_p_int.getCPtr(mx), SWIGTYPE_p_int.getCPtr(my), SWIGTYPE_p_int.getCPtr(mz));
  }

  public static void psmove_get_accelerometer_frame(PSMove move, Frame frame, SWIGTYPE_p_float ax, SWIGTYPE_p_float ay, SWIGTYPE_p_float az) {
    psmoveapi_csharpPINVOKE.psmove_get_accelerometer_frame(PSMove.getCPtr(move), (int)frame, SWIGTYPE_p_float.getCPtr(ax), SWIGTYPE_p_float.getCPtr(ay), SWIGTYPE_p_float.getCPtr(az));
  }

  public static void psmove_get_gyroscope_frame(PSMove move, Frame frame, SWIGTYPE_p_float gx, SWIGTYPE_p_float gy, SWIGTYPE_p_float gz) {
    psmoveapi_csharpPINVOKE.psmove_get_gyroscope_frame(PSMove.getCPtr(move), (int)frame, SWIGTYPE_p_float.getCPtr(gx), SWIGTYPE_p_float.getCPtr(gy), SWIGTYPE_p_float.getCPtr(gz));
  }

  public static void psmove_get_magnetometer_vector(PSMove move, SWIGTYPE_p_float mx, SWIGTYPE_p_float my, SWIGTYPE_p_float mz) {
    psmoveapi_csharpPINVOKE.psmove_get_magnetometer_vector(PSMove.getCPtr(move), SWIGTYPE_p_float.getCPtr(mx), SWIGTYPE_p_float.getCPtr(my), SWIGTYPE_p_float.getCPtr(mz));
  }

  public static PSMove_Bool psmove_has_calibration(PSMove move) {
    PSMove_Bool ret = (PSMove_Bool)psmoveapi_csharpPINVOKE.psmove_has_calibration(PSMove.getCPtr(move));
    return ret;
  }

  public static void psmove_dump_calibration(PSMove move) {
    psmoveapi_csharpPINVOKE.psmove_dump_calibration(PSMove.getCPtr(move));
  }

  public static void psmove_enable_orientation(PSMove move, PSMove_Bool enabled) {
    psmoveapi_csharpPINVOKE.psmove_enable_orientation(PSMove.getCPtr(move), (int)enabled);
  }

  public static PSMove_Bool psmove_has_orientation(PSMove move) {
    PSMove_Bool ret = (PSMove_Bool)psmoveapi_csharpPINVOKE.psmove_has_orientation(PSMove.getCPtr(move));
    return ret;
  }

  public static void psmove_get_orientation(PSMove move, SWIGTYPE_p_float w, SWIGTYPE_p_float x, SWIGTYPE_p_float y, SWIGTYPE_p_float z) {
    psmoveapi_csharpPINVOKE.psmove_get_orientation(PSMove.getCPtr(move), SWIGTYPE_p_float.getCPtr(w), SWIGTYPE_p_float.getCPtr(x), SWIGTYPE_p_float.getCPtr(y), SWIGTYPE_p_float.getCPtr(z));
  }

  public static void psmove_reset_orientation(PSMove move) {
    psmoveapi_csharpPINVOKE.psmove_reset_orientation(PSMove.getCPtr(move));
  }

  public static void psmove_reset_magnetometer_calibration(PSMove move) {
    psmoveapi_csharpPINVOKE.psmove_reset_magnetometer_calibration(PSMove.getCPtr(move));
  }

  public static void psmove_save_magnetometer_calibration(PSMove move) {
    psmoveapi_csharpPINVOKE.psmove_save_magnetometer_calibration(PSMove.getCPtr(move));
  }

  public static int psmove_get_magnetometer_calibration_range(PSMove move) {
    int ret = psmoveapi_csharpPINVOKE.psmove_get_magnetometer_calibration_range(PSMove.getCPtr(move));
    return ret;
  }

  public static void psmove_disconnect(PSMove move) {
    psmoveapi_csharpPINVOKE.psmove_disconnect(PSMove.getCPtr(move));
  }

  public static void psmove_reinit() {
    psmoveapi_csharpPINVOKE.psmove_reinit();
  }

  public static int psmove_util_get_ticks() {
    int ret = psmoveapi_csharpPINVOKE.psmove_util_get_ticks();
    return ret;
  }

  public static string psmove_util_get_data_dir() {
    string ret = psmoveapi_csharpPINVOKE.psmove_util_get_data_dir();
    return ret;
  }

  public static string psmove_util_get_file_path(string filename) {
    string ret = psmoveapi_csharpPINVOKE.psmove_util_get_file_path(filename);
    return ret;
  }

  public static string psmove_util_get_system_file_path(string filename) {
    string ret = psmoveapi_csharpPINVOKE.psmove_util_get_system_file_path(filename);
    return ret;
  }

  public static int psmove_util_get_env_int(string name) {
    int ret = psmoveapi_csharpPINVOKE.psmove_util_get_env_int(name);
    return ret;
  }

  public static string psmove_util_get_env_string(string name) {
    string ret = psmoveapi_csharpPINVOKE.psmove_util_get_env_string(name);
    return ret;
  }

  public static PSMoveTracker psmove_tracker_create_default() {
    IntPtr cPtr = psmoveapi_csharpPINVOKE.psmove_tracker_create_default();
    PSMoveTracker ret = (cPtr == IntPtr.Zero) ? null : new PSMoveTracker(cPtr, false);
    return ret;
  }

  public static PSMove psmove_tracker_exposure_lock_init() {
    IntPtr cPtr = psmoveapi_csharpPINVOKE.psmove_tracker_exposure_lock_init();
    PSMove ret = (cPtr == IntPtr.Zero) ? null : new PSMove(cPtr, false);
    return ret;
  }

  public static void psmove_tracker_exposure_lock_process(PSMove move, PSMoveTracker tracker, int camera) {
    psmoveapi_csharpPINVOKE.psmove_tracker_exposure_lock_process(PSMove.getCPtr(move), PSMoveTracker.getCPtr(tracker), camera);
  }

  public static void psmove_tracker_exposure_lock_finish(PSMove move) {
    psmoveapi_csharpPINVOKE.psmove_tracker_exposure_lock_finish(PSMove.getCPtr(move));
  }

  public static PSMoveTracker psmove_tracker_new() {
    IntPtr cPtr = psmoveapi_csharpPINVOKE.psmove_tracker_new();
    PSMoveTracker ret = (cPtr == IntPtr.Zero) ? null : new PSMoveTracker(cPtr, false);
    return ret;
  }

  public static PSMoveTracker psmove_tracker_new_with_camera(int camera) {
    IntPtr cPtr = psmoveapi_csharpPINVOKE.psmove_tracker_new_with_camera(camera);
    PSMoveTracker ret = (cPtr == IntPtr.Zero) ? null : new PSMoveTracker(cPtr, false);
    return ret;
  }

  public static void psmove_tracker_set_auto_update_leds(PSMoveTracker tracker, PSMove move, PSMove_Bool auto_update_leds) {
    psmoveapi_csharpPINVOKE.psmove_tracker_set_auto_update_leds(PSMoveTracker.getCPtr(tracker), PSMove.getCPtr(move), (int)auto_update_leds);
  }

  public static PSMove_Bool psmove_tracker_get_auto_update_leds(PSMoveTracker tracker, PSMove move) {
    PSMove_Bool ret = (PSMove_Bool)psmoveapi_csharpPINVOKE.psmove_tracker_get_auto_update_leds(PSMoveTracker.getCPtr(tracker), PSMove.getCPtr(move));
    return ret;
  }

  public static void psmove_tracker_set_dimming(PSMoveTracker tracker, float dimming) {
    psmoveapi_csharpPINVOKE.psmove_tracker_set_dimming(PSMoveTracker.getCPtr(tracker), dimming);
  }

  public static float psmove_tracker_get_dimming(PSMoveTracker tracker) {
    float ret = psmoveapi_csharpPINVOKE.psmove_tracker_get_dimming(PSMoveTracker.getCPtr(tracker));
    return ret;
  }

  public static void psmove_tracker_set_exposure(PSMoveTracker tracker, Exposure exposure) {
    psmoveapi_csharpPINVOKE.psmove_tracker_set_exposure(PSMoveTracker.getCPtr(tracker), (int)exposure);
  }

  public static Exposure psmove_tracker_get_exposure(PSMoveTracker tracker) {
    Exposure ret = (Exposure)psmoveapi_csharpPINVOKE.psmove_tracker_get_exposure(PSMoveTracker.getCPtr(tracker));
    return ret;
  }

  public static void psmove_tracker_enable_deinterlace(PSMoveTracker tracker, PSMove_Bool enabled) {
    psmoveapi_csharpPINVOKE.psmove_tracker_enable_deinterlace(PSMoveTracker.getCPtr(tracker), (int)enabled);
  }

  public static void psmove_tracker_set_mirror(PSMoveTracker tracker, PSMove_Bool enabled) {
    psmoveapi_csharpPINVOKE.psmove_tracker_set_mirror(PSMoveTracker.getCPtr(tracker), (int)enabled);
  }

  public static PSMove_Bool psmove_tracker_get_mirror(PSMoveTracker tracker) {
    PSMove_Bool ret = (PSMove_Bool)psmoveapi_csharpPINVOKE.psmove_tracker_get_mirror(PSMoveTracker.getCPtr(tracker));
    return ret;
  }

  public static Status psmove_tracker_enable(PSMoveTracker tracker, PSMove move) {
    Status ret = (Status)psmoveapi_csharpPINVOKE.psmove_tracker_enable(PSMoveTracker.getCPtr(tracker), PSMove.getCPtr(move));
    return ret;
  }

  public static Status psmove_tracker_enable_with_color(PSMoveTracker tracker, PSMove move, byte r, byte g, byte b) {
    Status ret = (Status)psmoveapi_csharpPINVOKE.psmove_tracker_enable_with_color(PSMoveTracker.getCPtr(tracker), PSMove.getCPtr(move), r, g, b);
    return ret;
  }

  public static void psmove_tracker_disable(PSMoveTracker tracker, PSMove move) {
    psmoveapi_csharpPINVOKE.psmove_tracker_disable(PSMoveTracker.getCPtr(tracker), PSMove.getCPtr(move));
  }

  public static int psmove_tracker_get_color(PSMoveTracker tracker, PSMove move, SWIGTYPE_p_unsigned_char r, SWIGTYPE_p_unsigned_char g, SWIGTYPE_p_unsigned_char b) {
    int ret = psmoveapi_csharpPINVOKE.psmove_tracker_get_color(PSMoveTracker.getCPtr(tracker), PSMove.getCPtr(move), SWIGTYPE_p_unsigned_char.getCPtr(r), SWIGTYPE_p_unsigned_char.getCPtr(g), SWIGTYPE_p_unsigned_char.getCPtr(b));
    return ret;
  }

  public static int psmove_tracker_get_camera_color(PSMoveTracker tracker, PSMove move, SWIGTYPE_p_unsigned_char r, SWIGTYPE_p_unsigned_char g, SWIGTYPE_p_unsigned_char b) {
    int ret = psmoveapi_csharpPINVOKE.psmove_tracker_get_camera_color(PSMoveTracker.getCPtr(tracker), PSMove.getCPtr(move), SWIGTYPE_p_unsigned_char.getCPtr(r), SWIGTYPE_p_unsigned_char.getCPtr(g), SWIGTYPE_p_unsigned_char.getCPtr(b));
    return ret;
  }

  public static int psmove_tracker_set_camera_color(PSMoveTracker tracker, PSMove move, byte r, byte g, byte b) {
    int ret = psmoveapi_csharpPINVOKE.psmove_tracker_set_camera_color(PSMoveTracker.getCPtr(tracker), PSMove.getCPtr(move), r, g, b);
    return ret;
  }

  public static Status psmove_tracker_get_status(PSMoveTracker tracker, PSMove move) {
    Status ret = (Status)psmoveapi_csharpPINVOKE.psmove_tracker_get_status(PSMoveTracker.getCPtr(tracker), PSMove.getCPtr(move));
    return ret;
  }

  public static void psmove_tracker_update_image(PSMoveTracker tracker) {
    psmoveapi_csharpPINVOKE.psmove_tracker_update_image(PSMoveTracker.getCPtr(tracker));
  }

  public static int psmove_tracker_update(PSMoveTracker tracker, PSMove move) {
    int ret = psmoveapi_csharpPINVOKE.psmove_tracker_update(PSMoveTracker.getCPtr(tracker), PSMove.getCPtr(move));
    return ret;
  }

  public static void psmove_tracker_annotate(PSMoveTracker tracker) {
    psmoveapi_csharpPINVOKE.psmove_tracker_annotate(PSMoveTracker.getCPtr(tracker));
  }

  public static SWIGTYPE_p_void psmove_tracker_get_frame(PSMoveTracker tracker) {
    IntPtr cPtr = psmoveapi_csharpPINVOKE.psmove_tracker_get_frame(PSMoveTracker.getCPtr(tracker));
    SWIGTYPE_p_void ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_void(cPtr, false);
    return ret;
  }

  public static PSMoveTrackerRGBImage psmove_tracker_get_image(PSMoveTracker tracker) {
    PSMoveTrackerRGBImage ret = new PSMoveTrackerRGBImage(psmoveapi_csharpPINVOKE.psmove_tracker_get_image(PSMoveTracker.getCPtr(tracker)), true);
    return ret;
  }

  public static int psmove_tracker_get_position(PSMoveTracker tracker, PSMove move, SWIGTYPE_p_float x, SWIGTYPE_p_float y, SWIGTYPE_p_float radius) {
    int ret = psmoveapi_csharpPINVOKE.psmove_tracker_get_position(PSMoveTracker.getCPtr(tracker), PSMove.getCPtr(move), SWIGTYPE_p_float.getCPtr(x), SWIGTYPE_p_float.getCPtr(y), SWIGTYPE_p_float.getCPtr(radius));
    return ret;
  }

  public static void psmove_tracker_get_size(PSMoveTracker tracker, SWIGTYPE_p_int width, SWIGTYPE_p_int height) {
    psmoveapi_csharpPINVOKE.psmove_tracker_get_size(PSMoveTracker.getCPtr(tracker), SWIGTYPE_p_int.getCPtr(width), SWIGTYPE_p_int.getCPtr(height));
  }

  public static float psmove_tracker_distance_from_radius(PSMoveTracker tracker, float radius) {
    float ret = psmoveapi_csharpPINVOKE.psmove_tracker_distance_from_radius(PSMoveTracker.getCPtr(tracker), radius);
    return ret;
  }

  public static void psmove_tracker_set_distance_parameters(PSMoveTracker tracker, float height, float center, float hwhm, float shape) {
    psmoveapi_csharpPINVOKE.psmove_tracker_set_distance_parameters(PSMoveTracker.getCPtr(tracker), height, center, hwhm, shape);
  }

  public static void psmove_tracker_free(PSMoveTracker tracker) {
    psmoveapi_csharpPINVOKE.psmove_tracker_free(PSMoveTracker.getCPtr(tracker));
  }

  public static PSMoveFusion psmove_fusion_new(PSMoveTracker tracker, float z_near, float z_far) {
    IntPtr cPtr = psmoveapi_csharpPINVOKE.psmove_fusion_new(PSMoveTracker.getCPtr(tracker), z_near, z_far);
    PSMoveFusion ret = (cPtr == IntPtr.Zero) ? null : new PSMoveFusion(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_float psmove_fusion_get_projection_matrix(PSMoveFusion fusion) {
    IntPtr cPtr = psmoveapi_csharpPINVOKE.psmove_fusion_get_projection_matrix(PSMoveFusion.getCPtr(fusion));
    SWIGTYPE_p_float ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr, false);
    return ret;
  }

  public static SWIGTYPE_p_float psmove_fusion_get_modelview_matrix(PSMoveFusion fusion, PSMove move) {
    IntPtr cPtr = psmoveapi_csharpPINVOKE.psmove_fusion_get_modelview_matrix(PSMoveFusion.getCPtr(fusion), PSMove.getCPtr(move));
    SWIGTYPE_p_float ret = (cPtr == IntPtr.Zero) ? null : new SWIGTYPE_p_float(cPtr, false);
    return ret;
  }

  public static void psmove_fusion_get_position(PSMoveFusion fusion, PSMove move, SWIGTYPE_p_float x, SWIGTYPE_p_float y, SWIGTYPE_p_float z) {
    psmoveapi_csharpPINVOKE.psmove_fusion_get_position(PSMoveFusion.getCPtr(fusion), PSMove.getCPtr(move), SWIGTYPE_p_float.getCPtr(x), SWIGTYPE_p_float.getCPtr(y), SWIGTYPE_p_float.getCPtr(z));
  }

  public static void psmove_fusion_free(PSMoveFusion fusion) {
    psmoveapi_csharpPINVOKE.psmove_fusion_free(PSMoveFusion.getCPtr(fusion));
  }

  public static int init(PSMove_Version version) {
    int ret = psmoveapi_csharpPINVOKE.init((int)version);
    return ret;
  }

  public static void set_remote_config(RemoteConfig config) {
    psmoveapi_csharpPINVOKE.set_remote_config((int)config);
  }

  public static int count_connected() {
    int ret = psmoveapi_csharpPINVOKE.count_connected();
    return ret;
  }

  public static void reinit() {
    psmoveapi_csharpPINVOKE.reinit();
  }

  public static readonly int PSMOVE_TRACKER_DEFAULT_WIDTH = psmoveapi_csharpPINVOKE.PSMOVE_TRACKER_DEFAULT_WIDTH_get();
  public static readonly int PSMOVE_TRACKER_DEFAULT_HEIGHT = psmoveapi_csharpPINVOKE.PSMOVE_TRACKER_DEFAULT_HEIGHT_get();
  public static readonly int PSMOVE_TRACKER_MAX_CONTROLLERS = psmoveapi_csharpPINVOKE.PSMOVE_TRACKER_MAX_CONTROLLERS_get();
  public static readonly string PSMOVE_TRACKER_CAMERA_ENV = psmoveapi_csharpPINVOKE.PSMOVE_TRACKER_CAMERA_ENV_get();
  public static readonly string PSMOVE_TRACKER_FILENAME_ENV = psmoveapi_csharpPINVOKE.PSMOVE_TRACKER_FILENAME_ENV_get();
  public static readonly string PSMOVE_TRACKER_ROI_SIZE_ENV = psmoveapi_csharpPINVOKE.PSMOVE_TRACKER_ROI_SIZE_ENV_get();
  public static readonly string PSMOVE_TRACKER_COLOR_ENV = psmoveapi_csharpPINVOKE.PSMOVE_TRACKER_COLOR_ENV_get();
  public static readonly string PSMOVE_TRACKER_WIDTH_ENV = psmoveapi_csharpPINVOKE.PSMOVE_TRACKER_WIDTH_ENV_get();
  public static readonly string PSMOVE_TRACKER_HEIGHT_ENV = psmoveapi_csharpPINVOKE.PSMOVE_TRACKER_HEIGHT_ENV_get();
  public static readonly int PSEYE_FOV_BLUE_DOT = psmoveapi_csharpPINVOKE.PSEYE_FOV_BLUE_DOT_get();
  public static readonly int PSEYE_FOV_RED_DOT = psmoveapi_csharpPINVOKE.PSEYE_FOV_RED_DOT_get();
}

}
