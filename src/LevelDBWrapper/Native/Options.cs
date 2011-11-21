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

public class Options : IDisposable {
  private HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Options(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new HandleRef(this, cPtr);
  }

  internal static HandleRef getCPtr(Options obj) {
    return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
  }

  ~Options() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          LeveldbPINVOKE.delete_Options(swigCPtr);
        }
        swigCPtr = new HandleRef(null, IntPtr.Zero);
      }
      GC.SuppressFinalize(this);
    }
  }

  public Options() : this(LeveldbPINVOKE.new_Options(), true) {
  }

  public bool CreateIfMissing {
    set {
      LeveldbPINVOKE.Options_CreateIfMissing_set(swigCPtr, value);
    } 
    get {
      bool ret = LeveldbPINVOKE.Options_CreateIfMissing_get(swigCPtr);
      return ret;
    } 
  }

  public bool ErrorIfExists {
    set {
      LeveldbPINVOKE.Options_ErrorIfExists_set(swigCPtr, value);
    } 
    get {
      bool ret = LeveldbPINVOKE.Options_ErrorIfExists_get(swigCPtr);
      return ret;
    } 
  }

  public bool ParanoidChecks {
    set {
      LeveldbPINVOKE.Options_ParanoidChecks_set(swigCPtr, value);
    } 
    get {
      bool ret = LeveldbPINVOKE.Options_ParanoidChecks_get(swigCPtr);
      return ret;
    } 
  }

  public uint WriteBufferSize {
    set {
      LeveldbPINVOKE.Options_WriteBufferSize_set(swigCPtr, value);
    } 
    get {
      uint ret = LeveldbPINVOKE.Options_WriteBufferSize_get(swigCPtr);
      return ret;
    } 
  }

  public int MaxOpenFiles {
    set {
      LeveldbPINVOKE.Options_MaxOpenFiles_set(swigCPtr, value);
    } 
    get {
      int ret = LeveldbPINVOKE.Options_MaxOpenFiles_get(swigCPtr);
      return ret;
    } 
  }

  public uint BlockSize {
    set {
      LeveldbPINVOKE.Options_BlockSize_set(swigCPtr, value);
    } 
    get {
      uint ret = LeveldbPINVOKE.Options_BlockSize_get(swigCPtr);
      return ret;
    } 
  }

  public int BlockRestartInterval {
    set {
      LeveldbPINVOKE.Options_BlockRestartInterval_set(swigCPtr, value);
    } 
    get {
      int ret = LeveldbPINVOKE.Options_BlockRestartInterval_get(swigCPtr);
      return ret;
    } 
  }

  public CompressionType Compression {
    set {
      LeveldbPINVOKE.Options_Compression_set(swigCPtr, (int)value);
    } 
    get {
      CompressionType ret = (CompressionType)LeveldbPINVOKE.Options_Compression_get(swigCPtr);
      return ret;
    } 
  }

}

}
