/*    Copyright 2015 MongoDB Inc.
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *    http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 */

#include "mongo/platform/strnlen.h"

#ifndef MONGO_HAVE_STRNLEN

namespace mongo {

    size_t strnlen(const char *s, size_t maxlen) {
        for (size_t i = 0; i < maxlen; ++i) {
            if (s[i] == '\0') { 
                return i; 
            }
        }
        return maxlen;
    }

}  // namespace mongo

#endif
