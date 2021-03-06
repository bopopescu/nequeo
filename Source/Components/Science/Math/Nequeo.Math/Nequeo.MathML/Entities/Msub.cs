/*  Company :       Nequeo Pty Ltd, http://www.nequeo.com.au/
 *  Copyright :     Copyright � Nequeo Pty Ltd 2017 http://www.nequeo.com.au/
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

using System.Text;

namespace Nequeo.MathML.Entities
{
    /// <summary>
    /// Subscript.
    /// </summary>
    public class Msub : WithBinaryContent
    {
        public Msub(IBuildable first, IBuildable second) : base(first, second) { }

        public override void Visit(StringBuilder sb, BuildContext bc)
        {
            bc.Tokens.Add(this);

            bool last = bc.Options.SubscriptMode;
            bc.Options.SubscriptMode = true;

            StringBuilder b = new StringBuilder();

            first.Visit(b, bc);
            b.Append("_");
            second.Visit(b, bc);

            string varName = b.ToString();
            if (!bc.Vars.Contains(varName))
                if (!last) // unless we are already in a subscript-entering mode...
                    bc.Vars.Add(varName);

            sb.Append(varName);

            bc.Options.SubscriptMode = last;
        }
    }
}