using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using JetBrains.ReSharper.Psi.Parsing;
using JetBrains.Text;

namespace JetBrains.ReSharper.Plugins.Spring
{
    public class CILexer : ILexer<int>
    {
        private ArrayList<SpringTokenType> TokenTypes;
        
        private CLexer antlrLexer;
        public CILexer(IBuffer buffer)
        {
            Buffer = buffer;
            ICharStream iCharStream = new AntlrInputStream(buffer.GetText());
            antlrLexer = new CLexer(iCharStream);
            IList<IToken> tokens = antlrLexer.GetAllTokens();

            CurrentPosition = 0;
        }

        private void nextToken()
        {
            IToken token = antlrLexer.NextToken();
            int tokenId = token.Type;
            if (tokenId < 0)
            {
                TokenType = null;
                TokenStart = -1;
                TokenEnd = -1;
                CurrentPosition = -1;
            }
            else
            {
                TokenType = SpringTokenType.SpringTokenTypes[tokenId];
                TokenStart = token.StartIndex;
                TokenEnd = token.StopIndex + 1;
                CurrentPosition++;
            }
        }

        public void Start()
        {
            antlrLexer.Reset();
            nextToken();
        }
        
        public void Advance()
        {
            nextToken();
        }

        public IBuffer Buffer { get; private set; }

        public int CurrentPosition { get; set; }

        object ILexer.CurrentPosition
        {
            get => CurrentPosition;
            set
            {
                int position = (int) value;
                antlrLexer.Reset();
                for (int i = 0; i < position; i++)
                {
                    nextToken();
                }
            }
        }

        public int TokenStart { get; private set; }
    
        public int TokenEnd { get; private set; }

        public TokenNodeType TokenType { get; private set; }
    }
}