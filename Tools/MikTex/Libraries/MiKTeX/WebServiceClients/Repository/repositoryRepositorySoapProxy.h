/* repositoryRepositorySoapProxy.h
   Generated by gSOAP 2.8.29 for Repository.h

gSOAP XML Web services tools
Copyright (C) 2000-2016, Robert van Engelen, Genivia Inc. All Rights Reserved.
The soapcpp2 tool and its generated software are released under the GPL.
This program is released under the GPL with the additional exemption that
compiling, linking, and/or using OpenSSL is allowed.
--------------------------------------------------------------------------------
A commercial use license is available from Genivia Inc., contact@genivia.com
--------------------------------------------------------------------------------
*/

#ifndef repositoryRepositorySoapProxy_H
#define repositoryRepositorySoapProxy_H
#include "repositoryH.h"

    class SOAP_CMAC RepositorySoapProxy : public soap {
      public:
        /// Endpoint URL of service 'RepositorySoapProxy' (change as needed)
        const char *soap_endpoint;
        /// Variables globally declared in Repository.h, if any
        /// Construct a proxy with new managing context
        RepositorySoapProxy();
        /// Copy constructor
        RepositorySoapProxy(const RepositorySoapProxy& rhs);
        /// Construct proxy given a managing context
        RepositorySoapProxy(const struct soap&);
        /// Constructor taking an endpoint URL
        RepositorySoapProxy(const char *endpoint);
        /// Constructor taking input and output mode flags for the new managing context
        RepositorySoapProxy(soap_mode iomode);
        /// Constructor taking endpoint URL and input and output mode flags for the new managing context
        RepositorySoapProxy(const char *endpoint, soap_mode iomode);
        /// Constructor taking input and output mode flags for the new managing context
        RepositorySoapProxy(soap_mode imode, soap_mode omode);
        /// Destructor deletes deserialized data and managing context
        virtual ~RepositorySoapProxy();
        /// Initializer used by constructors
        virtual void RepositorySoapProxy_init(soap_mode imode, soap_mode omode);
        /// Return a copy that has a new managing context with the same engine state
        virtual RepositorySoapProxy *copy() SOAP_PURE_VIRTUAL;
        /// Copy assignment
        RepositorySoapProxy& operator=(const RepositorySoapProxy&);
        /// Delete all deserialized data (uses soap_destroy() and soap_end())
        virtual void destroy();
        /// Delete all deserialized data and reset to default
        virtual void reset();
        /// Disables and removes SOAP Header from message by setting soap->header = NULL
        virtual void soap_noheader();
        /// Get SOAP Header structure (i.e. soap->header, which is NULL when absent)
        virtual const SOAP_ENV__Header *soap_header();
        /// Get SOAP Fault structure (i.e. soap->fault, which is NULL when absent)
        virtual const SOAP_ENV__Fault *soap_fault();
        /// Get SOAP Fault string (NULL when absent)
        virtual const char *soap_fault_string();
        /// Get SOAP Fault detail as string (NULL when absent)
        virtual const char *soap_fault_detail();
        /// Close connection (normally automatic, except for send_X ops)
        virtual int soap_close_socket();
        /// Force close connection (can kill a thread blocked on IO)
        virtual int soap_force_close_socket();
        /// Print fault
        virtual void soap_print_fault(FILE*);
    #ifndef WITH_LEAN
    #ifndef WITH_COMPAT
        /// Print fault to stream
        virtual void soap_stream_fault(std::ostream&);
    #endif
        /// Write fault to buffer
        virtual char *soap_sprint_fault(char *buf, size_t len);
    #endif
        /// Web service operation 'TryGetRepositoryInfo' (returns SOAP_OK or error code)
        virtual int TryGetRepositoryInfo(_mtrep__TryGetRepositoryInfo *mtrep__TryGetRepositoryInfo, _mtrep__TryGetRepositoryInfoResponse &mtrep__TryGetRepositoryInfoResponse)
        { return this->TryGetRepositoryInfo(NULL, NULL, mtrep__TryGetRepositoryInfo, mtrep__TryGetRepositoryInfoResponse); }
        virtual int TryGetRepositoryInfo(const char *soap_endpoint, const char *soap_action, _mtrep__TryGetRepositoryInfo *mtrep__TryGetRepositoryInfo, _mtrep__TryGetRepositoryInfoResponse &mtrep__TryGetRepositoryInfoResponse);
        /// Web service operation 'PickRepository' (returns SOAP_OK or error code)
        virtual int PickRepository(_mtrep__PickRepository *mtrep__PickRepository, _mtrep__PickRepositoryResponse &mtrep__PickRepositoryResponse)
        { return this->PickRepository(NULL, NULL, mtrep__PickRepository, mtrep__PickRepositoryResponse); }
        virtual int PickRepository(const char *soap_endpoint, const char *soap_action, _mtrep__PickRepository *mtrep__PickRepository, _mtrep__PickRepositoryResponse &mtrep__PickRepositoryResponse);
        /// Web service operation 'GetAllRepositories' (returns SOAP_OK or error code)
        virtual int GetAllRepositories(_mtrep__GetAllRepositories *mtrep__GetAllRepositories, _mtrep__GetAllRepositoriesResponse &mtrep__GetAllRepositoriesResponse)
        { return this->GetAllRepositories(NULL, NULL, mtrep__GetAllRepositories, mtrep__GetAllRepositoriesResponse); }
        virtual int GetAllRepositories(const char *soap_endpoint, const char *soap_action, _mtrep__GetAllRepositories *mtrep__GetAllRepositories, _mtrep__GetAllRepositoriesResponse &mtrep__GetAllRepositoriesResponse);
        /// Web service operation 'GetRepositories' (returns SOAP_OK or error code)
        virtual int GetRepositories(_mtrep__GetRepositories *mtrep__GetRepositories, _mtrep__GetRepositoriesResponse &mtrep__GetRepositoriesResponse)
        { return this->GetRepositories(NULL, NULL, mtrep__GetRepositories, mtrep__GetRepositoriesResponse); }
        virtual int GetRepositories(const char *soap_endpoint, const char *soap_action, _mtrep__GetRepositories *mtrep__GetRepositories, _mtrep__GetRepositoriesResponse &mtrep__GetRepositoriesResponse);
        /// Web service operation 'GetListCreationTime' (returns SOAP_OK or error code)
        virtual int GetListCreationTime(_mtrep2__GetListCreationTime *mtrep2__GetListCreationTime, _mtrep2__GetListCreationTimeResponse &mtrep2__GetListCreationTimeResponse)
        { return this->GetListCreationTime(NULL, NULL, mtrep2__GetListCreationTime, mtrep2__GetListCreationTimeResponse); }
        virtual int GetListCreationTime(const char *soap_endpoint, const char *soap_action, _mtrep2__GetListCreationTime *mtrep2__GetListCreationTime, _mtrep2__GetListCreationTimeResponse &mtrep2__GetListCreationTimeResponse);
        /// Web service operation 'GetRepositories2' (returns SOAP_OK or error code)
        virtual int GetRepositories2(_mtrep3__GetRepositories2 *mtrep3__GetRepositories2, _mtrep3__GetRepositories2Response &mtrep3__GetRepositories2Response)
        { return this->GetRepositories2(NULL, NULL, mtrep3__GetRepositories2, mtrep3__GetRepositories2Response); }
        virtual int GetRepositories2(const char *soap_endpoint, const char *soap_action, _mtrep3__GetRepositories2 *mtrep3__GetRepositories2, _mtrep3__GetRepositories2Response &mtrep3__GetRepositories2Response);
        /// Web service operation 'PickRepository2' (returns SOAP_OK or error code)
        virtual int PickRepository2(_mtrep3__PickRepository2 *mtrep3__PickRepository2, _mtrep3__PickRepository2Response &mtrep3__PickRepository2Response)
        { return this->PickRepository2(NULL, NULL, mtrep3__PickRepository2, mtrep3__PickRepository2Response); }
        virtual int PickRepository2(const char *soap_endpoint, const char *soap_action, _mtrep3__PickRepository2 *mtrep3__PickRepository2, _mtrep3__PickRepository2Response &mtrep3__PickRepository2Response);
        /// Web service operation 'TryGetRepositoryInfo2' (returns SOAP_OK or error code)
        virtual int TryGetRepositoryInfo2(_mtrep3__TryGetRepositoryInfo2 *mtrep3__TryGetRepositoryInfo2, _mtrep3__TryGetRepositoryInfo2Response &mtrep3__TryGetRepositoryInfo2Response)
        { return this->TryGetRepositoryInfo2(NULL, NULL, mtrep3__TryGetRepositoryInfo2, mtrep3__TryGetRepositoryInfo2Response); }
        virtual int TryGetRepositoryInfo2(const char *soap_endpoint, const char *soap_action, _mtrep3__TryGetRepositoryInfo2 *mtrep3__TryGetRepositoryInfo2, _mtrep3__TryGetRepositoryInfo2Response &mtrep3__TryGetRepositoryInfo2Response);
        /// Web service operation 'VerifyRepository' (returns SOAP_OK or error code)
        virtual int VerifyRepository(_mtrep4__VerifyRepository *mtrep4__VerifyRepository, _mtrep4__VerifyRepositoryResponse &mtrep4__VerifyRepositoryResponse)
        { return this->VerifyRepository(NULL, NULL, mtrep4__VerifyRepository, mtrep4__VerifyRepositoryResponse); }
        virtual int VerifyRepository(const char *soap_endpoint, const char *soap_action, _mtrep4__VerifyRepository *mtrep4__VerifyRepository, _mtrep4__VerifyRepositoryResponse &mtrep4__VerifyRepositoryResponse);
        /// Web service operation 'GetRepositories3' (returns SOAP_OK or error code)
        virtual int GetRepositories3(_mtrep5__GetRepositories3 *mtrep5__GetRepositories3, _mtrep5__GetRepositories3Response &mtrep5__GetRepositories3Response)
        { return this->GetRepositories3(NULL, NULL, mtrep5__GetRepositories3, mtrep5__GetRepositories3Response); }
        virtual int GetRepositories3(const char *soap_endpoint, const char *soap_action, _mtrep5__GetRepositories3 *mtrep5__GetRepositories3, _mtrep5__GetRepositories3Response &mtrep5__GetRepositories3Response);
        /// Web service operation 'PickRepository3' (returns SOAP_OK or error code)
        virtual int PickRepository3(_mtrep5__PickRepository3 *mtrep5__PickRepository3, _mtrep5__PickRepository3Response &mtrep5__PickRepository3Response)
        { return this->PickRepository3(NULL, NULL, mtrep5__PickRepository3, mtrep5__PickRepository3Response); }
        virtual int PickRepository3(const char *soap_endpoint, const char *soap_action, _mtrep5__PickRepository3 *mtrep5__PickRepository3, _mtrep5__PickRepository3Response &mtrep5__PickRepository3Response);
        /// Web service operation 'GetRepositories4' (returns SOAP_OK or error code)
        virtual int GetRepositories4(_mtrep6__GetRepositories4 *mtrep6__GetRepositories4, _mtrep6__GetRepositories4Response &mtrep6__GetRepositories4Response)
        { return this->GetRepositories4(NULL, NULL, mtrep6__GetRepositories4, mtrep6__GetRepositories4Response); }
        virtual int GetRepositories4(const char *soap_endpoint, const char *soap_action, _mtrep6__GetRepositories4 *mtrep6__GetRepositories4, _mtrep6__GetRepositories4Response &mtrep6__GetRepositories4Response);
        /// Web service operation 'PickRepository4' (returns SOAP_OK or error code)
        virtual int PickRepository4(_mtrep6__PickRepository4 *mtrep6__PickRepository4, _mtrep6__PickRepository4Response &mtrep6__PickRepository4Response)
        { return this->PickRepository4(NULL, NULL, mtrep6__PickRepository4, mtrep6__PickRepository4Response); }
        virtual int PickRepository4(const char *soap_endpoint, const char *soap_action, _mtrep6__PickRepository4 *mtrep6__PickRepository4, _mtrep6__PickRepository4Response &mtrep6__PickRepository4Response);
        /// Web service operation 'VerifyRepository2' (returns SOAP_OK or error code)
        virtual int VerifyRepository2(_mtrep7__VerifyRepository2 *mtrep7__VerifyRepository2, _mtrep7__VerifyRepository2Response &mtrep7__VerifyRepository2Response)
        { return this->VerifyRepository2(NULL, NULL, mtrep7__VerifyRepository2, mtrep7__VerifyRepository2Response); }
        virtual int VerifyRepository2(const char *soap_endpoint, const char *soap_action, _mtrep7__VerifyRepository2 *mtrep7__VerifyRepository2, _mtrep7__VerifyRepository2Response &mtrep7__VerifyRepository2Response);
        /// Web service operation 'TryGetRepositoryInfo3' (returns SOAP_OK or error code)
        virtual int TryGetRepositoryInfo3(_mtrep7__TryGetRepositoryInfo3 *mtrep7__TryGetRepositoryInfo3, _mtrep7__TryGetRepositoryInfo3Response &mtrep7__TryGetRepositoryInfo3Response)
        { return this->TryGetRepositoryInfo3(NULL, NULL, mtrep7__TryGetRepositoryInfo3, mtrep7__TryGetRepositoryInfo3Response); }
        virtual int TryGetRepositoryInfo3(const char *soap_endpoint, const char *soap_action, _mtrep7__TryGetRepositoryInfo3 *mtrep7__TryGetRepositoryInfo3, _mtrep7__TryGetRepositoryInfo3Response &mtrep7__TryGetRepositoryInfo3Response);
        /// Web service operation 'TryGetRepositoryInfo' (returns SOAP_OK or error code)
        virtual int TryGetRepositoryInfo_(_mtrep__TryGetRepositoryInfo *mtrep__TryGetRepositoryInfo, _mtrep__TryGetRepositoryInfoResponse &mtrep__TryGetRepositoryInfoResponse)
        { return this->TryGetRepositoryInfo_(NULL, NULL, mtrep__TryGetRepositoryInfo, mtrep__TryGetRepositoryInfoResponse); }
        virtual int TryGetRepositoryInfo_(const char *soap_endpoint, const char *soap_action, _mtrep__TryGetRepositoryInfo *mtrep__TryGetRepositoryInfo, _mtrep__TryGetRepositoryInfoResponse &mtrep__TryGetRepositoryInfoResponse);
        /// Web service operation 'PickRepository' (returns SOAP_OK or error code)
        virtual int PickRepository_(_mtrep__PickRepository *mtrep__PickRepository, _mtrep__PickRepositoryResponse &mtrep__PickRepositoryResponse)
        { return this->PickRepository_(NULL, NULL, mtrep__PickRepository, mtrep__PickRepositoryResponse); }
        virtual int PickRepository_(const char *soap_endpoint, const char *soap_action, _mtrep__PickRepository *mtrep__PickRepository, _mtrep__PickRepositoryResponse &mtrep__PickRepositoryResponse);
        /// Web service operation 'GetAllRepositories' (returns SOAP_OK or error code)
        virtual int GetAllRepositories_(_mtrep__GetAllRepositories *mtrep__GetAllRepositories, _mtrep__GetAllRepositoriesResponse &mtrep__GetAllRepositoriesResponse)
        { return this->GetAllRepositories_(NULL, NULL, mtrep__GetAllRepositories, mtrep__GetAllRepositoriesResponse); }
        virtual int GetAllRepositories_(const char *soap_endpoint, const char *soap_action, _mtrep__GetAllRepositories *mtrep__GetAllRepositories, _mtrep__GetAllRepositoriesResponse &mtrep__GetAllRepositoriesResponse);
        /// Web service operation 'GetRepositories' (returns SOAP_OK or error code)
        virtual int GetRepositories_(_mtrep__GetRepositories *mtrep__GetRepositories, _mtrep__GetRepositoriesResponse &mtrep__GetRepositoriesResponse)
        { return this->GetRepositories_(NULL, NULL, mtrep__GetRepositories, mtrep__GetRepositoriesResponse); }
        virtual int GetRepositories_(const char *soap_endpoint, const char *soap_action, _mtrep__GetRepositories *mtrep__GetRepositories, _mtrep__GetRepositoriesResponse &mtrep__GetRepositoriesResponse);
        /// Web service operation 'GetListCreationTime' (returns SOAP_OK or error code)
        virtual int GetListCreationTime_(_mtrep2__GetListCreationTime *mtrep2__GetListCreationTime, _mtrep2__GetListCreationTimeResponse &mtrep2__GetListCreationTimeResponse)
        { return this->GetListCreationTime_(NULL, NULL, mtrep2__GetListCreationTime, mtrep2__GetListCreationTimeResponse); }
        virtual int GetListCreationTime_(const char *soap_endpoint, const char *soap_action, _mtrep2__GetListCreationTime *mtrep2__GetListCreationTime, _mtrep2__GetListCreationTimeResponse &mtrep2__GetListCreationTimeResponse);
        /// Web service operation 'GetRepositories2' (returns SOAP_OK or error code)
        virtual int GetRepositories2_(_mtrep3__GetRepositories2 *mtrep3__GetRepositories2, _mtrep3__GetRepositories2Response &mtrep3__GetRepositories2Response)
        { return this->GetRepositories2_(NULL, NULL, mtrep3__GetRepositories2, mtrep3__GetRepositories2Response); }
        virtual int GetRepositories2_(const char *soap_endpoint, const char *soap_action, _mtrep3__GetRepositories2 *mtrep3__GetRepositories2, _mtrep3__GetRepositories2Response &mtrep3__GetRepositories2Response);
        /// Web service operation 'PickRepository2' (returns SOAP_OK or error code)
        virtual int PickRepository2_(_mtrep3__PickRepository2 *mtrep3__PickRepository2, _mtrep3__PickRepository2Response &mtrep3__PickRepository2Response)
        { return this->PickRepository2_(NULL, NULL, mtrep3__PickRepository2, mtrep3__PickRepository2Response); }
        virtual int PickRepository2_(const char *soap_endpoint, const char *soap_action, _mtrep3__PickRepository2 *mtrep3__PickRepository2, _mtrep3__PickRepository2Response &mtrep3__PickRepository2Response);
        /// Web service operation 'TryGetRepositoryInfo2' (returns SOAP_OK or error code)
        virtual int TryGetRepositoryInfo2_(_mtrep3__TryGetRepositoryInfo2 *mtrep3__TryGetRepositoryInfo2, _mtrep3__TryGetRepositoryInfo2Response &mtrep3__TryGetRepositoryInfo2Response)
        { return this->TryGetRepositoryInfo2_(NULL, NULL, mtrep3__TryGetRepositoryInfo2, mtrep3__TryGetRepositoryInfo2Response); }
        virtual int TryGetRepositoryInfo2_(const char *soap_endpoint, const char *soap_action, _mtrep3__TryGetRepositoryInfo2 *mtrep3__TryGetRepositoryInfo2, _mtrep3__TryGetRepositoryInfo2Response &mtrep3__TryGetRepositoryInfo2Response);
        /// Web service operation 'VerifyRepository' (returns SOAP_OK or error code)
        virtual int VerifyRepository_(_mtrep4__VerifyRepository *mtrep4__VerifyRepository, _mtrep4__VerifyRepositoryResponse &mtrep4__VerifyRepositoryResponse)
        { return this->VerifyRepository_(NULL, NULL, mtrep4__VerifyRepository, mtrep4__VerifyRepositoryResponse); }
        virtual int VerifyRepository_(const char *soap_endpoint, const char *soap_action, _mtrep4__VerifyRepository *mtrep4__VerifyRepository, _mtrep4__VerifyRepositoryResponse &mtrep4__VerifyRepositoryResponse);
        /// Web service operation 'GetRepositories3' (returns SOAP_OK or error code)
        virtual int GetRepositories3_(_mtrep5__GetRepositories3 *mtrep5__GetRepositories3, _mtrep5__GetRepositories3Response &mtrep5__GetRepositories3Response)
        { return this->GetRepositories3_(NULL, NULL, mtrep5__GetRepositories3, mtrep5__GetRepositories3Response); }
        virtual int GetRepositories3_(const char *soap_endpoint, const char *soap_action, _mtrep5__GetRepositories3 *mtrep5__GetRepositories3, _mtrep5__GetRepositories3Response &mtrep5__GetRepositories3Response);
        /// Web service operation 'PickRepository3' (returns SOAP_OK or error code)
        virtual int PickRepository3_(_mtrep5__PickRepository3 *mtrep5__PickRepository3, _mtrep5__PickRepository3Response &mtrep5__PickRepository3Response)
        { return this->PickRepository3_(NULL, NULL, mtrep5__PickRepository3, mtrep5__PickRepository3Response); }
        virtual int PickRepository3_(const char *soap_endpoint, const char *soap_action, _mtrep5__PickRepository3 *mtrep5__PickRepository3, _mtrep5__PickRepository3Response &mtrep5__PickRepository3Response);
        /// Web service operation 'GetRepositories4' (returns SOAP_OK or error code)
        virtual int GetRepositories4_(_mtrep6__GetRepositories4 *mtrep6__GetRepositories4, _mtrep6__GetRepositories4Response &mtrep6__GetRepositories4Response)
        { return this->GetRepositories4_(NULL, NULL, mtrep6__GetRepositories4, mtrep6__GetRepositories4Response); }
        virtual int GetRepositories4_(const char *soap_endpoint, const char *soap_action, _mtrep6__GetRepositories4 *mtrep6__GetRepositories4, _mtrep6__GetRepositories4Response &mtrep6__GetRepositories4Response);
        /// Web service operation 'PickRepository4' (returns SOAP_OK or error code)
        virtual int PickRepository4_(_mtrep6__PickRepository4 *mtrep6__PickRepository4, _mtrep6__PickRepository4Response &mtrep6__PickRepository4Response)
        { return this->PickRepository4_(NULL, NULL, mtrep6__PickRepository4, mtrep6__PickRepository4Response); }
        virtual int PickRepository4_(const char *soap_endpoint, const char *soap_action, _mtrep6__PickRepository4 *mtrep6__PickRepository4, _mtrep6__PickRepository4Response &mtrep6__PickRepository4Response);
        /// Web service operation 'VerifyRepository2' (returns SOAP_OK or error code)
        virtual int VerifyRepository2_(_mtrep7__VerifyRepository2 *mtrep7__VerifyRepository2, _mtrep7__VerifyRepository2Response &mtrep7__VerifyRepository2Response)
        { return this->VerifyRepository2_(NULL, NULL, mtrep7__VerifyRepository2, mtrep7__VerifyRepository2Response); }
        virtual int VerifyRepository2_(const char *soap_endpoint, const char *soap_action, _mtrep7__VerifyRepository2 *mtrep7__VerifyRepository2, _mtrep7__VerifyRepository2Response &mtrep7__VerifyRepository2Response);
        /// Web service operation 'TryGetRepositoryInfo3' (returns SOAP_OK or error code)
        virtual int TryGetRepositoryInfo3_(_mtrep7__TryGetRepositoryInfo3 *mtrep7__TryGetRepositoryInfo3, _mtrep7__TryGetRepositoryInfo3Response &mtrep7__TryGetRepositoryInfo3Response)
        { return this->TryGetRepositoryInfo3_(NULL, NULL, mtrep7__TryGetRepositoryInfo3, mtrep7__TryGetRepositoryInfo3Response); }
        virtual int TryGetRepositoryInfo3_(const char *soap_endpoint, const char *soap_action, _mtrep7__TryGetRepositoryInfo3 *mtrep7__TryGetRepositoryInfo3, _mtrep7__TryGetRepositoryInfo3Response &mtrep7__TryGetRepositoryInfo3Response);
    };
#endif
