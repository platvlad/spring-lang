using System;
using System.Xml;
using Antlr4.Runtime.Tree;
using JetBrains.Interop.WinApi;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using JetBrains.ReSharper.Psi.Resolve;
using JetBrains.ReSharper.Psi.Tree;
using JetBrains.ReSharper.Psi.TreeBuilder;

namespace JetBrains.ReSharper.Plugins.Spring
{
    internal class SpringFileNodeType : CompositeNodeType
    {
        public SpringFileNodeType(string s, int index) : base(s, index)
        {
        }

        public static readonly SpringFileNodeType Instance = new SpringFileNodeType("Spring_FILE", 0);

        public override CompositeElement Create()
        {
            return new SpringFile();
        }
    }
    internal class SpringCompositeNodeType : CompositeNodeType
    {
        public SpringCompositeNodeType(string s, int index) : base(s, index)
        {
        }
        public static readonly SpringCompositeNodeType BLOCK = new SpringCompositeNodeType("Spring_BLOCK", 0);
        public static readonly SpringCompositeNodeType OTHER = new SpringCompositeNodeType("Spring_OTHER", 1);

        
        
        public override CompositeElement Create()
        {
            if (this == BLOCK)
                return new SpringBlock();
            else 
                throw new InvalidOperationException();
        }

        
    }

    internal class SpringCompositeNodeWithArgumentType : CompositeNodeWithArgumentType
    {
        public SpringCompositeNodeWithArgumentType(string str, int index) : base(str, index)
        {
        }

        public static readonly SpringCompositeNodeWithArgumentType VAR_DECLARATION = 
            new SpringCompositeNodeWithArgumentType("Spring_DECLARATION", 3);
        public static readonly SpringCompositeNodeWithArgumentType VAR_REFERENCE = 
            new SpringCompositeNodeWithArgumentType("Spring_REFERENCE", 4);

        public override CompositeElement Create(object message)
        {
            if (message is CParser.DirectDeclaratorContext ddContext)
            {
                return new SpringVariableDeclarationElement(ddContext);
            } else if (message is CParser.PrimaryExpressionContext peContext)
            {
                return new SpringVariableReferenceElement(peContext);
            }
            else
            {
                return new SpringErrorElement("Wrong context type", 1);
            }
        }

        public override CompositeElement Create()
        {
            return new SpringErrorElement("Need context", 1);
        }
    }

    internal class SpringNodeType : NodeType
    {
        public SpringNodeType(string str, int index) : base(str, index)
        {
        }
        
        public static readonly NodeType Error = new SpringErrorNodeType("Spring_Error", 2);
        
    }
    

    public class SpringErrorElement : CompositeElement, IErrorElement
    {
        public int length
        {
            get;
        }
    
        public SpringErrorElement(string str, int length)
        {
            ErrorDescription = str;
            this.length = length;
        }

        public string ErrorDescription { get; }

        public override NodeType NodeType => SpringNodeType.Error;

        public override PsiLanguageType Language => SpringLanguage.Instance;
    }

    public class SpringVariableDeclarationElement : CompositeElement, IDeclaration
    {
        private string name;

        private CParser.DirectDeclaratorContext context;

        public SpringVariableDeclarationElement(CParser.DirectDeclaratorContext ctx)
        {
            context = ctx;
        }

        public override PsiLanguageType Language => SpringLanguage.Instance;

        public override NodeType NodeType => SpringCompositeNodeWithArgumentType.VAR_DECLARATION;

        public IDeclaredElement DeclaredElement { get; }

        public string DeclaredName { get; }

        public TreeTextRange GetNameRange()
        {
            return new TreeTextRange(GetTreeStartOffset(), GetTreeStartOffset() + GetText().Length);
        }

        public bool IsSynthetic() => false;

        public void SetName(string name)
        {
            this.name = name;
        }
        
        public XmlNode GetXMLDoc(bool b) => null;
    }

    public class SpringVariableReferenceElement : CompositeElement
    {
        public CParser.PrimaryExpressionContext context;
        public SpringVariableReferenceElement(CParser.PrimaryExpressionContext ctx)
        {
            context = ctx;
        }

        public override NodeType NodeType => SpringCompositeNodeWithArgumentType.VAR_REFERENCE;

        public override PsiLanguageType Language => SpringLanguage.Instance;

    }

    internal class SpringErrorNodeType: CompositeNodeWithArgumentType
    {
        public SpringErrorNodeType(string str, int index) : base(str, index)
        {
        }

        public override CompositeElement Create(object message)
        {
            var errorMessage = (ErrorMessage) message;
            return new SpringErrorElement(errorMessage.msg, errorMessage.length);
        }

        public override CompositeElement Create()
        {
            return null;
        }
    }

    public class ErrorMessage
    {
        public string msg { get; }

        public int length { get; }
    
        public ErrorMessage(string msg, int length)
        {
            this.msg = msg;
            this.length = length;
        }
    }

}