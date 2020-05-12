using System;
using System.IO;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Resolve;
using JetBrains.ReSharper.Psi.Resolve;
using JetBrains.ReSharper.Psi.Tree;

namespace JetBrains.ReSharper.Plugins.Spring
{
    public class SpringVariableReference : TreeReferenceBase<SpringVariableReferenceElement>
    {
        private readonly SpringVariableReferenceElement Owner;

        public SpringVariableReference(SpringVariableReferenceElement owner) : base(owner)
        {
            Owner = owner;
        }

        public override ResolveResultWithInfo ResolveWithoutCache()
        {
           var file = Owner.GetContainingFile();
            
            
            if (file == null)
            {
                return ResolveResultWithInfo.Unresolved;
            }

            foreach (var node in file.Descendants())
            {
                
                if (node is IDeclaration declaration)
                {
                    if (declaration.DeclaredName == GetName())
                    {
                        return new ResolveResultWithInfo(new SimpleResolveResult(declaration.DeclaredElement), 
                            ResolveErrorType.OK);
                    }
                }
            }
            return ResolveResultWithInfo.Unresolved;
        }

        public override string GetName() => Owner.GetText();
        
        public override ISymbolTable GetReferenceSymbolTable(bool useReferenceName)
        {
            throw new NotImplementedException();
        }

        public override TreeTextRange GetTreeTextRange() => Owner.GetTreeTextRange();

        public override IReference BindTo(IDeclaredElement element) => this;

        public override IReference BindTo(IDeclaredElement element, ISubstitution substitution) => this;

        public override IAccessContext GetAccessContext() => new DefaultAccessContext(Owner);

        public override bool IsValid() => Owner.IsValid();
    }
}