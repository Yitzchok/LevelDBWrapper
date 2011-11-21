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

public class DBIterator : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal DBIterator(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(DBIterator obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~DBIterator() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          LeveldbPINVOKE.delete_DBIterator(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public bool valid() {
    bool ret = LeveldbPINVOKE.DBIterator_valid(swigCPtr);
    return ret;
  }

  public void seekToFirst() {
    LeveldbPINVOKE.DBIterator_seekToFirst(swigCPtr);
  }

  public void seekToLast() {
    LeveldbPINVOKE.DBIterator_seekToLast(swigCPtr);
  }

  public void seek(string str) {
    LeveldbPINVOKE.DBIterator_seek(swigCPtr, str);
    if (LeveldbPINVOKE.SWIGPendingException.Pending) throw LeveldbPINVOKE.SWIGPendingException.Retrieve();
  }

  public void next() {
    LeveldbPINVOKE.DBIterator_next(swigCPtr);
  }

  public void prev() {
    LeveldbPINVOKE.DBIterator_prev(swigCPtr);
  }

  public string key() {
    string ret = LeveldbPINVOKE.DBIterator_key(swigCPtr);
    return ret;
  }

  public string value() {
    string ret = LeveldbPINVOKE.DBIterator_value(swigCPtr);
    return ret;
  }

  public Status status() {
    Status ret = new Status(LeveldbPINVOKE.DBIterator_status(swigCPtr), true);
    return ret;
  }

}

}
