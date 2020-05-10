using System.Text;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Parsing;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.Text;

namespace JetBrains.ReSharper.Plugins.Spring
{
    class CLeafElement: LeafElementBase, ITokenNode
    {
        private string Str;
        private TokenNodeType TokenNodeType;

        public CLeafElement(string str, SpringTokenType tokenType)
        {
            Str = str;
            TokenNodeType = tokenType;
        }
        
        public override int GetTextLength() => Str.Length;

        public override StringBuilder GetText(StringBuilder to)
        {
            to.Append(Str);
            return to;
        }

        public override string GetText() => Str;

        public override IBuffer GetTextAsBuffer()
        {
            return new StringBuffer(Str);
        }

        public override NodeType NodeType => TokenNodeType;

        public override PsiLanguageType Language => SpringLanguage.Instance;

        public TokenNodeType GetTokenType() => TokenNodeType;

    }
}