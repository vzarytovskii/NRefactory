//
// StringCompareToIsCultureSpecificAnalyzer.cs
//
// Author:
//       Mike Krüger <mkrueger@xamarin.com>
//
// Copyright (c) 2013 Xamarin Inc. (http://xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis.CodeFixes;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.Text;
using System.Threading;
using ICSharpCode.NRefactory6.CSharp.Refactoring;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using Microsoft.CodeAnalysis.Formatting;
using Microsoft.CodeAnalysis.FindSymbols;

namespace ICSharpCode.NRefactory6.CSharp.Diagnostics
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class StringCompareToIsCultureSpecificAnalyzer : DiagnosticAnalyzer
	{
		static readonly DiagnosticDescriptor descriptor = new DiagnosticDescriptor (
			NRefactoryDiagnosticIDs.StringCompareToIsCultureSpecificAnalyzerID, 
			GettextCatalog.GetString("Warns when a culture-aware 'string.CompareTo' call is used by default"),
			GettextCatalog.GetString("'string.CompareTo' is culture-aware"), 
			DiagnosticAnalyzerCategories.PracticesAndImprovements, 
			DiagnosticSeverity.Warning, 
			isEnabledByDefault: true,
			helpLinkUri: HelpLink.CreateFor(NRefactoryDiagnosticIDs.StringCompareToIsCultureSpecificAnalyzerID)
		);

		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create (descriptor);

		public override void Initialize(AnalysisContext context)
		{
			//context.RegisterSyntaxNodeAction(
			//	(nodeContext) => {
			//		Diagnostic diagnostic;
			//		if (TryGetDiagnostic (nodeContext, out diagnostic)) {
			//			nodeContext.ReportDiagnostic(diagnostic);
			//		}
			//	}, 
			//	new SyntaxKind[] { SyntaxKind.None }
			//);
		}

		static bool TryGetDiagnostic (SyntaxNodeAnalysisContext nodeContext, out Diagnostic diagnostic)
		{
			diagnostic = default(Diagnostic);
			if (nodeContext.IsFromGeneratedCode())
				return false;
			//var node = nodeContext.Node as ;
			//diagnostic = Diagnostic.Create (descriptor, node.GetLocation ());
			//return true;
			return false;
		}

//		class GatherVisitor : GatherVisitorBase<StringCompareToIsCultureSpecificAnalyzer>
//		{
//			public GatherVisitor(SemanticModel semanticModel, Action<Diagnostic> addDiagnostic, CancellationToken cancellationToken)
//				: base (semanticModel, addDiagnostic, cancellationToken)
//			{
//			}

////			public override void VisitInvocationExpression(InvocationExpression invocationExpression)
////			{
////				base.VisitInvocationExpression(invocationExpression);
////
////				var rr = ctx.Resolve(invocationExpression) as CSharpInvocationResolveResult;
////				if (rr == null || rr.IsError)
////					return;
////
////				if (rr.Member.Name != "CompareTo" || 
////				    !rr.Member.DeclaringType.IsKnownType (KnownTypeCode.String) ||
////				    rr.Member.Parameters.Count != 1 ||
////				    !rr.Member.Parameters[0].Type.IsKnownType(KnownTypeCode.String)) {
////					return;
////				}
////				AddDiagnosticAnalyzer(new CodeIssue(
////					invocationExpression,
////					ctx.TranslateString(""), 
////					new CodeAction(ctx.TranslateString(), script => AddArgument(script, invocationExpression, "Ordinal"), invocationExpression),
////					new CodeAction(ctx.TranslateString(), script => AddArgument(script, invocationExpression, "CurrentCulture"), invocationExpression)
////				));
////
////			}
////
////			void AddArgument(Script script, InvocationExpression invocationExpression, string ordinal)
////			{
////				var mr = invocationExpression.Target as MemberReferenceExpression;
////				if (mr == null)
////					return;
////
////				var astBuilder = ctx.CreateTypeSystemAstBuilder(invocationExpression);
////				var newArgument = astBuilder.ConvertType(new TopLevelTypeName("System", "StringComparison")).Member(ordinal);
////
////				var newInvocation = new PrimitiveType("string").Invoke(
////					"Compare",
////					mr.Target.Clone(),
////					invocationExpression.Arguments.First().Clone(),
////					newArgument
////				);
////				script.Replace(invocationExpression, newInvocation);
////			}
//		}
	}
}