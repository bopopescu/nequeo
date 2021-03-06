// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "targetver.h"

#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers
// Windows Header Files:

#include <windows.h>
#include <string.h>
#include <exception>
#include <stdio.h>
#include <stdexcept>
#include <vector>
#include <algorithm>
#include <memory>
#include <complex>
#include <sstream>
#include <iostream>

#ifdef NEQUEOMEDIAWINDOW_EXPORTS
#define EXPORT_NEQUEO_MEDIA_WINDOW_API __declspec(dllexport) 
#else
#define EXPORT_NEQUEO_MEDIA_WINDOW_API __declspec(dllimport) 
#endif