/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 1.3.40
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */

namespace Native
{

    using System;
    using System.Runtime.InteropServices;

    public class DBAccessor : IDisposable
    {
        private HandleRef swigCPtr;
        protected bool swigCMemOwn;

        internal DBAccessor(IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new HandleRef(this, cPtr);
        }

        internal static HandleRef getCPtr(DBAccessor obj)
        {
            return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
        }

        ~DBAccessor()
        {
            Dispose();
        }

        public virtual void Dispose()
        {
            lock (this)
            {
                if (swigCPtr.Handle != IntPtr.Zero)
                {
                    if (swigCMemOwn)
                    {
                        swigCMemOwn = false;
                        LeveldbPINVOKE.delete_DBAccessor(swigCPtr);
                    }
                    swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        public Status lastStatus
        {
            set
            {
                LeveldbPINVOKE.DBAccessor_lastStatus_set(swigCPtr, Status.getCPtr(value));
            }
            get
            {
                IntPtr cPtr = LeveldbPINVOKE.DBAccessor_lastStatus_get(swigCPtr);
                Status ret = (cPtr == IntPtr.Zero) ? null : new Status(cPtr, false);
                return ret;
            }
        }

        public Status open(Options options, string name)
        {
            Status ret = new Status(LeveldbPINVOKE.DBAccessor_open(swigCPtr, Options.getCPtr(options), name), true);
            if (LeveldbPINVOKE.SWIGPendingException.Pending) throw LeveldbPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public string get(ReadOptions options, string key)
        {
            string ret = LeveldbPINVOKE.DBAccessor_get(swigCPtr, ReadOptions.getCPtr(options), key);
            if (LeveldbPINVOKE.SWIGPendingException.Pending) throw LeveldbPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Status write(WriteOptions options, DBWriteBatch updates)
        {
            Status ret = new Status(LeveldbPINVOKE.DBAccessor_write(swigCPtr, WriteOptions.getCPtr(options), DBWriteBatch.getCPtr(updates)), true);
            if (LeveldbPINVOKE.SWIGPendingException.Pending) throw LeveldbPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Status put(WriteOptions options, string key, string value)
        {
            Status ret = new Status(LeveldbPINVOKE.DBAccessor_put(swigCPtr, WriteOptions.getCPtr(options), key, value), true);
            if (LeveldbPINVOKE.SWIGPendingException.Pending) throw LeveldbPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Status remove(WriteOptions options, string key)
        {
            Status ret = new Status(LeveldbPINVOKE.DBAccessor_remove(swigCPtr, WriteOptions.getCPtr(options), key), true);
            if (LeveldbPINVOKE.SWIGPendingException.Pending) throw LeveldbPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public DBIterator newIterator(ReadOptions options)
        {
            IntPtr cPtr = LeveldbPINVOKE.DBAccessor_newIterator(swigCPtr, ReadOptions.getCPtr(options));
            DBIterator ret = (cPtr == IntPtr.Zero) ? null : new DBIterator(cPtr, false);
            if (LeveldbPINVOKE.SWIGPendingException.Pending) throw LeveldbPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public Snapshot getSnapshot()
        {
            IntPtr cPtr = LeveldbPINVOKE.DBAccessor_getSnapshot(swigCPtr);
            Snapshot ret = (cPtr == IntPtr.Zero) ? null : new Snapshot(cPtr, false);
            return ret;
        }

        public void releaseSnapshot(Snapshot snapshot)
        {
            LeveldbPINVOKE.DBAccessor_releaseSnapshot(swigCPtr, Snapshot.getCPtr(snapshot));
        }

        public string getProperty(string property)
        {
            string ret = LeveldbPINVOKE.DBAccessor_getProperty(swigCPtr, property);
            if (LeveldbPINVOKE.SWIGPendingException.Pending) throw LeveldbPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public DBAccessor()
            : this(LeveldbPINVOKE.new_DBAccessor(), true)
        {
        }

    }

}
