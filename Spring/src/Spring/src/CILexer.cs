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
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\MyProjects\repo\dotNet\spring-lang-master\Spring\src\Spring\log.txt"))
            {
                foreach (IToken token in tokens)
                {
                    file.Write(token.Text + ' ');
                    file.Write(token.StartIndex.ToString() + ' ');
                    file.Write(token.StopIndex.ToString() + " \n");
                }
            }

            CurrentPosition = 0;
        }

        private void nextToken()
        {
            IToken token = antlrLexer.NextToken();
            int tokenId = token.Type;
            // what if token.Type == 0?
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