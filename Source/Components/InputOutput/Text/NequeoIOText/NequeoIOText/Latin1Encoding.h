/* Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
*  Copyright :     Copyright � Nequeo Pty Ltd 2014 http://www.nequeo.com.au/
*
*  File :          Latin1Encoding.h
*  Purpose :       Latin1Encoding header.
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

#ifndef _LATIN1ENCODING_H
#define _LATIN1ENCODING_H

#include "GlobalText.h"
#include "TextEncoding.h"

namespace Nequeo{
	namespace IO{
		namespace Text
		{
			class Latin1Encoding : public TextEncoding
				/// ISO Latin-1 (8859-1) text encoding.
			{
			public:
				Latin1Encoding();
				~Latin1Encoding();
				const char* canonicalName() const;
				bool isA(const std::string& encodingName) const;
				const CharacterMap& characterMap() const;
				int convert(const unsigned char* bytes) const;
				int convert(int ch, unsigned char* bytes, int length) const;
				int queryConvert(const unsigned char* bytes, int length) const;
				int sequenceLength(const unsigned char* bytes, int length) const;

			private:
				static const char* _names[];
				static const CharacterMap _charMap;
			};
		}
	}
}
#endif
