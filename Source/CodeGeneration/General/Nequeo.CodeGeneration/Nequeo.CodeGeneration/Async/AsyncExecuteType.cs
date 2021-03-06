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
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Xml;
using System.Reflection;
using System.Xml.Serialization;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.IO;

using Nequeo.Data.DataType;
using Nequeo.Extension;

namespace Nequeo.CodeGeneration
{
    /// <summary>
    /// Asynchronous execution handler for methods within a type.
    /// </summary>
    public sealed class AsyncExecuteType
    {
        #region Private Fields
        private CodeCompileUnit _targetUnit;
        private CodeNamespace _samples;
        private CodeTypeDeclaration _targetClass;
        private Type _model;
        #endregion

        #region Code Generation
        /// <summary>
        /// Generate the code.
        /// </summary>
        /// <param name="model">The data model type.</param>
        /// <returns>The code unit.</returns>
        public CodeCompileUnit Generate(Type model)
        {
            // Make sure the page reference exists.
            if (model == null) throw new ArgumentNullException("model");

            // If not null.
            if (model != null)
            {
                _model = model;

                // Create the namespace.
                InitialiseNamespace();
            }

            // If not null.
            if (model != null)
            {
                // Add the classes.
                AddClasses();
            }

            // Return the complie unit.
            _targetUnit.Namespaces.Add(_samples);
            return _targetUnit;
        }

        /// <summary>
        /// Create the code file specified in the compile unit
        /// </summary>
        /// <param name="fileName">The full path where the file is to be created.</param>
        /// <param name="codeCompileUnit">The code compile unit containing the code data.</param>
        public void CreateCodeFile(string fileName, CodeCompileUnit codeCompileUnit)
        {
            // Make sure the page reference exists.
            if (fileName == null) throw new ArgumentNullException("fileName");
            if (codeCompileUnit == null) throw new ArgumentNullException("codeCompileUnit");

            // If the director does not
            // exits create the directory.
            if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));

            // Create a new code dom provider in
            // C# code format. Add new options
            // to the code in 'C' format.
            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CodeGeneratorOptions options = new CodeGeneratorOptions();
            options.BracingStyle = "C";

