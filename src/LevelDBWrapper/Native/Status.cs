/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 1.3.40
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace LevelDBWrapper.Native {

using System;
using System.Runtime.InteropServices;

public class Status : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Status(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(Status obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~Status() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          LeveldbPINVOKE.delete_Status(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public bool IsReady() {
    bool ret = LeveldbPINVOKE.Status_IsReady(swigCPtr);
    return ret;
  }

  public bool IsNotFound() {
    bool ret = LeveldbPINVOKE.Status_IsNotFound(swigCPtr);
    return ret;
  }

  public string ToString() {
    string ret = LeveldbPINVOKE.Status_ToString(swigCPtr);
    return ret;
  }

  public Status() : this(LeveldbPINVOKE.new_Status(), true) {
  }

}

}
