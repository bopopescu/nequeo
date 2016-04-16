/* Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
*  Copyright :     Copyright � Nequeo Pty Ltd 2016 http://www.nequeo.com.au/
*
*  File :          VideoFileWriter.h
*  Purpose :       VideoFileWriter class.
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

#pragma once

#ifndef _VIDEOFILEWRITER_H
#define _VIDEOFILEWRITER_H

#include "stdafx.h"

#include "VideoCodec.h"
#include "WriterVideoPrivateData.h"
#include "VideoException.h"

using namespace System;
using namespace System::Drawing;
using namespace System::Drawing::Imaging;

namespace Nequeo
{
	namespace Media
	{
		namespace FFmpeg
		{
			/// <summary>
			/// Class for writing video files utilizing FFmpeg library.
			/// </summary>
			///
			/// <remarks><para>The class allows to write video files using <a href="http://www.ffmpeg.org/">FFmpeg</a> library.</para>
			///
			/// <para><note>Make sure you have <b>FFmpeg</b> binaries (DLLs) in the output folder of your application in order
			/// to use this class successfully. <b>FFmpeg</b> binaries can be found in Externals folder provided with AForge.NET
			/// framework's distribution.</note></para>
			///
			/// <para>Sample usage:</para>
			/// <code>
			/// int width  = 320;
			/// int height = 240;
			/// 
			/// // create instance of video writer
			/// VideoFileWriter writer = new VideoFileWriter( );
			/// // create new video file
			/// writer.Open( "test.avi", width, height, 25, VideoCodec.MPEG4 );
			/// // create a bitmap to save into the video file
			/// Bitmap image = new Bitmap( width, height, PixelFormat.Format24bppRgb );
			/// // write 1000 video frames
			/// for ( int i = 0; i &lt; 1000; i++ )
			/// {
			///     image.SetPixel( i % width, i % height, Color.Red );
			///     writer.WriteVideoFrame( image );
			/// }
			/// writer.Close( );
			/// </code>
			/// </remarks>
			public ref class VideoFileWriter : IDisposable
			{
			public:
				/// <summary>
				/// Initializes a new instance of the <see cref="VideoFileWriter"/> class.
				/// </summary>
				/// 
				VideoFileWriter();

				/// <summary>
				/// Disposes the object and frees its resources.
				/// </summary>
				/// 
				~VideoFileWriter()
				{
					if (!_disposed)
					{
						this->!VideoFileWriter();
						_disposed = true;
					}
				}

				/// <summary>
				/// Frame width of the opened video file.
				/// </summary>
				///
				/// <exception cref="System::IO::IOException">Thrown if no video file was open.</exception>
				///
				property int Width
				{
					int get()
					{
						CheckIfVideoFileIsOpen();
						return m_width;
					}
				}

				/// <summary>
				/// Frame height of the opened video file.
				/// </summary>
				///
				/// <exception cref="System::IO::IOException">Thrown if no video file was open.</exception>
				///
				property int Height
				{
					int get()
					{
						CheckIfVideoFileIsOpen();
						return m_height;
					}
				}

				/// <summary>
				/// Frame rate of the opened video file.
				/// </summary>
				///
				/// <exception cref="System::IO::IOException">Thrown if no video file was open.</exception>
				///
				property int FrameRate
				{
					int get()
					{
						CheckIfVideoFileIsOpen();
						return m_frameRate;
					}
				}

				/// <summary>
				/// Bit rate of the video stream.
				/// </summary>
				///
				/// <exception cref="System::IO::IOException">Thrown if no video file was open.</exception>
				///
				property int BitRate
				{
					int get()
					{
						CheckIfVideoFileIsOpen();
						return m_bitRate;
					}
				}

				/// <summary>
				/// Codec to use for the video file.
				/// </summary>
				///
				/// <exception cref="System::IO::IOException">Thrown if no video file was open.</exception>
				///
				property VideoCodec Codec
				{
					VideoCodec get()
					{
						CheckIfVideoFileIsOpen();
						return m_codec;
					}
				}

				/// <summary>
				/// The property specifies if a video file is opened or not by this instance of the class.
				/// </summary>
				property bool IsOpen
				{
					bool get()
					{
						return (data != nullptr);
					}
				}

			protected:

				/// <summary>
				/// Object's finalizer.
				/// </summary>
				/// 
				!VideoFileWriter()
				{
					Close();
				}

			public:

				/// <summary>
				/// Create video file with the specified name and attributes.
				/// </summary>
				///
				/// <param name="fileName">Video file name to create.</param>
				/// <param name="width">Frame width of the video file.</param>
				/// <param name="height">Frame height of the video file.</param>
				///
				/// <remarks><para>See documentation to the <see cref="Open( String^, int, int, int, VideoCodec )" />
				/// for more information and the list of possible exceptions.</para>
				///
				/// <para><note>The method opens the video file using <see cref="VideoCodec::Default" />
				/// codec and 25 fps frame rate.</note></para>
				/// </remarks>
				///
				void Open(String^ fileName, int width, int height);

				/// <summary>
				/// Create video file with the specified name and attributes.
				/// </summary>
				///
				/// <param name="fileName">Video file name to create.</param>
				/// <param name="width">Frame width of the video file.</param>
				/// <param name="height">Frame height of the video file.</param>
				/// <param name="frameRate">Frame rate of the video file.</param>
				///
				/// <remarks><para>See documentation to the <see cref="Open( String^, int, int, int, VideoCodec )" />
				/// for more information and the list of possible exceptions.</para>
				///
				/// <para><note>The method opens the video file using <see cref="VideoCodec::Default" />
				/// codec.</note></para>
				/// </remarks>
				///
				void Open(String^ fileName, int width, int height, int frameRate);

				/// <summary>
				/// Create video file with the specified name and attributes.
				/// </summary>
				///
				/// <param name="fileName">Video file name to create.</param>
				/// <param name="width">Frame width of the video file.</param>
				/// <param name="height">Frame height of the video file.</param>
				/// <param name="frameRate">Frame rate of the video file.</param>
				/// <param name="codec">Video codec to use for compression.</param>
				///
				/// <remarks><para>The methods creates new video file with the specified name.
				/// If a file with such name already exists in the file system, it will be overwritten.</para>
				///
				/// <para>When adding new video frames using <see cref="WriteVideoFrame(Bitmap^ frame)"/> method,
				/// the video frame must have width and height as specified during file opening.</para>
				/// </remarks>
				///
				/// <exception cref="ArgumentException">Video file resolution must be a multiple of two.</exception>
				/// <exception cref="ArgumentException">Invalid video codec is specified.</exception>
				/// <exception cref="VideoException">A error occurred while creating new video file. See exception message.</exception>
				/// <exception cref="System::IO::IOException">Cannot open video file with the specified name.</exception>
				/// 
				void Open(String^ fileName, int width, int height, int frameRate, VideoCodec codec);

				/// <summary>
				/// Create video file with the specified name and attributes.
				/// </summary>
				///
				/// <param name="fileName">Video file name to create.</param>
				/// <param name="width">Frame width of the video file.</param>
				/// <param name="height">Frame height of the video file.</param>
				/// <param name="frameRate">Frame rate of the video file.</param>
				/// <param name="codec">Video codec to use for compression.</param>
				/// <param name="bitRate">Bit rate of the video stream.</param>
				///
				/// <remarks><para>The methods creates new video file with the specified name.
				/// If a file with such name already exists in the file system, it will be overwritten.</para>
				///
				/// <para>When adding new video frames using <see cref="WriteVideoFrame(Bitmap^ frame)"/> method,
				/// the video frame must have width and height as specified during file opening.</para>
				///
				/// <para><note>The bit rate parameter represents a trade-off value between video quality
				/// and video file size. Higher bit rate value increase video quality and result in larger
				/// file size. Smaller values result in opposite � worse quality and small video files.</note></para>
				/// </remarks>
				///
				/// <exception cref="ArgumentException">Video file resolution must be a multiple of two.</exception>
				/// <exception cref="ArgumentException">Invalid video codec is specified.</exception>
				/// <exception cref="VideoException">A error occurred while creating new video file. See exception message.</exception>
				/// <exception cref="System::IO::IOException">Cannot open video file with the specified name.</exception>
				/// 
				void Open(String^ fileName, int width, int height, int frameRate, VideoCodec codec, int bitRate);

				/// <summary>
				/// Write new video frame into currently opened video file.
				/// </summary>
				///
				/// <param name="frame">Bitmap to add as a new video frame.</param>
				///
				/// <remarks><para>The specified bitmap must be either color 24 or 32 bpp image or grayscale 8 bpp (indexed) image.</para>
				/// </remarks>
				///
				/// <exception cref="System::IO::IOException">Thrown if no video file was open.</exception>
				/// <exception cref="ArgumentException">The provided bitmap must be 24 or 32 bpp color image or 8 bpp grayscale image.</exception>
				/// <exception cref="ArgumentException">Bitmap size must be of the same as video size, which was specified on opening video file.</exception>
				/// <exception cref="VideoException">A error occurred while writing new video frame. See exception message.</exception>
				/// 
				void WriteVideoFrame(Bitmap^ frame);

				/// <summary>
				/// Write new video frame with a specific timestamp into currently opened video file.
				/// </summary>
				///
				/// <param name="frame">Bitmap to add as a new video frame.</param>
				/// <param name="timestamp">Frame timestamp, total time since recording started.</param>
				///
				/// <remarks><para>The specified bitmap must be either color 24 or 32 bpp image or grayscale 8 bpp (indexed) image.</para>
				/// 
				/// <para><note>The <paramref name="timestamp"/> parameter allows user to specify presentation
				/// time of the frame being saved. However, it is user's responsibility to make sure the value is increasing
				/// over time.</note></para>
				/// </remarks>
				///
				/// <exception cref="System::IO::IOException">Thrown if no video file was open.</exception>
				/// <exception cref="ArgumentException">The provided bitmap must be 24 or 32 bpp color image or 8 bpp grayscale image.</exception>
				/// <exception cref="ArgumentException">Bitmap size must be of the same as video size, which was specified on opening video file.</exception>
				/// <exception cref="VideoException">A error occurred while writing new video frame. See exception message.</exception>
				/// 
				void WriteVideoFrame(Bitmap^ frame, TimeSpan timestamp);

				/// <summary>
				/// Video frame to writer.
				/// </summary>
				/// <param name="frame">The video bitmap frame to write.</param>
				/// <param name="position">The video frame position.</param>
				///
				/// <remarks><para>The specified bitmap must be either color 24 or 32 bpp image or grayscale 8 bpp (indexed) image.</para>
				/// </remarks>
				void WriteVideoFrame(Bitmap^ frame, signed long long position);

				/// <summary>
				/// Close currently opened video file if any.
				/// </summary>
				/// 
				void Close();

			private:

				int m_width;
				int m_height;
				int	m_frameRate;
				int m_bitRate;
				VideoCodec m_codec;

			private:
				// Checks if video file was opened
				void CheckIfVideoFileIsOpen()
				{
					if (data == nullptr)
					{
						throw gcnew System::IO::IOException("Video file is not open, so can not access its properties.");
					}
				}

				// Check if the object was already disposed
				void CheckIfDisposed()
				{
					if (_disposed)
					{
						throw gcnew System::ObjectDisposedException("The object was already disposed.");
					}
				}

			private:
				// private data of the class
				WriterVideoPrivateData^ data;
				bool _disposed;

				/// <summary>
				/// Video frame to encoder.
				/// </summary>
				/// <param name="frame">The video bitmap frame to write.</param>
				void EncodeVideoFrame(Bitmap^ frame);

			};

		}
	}
}
#endif