            // Write the code to the file
            // through the stream writer.
            using (StreamWriter sourceWriter = new StreamWriter(fileName))
            {
                provider.GenerateCodeFromCompileUnit(codeCompileUnit, sourceWriter, options);
            }
        }
        #endregion

        #region Create Namespaces
        /// <summary>
        /// Create the namespace and import namespaces.
        /// </summary>
        private void InitialiseNamespace()
        {
            // Create a new base compile unit module.
            _targetUnit = new CodeCompileUnit();

            // Create a new namespace.
            _samples = new CodeNamespace();

            // Add each namespace reference.
            _samples.Imports.Add(new CodeNamespaceImport("System"));
            _samples.Imports.Add(new CodeNamespaceImport("Nequeo.Threading"));
        }
        #endregion

        #region Create Classes
        /// <summary>
        /// Add the classes.
        /// </summary>
        private void AddClasses()
        {
            // Create the class and add base inheritance type.
            _targetClass = new CodeTypeDeclaration("Async" + _model.Name);
            _targetClass.IsClass = true;
            _targetClass.IsPartial = true;
            _targetClass.TypeAttributes = TypeAttributes.Public;

            // Create the comments on the class.
            _targetClass.Comments.Add(new CodeCommentStatement("<summary>", true));
            _targetClass.Comments.Add(new CodeCommentStatement("The Async" + _model.Name + " class.", true));
            _targetClass.Comments.Add(new CodeCommentStatement("</summary>", true));

            // Add the class members.
            AddMembers();

            // Add the class to the namespace
            // and add the namespace to the unit.
            _samples.Types.Add(_targetClass);
        }

        /// <summary>
        /// Add the class members.
        /// </summary>
        private void AddMembers()
        {
            AddConstructor();
            AddFields();
            AddMethod();
        }
        #endregion

        #region Create Constructors
        /// <summary>
        /// Add the constrctor to the class.
        /// </summary>
        private void AddConstructor()
        {
            // Declare the constructor.
            CodeConstructor constructor = new CodeConstructor();
            constructor.Attributes = MemberAttributes.Public | MemberAttributes.Final;

            // Create the comments on the constructor.
            constructor.Comments.Add(new CodeCommentStatement("<summary>", true));
            constructor.Comments.Add(new CodeCommentStatement("Default constructor.", true));
            constructor.Comments.Add(new CodeCommentStatement("</summary>", true));

            // Add the constructor to the class.
            _targetClass.Members.Add(constructor);
        }
        #endregion

        #region Create Fields
        /// <summary>
        /// Add the fields to the class.
        /// </summary>
        private void AddFields()
        {
            // Create a new field.
            CodeMemberField valueField = new CodeMemberField();

            // Assign the name and the accessor attribute.
            valueField.Attributes = MemberAttributes.Private;
            valueField.Name = "_asyncExecute" + _model.Name;
            valueField.InitExpression = new CodeSnippetExpression("null");
            valueField.Type = new CodeTypeReference("Nequeo.Threading.AsyncExecution<" + _model.FullName + ">");

            // Create a new field.
            CodeMemberEvent errorEventField = new CodeMemberEvent();

            // Assign the name and the accessor attribute.
            errorEventField.Attributes = MemberAttributes.Public;
            errorEventField.Name = "AsyncError";
            errorEventField.Type = new CodeTypeReference("Nequeo.Threading.EventHandler<System.Exception>");

            // Add the comments to the property.
            errorEventField.Comments.Add(new CodeCommentStatement("<summary>", true));
            errorEventField.Comments.Add(new CodeCommentStatement("Async error event handler", true));
            errorEventField.Comments.Add(new CodeCommentStatement("</summary>", true));

            // Create a new field.
            CodeMemberEvent completeEventField = new CodeMemberEvent();

            // Assign the name and the accessor attribute.
            completeEventField.Attributes = MemberAttributes.Public;
            completeEventField.Name = "AsyncComplete";
            completeEventField.Type = new CodeTypeReference("Nequeo.Threading.EventHandler<System.Object, System.String>");

            // Add the comments to the property.
            completeEventField.Comments.Add(new CodeCommentStatement("<summary>", true));
            completeEventField.Comments.Add(new CodeCommentStatement("Async complete event handler, with result and unique execution name", true));
            completeEventField.Comments.Add(new CodeCommentStatement("</summary>", true));

            // Add the field to the class.
            _targetClass.Members.Add(valueField);
            _targetClass.Members.Add(errorEventField);
            _targetClass.Members.Add(completeEventField);
        }
        #endregion

        #region Create Methods
        /// <summary>
        /// Add the methods to the class.
        /// </summary>
        private void AddMethod()
        {
            AddInitialiseMethod();
            AddExecuteActionMethod();
            AddAsyncMethod();
        }

        /// <summary>
        /// Add the initilse instance method.
        /// </summary>
        private void AddInitialiseMethod()
        {
            // Declaring a create data method
            CodeMemberMethod createMethod = new CodeMemberMethod();
            createMethod.Attributes = MemberAttributes.Public;
            createMethod.Name = "InitiliseAsyncInstance";
            createMethod.ReturnType = new CodeTypeReference(typeof(void));

            // Add the comments to the property.
            createMethod.Comments.Add(new CodeCommentStatement("<summary>", true));
            createMethod.Comments.Add(new CodeCommentStatement("Initilise Async Instance", true));
            createMethod.Comments.Add(new CodeCommentStatement("</summary>", true));

            // Add each parameter.
            createMethod.Parameters.Add(new CodeParameterDeclarationExpression(_model.FullName, "instance"));
            createMethod.Comments.Add(new CodeCommentStatement("<param name=\"instance\">The type instance.</param>", true));

            // Add the create code statement.
            createMethod.Statements.Add(
                new CodeSnippetExpression(
                    "if (instance == null) throw new ArgumentNullException(\"instance\")"));

            // Add the create code statement.
            createMethod.Statements.Add(
                new CodeSnippetExpression(
                    "_asyncExecute" + _model.Name + " = new Nequeo.Threading.AsyncExecution<" + _model.FullName + ">(instance)"));

            // Add the create code statement.
            createMethod.Statements.Add(
                new CodeSnippetExpression(
                    "_asyncExecute" + _model.Name + ".AsyncExecuteComplete += new Nequeo.Threading.EventHandler<object, bool, System.Exception>(AsyncHandler_AsyncExecuteComplete)"));

            // Add the property to the class.
            _targetClass.Members.Add(createMethod);
        }

        /// <summary>
        /// Add the initilse instance method.
        /// </summary>
        private void AddExecuteActionMethod()
        {
            // Declaring a create data method
            CodeMemberMethod actionMethod = new CodeMemberMethod();
            actionMethod.Attributes = MemberAttributes.Public;
            actionMethod.Name = "Execute";
            actionMethod.ReturnType = new CodeTypeReference(typeof(void));

            // Add the comments to the property.
            actionMethod.Comments.Add(new CodeCommentStatement("<summary>", true));
            actionMethod.Comments.Add(new CodeCommentStatement("Execute the asynchronous action.", true));
            actionMethod.Comments.Add(new CodeCommentStatement("</summary>", true));

            // Add each parameter.
            actionMethod.Parameters.Add(new CodeParameterDeclarationExpression("System.Action<" + _model.FullName + ">", "action"));
            actionMethod.Comments.Add(new CodeCommentStatement("<param name=\"action\">The action handler.</param>", true));
            actionMethod.Parameters.Add(new CodeParameterDeclarationExpression(typeof(string), "actionName"));
            actionMethod.Comments.Add(new CodeCommentStatement("<param name=\"actionName\">The unique action name.</param>", true));

            // Add the create code statement.
            actionMethod.Statements.Add(
                new CodeSnippetExpression(
                    "if (action == null) throw new ArgumentNullException(\"action\")"));

            // Add the create code statement.
            actionMethod.Statements.Add(
                new CodeSnippetExpression(
                    "if (String.IsNullOrEmpty(actionName)) throw new ArgumentNullException(\"actionName\")"));

            // Add the create code statement.
            actionMethod.Statements.Add(
                new CodeSnippetExpression(
                    "_asyncExecute" + _model.Name + ".Execute(action, actionName)"));

            // Declaring a create data method
            CodeMemberMethod functionMethod = new CodeMemberMethod();
            functionMethod.Attributes = MemberAttributes.Public;
            functionMethod.Name = "Execute<TResult>";
            functionMethod.ReturnType = new CodeTypeReference(typeof(void));

            // Add the comments to the property.
            functionMethod.Comments.Add(new CodeCommentStatement("<summary>", true));
            functionMethod.Comments.Add(new CodeCommentStatement("Execute the asynchronous action.", true));
            functionMethod.Comments.Add(new CodeCommentStatement("</summary>", true));

            // Add each parameter.
            functionMethod.Parameters.Add(new CodeParameterDeclarationExpression("System.Func<" + _model.FullName + ", TResult>", "action"));
            functionMethod.Comments.Add(new CodeCommentStatement("<param name=\"action\">The action handler.</param>", true));
            functionMethod.Parameters.Add(new CodeParameterDeclarationExpression(typeof(string), "actionName"));
            functionMethod.Comments.Add(new CodeCommentStatement("<param name=\"actionName\">The unique action name.</param>", true));

            // Add the create code statement.
            functionMethod.Statements.Add(
                new CodeSnippetExpression(
                    "if (action == null) throw new ArgumentNullException(\"action\")"));

            // Add the create code statement.
            functionMethod.Statements.Add(
                new CodeSnippetExpression(
                    "if (String.IsNullOrEmpty(actionName)) throw new ArgumentNullException(\"actionName\")"));

            // Add the create code statement.
            functionMethod.Statements.Add(
                new CodeSnippetExpression(
                    "_asyncExecute" + _model.Name + ".Execute<TResult>(action, actionName)"));

            // Add the property to the class.
            _targetClass.Members.Add(actionMethod);
            _targetClass.Members.Add(functionMethod);
        }

        /// <summary>
        /// Add the initilse instance method.
        /// </summary>
        private void AddAsyncMethod()
        {
            // Declaring a create data method
            CodeMemberMethod createMethod = new CodeMemberMethod();
            createMethod.Attributes = MemberAttributes.Private;
            createMethod.Name = "AsyncHandler_AsyncExecuteComplete";
            createMethod.ReturnType = new CodeTypeReference(typeof(void));

            // Add the comments to the property.
            createMethod.Comments.Add(new CodeCommentStatement("<summary>", true));
            createMethod.Comments.Add(new CodeCommentStatement("Asynchronous Execution Complete", true));
            createMethod.Comments.Add(new CodeCommentStatement("</summary>", true));

            // Add each parameter.
            createMethod.Parameters.Add(new CodeParameterDeclarationExpression(typeof(object), "sender"));
            createMethod.Comments.Add(new CodeCommentStatement("<param name=\"sender\">The event sender.</param>", true));
            createMethod.Parameters.Add(new CodeParameterDeclarationExpression(typeof(object), "e1"));
            createMethod.Comments.Add(new CodeCommentStatement("<param name=\"e1\">The unique async name reference.</param>", true));
            createMethod.Parameters.Add(new CodeParameterDeclarationExpression(typeof(bool), "e2"));
            createMethod.Comments.Add(new CodeCommentStatement("<param name=\"e2\">The operation result.</param>", true));
            createMethod.Parameters.Add(new CodeParameterDeclarationExpression(typeof(System.Exception), "e3"));
            createMethod.Comments.Add(new CodeCommentStatement("<param name=\"e3\">The current async exception.</param>", true));

            createMethod.Statements.Add(new CodeTryCatchFinallyStatement(
                new CodeStatement[]
                {
                    new CodeConditionStatement(new CodeSnippetExpression("e1 is string"), 
                        new CodeStatement[] 
                        { 
                            new CodeExpressionStatement(
                                new CodeSnippetExpression("object result = _asyncExecute" + _model.Name + ".GetExecuteAsyncResult<object>(e1.ToString())")),
                            new CodeConditionStatement(new CodeSnippetExpression("AsyncComplete != null"), 
                                new CodeStatement[] 
                                { 
                                    new CodeExpressionStatement(
                                        new CodeSnippetExpression("AsyncComplete(this, result, e1.ToString())"))
                                })
                        })
                },
                new CodeCatchClause[] 
                { 
                    new CodeCatchClause("ex", new CodeTypeReference(typeof(Exception)),
                        new CodeStatement[] 
                        {
                            new CodeConditionStatement(new CodeSnippetExpression("AsyncError != null"), 
                                new CodeStatement[] 
                                { 
                                    new CodeExpressionStatement(
                                        new CodeSnippetExpression("AsyncError(this, new System.Exception(ex.Message, _asyncExecute" + _model.Name + ".GetExecuteAsyncException(e1.ToString())))"))
                                })
                        }) 
                }));

            // Add the property to the class.
            _targetClass.Members.Add(createMethod);
        }
        #endregion
    }
}
