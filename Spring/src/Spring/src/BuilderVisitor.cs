using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using JetBrains.ReSharper.Psi.Parsing;
using JetBrains.ReSharper.Psi.TreeBuilder;

namespace JetBrains.ReSharper.Plugins.Spring
{
    public class BuilderVisitor: CBaseVisitor<object>
    {
        private PsiBuilder Builder;
        public BuilderVisitor(PsiBuilder builder)
        {
            Builder = builder;
        }

        private TokenNodeType skipWhitespaces()
        {
            var resharperTokenType = Builder.GetTokenType();
            if (resharperTokenType == null)
            {
                return null;
            }

            while (resharperTokenType.IsComment || 
                   resharperTokenType.IsWhitespace || 
                   resharperTokenType == SpringTokenType.ComplexDefine ||
                   resharperTokenType == SpringTokenType.IncludeDirective ||
                   resharperTokenType == SpringTokenType.AsmBlock ||
                   resharperTokenType == SpringTokenType.LineAfterPreprocessing ||
                   resharperTokenType == SpringTokenType.LineDirective ||
                   resharperTokenType == SpringTokenType.PragmaDirective)
            {
                Builder.AdvanceLexer();
                
                resharperTokenType = Builder.GetTokenType();
                if (resharperTokenType == null)
                    return null;
            }

            return resharperTokenType;
        }
        
        public override object VisitTerminal(ITerminalNode node)
        {
            var resharperTokenType = skipWhitespaces();
            if (resharperTokenType == null)
            {
                return null;
            }

            IToken antlrToken = node.Symbol;

            if (antlrToken.Type == SpringTokenType.Identifier.Index)
            {
                var mark = Builder.Mark();
                var tokenNodeType = Builder.AdvanceLexer();
                Builder.Done(mark, SpringCompositeNodeWithArgumentType.VAR_REFERENCE, node);
            }
            else
            {
                var tokenNodeType = Builder.AdvanceLexer();
            }
            return null;
        }

        public override object VisitDirectDeclarator(CParser.DirectDeclaratorContext context)
        {
            skipWhitespaces();
            var mark = Builder.Mark();

            VisitChildren(context);
            Builder.Done(mark, SpringCompositeNodeWithArgumentType.VAR_DECLARATION, context);
            return null;
        }


    }
}
