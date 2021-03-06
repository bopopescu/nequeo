﻿/*  Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
 *  Copyright :     Copyright © Nequeo Pty Ltd 2010 http://www.nequeo.com.au/
 * 
 *  File :          
 *  Purpose :       
 * 
 */

#region Nequeo Pty Ltd License
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
#endregion

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nequeo.Threading.Parallel.Algorithms
{
    public static partial class ParallelAlgorithms
    {
        /// <summary>Executes a function for each value in a range, returning the first result achieved and ceasing execution.</summary>
        /// <typeparam name="TResult">The type of the data returned.</typeparam>
        /// <param name="fromInclusive">The start of the range, inclusive.</param>
        /// <param name="toExclusive">The end of the range, exclusive.</param>
        /// <param name="body">The function to execute for each element.</param>
        /// <returns>The result computed.</returns>
        public static TResult SpeculativeFor<TResult>(
            int fromInclusive, int toExclusive, Func<int, TResult> body)
        {
            return SpeculativeFor(fromInclusive, toExclusive, s_defaultParallelOptions, body);
        }

        /// <summary>Executes a function for each value in a range, returning the first result achieved and ceasing execution.</summary>
        /// <typeparam name="TResult">The type of the data returned.</typeparam>
        /// <param name="fromInclusive">The start of the range, inclusive.</param>
        /// <param name="toExclusive">The end of the range, exclusive.</param>
        /// <param name="options">The options to use for processing the loop.</param>
        /// <param name="body">The function to execute for each element.</param>
        /// <returns>The result computed.</returns>
        public static TResult SpeculativeFor<TResult>(
            int fromInclusive, int toExclusive, ParallelOptions options, Func<int, TResult> body)
        {
            // Validate parameters; the Parallel.For we delegate to will validate the rest
            if (body == null) throw new ArgumentNullException("body");

            // Store one result.  We box it if it's a value type to avoid torn writes and enable
            // CompareExchange even for value types.
            object result = null;

            // Run all bodies in parallel, stopping as soon as one has completed.
            System.Threading.Tasks.Parallel.For(fromInclusive, toExclusive, options, (i, loopState) =>
            {
                // Run an iteration.  When it completes, store (box) 
                // the result, and cancel the rest
                System.Threading.Interlocked.CompareExchange(ref result, (object)body(i), null);
                loopState.Stop();
            });

            // Return the computed result
            return (TResult)result;
        }
    }
}