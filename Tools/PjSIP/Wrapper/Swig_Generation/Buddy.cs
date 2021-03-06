//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.7
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------


public class Buddy : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Buddy(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Buddy obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Buddy() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          pjsua2PINVOKE.delete_Buddy(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public Buddy() : this(pjsua2PINVOKE.new_Buddy(), true) {
  }

  public void create(Account acc, BuddyConfig cfg) {
    pjsua2PINVOKE.Buddy_create(swigCPtr, Account.getCPtr(acc), BuddyConfig.getCPtr(cfg));
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public bool isValid() {
    bool ret = pjsua2PINVOKE.Buddy_isValid(swigCPtr);
    return ret;
  }

  public BuddyInfo getInfo() {
    BuddyInfo ret = new BuddyInfo(pjsua2PINVOKE.Buddy_getInfo(swigCPtr), true);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void subscribePresence(bool subscribe) {
    pjsua2PINVOKE.Buddy_subscribePresence(swigCPtr, subscribe);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public void updatePresence() {
    pjsua2PINVOKE.Buddy_updatePresence(swigCPtr);
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public void sendInstantMessage(SWIGTYPE_p_SendInstantMessageParam prm) {
    pjsua2PINVOKE.Buddy_sendInstantMessage(swigCPtr, SWIGTYPE_p_SendInstantMessageParam.getCPtr(prm));
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public void sendTypingIndication(SWIGTYPE_p_SendTypingIndicationParam prm) {
    pjsua2PINVOKE.Buddy_sendTypingIndication(swigCPtr, SWIGTYPE_p_SendTypingIndicationParam.getCPtr(prm));
    if (pjsua2PINVOKE.SWIGPendingException.Pending) throw pjsua2PINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual void onBuddyState() {
    pjsua2PINVOKE.Buddy_onBuddyState(swigCPtr);
  }

}
