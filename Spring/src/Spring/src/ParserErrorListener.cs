using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using ICSharpCode.NRefactory.Xml;
using JetBrains.ReSharper.Psi.TreeBuilder;

namespace JetBrains.ReSharper.Plugins.Spring
{
    public class ParserErrorListener: IAntlrErrorListener<IToken>
    {
        private PsiBuilder Builder;
        public ParserErrorListener(PsiBuilder builder)
        {
            Builder = builder;
        }
        
        public void SyntaxError(TextWriter textWriter, IRecognizer recogniser, IToken token, int i1, int i2,
            string msg, RecognitionException recognitionException)
        {
            var lexeme = Builder.GetCurrentLexeme();
            var nonCommentLexeme = Builder.GetCurrentNonCommentLexeme();
            Builder.ResetCurrentLexeme(token.TokenIndex, token.TokenIndex);
            var mark = Builder.Mark();
            Builder.Done(mark, SpringNodeType.Error, new ErrorMessage(msg, token.StopIndex - token.StartIndex + 1));
            Builder.ResetCurrentLexeme(lexeme, nonCommentLexeme);
        }
    }
}