========================================================================
    MICROSOFT FOUNDATION CLASS LIBRARY : NequeoMediaFoundation Project Overview
========================================================================


AppWizard has created this NequeoMediaFoundation DLL for you.  This DLL not only
demonstrates the basics of using the Microsoft Foundation classes but
is also a starting point for writing your DLL.

This file contains a summary of what you will find in each of the files that
make up your NequeoMediaFoundation DLL.

NequeoMediaFoundation.vcxproj
    This is the main project file for VC++ projects generated using an Application Wizard.
    It contains information about the version of Visual C++ that generated the file, and
    information about the platforms, configurations, and project features selected with the
    Application Wizard.

NequeoMediaFoundation.vcxproj.filters
    This is the filters file for VC++ projects generated using an Application Wizard. 
    It contains information about the association between the files in your project 
    and the filters. This association is used in the IDE to show grouping of files with
    similar extensions under a specific node (for e.g. ".cpp" files are associated with the
    "Source Files" filter).

NequeoMediaFoundation.h
    This is the main header file for the DLL.  It declares the
    CNequeoMediaFoundationApp class.

NequeoMediaFoundation.cpp
    This is the main DLL source file.  It contains the class CNequeoMediaFoundationApp.

NequeoMediaFoundation.rc
    This is a listing of all of the Microsoft Windows resources that the
    program uses.  It includes the icons, bitmaps, and cursors that are stored
    in the RES subdirectory.  This file can be directly edited in Microsoft
    Visual C++.

res\NequeoMediaFoundation.rc2
    This file contains resources that are not edited by Microsoft
    Visual C++.  You should place all resources not editable by
    the resource editor in this file.

NequeoMediaFoundation.def
    This file contains information about the DLL that must be
    provided to run with Microsoft Windows.  It defines parameters
    such as the name and description of the DLL.  It also exports
    functions from the DLL.

/////////////////////////////////////////////////////////////////////////////
Other standard files:

StdAfx.h, StdAfx.cpp
    These files are used to build a precompiled header (PCH) file
    named NequeoMediaFoundation.pch and a precompiled types file named StdAfx.obj.

Resource.h
    This is the standard header file, which defines new resource IDs.
    Microsoft Visual C++ reads and updates this file.

/////////////////////////////////////////////////////////////////////////////
Other notes:

AppWizard uses "TODO:" to indicate parts of the source code you
should add to or customize.

/////////////////////////////////////////////////////////////////////////////

/////////////////////////////////////////////////////////////////////////////
MP3 Capture Configuration
ep.audio.collectionIndex = 0;
ep.audio.subtypeReader = { 0 };
ep.audio.subtype = MFAudioFormat_MP3;
ep.audio.transcode = MFTranscodeContainerType_MP3;
ep.audio.bitsPerSample = 0;
ep.audio.channels = 2
ep.audio.sampleRate = 32000;
ep.audio.blockAlign = 1;
ep.audio.bytesPerSecond = 40000;
////////////////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////////////////////
MP4 Capture Configuration
ep.audio.collectionIndex = -1;
ep.audio.subtypeReader = { 0 };
ep.audio.subtype = MFAudioFormat_AAC;
ep.audio.transcode = MFTranscodeContainerType_WAVE;
ep.audio.bitsPerSample = 16;
ep.audio.channels = 2;
ep.audio.sampleRate = 44100;
ep.audio.blockAlign = 0;
ep.audio.bytesPerSecond = 12000;

ep.video.subtype = MFVideoFormat_H264;
ep.video.subtypeReader = { 0 };
ep.video.transcode = MFTranscodeContainerType_FMPEG4;
ep.video.bitRate = 400000;
ep.video.frameSize.width = 320;
ep.video.frameSize.height = 240;
ep.video.frameRate.denominator = 1;
ep.video.frameRate.numerator = 30;
ep.video.aspectRatio.denominator = 1;
ep.video.aspectRatio.numerator = 1;
////////////////////////////////////////////////////////////////////////////