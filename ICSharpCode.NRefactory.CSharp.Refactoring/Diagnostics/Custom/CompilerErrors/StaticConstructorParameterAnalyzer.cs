﻿////
//// 
//// StaticConstructorParameterAnalyzer.cs
//// 
//// Author:
////      Ji Kun <jikun.nus@gmail.com>
////      Mike Krüger <mkrueger@xamarin.com>
////
//// Copyright (c) 2013 Ji Kun
//// Copyright (c) 2013 Xamarin Inc. (http://xamarin.com)
////
//// Permission is hereby granted, free of charge, to any person obtaining a copy
//// of this software and associated documentation files (the "Software"), to deal
//// in the Software without restriction, including without limitation the rights
//// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//// copies of the Software, and to permit persons to whom the Software is
//// furnished to do so, subject to the following conditions:
//// 
//// The above copyright notice and this permission notice shall be included in
//// all copies or substantial portions of the Software.
//// 
//// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//// THE SOFTWARE.

//using System;
//using System.Collections.Generic;
//using Microsoft.CodeAnalysis;
//using Microsoft.CodeAnalysis.CSharp;
//using Microsoft.CodeAnalysis.Diagnostics;
//using System.Collections.Immutable;
//using Microsoft.CodeAnalysis.CodeFixes;
//using System.Threading.Tasks;
//using Microsoft.CodeAnalysis.CodeActions;
//using Microsoft.CodeAnalysis.Text;
//using System.Threading;
//using ICSharpCode.NRefactory6.CSharp.Refactoring;
//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using System.Linq;
//using Microsoft.CodeAnalysis.Formatting;
//using Microsoft.CodeAnalysis.FindSymbols;

// TODO : Move to code fix 

//namespace ICSharpCode.NRefactory6.CSharp.Diagnostics
//{
//	[DiagnosticAnalyzer(LanguageNames.CSharp)]
//	public class StaticConstructorParameterAnalyzer : DiagnosticAnalyzer
//	{
//		internal const string DiagnosticId = "StaticConstructorParameterAnalyzer";
//		const string Description = "Static constructor should be parameterless";
//		const string MessageFormat = "Remove parameters";
//		const string Category = DiagnosticAnalyzerCategories.CompilerErrors;

//		static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Description, MessageFormat, Category, DiagnosticSeverity.Error, true, "Static constructor should be parameterless");

//		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
//		{
//			get
//			{
//				return ImmutableArray.Create(Rule);
//			}
//		}

//		public override void Initialize(AnalysisContext context)
//		{
//			//context.RegisterSyntaxNodeAction(
//			//	(nodeContext) => {
//			//		Diagnostic diagnostic;
//			//		if (TryGetDiagnostic (nodeContext, out diagnostic)) {
//			//			nodeContext.ReportDiagnostic(diagnostic);
//			//		}
//			//	}, 
//			//	new SyntaxKind[] { SyntaxKind.None }
//			//);
//		}

//		static bool TryGetDiagnostic (SyntaxNodeAnalysisContext nodeContext, out Diagnostic diagnostic)
//		{
//			diagnostic = default(Diagnostic);
			//if (nodeContext.IsFromGeneratedCode())
			//	return false;
//			//var node = nodeContext.Node as ;
//			//diagnostic = Diagnostic.Create (descriptor, node.GetLocation ());
//			//return true;
//			return false;
//		}

//		//class GatherVisitor : GatherVisitorBase<StaticConstructorParameterAnalyzer>
//		//{
//		//	public GatherVisitor(SemanticModel semanticModel, Action<Diagnostic> addDiagnostic, CancellationToken cancellationToken)
//		//		: base(semanticModel, addDiagnostic, cancellationToken)
//		//	{
//		//	}

//		//	public override void VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
//		//	{
//		//		if (!node.Modifiers.Any(m => m.IsKind(SyntaxKind.StaticKeyword)) || !node.ParameterList.Parameters.Any())
//		//			return;
//		//		AddDiagnosticAnalyzer(Diagnostic.Create(Rule, node.Identifier.GetLocation()));
//		//	}
//		//}
//	}

//	[ExportCodeFixProvider(LanguageNames.CSharp), System.Composition.Shared]
//	public class StaticConstructorParameterFixProvider : CodeFixProvider
//	{
//		public override ImmutableArray<string> FixableDiagnosticIds {
//			get {
//				return ImmutableArray.Create (StaticConstructorParameterAnalyzer.DiagnosticId);
//			}
//		}

//		public override FixAllProvider GetFixAllProvider()
//		{
//			return WellKnownFixAllProviders.BatchFixer;
//		}

//		public async override Task RegisterCodeFixesAsync(CodeFixContext context)
//		{
//			var document = context.Document;
//			var cancellationToken = context.CancellationToken;
//			var span = context.Span;
//			var diagnostics = context.Diagnostics;
//			var root = await document.GetSyntaxRootAsync(cancellationToken);
//			var diagnostic = diagnostics.First ();
//			var node = root.FindNode(context.Span) as ConstructorDeclarationSyntax;
//			if (node == null)
//				return;
//			var newRoot = root.ReplaceNode((SyntaxNode)node, node.WithParameterList(SyntaxFactory.ParameterList().WithTrailingTrivia(node.ParameterList.GetTrailingTrivia())));
//			context.RegisterCodeFix(CodeActionFactory.Create(node.Span, diagnostic.Severity, diagnostic.GetMessage(), document.WithSyntaxRoot(newRoot)), diagnostic);
//		}
//	}
//}