/* Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
*  Copyright :     Copyright � Nequeo Pty Ltd 2016 http://www.nequeo.com.au/
*
*  File :          MediaMetadata.cpp
*  Purpose :       MediaMetadata class.
*
*/

/*
Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.
*/

#include "stdafx.h"

#include "MediaMetadata.h"

using namespace Nequeo::Media::FFmpeg;

/// <summary>
/// Media meta data.
/// </summary>
MediaMetadata::MediaMetadata() :
	_disposed(false)
{
	libffmpeg::av_register_all();
}

/// <summary>
/// Disposes the object and frees its resources.
/// </summary>
MediaMetadata::~MediaMetadata()
{
	// If not disposed.
	if (!_disposed)
	{
		this->!MediaMetadata();
		_disposed = true;
	}
}

/// <summary>
/// Object's finalizer.
/// </summary>
MediaMetadata::!MediaMetadata()
{
	// If not disposed.
	if (!_disposed)
	{
	}
}

/// <summary>
/// Get the metadata for the media file.
/// </summary>
/// <param name="inputFile">Audio video file name to get metadata for.</param>
/// <return>The collection of name and value media metadata.</return>
array<Nequeo::Model::NameValue^>^ MediaMetadata::Open(String^ inputFile)
{
	int ret;
	bool success = false;
	List<Nequeo::Model::NameValue^>^ nameValues = gcnew List<Nequeo::Model::NameValue^>();
	
	// convert specified managed String to unmanaged string
	IntPtr ptrSourceFile = System::Runtime::InteropServices::Marshal::StringToHGlobalUni(inputFile);
	wchar_t* nativeSourceFileNameUnicode = (wchar_t*)ptrSourceFile.ToPointer();
	int utf8StringSizeSource = WideCharToMultiByte(CP_UTF8, 0, nativeSourceFileNameUnicode, -1, NULL, 0, NULL, NULL);
	char* nativeSourceFileName = new char[utf8StringSizeSource];
	WideCharToMultiByte(CP_UTF8, 0, nativeSourceFileNameUnicode, -1, nativeSourceFileName, utf8StringSizeSource, NULL, NULL);

	libffmpeg::AVFormatContext *fmt_ctx = NULL;
	libffmpeg::AVDictionaryEntry *tag = NULL;

	try
	{
		// Open the file.
		if ((ret = avformat_open_input(&fmt_ctx, nativeSourceFileName, NULL, NULL) < 0))
			throw gcnew Exception("Could not open input file.");

		// While more meta data exists.
		while ((tag = av_dict_get(fmt_ctx->metadata, "", tag, AV_DICT_IGNORE_SUFFIX)))
		{
			// Create a new name value item.
			Nequeo::Model::NameValue^ nameValue = gcnew Nequeo::Model::NameValue();
			nameValue->Name = gcnew String(tag->key);
			nameValue->Value = gcnew String(tag->value);

			// Add the item.
			nameValues->Add(nameValue);
		}

		// All is good.
		success = true;

		// Return the collection.
		return nameValues->ToArray();
	}
	finally
	{
		System::Runtime::InteropServices::Marshal::FreeHGlobal(ptrSourceFile);
		delete[] nativeSourceFileName;

		// If context exists.
		if (fmt_ctx)
		{
			// Close the format context.
			libffmpeg::avformat_close_input(&fmt_ctx);
		}
	}
}